namespace Wingine.Editor
{
    partial class LoadSceneMenu
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
            this.View = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // View
            // 
            this.View.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.View.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.View.Dock = System.Windows.Forms.DockStyle.Fill;
            this.View.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.View.ForeColor = System.Drawing.Color.Gold;
            this.View.FullRowSelect = true;
            this.View.Location = new System.Drawing.Point(0, 0);
            this.View.Name = "View";
            this.View.ShowLines = false;
            this.View.ShowPlusMinus = false;
            this.View.ShowRootLines = false;
            this.View.Size = new System.Drawing.Size(273, 319);
            this.View.TabIndex = 0;
            // 
            // LoadSceneMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.ClientSize = new System.Drawing.Size(273, 319);
            this.Controls.Add(this.View);
            this.ForeColor = System.Drawing.Color.Gold;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "LoadSceneMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Load Scene Menu";
            this.ResumeLayout(false);

        }

        #endregion

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'LoadSceneMenu.View'
        public System.Windows.Forms.TreeView View;
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'LoadSceneMenu.View'
    }
}