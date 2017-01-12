using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;


namespace CommonUtils
{

    public class ErrInfo
    {
        public int ErrCode { get; set; }
        public string ErrMsg { get; set; }

        public ErrInfo()
        {
            ErrCode = 0;
            ErrMsg = "";
        }
    }

    public class Configuration
    {
        public string InputDir { get; set; }
        public string Algorithm { get; set; } 

        public string ConnectString { get; set; }
        public double TokenLevelSimilarityThreshold { get; set; }
        public double WholeStringLevelSimilarityThreshold { get; set; }
        public string OutputDir { get; set; }
        public string WorkDir { get; set; }
        public string InputFile_1 { get; set; }
        public string InputFile_2 { get; set; }
        public string OutputFile { get; set; }
        public string PreProcessing_Dictionary { get; set; }    // This dictionary is used to standardize data. For example ST --> STREET
        public string PostProcessing_Dictionary { get; set; }   // This dictionary is used to filter out matching result. For example, if "Telecommunications" appear frequently, assign a low weight to it. 
        public string Split_Characters_File { get; set; }

        public string Input_ConnecString_1 { get; set; }
        public string Input_ConnectString_2 { get; set; }
        public string Output_ConnectString { get; set; }
        public string TableName_1 { get; set; }
        public string TableTextField_1 { get; set; }
        public string TableIdField_1 { get; set; }
        public string TableName_2 { get; set; }
        public string TableTextField_2 { get; set; }
        public string TableIdField_2 { get; set; }
        public string OutputTableName { get; set; }
        public string Output_IdField_1 { get; set; }
        public string Output_TextField_1 { get; set; }
        public string Output_IdField_2 { get; set; }
        public string Output_TextField_2 { get; set; }
        public string Output_ScoreField { get; set; }
        public string MatchMethod { get; set; }  // "CHARACTER_BASED" or "TOKEN_BASED"
        public string InputFilter_1 { get; set; }
        public string InputFilter_2 { get; set; }

        public string InputSourceType1 { get; set; }
        public string InputSourceType2 { get; set; }
        public string OutputType { get; set; }
        public int NumOfInputs { get; set; }


        public double SearchTermWeighting { get; set; }  // this is for score calculation. its value is between 0 and 1.  
                                                         // 1 means only consider the length of search terms (first list).
                                                         // 0 means only consider the length of searched string (second list). 
                                                         // 0.5 means use the avg length of the search term and the seached string 

        public double TokenFreqThreshold { get; set; }  // if a token appears very frequently in the data set, lower it's weight
                                                             // in token level score aggregation

        public bool SearchTermWeightBasedOnShorterString { get; set; }    // This is a bool switch. 
                                                                            // Yes:   the search weight is always for the shorter string when comparing two strings
                                                                            // No:    the search weight is for the search terms (the first list) 

        public bool UseAdaptiveThresholdForShortTokens { get; set; }     // This is a bool switch. 
                                                                         // Yes: Use adaptive threshold for shorter tokens. For example, if the current token-level threshold is 
                                                                         //      is 0.8. For shorter tokens we can use a threshold lower than that. For example, for tokens with length 2, we can use 0.5; 
                                                                         //      for tokens with length 3, we can use 0.6. In this way, more candidates can be found. 
                                                                         //  No: Use the current token-level threshold for all tokens. 

        public string AccentLetter_Dictionary { get; set; }              // This dictionary is used to replace accent letters to non-accent letters so that they can match with each others. 

        public int SqlCommandTimeout { get; set; }

        public int UserId { get; set; }
        public string SortMatchResult { get; set; }
        public string ExactNumberMatch { get; set; }
        public string ClusterType { get; set; }


     
        //for writing statistics

        public Configuration()
        {
            TokenFreqThreshold = 1.0;
            SqlCommandTimeout = 200;     // by default, set it as 200 seconds
        }

        private string read_connect_string(string line)
        {
            int beginIndex = line.IndexOf('"') + 1;
            int endIndex = line.LastIndexOf('"') - 1;
            string str = null;
            if (beginIndex < 1 || endIndex < beginIndex)
                str = "";
            else
                str = line.Substring(beginIndex, endIndex - beginIndex + 1);

            return str;
        }

