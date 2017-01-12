namespace StringMatchPrototype
{
    partial class MainStrMatchForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.BtnMultTest = new System.Windows.Forms.Button();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.TxtProgress = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButtonNoClustering = new System.Windows.Forms.RadioButton();
            this.radioButtonCompleteLink = new System.Windows.Forms.RadioButton();
            this.radioButtonSingleLink = new System.Windows.Forms.RadioButton();
            this.label24 = new System.Windows.Forms.Label();
            this.txtMaxDistance = new System.Windows.Forms.MaskedTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.BtnOutputDir = new System.Windows.Forms.Button();
            this.TxtOuptDir = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.OpenFileButton = new System.Windows.Forms.Button();
            this.TxtInputFile = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TxtNumOfBins = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtSimilarityThreshold = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ExitButton = new System.Windows.Forms.Button();
            this.RunButton = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.TxtNumOfMatchedDocs = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.TxtOutputFile = new System.Windows.Forms.TextBox();
            this.LblOutputFile = new System.Windows.Forms.Label();
            this.BtnLoadResult = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.TxtMinDocLen = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.TxtMaxDocLen = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.TxtNumOfTokens = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.TxtNonemptyBuckets = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.TxtInputReadTime = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.TxtTotalRunTime = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.TxtNumOfStrComparison = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.TxtAvgBucketSize = new System.Windows.Forms.TextBox();
            this.TxtMaxBucketSize = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.TxtAvgStringLength = new System.Windows.Forms.TextBox();
            this.TxtNumOfStrings = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tabClusters = new System.Windows.Forms.TabPage();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.txtClusterFile = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.btnLoadClusters = new System.Windows.Forms.Button();
            this.ClustersDataGrid = new System.Windows.Forms.DataGridView();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtClusterType = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.txtMaxClusterSize = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.txtAvgClusterSize = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.txtMinClusterSize = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.txtNumOfStringsForAllClusters = new System.Windows.Forms.TextBox();
            this.txtNumOfClusters = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.DialogInputDir = new System.Windows.Forms.FolderBrowserDialog();
            this.DialogOutputDir = new System.Windows.Forms.FolderBrowserDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.tabClusters.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ClustersDataGrid)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabClusters);
            this.tabControl1.Location = new System.Drawing.Point(31, 21);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(979, 510);
            this.tabControl1.TabIndex = 5;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.BtnMultTest);
            this.tabPage1.Controls.Add(this.BtnCancel);
            this.tabPage1.Controls.Add(this.TxtProgress);
            this.tabPage1.Controls.Add(this.progressBar1);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.ExitButton);
            this.tabPage1.Controls.Add(this.RunButton);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(971, 484);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Run";
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // BtnMultTest
            // 
            this.BtnMultTest.Location = new System.Drawing.Point(364, 349);
            this.BtnMultTest.Name = "BtnMultTest";
            this.BtnMultTest.Size = new System.Drawing.Size(86, 23);
            this.BtnMultTest.TabIndex = 11;
            this.BtnMultTest.Text = "MultTest";
            this.BtnMultTest.UseVisualStyleBackColor = true;
            this.BtnMultTest.Visible = false;
            this.BtnMultTest.Click += new System.EventHandler(this.BtnMultTest_Click);
            // 
            // BtnCancel
            // 
            this.BtnCancel.Location = new System.Drawing.Point(416, 298);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(86, 23);
            this.BtnCancel.TabIndex = 10;
            this.BtnCancel.Text = "Cancel";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Visible = false;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // TxtProgress
            // 
            this.TxtProgress.AutoSize = true;
            this.TxtProgress.Location = new System.Drawing.Point(68, 228);
            this.TxtProgress.Name = "TxtProgress";
            this.TxtProgress.Size = new System.Drawing.Size(225, 13);
            this.TxtProgress.TabIndex = 9;
            this.TxtProgress.Text = "The string matching task has been completed.";
            this.TxtProgress.Visible = false;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(71, 253);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(813, 23);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar1.TabIndex = 8;
            this.progressBar1.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButtonNoClustering);
            this.groupBox1.Controls.Add(this.radioButtonCompleteLink);
            this.groupBox1.Controls.Add(this.radioButtonSingleLink);
            this.groupBox1.Controls.Add(this.label24);
            this.groupBox1.Controls.Add(this.txtMaxDistance);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.BtnOutputDir);
            this.groupBox1.Controls.Add(this.TxtOuptDir);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.OpenFileButton);
            this.groupBox1.Controls.Add(this.TxtInputFile);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.TxtNumOfBins);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.TxtSimilarityThreshold);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBox1.Location = new System.Drawing.Point(71, 40);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(812, 160);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Parameters Setting";
            // 
            // radioButtonNoClustering
            // 
            this.radioButtonNoClustering.AutoSize = true;
            this.radioButtonNoClustering.Checked = true;
            this.radioButtonNoClustering.Location = new System.Drawing.Point(320, 125);
            this.radioButtonNoClustering.Name = "radioButtonNoClustering";
            this.radioButtonNoClustering.Size = new System.Drawing.Size(88, 17);
            this.radioButtonNoClustering.TabIndex = 17;
            this.radioButtonNoClustering.TabStop = true;
            this.radioButtonNoClustering.Text = "No Clustering";
            this.radioButtonNoClustering.UseVisualStyleBackColor = true;
            // 
            // radioButtonCompleteLink
            // 
            this.radioButtonCompleteLink.AutoSize = true;
            this.radioButtonCompleteLink.Location = new System.Drawing.Point(217, 125);
            this.radioButtonCompleteLink.Name = "radioButtonCompleteLink";
            this.radioButtonCompleteLink.Size = new System.Drawing.Size(92, 17);
            this.radioButtonCompleteLink.TabIndex = 16;
            this.radioButtonCompleteLink.Text = "Complete Link";
            this.radioButtonCompleteLink.UseVisualStyleBackColor = true;
            // 
            // radioButtonSingleLink
            // 
            this.radioButtonSingleLink.AutoSize = true;
            this.radioButtonSingleLink.Location = new System.Drawing.Point(123, 125);
            this.radioButtonSingleLink.Name = "radioButtonSingleLink";
            this.radioButtonSingleLink.Size = new System.Drawing.Size(77, 17);
            this.radioButtonSingleLink.TabIndex = 15;
            this.radioButtonSingleLink.Text = "Single Link";
            this.radioButtonSingleLink.UseVisualStyleBackColor = true;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(46, 125);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(56, 13);
            this.label24.TabIndex = 14;
            this.label24.Text = "Clustering:";
            // 
            // txtMaxDistance
            // 
            this.txtMaxDistance.Location = new System.Drawing.Point(490, 28);
            this.txtMaxDistance.Name = "txtMaxDistance";
            this.txtMaxDistance.Size = new System.Drawing.Size(58, 20);
            this.txtMaxDistance.TabIndex = 13;
            this.txtMaxDistance.Text = "1000";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(379, 31);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(106, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Max Distance Cutoff:";
            // 
            // BtnOutputDir
            // 
            this.BtnOutputDir.Image = global::StringMatchPrototype.Properties.Resources.File;
            this.BtnOutputDir.Location = new System.Drawing.Point(745, 86);
            this.BtnOutputDir.Name = "BtnOutputDir";
            this.BtnOutputDir.Size = new System.Drawing.Size(38, 34);
            this.BtnOutputDir.TabIndex = 11;
            this.BtnOutputDir.UseVisualStyleBackColor = true;
            this.BtnOutputDir.Click += new System.EventHandler(this.BtnOutputDir_Click);
            // 
            // TxtOuptDir
            // 
            this.TxtOuptDir.Location = new System.Drawing.Point(121, 90);
            this.TxtOuptDir.Name = "TxtOuptDir";
            this.TxtOuptDir.Size = new System.Drawing.Size(618, 20);
            this.TxtOuptDir.TabIndex = 10;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(16, 90);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(90, 13);
            this.label14.TabIndex = 9;
            this.label14.Text = "Output Directory: ";
            // 
            // OpenFileButton
            // 
            this.OpenFileButton.Image = global::StringMatchPrototype.Properties.Resources.File;
            this.OpenFileButton.Location = new System.Drawing.Point(745, 50);
            this.OpenFileButton.Name = "OpenFileButton";
            this.OpenFileButton.Size = new System.Drawing.Size(38, 34);
            this.OpenFileButton.TabIndex = 8;
            this.OpenFileButton.UseVisualStyleBackColor = true;
            this.OpenFileButton.Click += new System.EventHandler(this.OpenFileButton_Click);
            // 
            // TxtInputFile
            // 
            this.TxtInputFile.Location = new System.Drawing.Point(121, 62);
            this.TxtInputFile.Name = "TxtInputFile";
            this.TxtInputFile.Size = new System.Drawing.Size(618, 20);
            this.TxtInputFile.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Input Directory: ";
            // 
            // TxtNumOfBins
            // 
            this.TxtNumOfBins.Location = new System.Drawing.Point(305, 28);
            this.TxtNumOfBins.Name = "TxtNumOfBins";
            this.TxtNumOfBins.Size = new System.Drawing.Size(52, 20);
            this.TxtNumOfBins.TabIndex = 3;
            this.TxtNumOfBins.Text = "8";
            this.TxtNumOfBins.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.TxtNumOfBins_MaskInputRejected);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(218, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Number of Bins:";
            // 
            // TxtSimilarityThreshold
            // 
            this.TxtSimilarityThreshold.Location = new System.Drawing.Point(121, 29);
            this.TxtSimilarityThreshold.Name = "TxtSimilarityThreshold";
            this.TxtSimilarityThreshold.Size = new System.Drawing.Size(77, 20);
            this.TxtSimilarityThreshold.TabIndex = 1;
            this.TxtSimilarityThreshold.Text = "0.95";
            this.TxtSimilarityThreshold.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.TxtSimilarityThreshold_MaskInputRejected);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Similarity Degree:";
            // 
            // ExitButton
            // 
            this.ExitButton.Location = new System.Drawing.Point(593, 298);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(86, 23);
            this.ExitButton.TabIndex = 6;
            this.ExitButton.Text = "Exit";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // RunButton
            // 
            this.RunButton.Location = new System.Drawing.Point(231, 298);
            this.RunButton.Name = "RunButton";
            this.RunButton.Size = new System.Drawing.Size(89, 23);
            this.RunButton.TabIndex = 5;
            this.RunButton.Text = "Run";
            this.RunButton.UseVisualStyleBackColor = true;
            this.RunButton.Click += new System.EventHandler(this.RunButton_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox3);
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(971, 484);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Result";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.TxtNumOfMatchedDocs);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this.TxtOutputFile);
            this.groupBox3.Controls.Add(this.LblOutputFile);
            this.groupBox3.Controls.Add(this.BtnLoadResult);
            this.groupBox3.Controls.Add(this.dataGridView1);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(16, 154);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(942, 324);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Document Match Output";
            // 
            // TxtNumOfMatchedDocs
            // 
            this.TxtNumOfMatchedDocs.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtNumOfMatchedDocs.Location = new System.Drawing.Point(140, 22);
            this.TxtNumOfMatchedDocs.Name = "TxtNumOfMatchedDocs";
            this.TxtNumOfMatchedDocs.Size = new System.Drawing.Size(94, 20);
            this.TxtNumOfMatchedDocs.TabIndex = 22;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(33, 24);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(84, 13);
            this.label15.TabIndex = 23;
            this.label15.Text = "Matched Pairs:  ";
            // 
            // TxtOutputFile
            // 
            this.TxtOutputFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtOutputFile.Location = new System.Drawing.Point(349, 21);
            this.TxtOutputFile.Name = "TxtOutputFile";
            this.TxtOutputFile.Size = new System.Drawing.Size(442, 20);
            this.TxtOutputFile.TabIndex = 22;
            // 
            // LblOutputFile
            // 
            this.LblOutputFile.AutoSize = true;
            this.LblOutputFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblOutputFile.Location = new System.Drawing.Point(263, 24);
            this.LblOutputFile.Name = "LblOutputFile";
            this.LblOutputFile.Size = new System.Drawing.Size(67, 13);
            this.LblOutputFile.TabIndex = 2;
            this.LblOutputFile.Text = "Output File:  ";
            // 
            // BtnLoadResult
            // 
            this.BtnLoadResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnLoadResult.Location = new System.Drawing.Point(806, 18);
            this.BtnLoadResult.Name = "BtnLoadResult";
            this.BtnLoadResult.Size = new System.Drawing.Size(130, 23);
            this.BtnLoadResult.TabIndex = 1;
            this.BtnLoadResult.Text = "Load Result File";
            this.BtnLoadResult.UseVisualStyleBackColor = true;
            this.BtnLoadResult.Click += new System.EventHandler(this.BtnLoadResult_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView1.Location = new System.Drawing.Point(6, 53);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView1.Size = new System.Drawing.Size(930, 262);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridDblClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.TxtMinDocLen);
            this.groupBox2.Controls.Add(this.label18);
            this.groupBox2.Controls.Add(this.TxtMaxDocLen);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.TxtNumOfTokens);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.TxtNonemptyBuckets);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.TxtInputReadTime);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.TxtTotalRunTime);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.TxtNumOfStrComparison);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.TxtAvgBucketSize);
            this.groupBox2.Controls.Add(this.TxtMaxBucketSize);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.TxtAvgStringLength);
            this.groupBox2.Controls.Add(this.TxtNumOfStrings);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(16, 7);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(942, 141);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Document Match Statistics";
            // 
            // TxtMinDocLen
            // 
            this.TxtMinDocLen.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtMinDocLen.Location = new System.Drawing.Point(796, 53);
            this.TxtMinDocLen.Name = "TxtMinDocLen";
            this.TxtMinDocLen.Size = new System.Drawing.Size(100, 20);
            this.TxtMinDocLen.TabIndex = 27;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(626, 53);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(157, 13);
            this.label18.TabIndex = 26;
            this.label18.Text = "Min Document Size (by tokens):";
            // 
            // TxtMaxDocLen
            // 
            this.TxtMaxDocLen.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtMaxDocLen.Location = new System.Drawing.Point(505, 53);
            this.TxtMaxDocLen.Name = "TxtMaxDocLen";
            this.TxtMaxDocLen.Size = new System.Drawing.Size(100, 20);
            this.TxtMaxDocLen.TabIndex = 25;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(327, 53);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(160, 13);
            this.label17.TabIndex = 24;
            this.label17.Text = "Max Document Size (by tokens):";
            // 
            // TxtNumOfTokens
            // 
            this.TxtNumOfTokens.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtNumOfTokens.Location = new System.Drawing.Point(172, 53);
            this.TxtNumOfTokens.Name = "TxtNumOfTokens";
            this.TxtNumOfTokens.Size = new System.Drawing.Size(107, 20);
            this.TxtNumOfTokens.TabIndex = 23;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(69, 53);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(98, 13);
            this.label16.TabIndex = 22;
            this.label16.Text = "Number of Tokens:";
            this.label16.Click += new System.EventHandler(this.label16_Click);
            // 
            // TxtNonemptyBuckets
            // 
            this.TxtNonemptyBuckets.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtNonemptyBuckets.Location = new System.Drawing.Point(172, 79);
            this.TxtNonemptyBuckets.Name = "TxtNonemptyBuckets";
            this.TxtNonemptyBuckets.Size = new System.Drawing.Size(107, 20);
            this.TxtNonemptyBuckets.TabIndex = 21;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(67, 79);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(100, 13);
            this.label12.TabIndex = 20;
            this.label12.Text = "Nonempty Buckets:";
            // 
            // TxtInputReadTime
            // 
            this.TxtInputReadTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtInputReadTime.Location = new System.Drawing.Point(505, 105);
            this.TxtInputReadTime.Name = "TxtInputReadTime";
            this.TxtInputReadTime.Size = new System.Drawing.Size(100, 20);
            this.TxtInputReadTime.TabIndex = 19;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(396, 105);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(91, 13);
            this.label11.TabIndex = 18;
            this.label11.Text = "Data Import Time:";
            // 
            // TxtTotalRunTime
            // 
            this.TxtTotalRunTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtTotalRunTime.Location = new System.Drawing.Point(172, 105);
            this.TxtTotalRunTime.Name = "TxtTotalRunTime";
            this.TxtTotalRunTime.Size = new System.Drawing.Size(107, 20);
            this.TxtTotalRunTime.TabIndex = 17;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(81, 105);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(86, 13);
            this.label13.TabIndex = 15;
            this.label13.Text = "Total Run Time: ";
            // 
            // TxtNumOfStrComparison
            // 
            this.TxtNumOfStrComparison.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtNumOfStrComparison.Location = new System.Drawing.Point(796, 27);
            this.TxtNumOfStrComparison.Name = "TxtNumOfStrComparison";
            this.TxtNumOfStrComparison.Size = new System.Drawing.Size(100, 20);
            this.TxtNumOfStrComparison.TabIndex = 11;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(666, 27);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(117, 13);
            this.label10.TabIndex = 10;
            this.label10.Text = "Number of Comparison:";
            // 
            // TxtAvgBucketSize
            // 
            this.TxtAvgBucketSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtAvgBucketSize.Location = new System.Drawing.Point(796, 79);
            this.TxtAvgBucketSize.Name = "TxtAvgBucketSize";
            this.TxtAvgBucketSize.Size = new System.Drawing.Size(100, 20);
            this.TxtAvgBucketSize.TabIndex = 9;
            // 
            // TxtMaxBucketSize
            // 
            this.TxtMaxBucketSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtMaxBucketSize.Location = new System.Drawing.Point(505, 79);
            this.TxtMaxBucketSize.Name = "TxtMaxBucketSize";
            this.TxtMaxBucketSize.Size = new System.Drawing.Size(100, 20);
            this.TxtMaxBucketSize.TabIndex = 8;
            this.TxtMaxBucketSize.TextChanged += new System.EventHandler(this.TxtMaxBucketSize_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(673, 79);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(110, 13);
            this.label9.TabIndex = 6;
            this.label9.Text = "Average Bucket Size:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(373, 79);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(114, 13);
            this.label8.TabIndex = 5;
            this.label8.Text = "Maximum Bucket Size:";
            // 
            // TxtAvgStringLength
            // 
            this.TxtAvgStringLength.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtAvgStringLength.Location = new System.Drawing.Point(505, 27);
            this.TxtAvgStringLength.Name = "TxtAvgStringLength";
            this.TxtAvgStringLength.Size = new System.Drawing.Size(100, 20);
            this.TxtAvgStringLength.TabIndex = 3;
            // 
            // TxtNumOfStrings
            // 
            this.TxtNumOfStrings.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtNumOfStrings.Location = new System.Drawing.Point(172, 27);
            this.TxtNumOfStrings.Name = "TxtNumOfStrings";
            this.TxtNumOfStrings.Size = new System.Drawing.Size(107, 20);
            this.TxtNumOfStrings.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(328, 27);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(159, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Avg Document Size (by tokens):";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(51, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(116, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Number of Documents:";
            // 
            // tabClusters
            // 
            this.tabClusters.Controls.Add(this.groupBox5);
            this.tabClusters.Controls.Add(this.groupBox4);
            this.tabClusters.Location = new System.Drawing.Point(4, 22);
            this.tabClusters.Name = "tabClusters";
            this.tabClusters.Padding = new System.Windows.Forms.Padding(3);
            this.tabClusters.Size = new System.Drawing.Size(971, 484);
            this.tabClusters.TabIndex = 2;
            this.tabClusters.Text = "Clusters";
            this.tabClusters.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.button1);
            this.groupBox5.Controls.Add(this.txtClusterFile);
            this.groupBox5.Controls.Add(this.label23);
            this.groupBox5.Controls.Add(this.btnLoadClusters);
            this.groupBox5.Controls.Add(this.ClustersDataGrid);
            this.groupBox5.Location = new System.Drawing.Point(16, 111);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(937, 367);
            this.groupBox5.TabIndex = 4;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Clusters";
            // 
            // txtClusterFile
            // 
            this.txtClusterFile.Location = new System.Drawing.Point(75, 13);
            this.txtClusterFile.Name = "txtClusterFile";
            this.txtClusterFile.Size = new System.Drawing.Size(648, 20);
            this.txtClusterFile.TabIndex = 22;
            this.txtClusterFile.TextChanged += new System.EventHandler(this.txtClusterFile_TextChanged);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(14, 17);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(67, 13);
            this.label23.TabIndex = 2;
            this.label23.Text = "Output File:  ";
            this.label23.Click += new System.EventHandler(this.label23_Click);
            // 
            // btnLoadClusters
            // 
            this.btnLoadClusters.Location = new System.Drawing.Point(729, 11);
            this.btnLoadClusters.Name = "btnLoadClusters";
            this.btnLoadClusters.Size = new System.Drawing.Size(86, 23);
            this.btnLoadClusters.TabIndex = 1;
            this.btnLoadClusters.Text = "Load Clusters";
            this.btnLoadClusters.UseVisualStyleBackColor = true;
            this.btnLoadClusters.Click += new System.EventHandler(this.btnLoadClusters_Click);
            // 
            // ClustersDataGrid
            // 
            this.ClustersDataGrid.AllowUserToAddRows = false;
            this.ClustersDataGrid.AllowUserToDeleteRows = false;
            this.ClustersDataGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.ClustersDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ClustersDataGrid.Location = new System.Drawing.Point(6, 39);
            this.ClustersDataGrid.Name = "ClustersDataGrid";
            this.ClustersDataGrid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ClustersDataGrid.Size = new System.Drawing.Size(925, 322);
            this.ClustersDataGrid.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtClusterType);
            this.groupBox4.Controls.Add(this.label22);
            this.groupBox4.Controls.Add(this.txtMaxClusterSize);
            this.groupBox4.Controls.Add(this.label19);
            this.groupBox4.Controls.Add(this.txtAvgClusterSize);
            this.groupBox4.Controls.Add(this.label25);
            this.groupBox4.Controls.Add(this.txtMinClusterSize);
            this.groupBox4.Controls.Add(this.label27);
            this.groupBox4.Controls.Add(this.txtNumOfStringsForAllClusters);
            this.groupBox4.Controls.Add(this.txtNumOfClusters);
            this.groupBox4.Controls.Add(this.label28);
            this.groupBox4.Controls.Add(this.label29);
            this.groupBox4.Location = new System.Drawing.Point(16, 14);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(937, 82);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Cluster Statistics";
            // 
            // txtClusterType
            // 
            this.txtClusterType.Location = new System.Drawing.Point(678, 13);
            this.txtClusterType.Name = "txtClusterType";
            this.txtClusterType.Size = new System.Drawing.Size(100, 20);
            this.txtClusterType.TabIndex = 23;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(599, 17);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(69, 13);
            this.label22.TabIndex = 22;
            this.label22.Text = "Cluster Type:";
            // 
            // txtMaxClusterSize
            // 
            this.txtMaxClusterSize.Location = new System.Drawing.Point(138, 42);
            this.txtMaxClusterSize.Name = "txtMaxClusterSize";
            this.txtMaxClusterSize.Size = new System.Drawing.Size(100, 20);
            this.txtMaxClusterSize.TabIndex = 21;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(44, 44);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(88, 13);
            this.label19.TabIndex = 20;
            this.label19.Text = "Max Cluster Size:";
            // 
            // txtAvgClusterSize
            // 
            this.txtAvgClusterSize.Location = new System.Drawing.Point(678, 40);
            this.txtAvgClusterSize.Name = "txtAvgClusterSize";
            this.txtAvgClusterSize.Size = new System.Drawing.Size(100, 20);
            this.txtAvgClusterSize.TabIndex = 11;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(562, 42);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(108, 13);
            this.label25.TabIndex = 10;
            this.label25.Text = "Average Cluster Size:";
            // 
            // txtMinClusterSize
            // 
            this.txtMinClusterSize.Location = new System.Drawing.Point(399, 42);
            this.txtMinClusterSize.Name = "txtMinClusterSize";
            this.txtMinClusterSize.Size = new System.Drawing.Size(100, 20);
            this.txtMinClusterSize.TabIndex = 8;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(304, 45);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(85, 13);
            this.label27.TabIndex = 5;
            this.label27.Text = "Min Cluster Size:";
            // 
            // txtNumOfStringsForAllClusters
            // 
            this.txtNumOfStringsForAllClusters.Location = new System.Drawing.Point(399, 13);
            this.txtNumOfStringsForAllClusters.Name = "txtNumOfStringsForAllClusters";
            this.txtNumOfStringsForAllClusters.Size = new System.Drawing.Size(100, 20);
            this.txtNumOfStringsForAllClusters.TabIndex = 3;
            // 
            // txtNumOfClusters
            // 
            this.txtNumOfClusters.Location = new System.Drawing.Point(138, 16);
            this.txtNumOfClusters.Name = "txtNumOfClusters";
            this.txtNumOfClusters.Size = new System.Drawing.Size(100, 20);
            this.txtNumOfClusters.TabIndex = 2;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(296, 17);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(94, 13);
            this.label28.TabIndex = 1;
            this.label28.Text = "Number of Strings:";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(32, 20);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(99, 13);
            this.label29.TabIndex = 0;
            this.label29.Text = "Number of Clusters:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(845, 10);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(86, 23);
            this.button1.TabIndex = 23;
            this.button1.Text = "Export Dedup";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // MainStrMatchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1042, 543);
            this.Controls.Add(this.tabControl1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "MainStrMatchForm";
            this.Text = "DocMatch Prototype";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabClusters.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ClustersDataGrid)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label TxtProgress;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button OpenFileButton;
        private System.Windows.Forms.TextBox TxtInputFile;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.MaskedTextBox TxtNumOfBins;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox TxtSimilarityThreshold;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Button RunButton;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox TxtAvgStringLength;
        private System.Windows.Forms.TextBox TxtNumOfStrings;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox TxtNumOfStrComparison;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox TxtAvgBucketSize;
        private System.Windows.Forms.TextBox TxtMaxBucketSize;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button BtnLoadResult;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox TxtTotalRunTime;
        private System.Windows.Forms.Label LblOutputFile;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox TxtInputReadTime;
        private System.Windows.Forms.TextBox TxtNonemptyBuckets;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox TxtOutputFile;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.Button BtnOutputDir;
        private System.Windows.Forms.TextBox TxtOuptDir;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.FolderBrowserDialog DialogInputDir;
        private System.Windows.Forms.FolderBrowserDialog DialogOutputDir;
        private System.Windows.Forms.TextBox TxtNumOfMatchedDocs;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox TxtMaxDocLen;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox TxtNumOfTokens;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox TxtMinDocLen;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Button BtnMultTest;
        private System.Windows.Forms.MaskedTextBox txtMaxDistance;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RadioButton radioButtonNoClustering;
        private System.Windows.Forms.RadioButton radioButtonCompleteLink;
        private System.Windows.Forms.RadioButton radioButtonSingleLink;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TabPage tabClusters;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox txtClusterFile;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Button btnLoadClusters;
        private System.Windows.Forms.DataGridView ClustersDataGrid;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txtClusterType;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox txtMaxClusterSize;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txtAvgClusterSize;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox txtMinClusterSize;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.TextBox txtNumOfStringsForAllClusters;
        private System.Windows.Forms.TextBox txtNumOfClusters;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Button button1;
    }
}

