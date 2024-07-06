namespace FunctionSubsitution
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            splitContainer1 = new SplitContainer();
            dataGridView1 = new DataGridView();
            FileLabel = new Label();
            FileSelectBtn = new Button();
            FileNameBox = new TextBox();
            VariableKeyTB = new TextBox();
            ConstantKeyTB = new TextBox();
            VariableDelBtn = new Button();
            VariableAddBtn = new Button();
            ConstantDelBtn = new Button();
            ConstantAddBtn = new Button();
            button1 = new Button();
            NewProfileBtn = new Button();
            VariablesLB = new ListBox();
            FunctionTB = new TextBox();
            FunctionUpdateBtn = new Button();
            ConstantUpdateBtn = new Button();
            ColumnCb = new ComboBox();
            ConstantValueTB = new TextBox();
            ConstantValueLabel = new Label();
            CaculateBtn = new Button();
            result_colTB = new TextBox();
            OutputColumnLabel = new Label();
            VariableValueLabel = new Label();
            VariableLabel = new Label();
            ConstantsLB = new ListBox();
            ConstantsLabel = new Label();
            FunctionPic = new PictureBox();
            FunctionLabel = new Label();
            ProfileLabel = new Label();
            ProfileCb = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)FunctionPic).BeginInit();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(dataGridView1);
            splitContainer1.Panel1.Controls.Add(FileLabel);
            splitContainer1.Panel1.Controls.Add(FileSelectBtn);
            splitContainer1.Panel1.Controls.Add(FileNameBox);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(VariableKeyTB);
            splitContainer1.Panel2.Controls.Add(ConstantKeyTB);
            splitContainer1.Panel2.Controls.Add(VariableDelBtn);
            splitContainer1.Panel2.Controls.Add(VariableAddBtn);
            splitContainer1.Panel2.Controls.Add(ConstantDelBtn);
            splitContainer1.Panel2.Controls.Add(ConstantAddBtn);
            splitContainer1.Panel2.Controls.Add(button1);
            splitContainer1.Panel2.Controls.Add(NewProfileBtn);
            splitContainer1.Panel2.Controls.Add(VariablesLB);
            splitContainer1.Panel2.Controls.Add(FunctionTB);
            splitContainer1.Panel2.Controls.Add(FunctionUpdateBtn);
            splitContainer1.Panel2.Controls.Add(ConstantUpdateBtn);
            splitContainer1.Panel2.Controls.Add(ColumnCb);
            splitContainer1.Panel2.Controls.Add(ConstantValueTB);
            splitContainer1.Panel2.Controls.Add(ConstantValueLabel);
            splitContainer1.Panel2.Controls.Add(CaculateBtn);
            splitContainer1.Panel2.Controls.Add(result_colTB);
            splitContainer1.Panel2.Controls.Add(OutputColumnLabel);
            splitContainer1.Panel2.Controls.Add(VariableValueLabel);
            splitContainer1.Panel2.Controls.Add(VariableLabel);
            splitContainer1.Panel2.Controls.Add(ConstantsLB);
            splitContainer1.Panel2.Controls.Add(ConstantsLabel);
            splitContainer1.Panel2.Controls.Add(FunctionPic);
            splitContainer1.Panel2.Controls.Add(FunctionLabel);
            splitContainer1.Panel2.Controls.Add(ProfileLabel);
            splitContainer1.Panel2.Controls.Add(ProfileCb);
            splitContainer1.Size = new Size(1026, 618);
            splitContainer1.SplitterDistance = 632;
            splitContainer1.TabIndex = 0;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(21, 61);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(585, 541);
            dataGridView1.TabIndex = 2;
            // 
            // FileLabel
            // 
            FileLabel.AutoSize = true;
            FileLabel.Location = new Point(21, 5);
            FileLabel.Name = "FileLabel";
            FileLabel.Size = new Size(25, 15);
            FileLabel.TabIndex = 1;
            FileLabel.Text = "File";
            // 
            // FileSelectBtn
            // 
            FileSelectBtn.Location = new Point(511, 23);
            FileSelectBtn.Name = "FileSelectBtn";
            FileSelectBtn.Size = new Size(95, 23);
            FileSelectBtn.TabIndex = 1;
            FileSelectBtn.Text = "Select";
            FileSelectBtn.UseVisualStyleBackColor = true;
            FileSelectBtn.Click += FileSelectBtn_Click;
            // 
            // FileNameBox
            // 
            FileNameBox.Location = new Point(21, 23);
            FileNameBox.Name = "FileNameBox";
            FileNameBox.ReadOnly = true;
            FileNameBox.Size = new Size(470, 23);
            FileNameBox.TabIndex = 0;
            // 
            // VariableKeyTB
            // 
            VariableKeyTB.Location = new Point(15, 439);
            VariableKeyTB.Name = "VariableKeyTB";
            VariableKeyTB.Size = new Size(166, 23);
            VariableKeyTB.TabIndex = 27;
            // 
            // ConstantKeyTB
            // 
            ConstantKeyTB.Location = new Point(13, 264);
            ConstantKeyTB.Name = "ConstantKeyTB";
            ConstantKeyTB.Size = new Size(169, 23);
            ConstantKeyTB.TabIndex = 26;
            // 
            // VariableDelBtn
            // 
            VariableDelBtn.Location = new Point(107, 467);
            VariableDelBtn.Name = "VariableDelBtn";
            VariableDelBtn.Size = new Size(75, 23);
            VariableDelBtn.TabIndex = 25;
            VariableDelBtn.Text = "Delete";
            VariableDelBtn.UseVisualStyleBackColor = true;
            VariableDelBtn.Click += VariableDelBtn_Click;
            // 
            // VariableAddBtn
            // 
            VariableAddBtn.Location = new Point(15, 467);
            VariableAddBtn.Name = "VariableAddBtn";
            VariableAddBtn.Size = new Size(75, 23);
            VariableAddBtn.TabIndex = 24;
            VariableAddBtn.Text = "Add";
            VariableAddBtn.UseVisualStyleBackColor = true;
            VariableAddBtn.Click += VariableAddBtn_Click;
            // 
            // ConstantDelBtn
            // 
            ConstantDelBtn.Location = new Point(107, 292);
            ConstantDelBtn.Name = "ConstantDelBtn";
            ConstantDelBtn.Size = new Size(75, 23);
            ConstantDelBtn.TabIndex = 23;
            ConstantDelBtn.Text = "Delete";
            ConstantDelBtn.UseVisualStyleBackColor = true;
            ConstantDelBtn.Click += ConstantDelBtn_Click;
            // 
            // ConstantAddBtn
            // 
            ConstantAddBtn.Location = new Point(13, 292);
            ConstantAddBtn.Name = "ConstantAddBtn";
            ConstantAddBtn.Size = new Size(75, 23);
            ConstantAddBtn.TabIndex = 22;
            ConstantAddBtn.Text = "Add";
            ConstantAddBtn.UseVisualStyleBackColor = true;
            ConstantAddBtn.Click += ConstantAddBtn_Click;
            // 
            // button1
            // 
            button1.Location = new Point(834, 382);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 21;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            // 
            // NewProfileBtn
            // 
            NewProfileBtn.Location = new Point(300, 11);
            NewProfileBtn.Name = "NewProfileBtn";
            NewProfileBtn.Size = new Size(78, 23);
            NewProfileBtn.TabIndex = 20;
            NewProfileBtn.Text = "New Profile";
            NewProfileBtn.UseVisualStyleBackColor = true;
            NewProfileBtn.Click += NewProfileBtn_Click;
            // 
            // VariablesLB
            // 
            VariablesLB.FormattingEnabled = true;
            VariablesLB.ItemHeight = 15;
            VariablesLB.Location = new Point(15, 355);
            VariablesLB.Name = "VariablesLB";
            VariablesLB.Size = new Size(166, 79);
            VariablesLB.TabIndex = 19;
            VariablesLB.SelectedIndexChanged += VariablesLB_SelectedIndexChanged;
            // 
            // FunctionTB
            // 
            FunctionTB.Location = new Point(13, 114);
            FunctionTB.Name = "FunctionTB";
            FunctionTB.Size = new Size(270, 23);
            FunctionTB.TabIndex = 18;
            // 
            // FunctionUpdateBtn
            // 
            FunctionUpdateBtn.Location = new Point(301, 114);
            FunctionUpdateBtn.Name = "FunctionUpdateBtn";
            FunctionUpdateBtn.Size = new Size(77, 23);
            FunctionUpdateBtn.TabIndex = 17;
            FunctionUpdateBtn.Text = "Update";
            FunctionUpdateBtn.UseVisualStyleBackColor = true;
            FunctionUpdateBtn.Click += FunctionUpdateBtn_Click;
            // 
            // ConstantUpdateBtn
            // 
            ConstantUpdateBtn.Location = new Point(222, 250);
            ConstantUpdateBtn.Name = "ConstantUpdateBtn";
            ConstantUpdateBtn.Size = new Size(143, 23);
            ConstantUpdateBtn.TabIndex = 16;
            ConstantUpdateBtn.Text = "Update";
            ConstantUpdateBtn.UseVisualStyleBackColor = true;
            ConstantUpdateBtn.Click += ConstantUpdateBtn_Click;
            // 
            // ColumnCb
            // 
            ColumnCb.DropDownStyle = ComboBoxStyle.DropDownList;
            ColumnCb.FormattingEnabled = true;
            ColumnCb.Location = new Point(222, 396);
            ColumnCb.Name = "ColumnCb";
            ColumnCb.Size = new Size(143, 23);
            ColumnCb.TabIndex = 15;
            ColumnCb.SelectedIndexChanged += ColumnCb_SelectedIndexChanged;
            // 
            // ConstantValueTB
            // 
            ConstantValueTB.Location = new Point(222, 215);
            ConstantValueTB.Name = "ConstantValueTB";
            ConstantValueTB.Size = new Size(143, 23);
            ConstantValueTB.TabIndex = 14;
            // 
            // ConstantValueLabel
            // 
            ConstantValueLabel.AutoSize = true;
            ConstantValueLabel.Location = new Point(222, 197);
            ConstantValueLabel.Name = "ConstantValueLabel";
            ConstantValueLabel.Size = new Size(89, 15);
            ConstantValueLabel.TabIndex = 13;
            ConstantValueLabel.Text = "Constant Value";
            // 
            // CaculateBtn
            // 
            CaculateBtn.Location = new Point(13, 567);
            CaculateBtn.Name = "CaculateBtn";
            CaculateBtn.Size = new Size(365, 35);
            CaculateBtn.TabIndex = 12;
            CaculateBtn.Text = "Caculate and Save";
            CaculateBtn.UseVisualStyleBackColor = true;
            CaculateBtn.Click += CaculateBtn_Click;
            // 
            // result_colTB
            // 
            result_colTB.Location = new Point(15, 535);
            result_colTB.Name = "result_colTB";
            result_colTB.Size = new Size(363, 23);
            result_colTB.TabIndex = 11;
            result_colTB.Text = "result";
            // 
            // OutputColumnLabel
            // 
            OutputColumnLabel.AutoSize = true;
            OutputColumnLabel.Location = new Point(13, 512);
            OutputColumnLabel.Name = "OutputColumnLabel";
            OutputColumnLabel.Size = new Size(92, 15);
            OutputColumnLabel.TabIndex = 10;
            OutputColumnLabel.Text = "Output Column";
            // 
            // VariableValueLabel
            // 
            VariableValueLabel.AutoSize = true;
            VariableValueLabel.Location = new Point(222, 378);
            VariableValueLabel.Name = "VariableValueLabel";
            VariableValueLabel.Size = new Size(99, 15);
            VariableValueLabel.TabIndex = 7;
            VariableValueLabel.Text = "Selected Column";
            // 
            // VariableLabel
            // 
            VariableLabel.AutoSize = true;
            VariableLabel.Location = new Point(13, 337);
            VariableLabel.Name = "VariableLabel";
            VariableLabel.Size = new Size(55, 15);
            VariableLabel.TabIndex = 6;
            VariableLabel.Text = "Variables";
            // 
            // ConstantsLB
            // 
            ConstantsLB.FormattingEnabled = true;
            ConstantsLB.ItemHeight = 15;
            ConstantsLB.Location = new Point(13, 180);
            ConstantsLB.Name = "ConstantsLB";
            ConstantsLB.Size = new Size(169, 79);
            ConstantsLB.TabIndex = 5;
            ConstantsLB.SelectedIndexChanged += ConstantsLB_SelectedIndexChanged;
            // 
            // ConstantsLabel
            // 
            ConstantsLabel.AutoSize = true;
            ConstantsLabel.Location = new Point(13, 161);
            ConstantsLabel.Name = "ConstantsLabel";
            ConstantsLabel.Size = new Size(60, 15);
            ConstantsLabel.TabIndex = 4;
            ConstantsLabel.Text = "Constants";
            // 
            // FunctionPic
            // 
            FunctionPic.Location = new Point(13, 64);
            FunctionPic.Name = "FunctionPic";
            FunctionPic.Size = new Size(365, 42);
            FunctionPic.TabIndex = 3;
            FunctionPic.TabStop = false;
            // 
            // FunctionLabel
            // 
            FunctionLabel.AutoSize = true;
            FunctionLabel.Location = new Point(13, 44);
            FunctionLabel.Name = "FunctionLabel";
            FunctionLabel.Size = new Size(54, 15);
            FunctionLabel.TabIndex = 2;
            FunctionLabel.Text = "Function";
            // 
            // ProfileLabel
            // 
            ProfileLabel.AutoSize = true;
            ProfileLabel.Location = new Point(13, 16);
            ProfileLabel.Name = "ProfileLabel";
            ProfileLabel.Size = new Size(41, 15);
            ProfileLabel.TabIndex = 1;
            ProfileLabel.Text = "Profile";
            // 
            // ProfileCb
            // 
            ProfileCb.DropDownStyle = ComboBoxStyle.DropDownList;
            ProfileCb.FormattingEnabled = true;
            ProfileCb.Location = new Point(71, 13);
            ProfileCb.Name = "ProfileCb";
            ProfileCb.Size = new Size(212, 23);
            ProfileCb.TabIndex = 0;
            ProfileCb.SelectedIndexChanged += ProfileCb_SelectedIndexChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1026, 618);
            Controls.Add(splitContainer1);
            Name = "Form1";
            Text = "Function Substitution";
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)FunctionPic).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private Button FileSelectBtn;
        private TextBox FileNameBox;
        private Label FileLabel;
        private ComboBox ProfileCb;
        private Label FunctionLabel;
        private Label ProfileLabel;
        private DataGridView dataGridView1;
        private ListBox ConstantsLB;
        private Label ConstantsLabel;
        private PictureBox FunctionPic;
        private Label OutputColumnLabel;
        private Label VariableValueLabel;
        private Label VariableLabel;
        private Button CaculateBtn;
        private TextBox result_colTB;
        private Label ConstantValueLabel;
        private TextBox ConstantValueTB;
        private ComboBox ColumnCb;
        private TextBox FunctionTB;
        private Button FunctionUpdateBtn;
        private Button ConstantUpdateBtn;
        private ListBox VariablesLB;
        private Button NewProfileBtn;
        private Button ConstantDelBtn;
        private Button ConstantAddBtn;
        private Button button1;
        private Button VariableDelBtn;
        private Button VariableAddBtn;
        private TextBox VariableKeyTB;
        private TextBox ConstantKeyTB;
    }
}