        public void Read_Configuration_File(string cfgFileName, ErrInfo errInfo)
        {
            try
            {
                using (StreamReader sr = new StreamReader(cfgFileName))
                {
                    String line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        if (line.Trim().StartsWith("#") || line.Trim().Length == 0)
                            continue;

                        string[] tokens = line.Trim().Split('=');
                        if (tokens.Length < 2)
                        {
                            errInfo.ErrCode = 1;
                            errInfo.ErrMsg = "Error in configuration file " + cfgFileName + ": format not valid. \n" + line; 
                            Logger.writeLog(errInfo.ErrMsg, LogType.LOG_INFO);
                            //Environment.Exit(1);
                        }

                        string key = tokens[0].Trim().ToUpper();
                        if (key == "OUTPUT_DIR")
                            OutputDir = tokens[1].Trim();
                        else if (key == "INPUT_DIR")
                            InputDir = tokens[1].Trim();
                        else if (key == "OUTPUT_FILE")
                            OutputFile = tokens[1].Trim();
                        else if (key == "ALGORITHM")
                            Algorithm = tokens[1].Trim();
                        else if (key == "WORK_DIR")
                            WorkDir = tokens[1].Trim();
                        else if (key == "CONNECT_STRING")
                        {
                            ConnectString = read_connect_string(line);
                        }
                        else if (key == "SQL_COMMAND_TIMEOUT")
                        {
                            int result;
                            bool flag = Int32.TryParse(tokens[1].Trim(), out result);
                            if (flag == true)
                                SqlCommandTimeout = result;
                            else
                            {
                                errInfo.ErrCode = 1;
                                errInfo.ErrMsg = "Error in configuration file " + cfgFileName + ": format not valid. \n" + line;
                                Logger.writeLog(errInfo.ErrMsg, LogType.LOG_INFO);
                                return;
                                //Environment.Exit(1);
                            }
                        }
                        else if (key == "USER_ID")
                        {
                            int result;
                            bool flag = Int32.TryParse(tokens[1].Trim(), out result);
                            if (flag == true)
                                UserId = result;
                            else
                            {
                                Logger.writeLog("Error in configuration file " + cfgFileName + ": format not valid. \n" + line, LogType.LOG_INFO);
                                Environment.Exit(1);
                            }
                        }
                        else if (key == "SORT_MATCH_RESULT")
                            SortMatchResult = tokens[1].Trim();
                        else if (key == "EXACT_NUMBER_MATCH")
                            ExactNumberMatch = tokens[1].Trim();

                        else
                        {
                            errInfo.ErrCode = 1;
                            errInfo.ErrMsg = "Unknown Parameters in configuration file. " + line;
                            Logger.writeLog(errInfo.ErrMsg, LogType.LOG_ERROR);
                            return;
                            //Environment.Exit(1);
                        }
                    }  // end while loop
                } // end using
            } // end try
            catch (Exception e)
            {
                // Let the user know what went wrong.
                errInfo.ErrCode = 1;
                errInfo.ErrMsg = "Reading error of file: " + cfgFileName + e.StackTrace; 
                Logger.writeLog(errInfo.ErrMsg, LogType.LOG_ERROR);
                return; 
                //Environment.Exit(1);
            }

        }


