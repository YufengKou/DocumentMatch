using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO;

using Clustering;

namespace StringMatchPrototype
{
    public partial class MainStrMatchForm : Form
    {
        public MainStrMatchForm()
        {
            InitializeComponent();
        }

        public void update_Progress(int val)
        {
            progressBar1.Value = val;
        }

        public void set_Max_Progress_Value(int val)
        {
            progressBar1.Maximum = val;
        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void OpenFileButton_Click(object sender, EventArgs e)
        {
            if ( DialogInputDir.ShowDialog() == DialogResult.OK)
            {
                TxtInputFile.Text = DialogInputDir.SelectedPath;    //.FileName;
            }
            TxtOuptDir.Text = Directory.GetParent(DialogInputDir.SelectedPath).ToString() ;
        }

        private void set_statistics(StrCompStatistics statistics)
        {
            TxtAvgBucketSize.Text = statistics.AvgBucketSize.ToString();
            TxtMaxBucketSize.Text = statistics.MaxBucketSize.ToString();
            TxtAvgStringLength.Text = statistics.AvgStrLen.ToString();
            TxtNumOfStrings.Text = statistics.NumOfStrings.ToString();
            TxtMaxBucketSize.Text = statistics.MaxBucketSize.ToString();
            //TxtNumOfBuckets.Text = statistics.NumOfBuckets.ToString();
            TxtNumOfStrComparison.Text = statistics.NumOfStrComp.ToString();
            TxtTotalRunTime.Text = statistics.TotalRunTime.ToString();
            TxtInputReadTime.Text = statistics.DataImportTime.ToString();
            TxtNonemptyBuckets.Text = statistics.NumOfNonEmptyBuckets.ToString();
            TxtOutputFile.Text = statistics.OutputFile.ToString();
            TxtMinDocLen.Text = statistics.MinStrLen.ToString();
            TxtMaxDocLen.Text = statistics.MaxStrLen.ToString();
            TxtNumOfTokens.Text = statistics.NumOfTokens.ToString();
            TxtNumOfMatchedDocs.Text = statistics.NumOfMatched.ToString() ;

            // cluster statistics
            txtClusterFile.Text = statistics.ClusterFile;
            txtMaxClusterSize.Text = statistics.MaxClusterSize.ToString();
            txtAvgClusterSize.Text = Math.Round(statistics.AvgClusterSize, 3).ToString();
            txtMinClusterSize.Text = statistics.MinClusterSize.ToString();
            txtNumOfClusters.Text = statistics.NumOfClusters.ToString();
            txtNumOfStringsForAllClusters.Text = statistics.NumOfStrings.ToString();
            txtClusterType.Text = statistics.ClusterType;
        }

        private void init_statistics_display()
        {
            TxtAvgBucketSize.Text = "";
            TxtMaxBucketSize.Text = "";
            TxtAvgStringLength.Text = "";
            TxtNumOfStrings.Text = "";
            TxtMaxBucketSize.Text = "";
            //TxtNumOfBuckets.Text = "";
            TxtNumOfStrComparison.Text = "";
            TxtTotalRunTime.Text = "";
            TxtInputReadTime.Text = "";
            TxtNonemptyBuckets.Text = "";
            TxtOutputFile.Text = "";
            TxtMinDocLen.Text = "";
            TxtMaxDocLen.Text = "";
            TxtNumOfTokens.Text = "";
            TxtNumOfMatchedDocs.Text = "";
            dataGridView1.DataSource = null;
            dataGridView1.Refresh();

            // cluster statistics init
            txtClusterFile.Text = "";
            txtMaxClusterSize.Text = "";
            txtAvgClusterSize.Text = "";
            txtMinClusterSize.Text = "";
            txtNumOfClusters.Text = "";
            txtNumOfStringsForAllClusters.Text = "";
            txtClusterType.Text = "";
            ClustersDataGrid.DataSource = null;
            ClustersDataGrid.Refresh();

        }


        private void RunButton_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(TxtInputFile.Text))
            {
                MessageBox.Show("The input directory does not exist! ", "Error Information");
                return;
            }

