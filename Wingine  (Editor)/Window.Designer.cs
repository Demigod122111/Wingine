namespace Wingine.Editor
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("Directories", System.Windows.Forms.HorizontalAlignment.Center);
            System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("Files", System.Windows.Forms.HorizontalAlignment.Center);
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("Script.cs", 0);
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("Image.png", 0);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Window));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.Hierarchy = new System.Windows.Forms.TreeView();
            this.HierarchyCMS = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.createToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gameObjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sceneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.emptyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.duplicateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteCurrentSceneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reloadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.Scene = new System.Windows.Forms.PictureBox();
            this.TabControl = new System.Windows.Forms.TabControl();
            this.ConsoleTabPage = new System.Windows.Forms.TabPage();
            this.Console = new System.Windows.Forms.RichTextBox();
            this.ConsoleCMS = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.debugRepeatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Assets = new System.Windows.Forms.TabPage();
            this.AssetListView = new System.Windows.Forms.ListView();
            this.AssetsImageList = new System.Windows.Forms.ImageList(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.AssetLocation = new System.Windows.Forms.RichTextBox();
            this.AssetLocationCMS = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showInFileExplorerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AssetBack = new System.Windows.Forms.PictureBox();
            this.AssetHome = new System.Windows.Forms.PictureBox();
            this.ResourcesTabPage = new System.Windows.Forms.TabPage();
            this.Inspector = new System.Windows.Forms.Panel();
            this.ToolsBar = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.newProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BuildGameTSB = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.PixelEditor_TSB = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.SceneMenuTSB = new System.Windows.Forms.ToolStripButton();
            this.Editor = new System.Windows.Forms.Timer(this.components);
            this.HierarchyUpdater = new System.Windows.Forms.Timer(this.components);
            this.InspectorUpdater = new System.Windows.Forms.Timer(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.PlayStopTSB = new System.Windows.Forms.ToolStripButton();
            this.StatusBar = new System.Windows.Forms.FlowLayoutPanel();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.showFPSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.HierarchyCMS.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Scene)).BeginInit();
            this.TabControl.SuspendLayout();
            this.ConsoleTabPage.SuspendLayout();
            this.ConsoleCMS.SuspendLayout();
            this.Assets.SuspendLayout();
            this.panel1.SuspendLayout();
            this.AssetLocationCMS.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AssetBack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AssetHome)).BeginInit();
            this.ToolsBar.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.BackColor = System.Drawing.Color.Transparent;
            this.splitContainer1.Location = new System.Drawing.Point(5, 95);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.Hierarchy);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(904, 509);
            this.splitContainer1.SplitterDistance = 175;
            this.splitContainer1.TabIndex = 0;
            // 
            // Hierarchy
            // 
            this.Hierarchy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.Hierarchy.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Hierarchy.ContextMenuStrip = this.HierarchyCMS;
            this.Hierarchy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Hierarchy.Font = new System.Drawing.Font("Microsoft YaHei UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Hierarchy.ForeColor = System.Drawing.Color.MediumSlateBlue;
            this.Hierarchy.FullRowSelect = true;
            this.Hierarchy.Location = new System.Drawing.Point(0, 0);
            this.Hierarchy.Name = "Hierarchy";
            this.Hierarchy.ShowLines = false;
            this.Hierarchy.Size = new System.Drawing.Size(175, 509);
            this.Hierarchy.TabIndex = 0;
            this.Hierarchy.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.Hierarchy_AfterCheck);
            this.Hierarchy.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.Hierarchy_NodeMouseClick);
            this.Hierarchy.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.Hierarchy_NodeMouseDoubleClick);
            this.Hierarchy.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Hierarchy_MouseUp);
            // 
            // HierarchyCMS
            // 
            this.HierarchyCMS.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.HierarchyCMS.DropShadowEnabled = false;
            this.HierarchyCMS.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createToolStripMenuItem,
            this.duplicateToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.deleteCurrentSceneToolStripMenuItem,
            this.reloadToolStripMenuItem});
            this.HierarchyCMS.Name = "HierarchyCMS";
            this.HierarchyCMS.ShowImageMargin = false;
            this.HierarchyCMS.Size = new System.Drawing.Size(257, 124);
            // 
            // createToolStripMenuItem
            // 
            this.createToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.createToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gameObjectToolStripMenuItem,
            this.sceneToolStripMenuItem});
            this.createToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.createToolStripMenuItem.ForeColor = System.Drawing.Color.Beige;
            this.createToolStripMenuItem.Name = "createToolStripMenuItem";
            this.createToolStripMenuItem.Size = new System.Drawing.Size(256, 24);
            this.createToolStripMenuItem.Text = "Create";
            // 
            // gameObjectToolStripMenuItem
            // 
            this.gameObjectToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.gameObjectToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.gameObjectToolStripMenuItem.ForeColor = System.Drawing.Color.Goldenrod;
            this.gameObjectToolStripMenuItem.Name = "gameObjectToolStripMenuItem";
            this.gameObjectToolStripMenuItem.Size = new System.Drawing.Size(161, 24);
            this.gameObjectToolStripMenuItem.Text = "GameObject";
            this.gameObjectToolStripMenuItem.Click += new System.EventHandler(this.gameObjectToolStripMenuItem_Click);
            // 
            // sceneToolStripMenuItem
            // 
            this.sceneToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.sceneToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.emptyToolStripMenuItem});
            this.sceneToolStripMenuItem.ForeColor = System.Drawing.Color.Gold;
            this.sceneToolStripMenuItem.Name = "sceneToolStripMenuItem";
            this.sceneToolStripMenuItem.Size = new System.Drawing.Size(161, 24);
            this.sceneToolStripMenuItem.Text = "Scene";
            // 
            // emptyToolStripMenuItem
            // 
            this.emptyToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.emptyToolStripMenuItem.ForeColor = System.Drawing.Color.Navy;
            this.emptyToolStripMenuItem.Name = "emptyToolStripMenuItem";
            this.emptyToolStripMenuItem.Size = new System.Drawing.Size(120, 24);
            this.emptyToolStripMenuItem.Text = "Empty";
            this.emptyToolStripMenuItem.Click += new System.EventHandler(this.emptyToolStripMenuItem_Click);
            // 
            // duplicateToolStripMenuItem
            // 
            this.duplicateToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.duplicateToolStripMenuItem.ForeColor = System.Drawing.Color.Beige;
            this.duplicateToolStripMenuItem.Name = "duplicateToolStripMenuItem";
            this.duplicateToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.D)));
            this.duplicateToolStripMenuItem.Size = new System.Drawing.Size(256, 24);
            this.duplicateToolStripMenuItem.Text = "Duplicate";
            this.duplicateToolStripMenuItem.Click += new System.EventHandler(this.duplicateToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.deleteToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.deleteToolStripMenuItem.ForeColor = System.Drawing.Color.Beige;
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(256, 24);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // deleteCurrentSceneToolStripMenuItem
            // 
            this.deleteCurrentSceneToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.deleteCurrentSceneToolStripMenuItem.ForeColor = System.Drawing.Color.Beige;
            this.deleteCurrentSceneToolStripMenuItem.Name = "deleteCurrentSceneToolStripMenuItem";
            this.deleteCurrentSceneToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Delete)));
            this.deleteCurrentSceneToolStripMenuItem.Size = new System.Drawing.Size(256, 24);
            this.deleteCurrentSceneToolStripMenuItem.Text = "Delete Current Scene";
            this.deleteCurrentSceneToolStripMenuItem.Click += new System.EventHandler(this.deleteCurrentSceneToolStripMenuItem_Click);
            // 
            // reloadToolStripMenuItem
            // 
            this.reloadToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.reloadToolStripMenuItem.ForeColor = System.Drawing.Color.Beige;
            this.reloadToolStripMenuItem.Name = "reloadToolStripMenuItem";
            this.reloadToolStripMenuItem.Size = new System.Drawing.Size(256, 24);
            this.reloadToolStripMenuItem.Text = "Reload";
            this.reloadToolStripMenuItem.Click += new System.EventHandler(this.reloadToolStripMenuItem_Click);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.splitContainer3);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.Inspector);
            this.splitContainer2.Size = new System.Drawing.Size(725, 509);
            this.splitContainer2.SplitterDistance = 533;
            this.splitContainer2.TabIndex = 0;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.Scene);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.TabControl);
            this.splitContainer3.Size = new System.Drawing.Size(533, 509);
            this.splitContainer3.SplitterDistance = 329;
            this.splitContainer3.TabIndex = 0;
            // 
            // Scene
            // 
            this.Scene.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Scene.Location = new System.Drawing.Point(0, 0);
            this.Scene.Name = "Scene";
            this.Scene.Size = new System.Drawing.Size(533, 329);
            this.Scene.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Scene.TabIndex = 0;
            this.Scene.TabStop = false;
            // 
            // TabControl
            // 
            this.TabControl.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.TabControl.Controls.Add(this.ConsoleTabPage);
            this.TabControl.Controls.Add(this.Assets);
            this.TabControl.Controls.Add(this.ResourcesTabPage);
            this.TabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabControl.HotTrack = true;
            this.TabControl.Location = new System.Drawing.Point(0, 0);
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedIndex = 0;
            this.TabControl.Size = new System.Drawing.Size(533, 176);
            this.TabControl.TabIndex = 0;
            // 
            // ConsoleTabPage
            // 
            this.ConsoleTabPage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.ConsoleTabPage.Controls.Add(this.Console);
            this.ConsoleTabPage.ForeColor = System.Drawing.Color.Beige;
            this.ConsoleTabPage.Location = new System.Drawing.Point(4, 4);
            this.ConsoleTabPage.Name = "ConsoleTabPage";
            this.ConsoleTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.ConsoleTabPage.Size = new System.Drawing.Size(525, 150);
            this.ConsoleTabPage.TabIndex = 0;
            this.ConsoleTabPage.Text = "Console";
            // 
            // Console
            // 
            this.Console.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.Console.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Console.ContextMenuStrip = this.ConsoleCMS;
            this.Console.Cursor = System.Windows.Forms.Cursors.Default;
            this.Console.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Console.Font = new System.Drawing.Font("Consolas", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Console.ForeColor = System.Drawing.Color.Beige;
            this.Console.Location = new System.Drawing.Point(3, 3);
            this.Console.Name = "Console";
            this.Console.ReadOnly = true;
            this.Console.Size = new System.Drawing.Size(519, 144);
            this.Console.TabIndex = 0;
            this.Console.Text = "";
            // 
            // ConsoleCMS
            // 
            this.ConsoleCMS.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.ConsoleCMS.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearToolStripMenuItem,
            this.debugRepeatToolStripMenuItem});
            this.ConsoleCMS.Name = "ConsoleCMS";
            this.ConsoleCMS.ShowImageMargin = false;
            this.ConsoleCMS.Size = new System.Drawing.Size(147, 52);
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.AutoToolTip = true;
            this.clearToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.clearToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.clearToolStripMenuItem.ForeColor = System.Drawing.Color.Crimson;
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            this.clearToolStripMenuItem.Size = new System.Drawing.Size(146, 24);
            this.clearToolStripMenuItem.Text = "Clear";
            this.clearToolStripMenuItem.ToolTipText = "Clears the console of all it\'s contents";
            this.clearToolStripMenuItem.Click += new System.EventHandler(this.clearToolStripMenuItem_Click);
            // 
            // debugRepeatToolStripMenuItem
            // 
            this.debugRepeatToolStripMenuItem.CheckOnClick = true;
            this.debugRepeatToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.debugRepeatToolStripMenuItem.ForeColor = System.Drawing.Color.Beige;
            this.debugRepeatToolStripMenuItem.Name = "debugRepeatToolStripMenuItem";
            this.debugRepeatToolStripMenuItem.Size = new System.Drawing.Size(146, 24);
            this.debugRepeatToolStripMenuItem.Text = "Debug Repeat";
            this.debugRepeatToolStripMenuItem.ToolTipText = "Determines if the same message and type can be logged consecutively";
            this.debugRepeatToolStripMenuItem.CheckedChanged += new System.EventHandler(this.debugRepeatToolStripMenuItem_CheckedChanged);
            // 
            // Assets
            // 
            this.Assets.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.Assets.Controls.Add(this.AssetListView);
            this.Assets.Controls.Add(this.panel1);
            this.Assets.Location = new System.Drawing.Point(4, 4);
            this.Assets.Name = "Assets";
            this.Assets.Padding = new System.Windows.Forms.Padding(3);
            this.Assets.Size = new System.Drawing.Size(525, 150);
            this.Assets.TabIndex = 1;
            this.Assets.Text = "Assets";
            // 
            // AssetListView
            // 
            this.AssetListView.Alignment = System.Windows.Forms.ListViewAlignment.Left;
            this.AssetListView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.AssetListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.AssetListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AssetListView.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AssetListView.ForeColor = System.Drawing.Color.Beige;
            this.AssetListView.GridLines = true;
            listViewGroup1.Header = "Directories";
            listViewGroup1.HeaderAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            listViewGroup1.Name = "DirectoryGroup";
            listViewGroup2.Header = "Files";
            listViewGroup2.HeaderAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            listViewGroup2.Name = "FileGroup";
            this.AssetListView.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2});
            this.AssetListView.HideSelection = false;
            this.AssetListView.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2});
            this.AssetListView.LargeImageList = this.AssetsImageList;
            this.AssetListView.Location = new System.Drawing.Point(3, 26);
            this.AssetListView.Name = "AssetListView";
            this.AssetListView.Size = new System.Drawing.Size(519, 121);
            this.AssetListView.SmallImageList = this.AssetsImageList;
            this.AssetListView.StateImageList = this.AssetsImageList;
            this.AssetListView.TabIndex = 1;
            this.AssetListView.UseCompatibleStateImageBehavior = false;
            this.AssetListView.View = System.Windows.Forms.View.List;
            this.AssetListView.SelectedIndexChanged += new System.EventHandler(this.AssetListView_SelectedIndexChanged);
            this.AssetListView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.AssetListView_MouseDoubleClick);
            // 
            // AssetsImageList
            // 
            this.AssetsImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("AssetsImageList.ImageStream")));
            this.AssetsImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.AssetsImageList.Images.SetKeyName(0, "folder.png");
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.AssetLocation);
            this.panel1.Controls.Add(this.AssetBack);
            this.panel1.Controls.Add(this.AssetHome);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(519, 23);
            this.panel1.TabIndex = 0;
            // 
            // AssetLocation
            // 
            this.AssetLocation.AutoWordSelection = true;
            this.AssetLocation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.AssetLocation.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.AssetLocation.ContextMenuStrip = this.AssetLocationCMS;
            this.AssetLocation.Cursor = System.Windows.Forms.Cursors.Default;
            this.AssetLocation.DetectUrls = false;
            this.AssetLocation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AssetLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.AssetLocation.ForeColor = System.Drawing.Color.Beige;
            this.AssetLocation.Location = new System.Drawing.Point(50, 0);
            this.AssetLocation.Multiline = false;
            this.AssetLocation.Name = "AssetLocation";
            this.AssetLocation.ReadOnly = true;
            this.AssetLocation.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Horizontal;
            this.AssetLocation.Size = new System.Drawing.Size(469, 23);
            this.AssetLocation.TabIndex = 2;
            this.AssetLocation.Text = "";
            // 
            // AssetLocationCMS
            // 
            this.AssetLocationCMS.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showInFileExplorerToolStripMenuItem});
            this.AssetLocationCMS.Name = "AssetLocationCMS";
            this.AssetLocationCMS.Size = new System.Drawing.Size(184, 26);
            // 
            // showInFileExplorerToolStripMenuItem
            // 
            this.showInFileExplorerToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.showInFileExplorerToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.showInFileExplorerToolStripMenuItem.ForeColor = System.Drawing.Color.DarkCyan;
            this.showInFileExplorerToolStripMenuItem.Name = "showInFileExplorerToolStripMenuItem";
            this.showInFileExplorerToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.showInFileExplorerToolStripMenuItem.Text = "Show in File Explorer";
            this.showInFileExplorerToolStripMenuItem.Click += new System.EventHandler(this.showInFileExplorerToolStripMenuItem_Click);
            // 
            // AssetBack
            // 
            this.AssetBack.Dock = System.Windows.Forms.DockStyle.Left;
            this.AssetBack.Image = global::Wingine.Editor.Properties.Resources.back;
            this.AssetBack.Location = new System.Drawing.Point(25, 0);
            this.AssetBack.Margin = new System.Windows.Forms.Padding(16, 3, 3, 3);
            this.AssetBack.Name = "AssetBack";
            this.AssetBack.Size = new System.Drawing.Size(25, 23);
            this.AssetBack.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.AssetBack.TabIndex = 1;
            this.AssetBack.TabStop = false;
            this.AssetBack.Click += new System.EventHandler(this.AssetBack_Click);
            // 
            // AssetHome
            // 
            this.AssetHome.Dock = System.Windows.Forms.DockStyle.Left;
            this.AssetHome.Image = global::Wingine.Editor.Properties.Resources.home;
            this.AssetHome.Location = new System.Drawing.Point(0, 0);
            this.AssetHome.Name = "AssetHome";
            this.AssetHome.Size = new System.Drawing.Size(25, 23);
            this.AssetHome.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.AssetHome.TabIndex = 0;
            this.AssetHome.TabStop = false;
            this.AssetHome.Click += new System.EventHandler(this.AssetHome_Click);
            // 
            // ResourcesTabPage
            // 
            this.ResourcesTabPage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.ResourcesTabPage.Location = new System.Drawing.Point(4, 4);
            this.ResourcesTabPage.Name = "ResourcesTabPage";
            this.ResourcesTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.ResourcesTabPage.Size = new System.Drawing.Size(525, 150);
            this.ResourcesTabPage.TabIndex = 2;
            this.ResourcesTabPage.Text = "Resources";
            // 
            // Inspector
            // 
            this.Inspector.AutoScroll = true;
            this.Inspector.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Inspector.Location = new System.Drawing.Point(0, 0);
            this.Inspector.Name = "Inspector";
            this.Inspector.Size = new System.Drawing.Size(188, 509);
            this.Inspector.TabIndex = 0;
            // 
            // ToolsBar
            // 
            this.ToolsBar.AccessibleRole = System.Windows.Forms.AccessibleRole.ToolBar;
            this.ToolsBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ToolsBar.AutoSize = false;
            this.ToolsBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.ToolsBar.CanOverflow = false;
            this.ToolsBar.Dock = System.Windows.Forms.DockStyle.None;
            this.ToolsBar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.ToolsBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1,
            this.toolStripButton1,
            this.toolStripSeparator3,
            this.BuildGameTSB,
            this.PixelEditor_TSB,
            this.toolStripSeparator4,
            this.SceneMenuTSB});
            this.ToolsBar.Location = new System.Drawing.Point(5, 40);
            this.ToolsBar.Name = "ToolsBar";
            this.ToolsBar.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.ToolsBar.Size = new System.Drawing.Size(907, 29);
            this.ToolsBar.Stretch = true;
            this.ToolsBar.TabIndex = 0;
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.AutoToolTip = false;
            this.toolStripDropDownButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newProjectToolStripMenuItem,
            this.openProjectToolStripMenuItem,
            this.toolStripSeparator1,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.toolStripSeparator2,
            this.exitToolStripMenuItem});
            this.toolStripDropDownButton1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.toolStripDropDownButton1.ForeColor = System.Drawing.Color.Beige;
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(45, 26);
            this.toolStripDropDownButton1.Text = "File";
            // 
            // newProjectToolStripMenuItem
            // 
            this.newProjectToolStripMenuItem.Name = "newProjectToolStripMenuItem";
            this.newProjectToolStripMenuItem.Size = new System.Drawing.Size(272, 24);
            this.newProjectToolStripMenuItem.Text = "New Project";
            this.newProjectToolStripMenuItem.Click += new System.EventHandler(this.newProjectToolStripMenuItem_Click);
            // 
            // openProjectToolStripMenuItem
            // 
            this.openProjectToolStripMenuItem.Name = "openProjectToolStripMenuItem";
            this.openProjectToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.O)));
            this.openProjectToolStripMenuItem.Size = new System.Drawing.Size(272, 24);
            this.openProjectToolStripMenuItem.Text = "Open Project...";
            this.openProjectToolStripMenuItem.Click += new System.EventHandler(this.openProjectToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(269, 6);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(272, 24);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(272, 24);
            this.saveAsToolStripMenuItem.Text = "Save As...";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(269, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(272, 24);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // BuildGameTSB
            // 
            this.BuildGameTSB.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.BuildGameTSB.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BuildGameTSB.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.BuildGameTSB.Image = global::Wingine.Editor.Properties.Resources.build;
            this.BuildGameTSB.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BuildGameTSB.Name = "BuildGameTSB";
            this.BuildGameTSB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.BuildGameTSB.Size = new System.Drawing.Size(23, 26);
            this.BuildGameTSB.Text = "Build Game";
            this.BuildGameTSB.Click += new System.EventHandler(this.BuildGameTSB_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 29);
            // 
            // PixelEditor_TSB
            // 
            this.PixelEditor_TSB.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.PixelEditor_TSB.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.PixelEditor_TSB.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.PixelEditor_TSB.Image = global::Wingine.Editor.Properties.Resources.pixels;
            this.PixelEditor_TSB.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.PixelEditor_TSB.Name = "PixelEditor_TSB";
            this.PixelEditor_TSB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.PixelEditor_TSB.Size = new System.Drawing.Size(23, 26);
            this.PixelEditor_TSB.Text = "Pixel Editor";
            this.PixelEditor_TSB.Click += new System.EventHandler(this.PixelEditor_TSB_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 29);
            // 
            // SceneMenuTSB
            // 
            this.SceneMenuTSB.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.SceneMenuTSB.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.SceneMenuTSB.ForeColor = System.Drawing.Color.Beige;
            this.SceneMenuTSB.Image = global::Wingine.Editor.Properties.Resources.rubik;
            this.SceneMenuTSB.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SceneMenuTSB.Name = "SceneMenuTSB";
            this.SceneMenuTSB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.SceneMenuTSB.Size = new System.Drawing.Size(23, 26);
            this.SceneMenuTSB.Text = "Scene Menu";
            this.SceneMenuTSB.Click += new System.EventHandler(this.SceneMenuTSB_Click);
            // 
            // Editor
            // 
            this.Editor.Enabled = true;
            this.Editor.Interval = 1;
            this.Editor.Tick += new System.EventHandler(this.Editor_Tick);
            // 
            // HierarchyUpdater
            // 
            this.HierarchyUpdater.Enabled = true;
            this.HierarchyUpdater.Tick += new System.EventHandler(this.HierarchyUpdater_Tick);
            // 
            // InspectorUpdater
            // 
            this.InspectorUpdater.Enabled = true;
            this.InspectorUpdater.Tick += new System.EventHandler(this.InspectorUpdater_Tick);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.toolStrip1.CanOverflow = false;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PlayStopTSB});
            this.toolStrip1.Location = new System.Drawing.Point(8, 69);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStrip1.Size = new System.Drawing.Size(901, 23);
            this.toolStrip1.Stretch = true;
            this.toolStrip1.TabIndex = 2;
            // 
            // PlayStopTSB
            // 
            this.PlayStopTSB.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.PlayStopTSB.Image = global::Wingine.Editor.Properties.Resources.play2;
            this.PlayStopTSB.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.PlayStopTSB.Name = "PlayStopTSB";
            this.PlayStopTSB.Size = new System.Drawing.Size(23, 20);
            this.PlayStopTSB.Text = "Play/Stop";
            this.PlayStopTSB.Click += new System.EventHandler(this.PlayStopTSB_Click);
            // 
            // StatusBar
            // 
            this.StatusBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.StatusBar.BackColor = System.Drawing.Color.Transparent;
            this.StatusBar.ForeColor = System.Drawing.Color.Beige;
            this.StatusBar.Location = new System.Drawing.Point(8, 610);
            this.StatusBar.Name = "StatusBar";
            this.StatusBar.Size = new System.Drawing.Size(904, 28);
            this.StatusBar.TabIndex = 3;
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showFPSToolStripMenuItem});
            this.toolStripButton1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.toolStripButton1.Size = new System.Drawing.Size(75, 26);
            this.toolStripButton1.Text = "Settings";
            // 
            // showFPSToolStripMenuItem
            // 
            this.showFPSToolStripMenuItem.CheckOnClick = true;
            this.showFPSToolStripMenuItem.Name = "showFPSToolStripMenuItem";
            this.showFPSToolStripMenuItem.Size = new System.Drawing.Size(180, 24);
            this.showFPSToolStripMenuItem.Text = "Show FPS";
            // 
            // Window
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.ClientSize = new System.Drawing.Size(920, 640);
            this.Controls.Add(this.ToolsBar);
            this.Controls.Add(this.StatusBar);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.splitContainer1);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.Beige;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Window";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Wingine";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Window_FormClosing);
            this.Load += new System.EventHandler(this.Window_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.HierarchyCMS.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Scene)).EndInit();
            this.TabControl.ResumeLayout(false);
            this.ConsoleTabPage.ResumeLayout(false);
            this.ConsoleCMS.ResumeLayout(false);
            this.Assets.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.AssetLocationCMS.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.AssetBack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AssetHome)).EndInit();
            this.ToolsBar.ResumeLayout(false);
            this.ToolsBar.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView Hierarchy;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.Panel Inspector;
        private System.Windows.Forms.PictureBox Scene;
        private System.Windows.Forms.TabControl TabControl;
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Window.ToolsBar'
        public System.Windows.Forms.ToolStrip ToolsBar;
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Window.ToolsBar'
        private System.Windows.Forms.Timer Editor;
        private System.Windows.Forms.Timer HierarchyUpdater;
        private System.Windows.Forms.Timer InspectorUpdater;
        private System.Windows.Forms.TabPage ConsoleTabPage;
        private System.Windows.Forms.RichTextBox Console;
        private System.Windows.Forms.ContextMenuStrip HierarchyCMS;
        private System.Windows.Forms.ToolStripMenuItem createToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gameObjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip ConsoleCMS;
        private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Window.toolStrip1'
        public System.Windows.Forms.ToolStrip toolStrip1;
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Window.toolStrip1'
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem openProjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reloadToolStripMenuItem;
#pragma warning disable CS0108 // 'Window.StatusBar' hides inherited member 'XCoolForm.StatusBar'. Use the new keyword if hiding was intended.
        private System.Windows.Forms.FlowLayoutPanel StatusBar;
