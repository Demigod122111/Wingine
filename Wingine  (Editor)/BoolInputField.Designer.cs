namespace Wingine.Editor
{
    partial class BoolInputField
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
            this.components = new System.ComponentModel.Container();
            this.Title = new System.Windows.Forms.Label();
            this.Value = new System.Windows.Forms.CheckBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
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
            this.Value.AutoSize = true;
            this.Value.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Value.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Value.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.Value.FlatAppearance.BorderSize = 2;
            this.Value.Location = new System.Drawing.Point(0, 21);
            this.Value.Name = "Value";
            this.Value.Size = new System.Drawing.Size(325, 24);
            this.Value.TabIndex = 1;
            this.Value.UseVisualStyleBackColor = true;
            this.Value.CheckedChanged += new System.EventHandler(this.Value_CheckedChanged);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // BoolInputField
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.Value);
            this.Controls.Add(this.Title);
            this.DoubleBuffered = true;
            this.Name = "BoolInputField";
            this.Size = new System.Drawing.Size(325, 45);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'BoolInputField.Title'
        public System.Windows.Forms.Label Title;
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'BoolInputField.Title'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'BoolInputField.Value'
        public System.Windows.Forms.CheckBox Value;
        private System.Windows.Forms.Timer timer1;
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'BoolInputField.Value'
    }
}
