
namespace CacheEmulator
{
    partial class MainForm
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
            System.Windows.Forms.ListViewItem listViewItem5 = new System.Windows.Forms.ListViewItem(new string[] {
            "五个字测试",
            "360/5656",
            "66.3333%",
            "23445",
            "50"}, -1);
            this.setNumComboBox = new System.Windows.Forms.ComboBox();
            this.lineNumComboBox = new System.Windows.Forms.ComboBox();
            this.setNumLabel = new System.Windows.Forms.Label();
            this.lineNumLabel = new System.Windows.Forms.Label();
            this.replacementAlgorithmComboBox = new System.Windows.Forms.ComboBox();
            this.replacementAlgorithmLabel = new System.Windows.Forms.Label();
            this.programLabel = new System.Windows.Forms.Label();
            this.programComboBox = new System.Windows.Forms.ComboBox();
            this.confirmButton = new System.Windows.Forms.Button();
            this.reselectButton = new System.Windows.Forms.Button();
            this.continuousButton = new System.Windows.Forms.Button();
            this.pauseButton = new System.Windows.Forms.Button();
            this.resetButton = new System.Windows.Forms.Button();
            this.stepButton = new System.Windows.Forms.Button();
            this.intervalNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.intervalLabel = new System.Windows.Forms.Label();
            this.goToEndButton = new System.Windows.Forms.Button();
            this.statisticsButton = new System.Windows.Forms.Button();
            this.statisticListView = new System.Windows.Forms.ListView();
            this.programColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.missColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.missRateColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cyclesColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.overheadColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.helpButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.intervalNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // setNumComboBox
            // 
            this.setNumComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.setNumComboBox.FormattingEnabled = true;
            this.setNumComboBox.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8"});
            this.setNumComboBox.Location = new System.Drawing.Point(175, 45);
            this.setNumComboBox.Name = "setNumComboBox";
            this.setNumComboBox.Size = new System.Drawing.Size(121, 23);
            this.setNumComboBox.TabIndex = 0;
            this.setNumComboBox.SelectedIndexChanged += new System.EventHandler(this.setNumComboBox_SelectedIndexChanged);
            // 
            // lineNumComboBox
            // 
            this.lineNumComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.lineNumComboBox.FormattingEnabled = true;
            this.lineNumComboBox.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.lineNumComboBox.Location = new System.Drawing.Point(375, 45);
            this.lineNumComboBox.Name = "lineNumComboBox";
            this.lineNumComboBox.Size = new System.Drawing.Size(121, 23);
            this.lineNumComboBox.TabIndex = 1;
            this.lineNumComboBox.SelectedIndexChanged += new System.EventHandler(this.lineNumComboBox_SelectedIndexChanged);
            // 
            // setNumLabel
            // 
            this.setNumLabel.AutoSize = true;
            this.setNumLabel.Location = new System.Drawing.Point(117, 48);
            this.setNumLabel.Name = "setNumLabel";
            this.setNumLabel.Size = new System.Drawing.Size(52, 15);
            this.setNumLabel.TabIndex = 2;
            this.setNumLabel.Text = "组数量";
            // 
            // lineNumLabel
            // 
            this.lineNumLabel.AutoSize = true;
            this.lineNumLabel.Location = new System.Drawing.Point(302, 48);
            this.lineNumLabel.Name = "lineNumLabel";
            this.lineNumLabel.Size = new System.Drawing.Size(67, 15);
            this.lineNumLabel.TabIndex = 3;
            this.lineNumLabel.Text = "组相联度";
            // 
            // replacementAlgorithmComboBox
            // 
            this.replacementAlgorithmComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.replacementAlgorithmComboBox.FormattingEnabled = true;
            this.replacementAlgorithmComboBox.Items.AddRange(new object[] {
            "FIFO",
            "LRU"});
            this.replacementAlgorithmComboBox.Location = new System.Drawing.Point(575, 45);
            this.replacementAlgorithmComboBox.Name = "replacementAlgorithmComboBox";
            this.replacementAlgorithmComboBox.Size = new System.Drawing.Size(121, 23);
            this.replacementAlgorithmComboBox.TabIndex = 4;
            this.replacementAlgorithmComboBox.SelectedIndexChanged += new System.EventHandler(this.replacementAlgorithmComboBox_SelectedIndexChanged);
            // 
            // replacementAlgorithmLabel
            // 
            this.replacementAlgorithmLabel.AutoSize = true;
            this.replacementAlgorithmLabel.Location = new System.Drawing.Point(502, 48);
            this.replacementAlgorithmLabel.Name = "replacementAlgorithmLabel";
            this.replacementAlgorithmLabel.Size = new System.Drawing.Size(67, 15);
            this.replacementAlgorithmLabel.TabIndex = 5;
            this.replacementAlgorithmLabel.Text = "替换算法";
            // 
            // programLabel
            // 
            this.programLabel.AutoSize = true;
            this.programLabel.Location = new System.Drawing.Point(702, 48);
            this.programLabel.Name = "programLabel";
            this.programLabel.Size = new System.Drawing.Size(37, 15);
            this.programLabel.TabIndex = 6;
            this.programLabel.Text = "程序";
            // 
            // programComboBox
            // 
            this.programComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.programComboBox.FormattingEnabled = true;
            this.programComboBox.Items.AddRange(new object[] {
            "矩阵乘法",
            "矩阵乘法改",
            "冒泡排序",
            "选择排序",
            "插入排序",
            "希尔排序",
            "快速排序"});
            this.programComboBox.Location = new System.Drawing.Point(745, 45);
            this.programComboBox.Name = "programComboBox";
            this.programComboBox.Size = new System.Drawing.Size(121, 23);
            this.programComboBox.TabIndex = 7;
            // 
            // confirmButton
            // 
            this.confirmButton.Location = new System.Drawing.Point(968, 44);
            this.confirmButton.Name = "confirmButton";
            this.confirmButton.Size = new System.Drawing.Size(75, 23);
            this.confirmButton.TabIndex = 8;
            this.confirmButton.Text = "确认选择";
            this.confirmButton.UseVisualStyleBackColor = true;
            this.confirmButton.Click += new System.EventHandler(this.confirmButton_Click);
            // 
            // reselectButton
            // 
            this.reselectButton.Enabled = false;
            this.reselectButton.Location = new System.Drawing.Point(1065, 44);
            this.reselectButton.Name = "reselectButton";
            this.reselectButton.Size = new System.Drawing.Size(75, 23);
            this.reselectButton.TabIndex = 9;
            this.reselectButton.Text = "重新选择";
            this.reselectButton.UseVisualStyleBackColor = true;
            this.reselectButton.Click += new System.EventHandler(this.reselectButton_Click);
            // 
            // continuousButton
            // 
            this.continuousButton.Enabled = false;
            this.continuousButton.Location = new System.Drawing.Point(1341, 44);
            this.continuousButton.Name = "continuousButton";
            this.continuousButton.Size = new System.Drawing.Size(75, 23);
            this.continuousButton.TabIndex = 10;
            this.continuousButton.Text = "连续运行";
            this.continuousButton.UseVisualStyleBackColor = true;
            this.continuousButton.Click += new System.EventHandler(this.continuousButton_Click);
            // 
            // pauseButton
            // 
            this.pauseButton.Enabled = false;
            this.pauseButton.Location = new System.Drawing.Point(1446, 44);
            this.pauseButton.Name = "pauseButton";
            this.pauseButton.Size = new System.Drawing.Size(75, 23);
            this.pauseButton.TabIndex = 11;
            this.pauseButton.Text = "暂停";
            this.pauseButton.UseVisualStyleBackColor = true;
            this.pauseButton.Click += new System.EventHandler(this.pauseButton_Click);
            // 
            // resetButton
            // 
            this.resetButton.Enabled = false;
            this.resetButton.Location = new System.Drawing.Point(1657, 44);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(75, 23);
            this.resetButton.TabIndex = 12;
            this.resetButton.Text = "跳到开始";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // stepButton
            // 
            this.stepButton.Enabled = false;
            this.stepButton.Location = new System.Drawing.Point(1235, 45);
            this.stepButton.Name = "stepButton";
            this.stepButton.Size = new System.Drawing.Size(75, 23);
            this.stepButton.TabIndex = 13;
            this.stepButton.Text = "步进";
            this.stepButton.UseVisualStyleBackColor = true;
            this.stepButton.Click += new System.EventHandler(this.stepButton_Click);
            // 
            // intervalNumericUpDown
            // 
            this.intervalNumericUpDown.Location = new System.Drawing.Point(1340, 74);
            this.intervalNumericUpDown.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.intervalNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.intervalNumericUpDown.Name = "intervalNumericUpDown";
            this.intervalNumericUpDown.Size = new System.Drawing.Size(80, 25);
            this.intervalNumericUpDown.TabIndex = 14;
            this.intervalNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.intervalNumericUpDown.ValueChanged += new System.EventHandler(this.intervalNumericUpDown_ValueChanged);
            // 
            // intervalLabel
            // 
            this.intervalLabel.AutoSize = true;
            this.intervalLabel.Location = new System.Drawing.Point(1233, 80);
            this.intervalLabel.Name = "intervalLabel";
            this.intervalLabel.Size = new System.Drawing.Size(99, 15);
            this.intervalLabel.TabIndex = 15;
            this.intervalLabel.Text = "每步间隔(ms)";
            // 
            // goToEndButton
            // 
            this.goToEndButton.Enabled = false;
            this.goToEndButton.Location = new System.Drawing.Point(1553, 44);
            this.goToEndButton.Name = "goToEndButton";
            this.goToEndButton.Size = new System.Drawing.Size(75, 23);
            this.goToEndButton.TabIndex = 16;
            this.goToEndButton.Text = "跳到末尾";
            this.goToEndButton.UseVisualStyleBackColor = true;
            this.goToEndButton.Click += new System.EventHandler(this.goToEndButton_Click);
            // 
            // statisticsButton
            // 
            this.statisticsButton.Location = new System.Drawing.Point(745, 74);
            this.statisticsButton.Name = "statisticsButton";
            this.statisticsButton.Size = new System.Drawing.Size(122, 23);
            this.statisticsButton.TabIndex = 17;
            this.statisticsButton.Text = "统计所有程序";
            this.statisticsButton.UseVisualStyleBackColor = true;
            this.statisticsButton.Click += new System.EventHandler(this.statisticsButton_Click);
            // 
            // statisticListView
            // 
            this.statisticListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.programColumnHeader,
            this.missColumnHeader,
            this.missRateColumnHeader,
            this.cyclesColumnHeader,
            this.overheadColumnHeader});
            this.statisticListView.HideSelection = false;
            this.statisticListView.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem5});
            this.statisticListView.Location = new System.Drawing.Point(581, 103);
            this.statisticListView.Name = "statisticListView";
            this.statisticListView.Size = new System.Drawing.Size(462, 364);
            this.statisticListView.TabIndex = 18;
            this.statisticListView.UseCompatibleStateImageBehavior = false;
            this.statisticListView.View = System.Windows.Forms.View.Details;
            this.statisticListView.Visible = false;
            // 
            // programColumnHeader
            // 
            this.programColumnHeader.Text = "程序";
            this.programColumnHeader.Width = 94;
            // 
            // missColumnHeader
            // 
            this.missColumnHeader.Text = "miss";
            this.missColumnHeader.Width = 97;
            // 
            // missRateColumnHeader
            // 
            this.missRateColumnHeader.Text = "miss rate";
            this.missRateColumnHeader.Width = 84;
            // 
            // cyclesColumnHeader
            // 
            this.cyclesColumnHeader.Text = "访存周期数";
            this.cyclesColumnHeader.Width = 92;
            // 
            // overheadColumnHeader
            // 
            this.overheadColumnHeader.Text = "overhead";
            this.overheadColumnHeader.Width = 82;
            // 
            // helpButton
            // 
            this.helpButton.Location = new System.Drawing.Point(36, 44);
            this.helpButton.Name = "helpButton";
            this.helpButton.Size = new System.Drawing.Size(75, 23);
            this.helpButton.TabIndex = 19;
            this.helpButton.Text = "说明";
            this.helpButton.UseVisualStyleBackColor = true;
            this.helpButton.Click += new System.EventHandler(this.helpButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1902, 1033);
            this.Controls.Add(this.helpButton);
            this.Controls.Add(this.statisticListView);
            this.Controls.Add(this.statisticsButton);
            this.Controls.Add(this.goToEndButton);
            this.Controls.Add(this.intervalLabel);
            this.Controls.Add(this.intervalNumericUpDown);
            this.Controls.Add(this.stepButton);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.pauseButton);
            this.Controls.Add(this.continuousButton);
            this.Controls.Add(this.reselectButton);
            this.Controls.Add(this.confirmButton);
            this.Controls.Add(this.programComboBox);
            this.Controls.Add(this.programLabel);
            this.Controls.Add(this.replacementAlgorithmLabel);
            this.Controls.Add(this.replacementAlgorithmComboBox);
            this.Controls.Add(this.lineNumLabel);
            this.Controls.Add(this.setNumLabel);
            this.Controls.Add(this.lineNumComboBox);
            this.Controls.Add(this.setNumComboBox);
            this.DoubleBuffered = true;
            this.Name = "MainForm";
            this.Text = "Cache模拟器";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.MainForm_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.intervalNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox setNumComboBox;
        private System.Windows.Forms.ComboBox lineNumComboBox;
        private System.Windows.Forms.Label setNumLabel;
        private System.Windows.Forms.Label lineNumLabel;
        private System.Windows.Forms.ComboBox replacementAlgorithmComboBox;
        private System.Windows.Forms.Label replacementAlgorithmLabel;
        private System.Windows.Forms.Label programLabel;
        private System.Windows.Forms.ComboBox programComboBox;
        private System.Windows.Forms.Button confirmButton;
        private System.Windows.Forms.Button reselectButton;
        private System.Windows.Forms.Button continuousButton;
        private System.Windows.Forms.Button pauseButton;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.Button stepButton;
        private System.Windows.Forms.NumericUpDown intervalNumericUpDown;
        private System.Windows.Forms.Label intervalLabel;
        private System.Windows.Forms.Button goToEndButton;
        private System.Windows.Forms.Button statisticsButton;
        private System.Windows.Forms.ListView statisticListView;
        private System.Windows.Forms.ColumnHeader missColumnHeader;
        private System.Windows.Forms.ColumnHeader missRateColumnHeader;
        private System.Windows.Forms.ColumnHeader cyclesColumnHeader;
        private System.Windows.Forms.ColumnHeader overheadColumnHeader;
        private System.Windows.Forms.ColumnHeader programColumnHeader;
        private System.Windows.Forms.Button helpButton;
    }
}