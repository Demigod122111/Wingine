namespace Wingine.Editor
{
    partial class VectorInputField
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
            this.Value1 = new Wingine.Editor.CustomNumericUpDown();
            this.Value2 = new Wingine.Editor.CustomNumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.Value1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Value2)).BeginInit();
            this.SuspendLayout();
            // 
            // Title
            // 
            this.Title.Dock = System.Windows.Forms.DockStyle.Top;
            this.Title.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Title.ForeColor = System.Drawing.Color.Beige;
            this.Title.Location = new System.Drawing.Point(0, 0);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(326, 21);
            this.Title.TabIndex = 0;
            this.Title.Text = "[FIELD]";
            this.Title.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Value1
            // 
            this.Value1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.Value1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.Value1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Value1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Value1.ForeColor = System.Drawing.Color.Beige;
            this.Value1.Location = new System.Drawing.Point(0, 21);
            this.Value1.Name = "Value1";
            this.Value1.Size = new System.Drawing.Size(132, 20);
            this.Value1.TabIndex = 1;
            // 
            // Value2
            // 
            this.Value2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Value2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.Value2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Value2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Value2.ForeColor = System.Drawing.Color.Beige;
            this.Value2.Location = new System.Drawing.Point(196, 21);
            this.Value2.Name = "Value2";
            this.Value2.Size = new System.Drawing.Size(131, 20);
            this.Value2.TabIndex = 2;
            // 
            // VectorInputField
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.Value2);
            this.Controls.Add(this.Value1);
            this.Controls.Add(this.Title);
            this.DoubleBuffered = true;
            this.Name = "VectorInputField";
            this.Size = new System.Drawing.Size(326, 42);
            ((System.ComponentModel.ISupportInitialize)(this.Value1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Value2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'VectorInputField.Title'
        public System.Windows.Forms.Label Title;
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'VectorInputField.Title'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'VectorInputField.Value1'
        public CustomNumericUpDown Value1;
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'VectorInputField.Value1'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'VectorInputField.Value2'
        public CustomNumericUpDown Value2;
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'VectorInputField.Value2'
    }
}