        public void Read_Configuration_File(string cfgFileName)
        {
            try
            {
                using (StreamReader sr = new StreamReader(cfgFileName) )
                {
                    String line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        if (line.Trim().StartsWith("#") || line.Trim().Length == 0)
                            continue;

                        string[] tokens = line.Trim().Split('=');
                        if (tokens.Length < 2)
                        {
                            Logger.writeLog("Error in configuration file " + cfgFileName + ": format not valid. \n" + line, LogType.LOG_INFO);
                            Environment.Exit(1);
                        }

                        string key = tokens[0].Trim().ToUpper();
                        if (key == "OUTPUT_DIR")
                            OutputDir = tokens[1].Trim();
                        else if (key == "WORK_DIR")
                            WorkDir = tokens[1].Trim();
                        else if (key == "TOKEN_THRESHOLD")
                        {
                            double result;
                            bool flag = Double.TryParse(tokens[1].Trim(), out result);
                            if (flag == true)
                                TokenLevelSimilarityThreshold = result;
                            else
                            {
                                Logger.writeLog("Error in configuration file " + cfgFileName + ": format not valid. \n" + line, LogType.LOG_INFO);
                                Environment.Exit(1);
                            }
                        }
                        else if (key == "STRING_THRESHOLD")
                        {
                            double result;
                            bool flag = Double.TryParse(tokens[1].Trim(), out result);
                            if (flag == true)
                                WholeStringLevelSimilarityThreshold = result;
                            else
                            {
                                Logger.writeLog("Error in configuration file " + cfgFileName + ": format not valid. \n" + line, LogType.LOG_INFO);
                                Environment.Exit(1);
                            }
                        }
                        else if (key == "CONNECT_STRING")
                        {
                            ConnectString = read_connect_string(line);
                        }
                        else if (key == "INPUT_FILE_1")
                        {
                            InputFile_1 = tokens[1].Trim();
                        }
                        else if (key == "INPUT_FILE_2")
                        {
                            InputFile_2 = tokens[1].Trim();
                        }
                        else if (key == "SPLIT_CHARACTERS_FILE")
                        {
                            Split_Characters_File = tokens[1].Trim();
                        }
                        else if (key == "MATCH_METHOD")
                        {
                            MatchMethod = tokens[1].Trim();
                        }
                        else if (key == "POST_PROCESSING_DICTIONARY")
                            PostProcessing_Dictionary = tokens[1].Trim();
                        else if (key == "PRE_PROCESSING_DICTIONARY")
                            PreProcessing_Dictionary = tokens[1].Trim();
                        else if (key == "INPUT_CONNECT_STRING_1")
                            Input_ConnecString_1 = read_connect_string(line);
                        else if (key == "INPUT_TABLE_1")
                            TableName_1 = tokens[1].Trim();
                        else if (key == "INPUT_TEXT_FIELD_1")
                            TableTextField_1 = tokens[1].Trim();
                        else if (key == "INPUT_ID_FIELD_1")
                            TableIdField_1 = tokens[1].Trim();
                        else if (key == "INPUT_FILTER_1")
                            InputFilter_1 = tokens[1].Trim();
                        else if (key == "INPUT_CONNECT_STRING_2")
                            Input_ConnectString_2 = read_connect_string(line);
                        else if (key == "INPUT_TABLE_2")
                            TableName_2 = tokens[1].Trim();
                        else if (key == "INPUT_TEXT_FIELD_2")
                            TableTextField_2 = tokens[1].Trim();
                        else if (key == "INPUT_ID_FIELD_2")
                            TableIdField_2 = tokens[1].Trim();
                        else if (key == "INPUT_FILTER_2")
                            InputFilter_2 = tokens[1].Trim();
                        else if (key == "OUTPUT_CONNECT_STRING")
                            Output_ConnectString = read_connect_string(line);
                        else if (key == "OUTPUT_TABLE_NAME")
                            OutputTableName = tokens[1].Trim();
                        else if (key == "OUTPUT_ID_FIELD_1")
                            Output_IdField_1 = tokens[1].Trim();
                        else if (key == "OUTPUT_TEXT_FIELD_1")
                            Output_TextField_1 = tokens[1].Trim();
                        else if (key == "OUTPUT_ID_FIELD_2")
                            Output_IdField_2 = tokens[1].Trim();
                        else if (key == "OUTPUT_TEXT_FIELD_2")
                            Output_TextField_2 = tokens[1].Trim();
                        else if (key == "OUTPUT_SCORE_FIELD")
                            Output_ScoreField = tokens[1].Trim();
                        else if (key == "TOKEN_FREQ_THRESHOLD")
                        {
                            double result;
                            bool flag = Double.TryParse(tokens[1].Trim(), out result);
                            if (flag == true)
                                TokenFreqThreshold = result;
                            else
                            {
                                Logger.writeLog("Error in configuration file " + cfgFileName + ": TOKEN_FREQ_THRESHOLDformat not valid. \n" + line, LogType.LOG_INFO);
                                Environment.Exit(1);
                            }
                        }
                        else if (key == "SEARCH_TERM_WEIGHTING")
                        {
                            double result;
                            bool flag = Double.TryParse(tokens[1].Trim(), out result);
                            if (flag == true)
                                SearchTermWeighting = result;
                            else
                            {
                                Logger.writeLog("Error in configuration file " + cfgFileName + ": SEARCH_TERM_WEIGHTING format not valid. \n" + line, LogType.LOG_INFO);
                                Environment.Exit(1);
                            }
                        }
                        else if (key == "SEARCH_WEIGHTING_BASED_ON_SHORTER_STRING")
                        {
                            if (tokens[1].Trim().ToUpper() == "TRUE")
                                SearchTermWeightBasedOnShorterString = true;
                            else
                            {
                                Logger.writeLog("Error in configuration file " + cfgFileName + ": SEARCH_WEIGHTING_BASED_ON_SHORTER_STRING format not valid. \n" + line, LogType.LOG_INFO);
                                Environment.Exit(1);
                            }
                        }
                        else if (key == "USE_ADAPTIVE_THRESHOLD_FOR_SHORT_TOKENS")
                        {
                            if (tokens[1].Trim().ToUpper() == "TRUE")
                                UseAdaptiveThresholdForShortTokens = true;
                            else
                            {
                                Logger.writeLog("Error in configuration file " + cfgFileName + ": USE_ADAPTIVE_THRESHOLD_FOR_SHORT_TOKENS format not valid. \n" + line, LogType.LOG_INFO);
                                Environment.Exit(1);
                            }
                        }
                        else if (key == "SQL_COMMAND_TIMEOUT")
                        {
                            int result;
                            bool flag = Int32.TryParse(tokens[1].Trim(), out result);
                            if (flag == true)
                                SqlCommandTimeout = result;
                            else
                            {
                                Logger.writeLog("Error in configuration file " + cfgFileName + ": format not valid. \n" + line, LogType.LOG_INFO);
                                Environment.Exit(1);
                            }
                        }
                        else if (key == "ACCENT_LETTER_DICTIONARY")
                            AccentLetter_Dictionary = tokens[1].Trim();
                        else
                        {
                            Logger.writeLog("Unknown Parameters in configuration file. " + line, LogType.LOG_ERROR);
                            Environment.Exit(1);
                        }
                    }  // end while loop
                } // end using
            } // end try
            catch (Exception e)
            {
                // Let the user know what went wrong.
                Logger.writeLog("Reading error of file: " + cfgFileName + e.StackTrace, LogType.LOG_ERROR);
                Environment.Exit(1);
            }
        }  // end of function

    }  // end of class

} // end of namespace
