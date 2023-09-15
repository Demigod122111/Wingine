namespace Wingine.Editor
{
    partial class ComponentHeader
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
            this.X = new System.Windows.Forms.Button();
            this.CB = new System.Windows.Forms.CheckBox();
            this.Title = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // X
            // 
            this.X.Dock = System.Windows.Forms.DockStyle.Right;
            this.X.FlatAppearance.BorderColor = System.Drawing.Color.Crimson;
            this.X.FlatAppearance.BorderSize = 0;
            this.X.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.X.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.X.ForeColor = System.Drawing.Color.Red;
            this.X.Location = new System.Drawing.Point(266, 0);
            this.X.Name = "X";
            this.X.Size = new System.Drawing.Size(33, 23);
            this.X.TabIndex = 0;
            this.X.Text = "X";
            this.X.UseVisualStyleBackColor = true;
            // 
            // CB
            // 
            this.CB.AutoSize = true;
            this.CB.Dock = System.Windows.Forms.DockStyle.Left;
            this.CB.Location = new System.Drawing.Point(0, 0);
            this.CB.Name = "CB";
            this.CB.Size = new System.Drawing.Size(15, 23);
            this.CB.TabIndex = 1;
            this.CB.UseVisualStyleBackColor = true;
            // 
            // Title
            // 
            this.Title.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Title.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Title.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Title.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.Title.Location = new System.Drawing.Point(15, 0);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(251, 23);
            this.Title.TabIndex = 3;
            this.Title.Text = "[COMPONENT]";
            this.Title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ComponentHeader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.Controls.Add(this.Title);
            this.Controls.Add(this.CB);
            this.Controls.Add(this.X);
            this.Name = "ComponentHeader";
            this.Size = new System.Drawing.Size(299, 23);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ComponentHeader.X'
        public System.Windows.Forms.Button X;
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ComponentHeader.X'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ComponentHeader.Title'
        public System.Windows.Forms.Label Title;
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ComponentHeader.Title'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ComponentHeader.CB'
        public System.Windows.Forms.CheckBox CB;
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ComponentHeader.CB'
    }
}
