namespace Wingine.Hub
{
    partial class Window
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Window));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lb_projects = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_open_dir = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_proj_dir = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_create = new System.Windows.Forms.Button();
            this.cb_proj_type = new System.Windows.Forms.ComboBox();
            this.tb_proj_name = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tb_engine = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label5);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 48);
            this.panel1.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Font = new System.Drawing.Font("Impact", 28F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Crimson;
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(800, 48);
            this.label5.TabIndex = 0;
            this.label5.Text = "Wingine Hub";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.lb_projects);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI Black", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.groupBox1.Location = new System.Drawing.Point(536, 45);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(252, 393);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Created Projects";
            // 
            // lb_projects
            // 
            this.lb_projects.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.lb_projects.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lb_projects.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_projects.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_projects.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.lb_projects.FormattingEnabled = true;
            this.lb_projects.HorizontalScrollbar = true;
            this.lb_projects.ItemHeight = 20;
            this.lb_projects.Location = new System.Drawing.Point(3, 27);
            this.lb_projects.Name = "lb_projects";
            this.lb_projects.Size = new System.Drawing.Size(246, 363);
            this.lb_projects.TabIndex = 2;
            this.lb_projects.DoubleClick += new System.EventHandler(this.lb_projects_DoubleClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.btn_open_dir);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.tb_proj_dir);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.btn_create);
            this.groupBox2.Controls.Add(this.cb_proj_type);
            this.groupBox2.Controls.Add(this.tb_proj_name);
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI Black", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.groupBox2.Location = new System.Drawing.Point(12, 45);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(252, 393);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Create Project";
            // 
            // btn_open_dir
            // 
            this.btn_open_dir.FlatAppearance.BorderColor = System.Drawing.SystemColors.MenuHighlight;
            this.btn_open_dir.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Highlight;
            this.btn_open_dir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_open_dir.Font = new System.Drawing.Font("Leelawadee UI", 9F, System.Drawing.FontStyle.Bold);
            this.btn_open_dir.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.btn_open_dir.Location = new System.Drawing.Point(6, 236);
            this.btn_open_dir.Name = "btn_open_dir";
            this.btn_open_dir.Size = new System.Drawing.Size(240, 25);
            this.btn_open_dir.TabIndex = 8;
            this.btn_open_dir.Text = "Open In Explorer";
            this.btn_open_dir.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_open_dir.UseVisualStyleBackColor = true;
            this.btn_open_dir.Click += new System.EventHandler(this.btn_open_dir_Click);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 11F);
            this.label3.Location = new System.Drawing.Point(6, 184);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(240, 23);
            this.label3.TabIndex = 7;
            this.label3.Text = "Project Directory";
            // 
            // tb_proj_dir
            // 
            this.tb_proj_dir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.tb_proj_dir.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_proj_dir.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_proj_dir.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.tb_proj_dir.Location = new System.Drawing.Point(6, 210);
            this.tb_proj_dir.MaxLength = 999999999;
            this.tb_proj_dir.Name = "tb_proj_dir";
            this.tb_proj_dir.ReadOnly = true;
            this.tb_proj_dir.Size = new System.Drawing.Size(240, 20);
            this.tb_proj_dir.TabIndex = 6;
            this.tb_proj_dir.Text = "C:\\Wingine Projects";
            this.tb_proj_dir.Click += new System.EventHandler(this.tb_proj_dir_Click);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 11F);
            this.label2.Location = new System.Drawing.Point(6, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(240, 23);
            this.label2.TabIndex = 5;
            this.label2.Text = "Project Name:";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 11F);
            this.label1.Location = new System.Drawing.Point(6, 112);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(240, 23);
            this.label1.TabIndex = 4;
            this.label1.Text = "Select Template:";
            // 
            // btn_create
            // 
            this.btn_create.FlatAppearance.BorderColor = System.Drawing.SystemColors.MenuHighlight;
            this.btn_create.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Highlight;
            this.btn_create.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_create.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btn_create.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.btn_create.Location = new System.Drawing.Point(32, 356);
            this.btn_create.Name = "btn_create";
            this.btn_create.Size = new System.Drawing.Size(190, 31);
            this.btn_create.TabIndex = 2;
            this.btn_create.Text = "Create";
            this.btn_create.UseVisualStyleBackColor = true;
            this.btn_create.Click += new System.EventHandler(this.btn_create_Click);
            // 
            // cb_proj_type
            // 
            this.cb_proj_type.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.cb_proj_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_proj_type.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_proj_type.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.cb_proj_type.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.cb_proj_type.FormattingEnabled = true;
            this.cb_proj_type.Items.AddRange(new object[] {
            "Default",
            "Empty"});
            this.cb_proj_type.Location = new System.Drawing.Point(6, 138);
            this.cb_proj_type.Name = "cb_proj_type";
            this.cb_proj_type.Size = new System.Drawing.Size(240, 28);
            this.cb_proj_type.TabIndex = 1;
            // 
            // tb_proj_name
            // 
            this.tb_proj_name.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.tb_proj_name.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_proj_name.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_proj_name.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.tb_proj_name.Location = new System.Drawing.Point(6, 68);
            this.tb_proj_name.MaxLength = 2000;
            this.tb_proj_name.Name = "tb_proj_name";
            this.tb_proj_name.Size = new System.Drawing.Size(240, 20);
            this.tb_proj_name.TabIndex = 0;
            this.tb_proj_name.Text = "New Project";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 11F);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.label4.Location = new System.Drawing.Point(270, 392);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(260, 23);
            this.label4.TabIndex = 9;
            this.label4.Text = "Engine Location";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tb_engine
            // 
            this.tb_engine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.tb_engine.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_engine.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_engine.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.tb_engine.Location = new System.Drawing.Point(270, 418);
            this.tb_engine.MaxLength = 999999999;
            this.tb_engine.Name = "tb_engine";
            this.tb_engine.ReadOnly = true;
            this.tb_engine.Size = new System.Drawing.Size(260, 20);
            this.tb_engine.TabIndex = 8;
            this.tb_engine.Text = "C:\\Wingine Projects";
            this.tb_engine.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_engine.Click += new System.EventHandler(this.tb_engine_Click);
            // 
            // Window
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.BackgroundImage = global::Wingine.Hub.Properties.Resources.Wingine_Icon__1_;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tb_engine);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.Beige;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Window";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Wingine Hub";
            this.Load += new System.EventHandler(this.Window_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox lb_projects;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox tb_proj_name;
        private System.Windows.Forms.ComboBox cb_proj_type;
        private System.Windows.Forms.Button btn_create;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_proj_dir;
        private System.Windows.Forms.Button btn_open_dir;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tb_engine;
        private System.Windows.Forms.Label label5;
    }
}

