using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Security.Cryptography;
using CommonUtils;

namespace ExactDupDetector
{

    public class MyDictionary<K,V>
    {
        private List<Dictionary<K, V>> dictList = new List<Dictionary<K, V>>();
        static private int MaxDictSize = 600000;

        public int ContainsKey(K key)
        {
            for (int i = 0; i< dictList.Count; i++ )
            {
                if (dictList[i].ContainsKey(key))
                    return i;
            }

            return -1;
        }

        public void Put(K key, V val)
        {
            int index = ContainsKey(key);
            if (index >= 0)
            {
                dictList[index][key] = val;
            }
            else if (dictList.Count == 0 || dictList[dictList.Count - 1].Count == MaxDictSize )
            {
                dictList.Add(new Dictionary<K, V>());
                dictList[dictList.Count - 1][key] = val;
            }
            else
                dictList[dictList.Count - 1][key] = val;
        }


        public V Get(K key, int dictIndex)
        {
            return dictList[dictIndex][key];
        }

        public int GetSize()
        {
            int count = 0;
            for (int i = 0; i < dictList.Count; i++)
            {
                count += dictList[i].Count;
            }

            return count;
        }

        public List<Dictionary<K, V>> GetDictionaryList()
        {
            return dictList;
        }
    }


    public class Algorithms
    {
        public static readonly HashAlgorithm MD5 = new MD5CryptoServiceProvider();
        public static readonly HashAlgorithm SHA1 = new SHA1Managed();
        public static readonly HashAlgorithm SHA256 = new SHA256Managed();
        public static readonly HashAlgorithm SHA384 = new SHA384Managed();
        public static readonly HashAlgorithm SHA512 = new SHA512Managed();
        public static readonly HashAlgorithm RIPEMD160 = new RIPEMD160Managed();
    }


    class MyFileInfo
    {
        public string FileName { get; set; }
        public long FileSize { get; set; } 
    }


    class DupDetector
    {
        private HashAlgorithm algorithm; 


        public static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        { Logger.writeLog(e.ExceptionObject.ToString(), LogType.LOG_DEBUG); }


        public static void Main(string[] args)
        {
            DupDetector deDup = new DupDetector();
            //deDup.Run_Dedup();
            deDup.Run_Dedup_For_Very_Large_DataSet();
        }

        public void Run_Dedup()
        {
            Logger.writeLog("*** Start Running Exact Duplicate Detector *** ", LogType.LOG_INFO);
            DateTime dtProgramStart = DateTime.Now;

            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

            Configuration cfg = new Configuration();
            ErrInfo errInfo = new ErrInfo();
            cfg.Read_Configuration_File("ExactDupDetector.cfg", errInfo);
            if (cfg.Algorithm == "MD5")
                algorithm = Algorithms.MD5;
            else if (cfg.Algorithm == "SHA1")
                algorithm = Algorithms.SHA1;
            else if (cfg.Algorithm == "SHA256")
                algorithm = Algorithms.SHA256;
            else if (cfg.Algorithm == "SHA384")
                algorithm = Algorithms.SHA384;
            else if (cfg.Algorithm == "SHA512")
                algorithm = Algorithms.SHA512;
            else
                algorithm = Algorithms.MD5;

            Logger.writeLog("Algorithm type: " + cfg.Algorithm, LogType.LOG_INFO);
            Logger.writeLog("InputDir: " + cfg.InputDir, LogType.LOG_INFO);
            Logger.writeLog("OutputFile: " + cfg.OutputFile, LogType.LOG_INFO);

            Dictionary<int, MyFileInfo> Dict_Files = new Dictionary<int, MyFileInfo>();
            Dictionary<string, List<int>> Dict_Hashes = new Dictionary<string, List<int>>();  // hashvalue --> list of files

            string[] files = Directory.GetFiles(cfg.InputDir, "*", SearchOption.AllDirectories);
            Logger.writeLog("In total, " + files.Length + " files exist in directory " + cfg.InputDir, LogType.LOG_INFO);

            int fileCount = 0; 
            foreach (var f in files)
            {
                MyFileInfo fInfo = new MyFileInfo();
                fInfo.FileName = f;
                FileInfo fi = new FileInfo(f);
                fInfo.FileSize = fi.Length;
                fileCount++;
                Dict_Files[fileCount] = fInfo;
                    
                string hash = GetHashFromFile(f, Algorithms.MD5);
                if (Dict_Hashes.ContainsKey(hash))
                {
                    Dict_Hashes[hash].Add(fileCount);
                }
                else
                {
                    List<int> fList = new List<int>();
                    fList.Add(fileCount);
                    Dict_Hashes[hash] = fList;
                }

                if (fileCount % 5000 == 0)
                {
                    using (System.Diagnostics.Process proc = System.Diagnostics.Process.GetCurrentProcess()) 
                    {
                        Logger.writeLog("" + fileCount + " files have been processed. SizeOfDictionary is " + Dict_Hashes.Count + ". Current Memory Usage: " + proc.PrivateMemorySize64, LogType.LOG_INFO);
                    }
                }
            }

            // print out result
            StreamWriter sw = new StreamWriter(cfg.OutputFile);
            sw.WriteLine("DocumentId\tFileName\tClusterId\tClusterSize");
            int clusterId = 1; 
            int numOfClusterGtOne = 0; 
            int numOfSinglePoints = 0; 
            foreach (string key in Dict_Hashes.Keys)
            {
                List<int> fList = Dict_Hashes[key];
                if( fList.Count > 1 ) 
                    numOfClusterGtOne++;
                else
                    numOfSinglePoints++;

                foreach (int fId in fList)
                {
                    MyFileInfo myFile = Dict_Files[fId];
                    sw.WriteLine("" + fId + "\t" + 
                                      myFile.FileName + "\t" + 
                                      clusterId + "\t" + 
                                      fList.Count);
                }

                clusterId++; 
            }
            sw.Close();

            Logger.writeLog("----------- Statistics ----------", LogType.LOG_INFO);
            Logger.writeLog("Total Files: " + Dict_Files.Count + ", " + 
                            "Total clusters with size greater than one:  " + numOfClusterGtOne + ", " + 
                            "NumOfSinglePoints:" + numOfSinglePoints, LogType.LOG_INFO);

            TimeSpan ts = DateTime.Now - dtProgramStart;

            Logger.writeLog("**** End of running. It took " + ts.TotalSeconds + " seconds. ", LogType.LOG_INFO);


        }


