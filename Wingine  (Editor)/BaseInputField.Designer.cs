namespace Wingine.Editor
{
    partial class BaseInputField
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
            this.Value = new System.Windows.Forms.RichTextBox();
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
            this.Value.AcceptsTab = true;
            this.Value.AutoWordSelection = true;
            this.Value.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.Value.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Value.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Value.EnableAutoDragDrop = true;
            this.Value.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Value.ForeColor = System.Drawing.Color.Silver;
            this.Value.Location = new System.Drawing.Point(0, 21);
            this.Value.Multiline = false;
            this.Value.Name = "Value";
            this.Value.Size = new System.Drawing.Size(325, 24);
            this.Value.TabIndex = 1;
            this.Value.Text = "";
            this.Value.TextChanged += new System.EventHandler(this.Value_TextChanged);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // BaseInputField
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.Value);
            this.Controls.Add(this.Title);
            this.DoubleBuffered = true;
            this.Name = "BaseInputField";
            this.Size = new System.Drawing.Size(325, 45);
            this.ResumeLayout(false);

        }

        #endregion

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'BaseInputField.Title'
        public System.Windows.Forms.Label Title;
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'BaseInputField.Title'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'BaseInputField.Value'
        public System.Windows.Forms.RichTextBox Value;
        private System.Windows.Forms.Timer timer1;
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'BaseInputField.Value'
    }
}
