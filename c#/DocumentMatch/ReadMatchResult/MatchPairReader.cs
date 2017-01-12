using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ReadMatchResult
{
    class DocInfo
    {
        public string DocName { get; set; }
        public Dictionary<int, bool> DupDict { get; set; }

        public DocInfo()
        {
            DocName = null;
            DupDict = null;
        }
    }

    class Cluster
    {
        public int ID { get; set; }
        public List<string> FileList { get; set; } 
    }

    class MatchPairReader
    {

        static void Split_Dedup_Result()
        {
            List<Cluster> cList = new List<Cluster>();

            StreamReader sr = new StreamReader("C:\\Users\\ykou\\Documents\\Yufeng\\10Million_Dedup\\Result_11m_data\\ExactDup_11m_data.txt");
            StreamWriter sw = new StreamWriter("tmp");
            string line = "";
            sr.ReadLine();
            int count = 0; 
            while ((line = sr.ReadLine()) != null)
            {
                string[] tokens = line.Split('\t');
                count++;
                sw.WriteLine(line);
                if (count >= 1000)
                    break;
            }
            sr.Close();
            sw.Close();

        }

        static void Main(string[] args)
        {

            //DocInfo [] docArr = new DocInfo[973664];
            Split_Dedup_Result();
        }

        static void Convert_Cluster_Result_Format()
        {
            List<Cluster> cList = new List<Cluster>();

            StreamReader sr = new StreamReader("C:\\Users\\ykou\\Documents\\Yufeng\\10Million_Dedup\\Result_first_batch\\DocumentMatch.clusters");
            string line = "";
            Cluster cluster = null;
            while ((line = sr.ReadLine()) != null)
            {
                if (line.StartsWith("Cluster"))
                {
                    if (cluster != null)
                        cList.Add(cluster);

                    cluster = new Cluster();
                    string[] tokens = line.Trim().Split(' ');
                    cluster.ID = int.Parse(tokens[1]);
                    cluster.FileList = new List<string>();
                }
                else
                {
                    if (line.Trim().Length == 0)
                        continue;

                    cluster.FileList.Add(line.Trim());
                }

            }
            cList.Add(cluster);
            sr.Close();


            StreamWriter sw = new StreamWriter("cluster.csv");
            sw.WriteLine("ClusterID,ClusterSize,FileName");
            foreach (Cluster c in cList)
            {
                foreach (string f in c.FileList)
                    sw.WriteLine("" + c.ID + "," + c.FileList.Count + "," + f);
            }
            sw.Close();

        }
    }
}
