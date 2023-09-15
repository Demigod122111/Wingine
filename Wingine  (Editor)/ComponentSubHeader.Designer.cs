namespace Wingine.Editor
{
    partial class ComponentSubHeader
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
            this.SuspendLayout();
            // 
            // Title
            // 
            this.Title.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Title.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Title.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Title.ForeColor = System.Drawing.Color.PaleGoldenrod;
            this.Title.Location = new System.Drawing.Point(0, 0);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(299, 23);
            this.Title.TabIndex = 3;
            this.Title.Text = "[Sub Heading]";
            this.Title.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ComponentSubHeader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.Controls.Add(this.Title);
            this.Name = "ComponentSubHeader";
            this.Size = new System.Drawing.Size(299, 23);
            this.ResumeLayout(false);

        }

        #endregion
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ComponentHeader.X'
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ComponentHeader.X'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ComponentHeader.Title'
        public System.Windows.Forms.Label Title;
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ComponentHeader.Title'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ComponentHeader.CB'
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ComponentHeader.CB'
    }
}
