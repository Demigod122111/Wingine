namespace Wingine.Editor
{
    partial class ExtendedColorInputField
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Title = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.Value = new Cyotek.Windows.Forms.ColorWheel();
            this.Value2 = new Cyotek.Windows.Forms.ColorEditor();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Title
            // 
            this.Title.Dock = System.Windows.Forms.DockStyle.Top;
            this.Title.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Title.ForeColor = System.Drawing.Color.Beige;
            this.Title.Location = new System.Drawing.Point(0, 0);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(481, 21);
            this.Title.TabIndex = 0;
            this.Title.Text = "[FIELD]";
            this.Title.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 21);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.Value);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.Value2);
            this.splitContainer1.Size = new System.Drawing.Size(481, 119);
            this.splitContainer1.SplitterDistance = 160;
            this.splitContainer1.TabIndex = 1;
            // 
            // Value
            // 
            this.Value.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Value.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Value.Location = new System.Drawing.Point(0, 0);
            this.Value.Name = "Value";
            this.Value.Size = new System.Drawing.Size(160, 119);
            this.Value.TabIndex = 0;
            this.Value.ColorChanged += new System.EventHandler(this.Value_ColorChanged);
            // 
            // Value2
            // 
            this.Value2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Value2.ForeColor = System.Drawing.Color.Beige;
            this.Value2.Location = new System.Drawing.Point(0, 0);
            this.Value2.Name = "Value2";
            this.Value2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.Value2.Size = new System.Drawing.Size(317, 119);
            this.Value2.TabIndex = 2;
            this.Value2.ColorChanged += new System.EventHandler(this.Value2_ColorChanged);
            // 
            // ColorInputField
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.Title);
            this.DoubleBuffered = true;
            this.Name = "ColorInputField";
            this.Size = new System.Drawing.Size(481, 140);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Label Title;
        private System.Windows.Forms.SplitContainer splitContainer1;
        public Cyotek.Windows.Forms.ColorWheel Value;
        public Cyotek.Windows.Forms.ColorEditor Value2;
    }
}
