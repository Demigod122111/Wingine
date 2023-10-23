namespace Wingine.Editor
{
    partial class SceneCameraPositionChanger
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SceneCameraPositionChanger));
            this.Value = new Wingine.Editor.VectorInputField();
            this.set = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Value
            // 
            this.Value.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.Value.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Value.Dock = System.Windows.Forms.DockStyle.Top;
            this.Value.Location = new System.Drawing.Point(0, 0);
            this.Value.Name = "Value";
            this.Value.Size = new System.Drawing.Size(264, 42);
            this.Value.TabIndex = 0;
            // 
            // set
            // 
            this.set.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.set.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.set.Location = new System.Drawing.Point(26, 48);
            this.set.Name = "set";
            this.set.Size = new System.Drawing.Size(75, 23);
            this.set.TabIndex = 1;
            this.set.Text = "Change";
            this.set.UseVisualStyleBackColor = true;
            // 
            // cancel
            // 
            this.cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancel.Location = new System.Drawing.Point(162, 48);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(75, 23);
            this.cancel.TabIndex = 2;
            this.cancel.Text = "Cancel";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // SceneCameraPositionChanger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.ClientSize = new System.Drawing.Size(264, 81);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.set);
            this.Controls.Add(this.Value);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.Beige;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SceneCameraPositionChanger";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SceneCameraPositionChanger";
            this.Load += new System.EventHandler(this.SceneCameraPositionChanger_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public VectorInputField Value;
        private System.Windows.Forms.Button set;
        private System.Windows.Forms.Button cancel;
    }
}