#pragma warning restore CS0108 // 'Window.StatusBar' hides inherited member 'XCoolForm.StatusBar'. Use the new keyword if hiding was intended.
        private System.Windows.Forms.ToolStripMenuItem duplicateToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton PlayStopTSB;
        private System.Windows.Forms.ToolStripMenuItem sceneToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem emptyToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton SceneMenuTSB;
        private System.Windows.Forms.ToolStripMenuItem deleteCurrentSceneToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.TabPage Assets;
        private System.Windows.Forms.ImageList AssetsImageList;
        private System.Windows.Forms.ListView AssetListView;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox AssetHome;
        private System.Windows.Forms.PictureBox AssetBack;
        private System.Windows.Forms.RichTextBox AssetLocation;
        private System.Windows.Forms.ContextMenuStrip AssetLocationCMS;
        private System.Windows.Forms.ToolStripMenuItem showInFileExplorerToolStripMenuItem;
        private System.Windows.Forms.TabPage ResourcesTabPage;
        private System.Windows.Forms.ToolStripMenuItem newProjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton BuildGameTSB;
        private System.Windows.Forms.ToolStripButton PixelEditor_TSB;
        private System.Windows.Forms.ToolStripMenuItem debugRepeatToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripDropDownButton toolStripButton1;
        private System.Windows.Forms.ToolStripMenuItem showFPSToolStripMenuItem;
    }
}

