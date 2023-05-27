namespace Wingine.Editor
{
    partial class NumberInputField
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
            this.Value = new Wingine.Editor.CustomNumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.Value)).BeginInit();
            this.SuspendLayout();
            // 
            // Title
            // 
            this.Title.Dock = System.Windows.Forms.DockStyle.Top;
            this.Title.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Title.ForeColor = System.Drawing.Color.Beige;
            this.Title.Location = new System.Drawing.Point(0, 0);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(325, 21);
            this.Title.TabIndex = 0;
            this.Title.Text = "[FIELD]";
            this.Title.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Value
            // 
            this.Value.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.Value.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Value.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Value.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Value.ForeColor = System.Drawing.Color.Beige;
            this.Value.Location = new System.Drawing.Point(0, 21);
            this.Value.Name = "Value";
            this.Value.Size = new System.Drawing.Size(325, 20);
            this.Value.TabIndex = 1;
            // 
            // NumberInputField
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.Value);
            this.Controls.Add(this.Title);
            this.DoubleBuffered = true;
            this.Name = "NumberInputField";
            this.Size = new System.Drawing.Size(325, 45);
            ((System.ComponentModel.ISupportInitialize)(this.Value)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Label Title;
        public CustomNumericUpDown Value;
    }
}
