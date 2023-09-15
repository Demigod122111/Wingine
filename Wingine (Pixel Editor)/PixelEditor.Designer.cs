namespace Wingine.PixelEditor
{
    partial class PixelEditor
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PixelEditor));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ComboBox_Tool = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ColorGrid_BG = new Cyotek.Windows.Forms.ColorGrid();
            this.ColorEditor_Pixel = new Cyotek.Windows.Forms.ColorEditor();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.panel2 = new System.Windows.Forms.Panel();
            this.NumericUpDown_Resolution = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.ColorWheel_Grid = new Cyotek.Windows.Forms.ColorWheel();
            this.CheckBox_ShowGrid = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.RichTextBox_PixelData = new System.Windows.Forms.RichTextBox();
            this.ComboBox_FillType = new System.Windows.Forms.ComboBox();
            this.ComboBox_PixelType = new System.Windows.Forms.ComboBox();
            this.Canvas = new System.Windows.Forms.PictureBox();
            this.Render = new System.Windows.Forms.Timer(this.components);
            this.NumericUpDown_VY = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.NumericUpDown_VX = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown_Resolution)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Canvas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown_VY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown_VX)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(800, 450);
            this.splitContainer1.SplitterDistance = 266;
            this.splitContainer1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.panel1.Controls.Add(this.ComboBox_Tool);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.ColorGrid_BG);
            this.panel1.Controls.Add(this.ColorEditor_Pixel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.ForeColor = System.Drawing.Color.Silver;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(266, 450);
            this.panel1.TabIndex = 0;
            // 
            // ComboBox_Tool
            // 
            this.ComboBox_Tool.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ComboBox_Tool.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.ComboBox_Tool.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBox_Tool.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ComboBox_Tool.ForeColor = System.Drawing.Color.Silver;
            this.ComboBox_Tool.FormattingEnabled = true;
            this.ComboBox_Tool.Items.AddRange(new object[] {
            "Pencil",
            "Eraser"});
            this.ComboBox_Tool.Location = new System.Drawing.Point(6, 230);
            this.ComboBox_Tool.Name = "ComboBox_Tool";
            this.ComboBox_Tool.Size = new System.Drawing.Size(244, 21);
            this.ComboBox_Tool.TabIndex = 11;
            this.ComboBox_Tool.SelectedIndexChanged += new System.EventHandler(this.ComboBox_Tool_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 204);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(260, 23);
            this.label2.TabIndex = 8;
            this.label2.Text = "Pixel Settings";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(266, 23);
            this.label1.TabIndex = 4;
            this.label1.Text = "Canvas Background";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ColorGrid_BG
            // 
            this.ColorGrid_BG.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ColorGrid_BG.CellBorderStyle = Cyotek.Windows.Forms.ColorCellBorderStyle.None;
            this.ColorGrid_BG.Location = new System.Drawing.Point(3, 26);
            this.ColorGrid_BG.Name = "ColorGrid_BG";
            this.ColorGrid_BG.Size = new System.Drawing.Size(247, 165);
            this.ColorGrid_BG.TabIndex = 5;
            // 
            // ColorEditor_Pixel
            // 
            this.ColorEditor_Pixel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ColorEditor_Pixel.Color = System.Drawing.Color.DimGray;
            this.ColorEditor_Pixel.Location = new System.Drawing.Point(3, 257);
            this.ColorEditor_Pixel.Name = "ColorEditor_Pixel";
            this.ColorEditor_Pixel.ShowColorSpaceLabels = false;
            this.ColorEditor_Pixel.Size = new System.Drawing.Size(247, 190);
            this.ColorEditor_Pixel.TabIndex = 7;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.panel2);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.Canvas);
            this.splitContainer2.Size = new System.Drawing.Size(530, 450);
            this.splitContainer2.SplitterDistance = 193;
            this.splitContainer2.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.NumericUpDown_VX);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.NumericUpDown_VY);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.NumericUpDown_Resolution);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.button4);
            this.panel2.Controls.Add(this.button3);
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.ColorWheel_Grid);
            this.panel2.Controls.Add(this.CheckBox_ShowGrid);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.RichTextBox_PixelData);
            this.panel2.Controls.Add(this.ComboBox_FillType);
            this.panel2.Controls.Add(this.ComboBox_PixelType);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(530, 193);
            this.panel2.TabIndex = 0;
            // 
            // NumericUpDown_Resolution
            // 
            this.NumericUpDown_Resolution.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.NumericUpDown_Resolution.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.NumericUpDown_Resolution.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.NumericUpDown_Resolution.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NumericUpDown_Resolution.ForeColor = System.Drawing.Color.Silver;
            this.NumericUpDown_Resolution.Location = new System.Drawing.Point(173, 136);
            this.NumericUpDown_Resolution.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.NumericUpDown_Resolution.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumericUpDown_Resolution.Name = "NumericUpDown_Resolution";
            this.NumericUpDown_Resolution.Size = new System.Drawing.Size(74, 16);
            this.NumericUpDown_Resolution.TabIndex = 21;
            this.NumericUpDown_Resolution.ThousandsSeparator = true;
            this.NumericUpDown_Resolution.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumericUpDown_Resolution.ValueChanged += new System.EventHandler(this.NumericUpDown_Resolution_ValueChanged);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(170, 122);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 15);
            this.label3.TabIndex = 20;
            this.label3.Text = "Resolution";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // button4
            // 
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(5, 84);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(214, 23);
            this.button4.TabIndex = 19;
            this.button4.Text = "Load from PEG";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(115, 55);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(104, 23);
            this.button3.TabIndex = 18;
            this.button3.Text = "Save as PEG";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(5, 55);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(104, 23);
            this.button2.TabIndex = 17;
            this.button2.Text = "Save as PNG";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // ColorWheel_Grid
            // 
            this.ColorWheel_Grid.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ColorWheel_Grid.Location = new System.Drawing.Point(94, 112);
            this.ColorWheel_Grid.Name = "ColorWheel_Grid";
            this.ColorWheel_Grid.Size = new System.Drawing.Size(49, 44);
            this.ColorWheel_Grid.TabIndex = 16;
            // 
            // CheckBox_ShowGrid
            // 
            this.CheckBox_ShowGrid.AutoSize = true;
            this.CheckBox_ShowGrid.Checked = true;
            this.CheckBox_ShowGrid.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CheckBox_ShowGrid.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CheckBox_ShowGrid.Location = new System.Drawing.Point(4, 136);
            this.CheckBox_ShowGrid.Name = "CheckBox_ShowGrid";
            this.CheckBox_ShowGrid.Size = new System.Drawing.Size(84, 17);
            this.CheckBox_ShowGrid.TabIndex = 15;
            this.CheckBox_ShowGrid.Text = "Show Grid";
            this.CheckBox_ShowGrid.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(3, 26);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(244, 23);
            this.button1.TabIndex = 14;
            this.button1.Text = "New Canvas";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // RichTextBox_PixelData
            // 
            this.RichTextBox_PixelData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.RichTextBox_PixelData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RichTextBox_PixelData.Dock = System.Windows.Forms.DockStyle.Right;
            this.RichTextBox_PixelData.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RichTextBox_PixelData.ForeColor = System.Drawing.Color.Silver;
            this.RichTextBox_PixelData.Location = new System.Drawing.Point(253, 0);
            this.RichTextBox_PixelData.Name = "RichTextBox_PixelData";
            this.RichTextBox_PixelData.Size = new System.Drawing.Size(277, 193);
            this.RichTextBox_PixelData.TabIndex = 13;
            this.RichTextBox_PixelData.Text = "";
            this.RichTextBox_PixelData.TextChanged += new System.EventHandler(this.RichTextBox_PixelData_TextChanged);
            // 
            // ComboBox_FillType
            // 
            this.ComboBox_FillType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.ComboBox_FillType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBox_FillType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ComboBox_FillType.ForeColor = System.Drawing.Color.Silver;
            this.ComboBox_FillType.FormattingEnabled = true;
            this.ComboBox_FillType.Items.AddRange(new object[] {
            "Fill",
            "No Fill"});
            this.ComboBox_FillType.Location = new System.Drawing.Point(126, 2);
            this.ComboBox_FillType.Name = "ComboBox_FillType";
            this.ComboBox_FillType.Size = new System.Drawing.Size(121, 21);
            this.ComboBox_FillType.TabIndex = 12;
            // 
            // ComboBox_PixelType
            // 
            this.ComboBox_PixelType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.ComboBox_PixelType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBox_PixelType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ComboBox_PixelType.ForeColor = System.Drawing.Color.Silver;
            this.ComboBox_PixelType.FormattingEnabled = true;
            this.ComboBox_PixelType.Items.AddRange(new object[] {
            "Rectangle",
            "Ellipsis"});
            this.ComboBox_PixelType.Location = new System.Drawing.Point(3, 2);
            this.ComboBox_PixelType.Name = "ComboBox_PixelType";
            this.ComboBox_PixelType.Size = new System.Drawing.Size(121, 21);
            this.ComboBox_PixelType.TabIndex = 11;
            // 
            // Canvas
            // 
            this.Canvas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Canvas.Location = new System.Drawing.Point(0, 0);
            this.Canvas.Name = "Canvas";
            this.Canvas.Size = new System.Drawing.Size(530, 253);
            this.Canvas.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Canvas.TabIndex = 1;
            this.Canvas.TabStop = false;
            this.Canvas.Click += new System.EventHandler(this.Canvas_Click);
            // 
            // Render
            // 
            this.Render.Enabled = true;
            this.Render.Tick += new System.EventHandler(this.Render_Tick);
            // 
            // NumericUpDown_VY
            // 
            this.NumericUpDown_VY.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.NumericUpDown_VY.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.NumericUpDown_VY.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.NumericUpDown_VY.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NumericUpDown_VY.ForeColor = System.Drawing.Color.Silver;
            this.NumericUpDown_VY.Location = new System.Drawing.Point(202, 169);
            this.NumericUpDown_VY.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.NumericUpDown_VY.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.NumericUpDown_VY.Name = "NumericUpDown_VY";
            this.NumericUpDown_VY.Size = new System.Drawing.Size(45, 16);
            this.NumericUpDown_VY.TabIndex = 23;
            this.NumericUpDown_VY.ThousandsSeparator = true;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(199, 155);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 15);
            this.label4.TabIndex = 22;
            this.label4.Text = "View Y";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // NumericUpDown_VX
            // 
            this.NumericUpDown_VX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.NumericUpDown_VX.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.NumericUpDown_VX.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.NumericUpDown_VX.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NumericUpDown_VX.ForeColor = System.Drawing.Color.Silver;
            this.NumericUpDown_VX.Location = new System.Drawing.Point(148, 169);
            this.NumericUpDown_VX.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.NumericUpDown_VX.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.NumericUpDown_VX.Name = "NumericUpDown_VX";
            this.NumericUpDown_VX.Size = new System.Drawing.Size(45, 16);
            this.NumericUpDown_VX.TabIndex = 25;
            this.NumericUpDown_VX.ThousandsSeparator = true;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(145, 155);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 15);
            this.label5.TabIndex = 24;
            this.label5.Text = "View X";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // PixelEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.splitContainer1);
            this.ForeColor = System.Drawing.Color.Silver;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PixelEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Wingine Pixel Editor";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown_Resolution)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Canvas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown_VY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown_VX)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Cyotek.Windows.Forms.ColorGrid ColorGrid_BG;
        private Cyotek.Windows.Forms.ColorEditor ColorEditor_Pixel;
        private System.Windows.Forms.Timer Render;
        private System.Windows.Forms.ComboBox ComboBox_Tool;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox ComboBox_FillType;
        private System.Windows.Forms.ComboBox ComboBox_PixelType;
        private System.Windows.Forms.PictureBox Canvas;
        private System.Windows.Forms.RichTextBox RichTextBox_PixelData;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox CheckBox_ShowGrid;
        private Cyotek.Windows.Forms.ColorWheel ColorWheel_Grid;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown NumericUpDown_Resolution;
        private System.Windows.Forms.NumericUpDown NumericUpDown_VX;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown NumericUpDown_VY;
        private System.Windows.Forms.Label label4;
    }
}