            if (!Directory.Exists(TxtOuptDir.Text))
            {
                MessageBox.Show("The output directory does not exist! ", "Error Information");
                return;
            }

            progressBar1.Style = ProgressBarStyle.Blocks;
            progressBar1.MarqueeAnimationSpeed = 50;
            progressBar1.Visible = true;
            progressBar1.Value = 0;
            backgroundWorker1.RunWorkerAsync();
            TxtProgress.Text = "String matching job has been started ...." ;
            TxtProgress.Visible = true;
            
            init_statistics_display();
            
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            appStrMatch s = new appStrMatch(TxtInputFile.Text, TxtOuptDir.Text);
            int numOfBins = Int32.Parse(TxtNumOfBins.Text);
            int maxDist = Int32.Parse(txtMaxDistance.Text);
            double threshold;
            bool result = Double.TryParse(TxtSimilarityThreshold.Text, out threshold);
            int maxVal = 10000000;
            //result = Int32.TryParse(TxtMaxBinVal.Text, out maxVal);

            ClusteringType clusterType = ClusteringType.NO_CLUSTERING;
            if (radioButtonSingleLink.Checked == true)
                clusterType = ClusteringType.SINGLE_LINK;
            else if (radioButtonCompleteLink.Checked == true)
                clusterType = ClusteringType.COMPLETE_LINK;

            if (s.strMatch_New(numOfBins, maxVal, threshold, maxDist, clusterType, backgroundWorker1) < 0)  // the task was aborted. 
                return;

            StrCompStatistics statistics = s.GetStrMatchStatistics();
            e.Result = statistics;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progressBar1.Visible = false;
            TxtProgress.Text = "The string matching task has completed. ";
            StrCompStatistics statistics = (StrCompStatistics) e.Result;
            set_statistics(statistics);
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            TxtProgress.Text = "The string matching task has completed " + e.ProgressPercentage.ToString() + "%.";
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void BtnLoadResult_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            DataColumn col0 = new DataColumn();
            col0.ColumnName = "Row";
            dt.Columns.Add(col0);

            DataColumn col1 = new DataColumn();
            col1.ColumnName = "Document 1";
            dt.Columns.Add(col1);


            DataColumn col2 = new DataColumn();
            col2.ColumnName = "Document 2";
            dt.Columns.Add(col2);

            DataColumn col3 = new DataColumn();
            col3.ColumnName = "Similarity";
            dt.Columns.Add(col3);

            DataColumn col4 = new DataColumn();
            col4.ColumnName = "Edit Distance";
            dt.Columns.Add(col4);

            DataColumn col5 = new DataColumn();
            col5.ColumnName = "Index1";
            dt.Columns.Add(col5);

            DataColumn col6 = new DataColumn();
            col6.ColumnName = "Index2";
            dt.Columns.Add(col6);
            
            StreamReader sr = new StreamReader(TxtOutputFile.Text);
            string str;
            int i = 1;
            while ((str = sr.ReadLine()) != null)
            {
                DataRow r = dt.NewRow();
                string[] tokens = str.Split('\t');
                if (tokens == null || tokens.Length < 6)
                    continue;
                r[0] = i++; 
                r[1] = tokens[0];
                r[2] = tokens[1];
                r[3] = tokens[2];
                r[4] = tokens[3];
                r[5] = tokens[4];
                r[6] = tokens[5];
                dt.Rows.Add(r);
            }
            sr.Close();

            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].Width = 60;
            dataGridView1.Columns[1].Width = 350;
            dataGridView1.Columns[2].Width = 350;
            dataGridView1.Columns[3].Width = 63;
            dataGridView1.Columns[4].Width = 63;
            dataGridView1.Columns[5].Visible = false;
            dataGridView1.Columns[6].Visible = false;

