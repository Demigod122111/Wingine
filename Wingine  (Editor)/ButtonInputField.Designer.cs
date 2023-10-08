namespace Wingine.Editor
{
    partial class ButtonInputField
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
            this.Action = new System.Windows.Forms.Button();
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
            // Action
            // 
            this.Action.AutoEllipsis = true;
            this.Action.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Action.FlatAppearance.BorderSize = 0;
            this.Action.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Action.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Action.ForeColor = System.Drawing.Color.Silver;
            this.Action.Location = new System.Drawing.Point(0, 21);
            this.Action.Name = "Action";
            this.Action.Size = new System.Drawing.Size(325, 28);
            this.Action.TabIndex = 1;
            this.Action.Text = "[Action]";
            this.Action.UseVisualStyleBackColor = false;
            // 
            // ButtonInputField
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.Action);
            this.Controls.Add(this.Title);
            this.DoubleBuffered = true;
            this.Name = "ButtonInputField";
            this.Size = new System.Drawing.Size(325, 49);
            this.ResumeLayout(false);

        }

        #endregion

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ButtonInputField.Title'
        public System.Windows.Forms.Label Title;
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ButtonInputField.Title'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ButtonInputField.Action'
        public System.Windows.Forms.Button Action;
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ButtonInputField.Action'
    }
}