        public void Run_Dedup_For_Very_Large_DataSet()
        {
            Logger.writeLog("*** Start Running Exact Duplicate Detector *** ", LogType.LOG_INFO);
            DateTime dtProgramStart = DateTime.Now;

            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

            Configuration cfg = new Configuration();
            ErrInfo errInfo = new ErrInfo();
            cfg.Read_Configuration_File("ExactDupDetector.cfg", errInfo);
            if (cfg.Algorithm == "MD5")
                algorithm = Algorithms.MD5;
            else if (cfg.Algorithm == "SHA1")
                algorithm = Algorithms.SHA1;
            else if (cfg.Algorithm == "SHA256")
                algorithm = Algorithms.SHA256;
            else if (cfg.Algorithm == "SHA384")
                algorithm = Algorithms.SHA384;
            else if (cfg.Algorithm == "SHA512")
                algorithm = Algorithms.SHA512;
            else
                algorithm = Algorithms.MD5;

            Logger.writeLog("Algorithm type: " + cfg.Algorithm, LogType.LOG_INFO);
            Logger.writeLog("InputDir: " + cfg.InputDir, LogType.LOG_INFO);
            Logger.writeLog("OutputFile: " + cfg.OutputFile, LogType.LOG_INFO);

            MyDictionary<int, MyFileInfo> Dict_Files = new MyDictionary<int, MyFileInfo>();
            MyDictionary<string, List<int>> Dict_Hashes = new MyDictionary<string, List<int>>();  // hashvalue --> list of files

            string[] files = Directory.GetFiles(cfg.InputDir, "*", SearchOption.AllDirectories);
            int fileCount = 0;
            Logger.writeLog("In total, " + files.Length + " files exist in directory " + cfg.InputDir, LogType.LOG_INFO);
            foreach (var f in files)
            {
                MyFileInfo fInfo = new MyFileInfo();
                fInfo.FileName = f;
                FileInfo fi = new FileInfo(f);
                fInfo.FileSize = fi.Length;
                fileCount++;
                Dict_Files.Put(fileCount, fInfo);

                string hash = GetHashFromFile(f, Algorithms.MD5);
                int dictIndex = Dict_Hashes.ContainsKey(hash); 
                if ( dictIndex >= 0 )
                {
                    Dict_Hashes.Get(hash, dictIndex).Add(fileCount);
                }
                else
                {
                    List<int> fList = new List<int>();
                    fList.Add(fileCount);
                    Dict_Hashes.Put(hash, fList);
                }

                if (fileCount % 5000 == 0)
                {
                    using (System.Diagnostics.Process proc = System.Diagnostics.Process.GetCurrentProcess())
                    {
                        Logger.writeLog("" + fileCount + " files have been processed. SizeOfDictionary is " + Dict_Hashes.GetSize() + ". Current Memory Usage: " + proc.PrivateMemorySize64, LogType.LOG_INFO);
                    }
                }
            }

            // print out result
            StreamWriter sw = new StreamWriter(cfg.OutputFile);
            sw.WriteLine("DocumentId\tFileName\tClusterId\tClusterSize");
            int clusterId = 1;
            int numOfClusterGtOne = 0;
            int numOfSinglePoints = 0;
            foreach(Dictionary<string, List<int>> dict in Dict_Hashes.GetDictionaryList() )
            {
                foreach (string key in dict.Keys)
                {
                    List<int> fList = dict[key];
                    if (fList.Count > 1)
                        numOfClusterGtOne++;
                    else
                        numOfSinglePoints++;

                    foreach (int fId in fList)
                    {
                        int dIndex = Dict_Files.ContainsKey(fId);
                        if (dIndex >= 0)
                        {
                            MyFileInfo myFile = Dict_Files.Get(fId, dIndex);
                            sw.WriteLine("" + fId + "\t" +
                                              myFile.FileName + "\t" +
                                              clusterId + "\t" +
                                              fList.Count);
                        }
                    }

                    clusterId++;
                }
            }
            sw.Close();

            Logger.writeLog("----------- Statistics ----------", LogType.LOG_INFO);
            Logger.writeLog("Total Files: " + Dict_Files.GetSize() + ", " +
                            "Total clusters with size greater than one:  " + numOfClusterGtOne + ", " +
                            "NumOfSinglePoints:" + numOfSinglePoints, LogType.LOG_INFO);

            TimeSpan ts = DateTime.Now - dtProgramStart;

            Logger.writeLog("**** End of running. It took " + ts.TotalSeconds + " seconds. ", LogType.LOG_INFO);


        }

        
        
        public static string GetHashFromFile(string fileName, HashAlgorithm algorithm)
        {
              using (var stream = new BufferedStream(File.OpenRead(fileName), 100000))
              {
                    return BitConverter.ToString(algorithm.ComputeHash(stream)).Replace("-", string.Empty);
              }
        }
    
    }  // end of class DupDetector

}