            dataGridView1.Refresh();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            backgroundWorker1.CancelAsync();
            init_statistics_display();
        }

        private void BtnOutputDir_Click(object sender, EventArgs e)
        {
            if (DialogOutputDir.ShowDialog() == DialogResult.OK)
            {
                TxtOuptDir.Text = DialogOutputDir.SelectedPath;    //.FileName;
            }
        }

        private void TxtMaxBucketSize_TextChanged(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void BtnMultTest_Click(object sender, EventArgs e)
        {
            Logger.writeLog("Start running Multiple Test", LogType.LOG_INFO);
            List<TestStrMatch> testList = new List<TestStrMatch>();
            try
            {
                StreamReader sr = new StreamReader("MultTest.input");
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] tokens = line.Split('\t');
                    if (tokens != null && tokens.Length == 3)
                    {
                        double threshold = Double.Parse(tokens[0].Trim());
                        int nBins = Int32.Parse(tokens[1].Trim());
                        int mVal = Int32.Parse(tokens[2].Trim());
                        TestStrMatch t = new TestStrMatch(threshold, nBins, mVal);
                        testList.Add(t);
                    }
                }
                sr.Close();
            }
            catch (Exception ex)
            {
                Logger.writeLog(ex.StackTrace + "\n" + ex.Message, LogType.LOG_INFO);
                return;
            }

            foreach (var test in testList)
            {
                test.TestFileName = TxtInputFile.Text;
                appStrMatch s = new appStrMatch(TxtInputFile.Text, TxtOuptDir.Text);
                s.strMatch_New(test.NumOfBins, test.MaxVal, test.Threshold, test.MaxDistance, ClusteringType.NO_CLUSTERING, backgroundWorker1);
                StrCompStatistics statistics = s.GetStrMatchStatistics();
                test.NumOfMatchedPairs = statistics.NumOfMatched;
                test.Runtime = statistics.TotalRunTime - statistics.DataImportTime;
                test.NumOfBuckets = statistics.NumOfNonEmptyBuckets;
                test.AvgBucketSize = statistics.AvgBucketSize;
                test.NumOfMatches = statistics.NumOfStrComp;
            }

            // print out result
            StreamWriter sw = new StreamWriter("MultTest.output");
            sw.WriteLine("Input directory: " + TxtInputFile.Text);
            sw.WriteLine("Output directory: " + TxtOuptDir.Text);
            sw.WriteLine("Threshold\tNumOfBins\tMaxVal\tTotalRuntime_minus_data_import\tMatchedPairs\tTotalStringComparison\tNumOfBuckets\tAvgBucketSize");
            foreach (var test in testList)
            {
                sw.WriteLine("" + test.Threshold + "\t" + test.NumOfBins + "\t" + test.MaxVal + "\t" + test.Runtime + "\t" + test.NumOfMatchedPairs + "\t" + test.NumOfMatches + "\t" + test.NumOfBuckets + "\t" + test.AvgBucketSize);
            }
            sw.Close();

            Logger.writeLog("End of running Multiple Test. ", LogType.LOG_INFO);
        }

        private void gridDblClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            if (rowIndex < 0)
                return;

            string fName1 = dataGridView1.Rows[rowIndex].Cells[1].Value.ToString();
            string fName2 = dataGridView1.Rows[rowIndex].Cells[2].Value.ToString();
            int k = Int32.Parse(dataGridView1.Rows[rowIndex].Cells[4].Value.ToString() );
            int docIndex1 = Int32.Parse(dataGridView1.Rows[rowIndex].Cells[5].Value.ToString());
            int docIndex2 = Int32.Parse(dataGridView1.Rows[rowIndex].Cells[6].Value.ToString());
            List<int> tokenIdList1 = appStrMatch.GetDocTokenIdList(docIndex1);
            List<string> tokenStrList1 = appStrMatch.GetDocTokenStringList(docIndex1);
            List<int> tokenIdList2 = appStrMatch.GetDocTokenIdList(docIndex2);
            List<string> tokenStrList2 = appStrMatch.GetDocTokenStringList(docIndex2);
            DiffDisplay diffForm = new DiffDisplay(fName1, fName2, tokenIdList1, tokenIdList2, tokenStrList1, tokenStrList2, k);
            diffForm.ShowDialog();
        }

        private void TxtNumOfBins_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void TxtSimilarityThreshold_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void btnLoadClusters_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            DataColumn col0 = new DataColumn();
            col0.ColumnName = "Cluster ID";
            dt.Columns.Add(col0);

            DataColumn col1 = new DataColumn();
            col1.ColumnName = "Document File Name";
            dt.Columns.Add(col1);

            DataColumn col2 = new DataColumn();
            col2.ColumnName = "Cluster Size";
            dt.Columns.Add(col2);
            StreamReader sr = null;
            try
            {
                sr = new StreamReader(txtClusterFile.Text);
                string str;
                while ((str = sr.ReadLine()) != null)
                {
                    if (str.Trim().Length == 0)
                        continue;

                    DataRow r = null;
                    if (str.StartsWith("Cluster"))
                    {
                        r = dt.NewRow();
                        //r[0] = ++i;
                        r[0] = str;
                        str = sr.ReadLine();
                        string clusterElements = "";
                        int count = 0;
                        while (str != null && str != "" && !str.StartsWith("Cluster"))
                        {
                            clusterElements += (str + "\n");
                            count++;
                            str = sr.ReadLine();
                        }
                        if (clusterElements.EndsWith("\n"))
                            clusterElements = clusterElements.Substring(0, clusterElements.Length - 1);
                        r[1] = clusterElements;
                        r[2] = count;
                    }
                    dt.Rows.Add(r);
                }
                sr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Invalid file name. Reading file failed. ", "File I/P Error");
                Logger.writeLog(ex.Message, LogType.LOG_ERROR);
                ClustersDataGrid.DataSource = null;
                ClustersDataGrid.Refresh();
            }

            ClustersDataGrid.DataSource = dt;
            ClustersDataGrid.Columns[0].Width = 150;
            ClustersDataGrid.Columns[1].Width = 615;
            ClustersDataGrid.Columns[2].Width = 100;
            ClustersDataGrid.Columns[1].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            ClustersDataGrid.Refresh();
        }

        private void txtClusterFile_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult exportDialog = MessageBox.Show("This operation will put all deduped documents to a directory. It may take time and disk space. Do you want to proceed?", "Confirmation", MessageBoxButtons.YesNo);
            if (exportDialog != DialogResult.Yes)
            {
                return;
            }


            FolderBrowserDialog fbd = new FolderBrowserDialog();
            DialogResult result = fbd.ShowDialog();
            if (result != DialogResult.OK)
            {
                return;
            }

            string path = fbd.SelectedPath;
            StreamReader sr = null;
            try
            {
                sr = new StreamReader(txtClusterFile.Text);
                string str;
                while ((str = sr.ReadLine()) != null)
                {
                    if (str.Trim().Length == 0)
                        continue;

                    if (str.StartsWith("Cluster"))
                    {
                        str = sr.ReadLine();
                        bool isFirst = true;
                        while (str != null && str != "" && !str.StartsWith("Cluster"))
                        {
                            if (isFirst)
                            {
                                string srcFileName = str;
                                string fileNameOnly = System.IO.Path.GetFileName(srcFileName);
                                string destFile = System.IO.Path.Combine(fbd.SelectedPath, fileNameOnly);
                                System.IO.File.Copy(srcFileName, destFile, true);
                                isFirst = false;
                            }
                            str = sr.ReadLine();
                        }
                    }
                }
                sr.Close();


                // copy single point file
                sr = new StreamReader("SinglePoints.txt");
                while ((str = sr.ReadLine()) != null)
                {
                    if (str.Trim().Length == 0)
                        continue;
                    string srcFileName = str;
                    string fileNameOnly = System.IO.Path.GetFileName(srcFileName);
                    string destFile = System.IO.Path.Combine(fbd.SelectedPath, fileNameOnly);
                    System.IO.File.Copy(srcFileName, destFile, true);
                }
                sr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Invalid file name. Reading file failed. ", "File I/P Error");
                Logger.writeLog(ex.Message, LogType.LOG_ERROR);
                ClustersDataGrid.DataSource = null;
                ClustersDataGrid.Refresh();
            }
        }

    }
}
