namespace Wingine.Editor
{
    partial class EnumInputField
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
            this.Value = new System.Windows.Forms.ComboBox();
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
            this.Value.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.Value.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Value.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Value.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Value.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.Value.ForeColor = System.Drawing.Color.Silver;
            this.Value.FormattingEnabled = true;
            this.Value.Location = new System.Drawing.Point(0, 21);
            this.Value.Name = "Value";
            this.Value.Size = new System.Drawing.Size(325, 26);
            this.Value.TabIndex = 1;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // EnumInputField
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.Value);
            this.Controls.Add(this.Title);
            this.DoubleBuffered = true;
            this.Name = "EnumInputField";
            this.Size = new System.Drawing.Size(325, 45);
            this.ResumeLayout(false);

        }

        #endregion

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'BaseInputField.Title'
        public System.Windows.Forms.Label Title;
        public System.Windows.Forms.ComboBox Value;
        private System.Windows.Forms.Timer timer1;
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'BaseInputField.Title'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'BaseInputField.Value'
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'BaseInputField.Value'
    }
}
