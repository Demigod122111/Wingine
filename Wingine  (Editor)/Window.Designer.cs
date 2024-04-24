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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Window));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.Hierarchy = new System.Windows.Forms.TreeView();
            this.HierarchyCMS = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.createToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sceneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.emptyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.defaultSceneToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.gameObjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.emptyToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.cameraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.canvasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.duplicateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteCurrentSceneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reloadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.Scene = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.SceneCameraSpeedTSCB = new System.Windows.Forms.ToolStripComboBox();
            this.SCPTSB = new System.Windows.Forms.ToolStripButton();
            this.TabControl = new System.Windows.Forms.TabControl();
            this.ConsoleTabPage = new System.Windows.Forms.TabPage();
            this.Console = new System.Windows.Forms.RichTextBox();
            this.ConsoleCMS = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.debugRepeatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearOnPlayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.ResourcesTable = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.rtb_threads = new System.Windows.Forms.RichTextBox();
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
            this.toolStripButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.showFPSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showDiagnosticsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeProjectNameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeApplicationTitleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.BuildGameTSB = new System.Windows.Forms.ToolStripButton();
            this.PixelEditor_TSB = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.SceneMenuTSB = new System.Windows.Forms.ToolStripButton();
            this.CurrentSceneNameTSTB = new System.Windows.Forms.ToolStripTextBox();
            this.Editor = new System.Windows.Forms.Timer(this.components);
            this.HierarchyUpdater = new System.Windows.Forms.Timer(this.components);
            this.InspectorUpdater = new System.Windows.Forms.Timer(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.PlayStopTSB = new System.Windows.Forms.ToolStripButton();
            this.StatusBar = new System.Windows.Forms.FlowLayoutPanel();
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
            this.panel3.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.TabControl.SuspendLayout();
            this.ConsoleTabPage.SuspendLayout();
            this.ConsoleCMS.SuspendLayout();
            this.Assets.SuspendLayout();
            this.panel1.SuspendLayout();
            this.AssetLocationCMS.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AssetBack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AssetHome)).BeginInit();
            this.ResourcesTabPage.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.ToolsBar.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            resources.ApplyResources(this.splitContainer1, "splitContainer1");
            this.splitContainer1.BackColor = System.Drawing.Color.Transparent;
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            resources.ApplyResources(this.splitContainer1.Panel1, "splitContainer1.Panel1");
            this.splitContainer1.Panel1.Controls.Add(this.Hierarchy);
            // 
            // splitContainer1.Panel2
            // 
            resources.ApplyResources(this.splitContainer1.Panel2, "splitContainer1.Panel2");
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            // 
            // Hierarchy
            // 
            resources.ApplyResources(this.Hierarchy, "Hierarchy");
            this.Hierarchy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.Hierarchy.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Hierarchy.ContextMenuStrip = this.HierarchyCMS;
            this.Hierarchy.ForeColor = System.Drawing.Color.MediumSlateBlue;
            this.Hierarchy.FullRowSelect = true;
            this.Hierarchy.Name = "Hierarchy";
            this.Hierarchy.ShowLines = false;
            this.Hierarchy.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.Hierarchy_AfterCheck);
            this.Hierarchy.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.Hierarchy_ItemDrag);
            this.Hierarchy.NodeMouseHover += new System.Windows.Forms.TreeNodeMouseHoverEventHandler(this.Hierarchy_NodeMouseHover);
            this.Hierarchy.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.Hierarchy_NodeMouseClick);
            this.Hierarchy.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.Hierarchy_NodeMouseDoubleClick);
            this.Hierarchy.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Hierarchy_KeyDown);
            this.Hierarchy.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Hierarchy_MouseDown);
            this.Hierarchy.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Hierarchy_MouseUp);
            // 
            // HierarchyCMS
            // 
            resources.ApplyResources(this.HierarchyCMS, "HierarchyCMS");
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
            // 
            // createToolStripMenuItem
            // 
            resources.ApplyResources(this.createToolStripMenuItem, "createToolStripMenuItem");
            this.createToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.createToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sceneToolStripMenuItem,
            this.gameObjectToolStripMenuItem});
            this.createToolStripMenuItem.ForeColor = System.Drawing.Color.Beige;
            this.createToolStripMenuItem.Name = "createToolStripMenuItem";
            // 
            // sceneToolStripMenuItem
            // 
            resources.ApplyResources(this.sceneToolStripMenuItem, "sceneToolStripMenuItem");
            this.sceneToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.sceneToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.emptyToolStripMenuItem,
            this.defaultSceneToolStripMenuItem1});
            this.sceneToolStripMenuItem.ForeColor = System.Drawing.Color.Gold;
            this.sceneToolStripMenuItem.Name = "sceneToolStripMenuItem";
            // 
            // emptyToolStripMenuItem
            // 
            resources.ApplyResources(this.emptyToolStripMenuItem, "emptyToolStripMenuItem");
            this.emptyToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.emptyToolStripMenuItem.ForeColor = System.Drawing.Color.Cyan;
            this.emptyToolStripMenuItem.Name = "emptyToolStripMenuItem";
            this.emptyToolStripMenuItem.Click += new System.EventHandler(this.emptyToolStripMenuItem_Click);
            // 
            // defaultSceneToolStripMenuItem1
            // 
            resources.ApplyResources(this.defaultSceneToolStripMenuItem1, "defaultSceneToolStripMenuItem1");
            this.defaultSceneToolStripMenuItem1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.defaultSceneToolStripMenuItem1.ForeColor = System.Drawing.Color.Cyan;
            this.defaultSceneToolStripMenuItem1.Name = "defaultSceneToolStripMenuItem1";
            this.defaultSceneToolStripMenuItem1.Click += new System.EventHandler(this.defaultSceneToolStripMenuItem1_Click);
            // 
            // gameObjectToolStripMenuItem
            // 
            resources.ApplyResources(this.gameObjectToolStripMenuItem, "gameObjectToolStripMenuItem");
            this.gameObjectToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.gameObjectToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.gameObjectToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.emptyToolStripMenuItem1,
            this.toolStripSeparator5,
            this.cameraToolStripMenuItem,
            this.uIToolStripMenuItem});
            this.gameObjectToolStripMenuItem.ForeColor = System.Drawing.Color.Gold;
            this.gameObjectToolStripMenuItem.Name = "gameObjectToolStripMenuItem";
            // 
            // emptyToolStripMenuItem1
            // 
            resources.ApplyResources(this.emptyToolStripMenuItem1, "emptyToolStripMenuItem1");
            this.emptyToolStripMenuItem1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.emptyToolStripMenuItem1.ForeColor = System.Drawing.Color.Cyan;
            this.emptyToolStripMenuItem1.Name = "emptyToolStripMenuItem1";
            this.emptyToolStripMenuItem1.Click += new System.EventHandler(this.emptyToolStripMenuItem1_Click);
            // 
            // toolStripSeparator5
            // 
            resources.ApplyResources(this.toolStripSeparator5, "toolStripSeparator5");
            this.toolStripSeparator5.BackColor = System.Drawing.Color.Black;
            this.toolStripSeparator5.ForeColor = System.Drawing.Color.Black;
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            // 
            // cameraToolStripMenuItem
            // 
            resources.ApplyResources(this.cameraToolStripMenuItem, "cameraToolStripMenuItem");
            this.cameraToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.cameraToolStripMenuItem.ForeColor = System.Drawing.Color.Cyan;
            this.cameraToolStripMenuItem.Name = "cameraToolStripMenuItem";
            this.cameraToolStripMenuItem.Click += new System.EventHandler(this.cameraToolStripMenuItem_Click);
            // 
            // uIToolStripMenuItem
            // 
            resources.ApplyResources(this.uIToolStripMenuItem, "uIToolStripMenuItem");
            this.uIToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.uIToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.canvasToolStripMenuItem,
            this.textToolStripMenuItem,
            this.buttonToolStripMenuItem});
            this.uIToolStripMenuItem.ForeColor = System.Drawing.Color.Cyan;
            this.uIToolStripMenuItem.Name = "uIToolStripMenuItem";
            // 
            // canvasToolStripMenuItem
            // 
            resources.ApplyResources(this.canvasToolStripMenuItem, "canvasToolStripMenuItem");
            this.canvasToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.canvasToolStripMenuItem.ForeColor = System.Drawing.Color.SpringGreen;
            this.canvasToolStripMenuItem.Name = "canvasToolStripMenuItem";
            this.canvasToolStripMenuItem.Click += new System.EventHandler(this.canvasToolStripMenuItem_Click);
            // 
            // textToolStripMenuItem
            // 
            resources.ApplyResources(this.textToolStripMenuItem, "textToolStripMenuItem");
            this.textToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.textToolStripMenuItem.ForeColor = System.Drawing.Color.SpringGreen;
            this.textToolStripMenuItem.Name = "textToolStripMenuItem";
            this.textToolStripMenuItem.Click += new System.EventHandler(this.textToolStripMenuItem_Click);
            // 
            // buttonToolStripMenuItem
            // 
            resources.ApplyResources(this.buttonToolStripMenuItem, "buttonToolStripMenuItem");
            this.buttonToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.buttonToolStripMenuItem.ForeColor = System.Drawing.Color.SpringGreen;
            this.buttonToolStripMenuItem.Name = "buttonToolStripMenuItem";
            this.buttonToolStripMenuItem.Click += new System.EventHandler(this.buttonToolStripMenuItem_Click);
            // 
            // duplicateToolStripMenuItem
            // 
            resources.ApplyResources(this.duplicateToolStripMenuItem, "duplicateToolStripMenuItem");
            this.duplicateToolStripMenuItem.ForeColor = System.Drawing.Color.Beige;
            this.duplicateToolStripMenuItem.Name = "duplicateToolStripMenuItem";
            this.duplicateToolStripMenuItem.Click += new System.EventHandler(this.duplicateToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            resources.ApplyResources(this.deleteToolStripMenuItem, "deleteToolStripMenuItem");
            this.deleteToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.deleteToolStripMenuItem.ForeColor = System.Drawing.Color.Beige;
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // deleteCurrentSceneToolStripMenuItem
            // 
            resources.ApplyResources(this.deleteCurrentSceneToolStripMenuItem, "deleteCurrentSceneToolStripMenuItem");
            this.deleteCurrentSceneToolStripMenuItem.ForeColor = System.Drawing.Color.Beige;
            this.deleteCurrentSceneToolStripMenuItem.Name = "deleteCurrentSceneToolStripMenuItem";
            this.deleteCurrentSceneToolStripMenuItem.Click += new System.EventHandler(this.deleteCurrentSceneToolStripMenuItem_Click);
            // 
            // reloadToolStripMenuItem
            // 
            resources.ApplyResources(this.reloadToolStripMenuItem, "reloadToolStripMenuItem");
            this.reloadToolStripMenuItem.ForeColor = System.Drawing.Color.Beige;
            this.reloadToolStripMenuItem.Name = "reloadToolStripMenuItem";
            this.reloadToolStripMenuItem.Click += new System.EventHandler(this.reloadToolStripMenuItem_Click);
            // 
            // splitContainer2
            // 
            resources.ApplyResources(this.splitContainer2, "splitContainer2");
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            resources.ApplyResources(this.splitContainer2.Panel1, "splitContainer2.Panel1");
            this.splitContainer2.Panel1.Controls.Add(this.splitContainer3);
            // 
            // splitContainer2.Panel2
            // 
            resources.ApplyResources(this.splitContainer2.Panel2, "splitContainer2.Panel2");
            this.splitContainer2.Panel2.Controls.Add(this.Inspector);
            // 
            // splitContainer3
            // 
            resources.ApplyResources(this.splitContainer3, "splitContainer3");
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            resources.ApplyResources(this.splitContainer3.Panel1, "splitContainer3.Panel1");
            this.splitContainer3.Panel1.Controls.Add(this.Scene);
            this.splitContainer3.Panel1.Controls.Add(this.panel3);
            // 
            // splitContainer3.Panel2
            // 
            resources.ApplyResources(this.splitContainer3.Panel2, "splitContainer3.Panel2");
            this.splitContainer3.Panel2.Controls.Add(this.TabControl);
            // 
            // Scene
            // 
            resources.ApplyResources(this.Scene, "Scene");
            this.Scene.Name = "Scene";
            this.Scene.TabStop = false;
            this.Scene.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Scene_MouseDown);
            this.Scene.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Scene_MouseUp);
            // 
            // panel3
            // 
            resources.ApplyResources(this.panel3, "panel3");
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.panel3.Controls.Add(this.toolStrip2);
            this.panel3.Name = "panel3";
            // 
            // toolStrip2
            // 
            resources.ApplyResources(this.toolStrip2, "toolStrip2");
            this.toolStrip2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SceneCameraSpeedTSCB,
            this.SCPTSB});
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            // 
            // SceneCameraSpeedTSCB
            // 
            resources.ApplyResources(this.SceneCameraSpeedTSCB, "SceneCameraSpeedTSCB");
            this.SceneCameraSpeedTSCB.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.SceneCameraSpeedTSCB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.SceneCameraSpeedTSCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SceneCameraSpeedTSCB.DropDownWidth = 121;
            this.SceneCameraSpeedTSCB.ForeColor = System.Drawing.Color.Beige;
            this.SceneCameraSpeedTSCB.Items.AddRange(new object[] {
            resources.GetString("SceneCameraSpeedTSCB.Items"),
            resources.GetString("SceneCameraSpeedTSCB.Items1"),
            resources.GetString("SceneCameraSpeedTSCB.Items2"),
            resources.GetString("SceneCameraSpeedTSCB.Items3"),
            resources.GetString("SceneCameraSpeedTSCB.Items4"),
            resources.GetString("SceneCameraSpeedTSCB.Items5"),
            resources.GetString("SceneCameraSpeedTSCB.Items6"),
            resources.GetString("SceneCameraSpeedTSCB.Items7"),
            resources.GetString("SceneCameraSpeedTSCB.Items8"),
            resources.GetString("SceneCameraSpeedTSCB.Items9"),
            resources.GetString("SceneCameraSpeedTSCB.Items10")});
            this.SceneCameraSpeedTSCB.Name = "SceneCameraSpeedTSCB";
            // 
            // SCPTSB
            // 
            resources.ApplyResources(this.SCPTSB, "SCPTSB");
            this.SCPTSB.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.SCPTSB.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.SCPTSB.Name = "SCPTSB";
            this.SCPTSB.Click += new System.EventHandler(this.SCPTSB_Click);
            // 
            // TabControl
            // 
            resources.ApplyResources(this.TabControl, "TabControl");
            this.TabControl.Controls.Add(this.ConsoleTabPage);
            this.TabControl.Controls.Add(this.Assets);
            this.TabControl.Controls.Add(this.ResourcesTabPage);
            this.TabControl.Controls.Add(this.tabPage1);
            this.TabControl.HotTrack = true;
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedIndex = 0;
            // 
            // ConsoleTabPage
            // 
            resources.ApplyResources(this.ConsoleTabPage, "ConsoleTabPage");
            this.ConsoleTabPage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.ConsoleTabPage.Controls.Add(this.Console);
            this.ConsoleTabPage.ForeColor = System.Drawing.Color.Beige;
            this.ConsoleTabPage.Name = "ConsoleTabPage";
            // 
            // Console
            // 
            resources.ApplyResources(this.Console, "Console");
            this.Console.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.Console.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Console.ContextMenuStrip = this.ConsoleCMS;
            this.Console.Cursor = System.Windows.Forms.Cursors.Default;
            this.Console.ForeColor = System.Drawing.Color.Beige;
            this.Console.Name = "Console";
            this.Console.ReadOnly = true;
            // 
            // ConsoleCMS
            // 
            resources.ApplyResources(this.ConsoleCMS, "ConsoleCMS");
            this.ConsoleCMS.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.ConsoleCMS.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearToolStripMenuItem,
            this.debugRepeatToolStripMenuItem,
            this.clearOnPlayToolStripMenuItem});
            this.ConsoleCMS.Name = "ConsoleCMS";
            this.ConsoleCMS.ShowImageMargin = false;
            // 
            // clearToolStripMenuItem
            // 
            resources.ApplyResources(this.clearToolStripMenuItem, "clearToolStripMenuItem");
            this.clearToolStripMenuItem.AutoToolTip = true;
            this.clearToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.clearToolStripMenuItem.ForeColor = System.Drawing.Color.Crimson;
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            this.clearToolStripMenuItem.Click += new System.EventHandler(this.clearToolStripMenuItem_Click);
            // 
            // debugRepeatToolStripMenuItem
            // 
            resources.ApplyResources(this.debugRepeatToolStripMenuItem, "debugRepeatToolStripMenuItem");
            this.debugRepeatToolStripMenuItem.CheckOnClick = true;
            this.debugRepeatToolStripMenuItem.ForeColor = System.Drawing.Color.Beige;
            this.debugRepeatToolStripMenuItem.Name = "debugRepeatToolStripMenuItem";
            this.debugRepeatToolStripMenuItem.CheckedChanged += new System.EventHandler(this.debugRepeatToolStripMenuItem_CheckedChanged);
            // 
            // clearOnPlayToolStripMenuItem
            // 
            resources.ApplyResources(this.clearOnPlayToolStripMenuItem, "clearOnPlayToolStripMenuItem");
            this.clearOnPlayToolStripMenuItem.Checked = true;
            this.clearOnPlayToolStripMenuItem.CheckOnClick = true;
            this.clearOnPlayToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.clearOnPlayToolStripMenuItem.ForeColor = System.Drawing.Color.Beige;
            this.clearOnPlayToolStripMenuItem.Name = "clearOnPlayToolStripMenuItem";
            // 
            // Assets
            // 
            resources.ApplyResources(this.Assets, "Assets");
            this.Assets.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.Assets.Controls.Add(this.AssetListView);
            this.Assets.Controls.Add(this.panel1);
            this.Assets.Name = "Assets";
            // 
            // AssetListView
            // 
            resources.ApplyResources(this.AssetListView, "AssetListView");
            this.AssetListView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.AssetListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.AssetListView.ForeColor = System.Drawing.Color.Beige;
            this.AssetListView.GridLines = true;
            this.AssetListView.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            ((System.Windows.Forms.ListViewGroup)(resources.GetObject("AssetListView.Groups"))),
            ((System.Windows.Forms.ListViewGroup)(resources.GetObject("AssetListView.Groups1")))});
            this.AssetListView.HideSelection = false;
            this.AssetListView.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            ((System.Windows.Forms.ListViewItem)(resources.GetObject("AssetListView.Items"))),
            ((System.Windows.Forms.ListViewItem)(resources.GetObject("AssetListView.Items1")))});
            this.AssetListView.LargeImageList = this.AssetsImageList;
            this.AssetListView.Name = "AssetListView";
            this.AssetListView.SmallImageList = this.AssetsImageList;
            this.AssetListView.StateImageList = this.AssetsImageList;
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
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Controls.Add(this.AssetLocation);
            this.panel1.Controls.Add(this.AssetBack);
            this.panel1.Controls.Add(this.AssetHome);
            this.panel1.Name = "panel1";
            // 
            // AssetLocation
            // 
            resources.ApplyResources(this.AssetLocation, "AssetLocation");
            this.AssetLocation.AutoWordSelection = true;
            this.AssetLocation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.AssetLocation.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.AssetLocation.ContextMenuStrip = this.AssetLocationCMS;
            this.AssetLocation.Cursor = System.Windows.Forms.Cursors.Default;
            this.AssetLocation.DetectUrls = false;
            this.AssetLocation.ForeColor = System.Drawing.Color.Beige;
            this.AssetLocation.Name = "AssetLocation";
            this.AssetLocation.ReadOnly = true;
            // 
            // AssetLocationCMS
            // 
            resources.ApplyResources(this.AssetLocationCMS, "AssetLocationCMS");
            this.AssetLocationCMS.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showInFileExplorerToolStripMenuItem});
            this.AssetLocationCMS.Name = "AssetLocationCMS";
            // 
            // showInFileExplorerToolStripMenuItem
            // 
            resources.ApplyResources(this.showInFileExplorerToolStripMenuItem, "showInFileExplorerToolStripMenuItem");
            this.showInFileExplorerToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.showInFileExplorerToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.showInFileExplorerToolStripMenuItem.ForeColor = System.Drawing.Color.DarkCyan;
            this.showInFileExplorerToolStripMenuItem.Name = "showInFileExplorerToolStripMenuItem";
            this.showInFileExplorerToolStripMenuItem.Click += new System.EventHandler(this.showInFileExplorerToolStripMenuItem_Click);
            // 
            // AssetBack
            // 
            resources.ApplyResources(this.AssetBack, "AssetBack");
            this.AssetBack.Image = global::Wingine.Editor.Properties.Resources.back;
            this.AssetBack.Name = "AssetBack";
            this.AssetBack.TabStop = false;
            this.AssetBack.Click += new System.EventHandler(this.AssetBack_Click);
            // 
            // AssetHome
            // 
            resources.ApplyResources(this.AssetHome, "AssetHome");
            this.AssetHome.Image = global::Wingine.Editor.Properties.Resources.home;
            this.AssetHome.Name = "AssetHome";
            this.AssetHome.TabStop = false;
            this.AssetHome.Click += new System.EventHandler(this.AssetHome_Click);
            // 
            // ResourcesTabPage
            // 
            resources.ApplyResources(this.ResourcesTabPage, "ResourcesTabPage");
            this.ResourcesTabPage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.ResourcesTabPage.Controls.Add(this.ResourcesTable);
            this.ResourcesTabPage.Controls.Add(this.panel2);
            this.ResourcesTabPage.Name = "ResourcesTabPage";
            // 
            // ResourcesTable
            // 
            resources.ApplyResources(this.ResourcesTable, "ResourcesTable");
            this.ResourcesTable.Name = "ResourcesTable";
            // 
            // panel2
            // 
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Name = "panel2";
            // 
            // tabPage1
            // 
            resources.ApplyResources(this.tabPage1, "tabPage1");
            this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.tabPage1.Controls.Add(this.rtb_threads);
            this.tabPage1.Name = "tabPage1";
            // 
            // rtb_threads
            // 
            resources.ApplyResources(this.rtb_threads, "rtb_threads");
            this.rtb_threads.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.rtb_threads.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtb_threads.ForeColor = System.Drawing.Color.Beige;
            this.rtb_threads.Name = "rtb_threads";
            this.rtb_threads.ReadOnly = true;
            // 
            // Inspector
            // 
            resources.ApplyResources(this.Inspector, "Inspector");
            this.Inspector.Name = "Inspector";
            // 
            // ToolsBar
            // 
            resources.ApplyResources(this.ToolsBar, "ToolsBar");
            this.ToolsBar.AccessibleRole = System.Windows.Forms.AccessibleRole.ToolBar;
            this.ToolsBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.ToolsBar.CanOverflow = false;
            this.ToolsBar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.ToolsBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1,
            this.toolStripButton1,
            this.toolStripSeparator3,
            this.BuildGameTSB,
            this.PixelEditor_TSB,
            this.toolStripSeparator4,
            this.SceneMenuTSB,
            this.CurrentSceneNameTSTB});
            this.ToolsBar.Name = "ToolsBar";
            this.ToolsBar.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.ToolsBar.Stretch = true;
            // 
            // toolStripDropDownButton1
            // 
            resources.ApplyResources(this.toolStripDropDownButton1, "toolStripDropDownButton1");
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
            this.toolStripDropDownButton1.ForeColor = System.Drawing.Color.Beige;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            // 
            // newProjectToolStripMenuItem
            // 
            resources.ApplyResources(this.newProjectToolStripMenuItem, "newProjectToolStripMenuItem");
            this.newProjectToolStripMenuItem.Name = "newProjectToolStripMenuItem";
            this.newProjectToolStripMenuItem.Click += new System.EventHandler(this.newProjectToolStripMenuItem_Click);
            // 
            // openProjectToolStripMenuItem
            // 
            resources.ApplyResources(this.openProjectToolStripMenuItem, "openProjectToolStripMenuItem");
            this.openProjectToolStripMenuItem.Name = "openProjectToolStripMenuItem";
            this.openProjectToolStripMenuItem.Click += new System.EventHandler(this.openProjectToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            // 
            // saveToolStripMenuItem
            // 
            resources.ApplyResources(this.saveToolStripMenuItem, "saveToolStripMenuItem");
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            resources.ApplyResources(this.saveAsToolStripMenuItem, "saveAsToolStripMenuItem");
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            // 
            // exitToolStripMenuItem
            // 
            resources.ApplyResources(this.exitToolStripMenuItem, "exitToolStripMenuItem");
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // toolStripButton1
            // 
            resources.ApplyResources(this.toolStripButton1, "toolStripButton1");
            this.toolStripButton1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showFPSToolStripMenuItem,
            this.showDiagnosticsToolStripMenuItem,
            this.changeProjectNameToolStripMenuItem,
            this.changeApplicationTitleToolStripMenuItem});
            this.toolStripButton1.Name = "toolStripButton1";
            // 
            // showFPSToolStripMenuItem
            // 
            resources.ApplyResources(this.showFPSToolStripMenuItem, "showFPSToolStripMenuItem");
            this.showFPSToolStripMenuItem.CheckOnClick = true;
            this.showFPSToolStripMenuItem.Name = "showFPSToolStripMenuItem";
            // 
            // showDiagnosticsToolStripMenuItem
            // 
            resources.ApplyResources(this.showDiagnosticsToolStripMenuItem, "showDiagnosticsToolStripMenuItem");
            this.showDiagnosticsToolStripMenuItem.CheckOnClick = true;
            this.showDiagnosticsToolStripMenuItem.Name = "showDiagnosticsToolStripMenuItem";
            // 
            // changeProjectNameToolStripMenuItem
            // 
            resources.ApplyResources(this.changeProjectNameToolStripMenuItem, "changeProjectNameToolStripMenuItem");
            this.changeProjectNameToolStripMenuItem.Name = "changeProjectNameToolStripMenuItem";
            this.changeProjectNameToolStripMenuItem.Click += new System.EventHandler(this.changeProjectNameToolStripMenuItem_Click);
            // 
            // changeApplicationTitleToolStripMenuItem
            // 
            resources.ApplyResources(this.changeApplicationTitleToolStripMenuItem, "changeApplicationTitleToolStripMenuItem");
            this.changeApplicationTitleToolStripMenuItem.Name = "changeApplicationTitleToolStripMenuItem";
            this.changeApplicationTitleToolStripMenuItem.Click += new System.EventHandler(this.changeApplicationTitleToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            resources.ApplyResources(this.toolStripSeparator3, "toolStripSeparator3");
            this.toolStripSeparator3.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            // 
            // BuildGameTSB
            // 
            resources.ApplyResources(this.BuildGameTSB, "BuildGameTSB");
            this.BuildGameTSB.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.BuildGameTSB.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BuildGameTSB.Image = global::Wingine.Editor.Properties.Resources.build;
            this.BuildGameTSB.Name = "BuildGameTSB";
            this.BuildGameTSB.Click += new System.EventHandler(this.BuildGameTSB_Click);
            // 
            // PixelEditor_TSB
            // 
            resources.ApplyResources(this.PixelEditor_TSB, "PixelEditor_TSB");
            this.PixelEditor_TSB.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.PixelEditor_TSB.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.PixelEditor_TSB.Image = global::Wingine.Editor.Properties.Resources.pixels;
            this.PixelEditor_TSB.Name = "PixelEditor_TSB";
            this.PixelEditor_TSB.Click += new System.EventHandler(this.PixelEditor_TSB_Click);
            // 
            // toolStripSeparator4
            // 
            resources.ApplyResources(this.toolStripSeparator4, "toolStripSeparator4");
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            // 
            // SceneMenuTSB
            // 
            resources.ApplyResources(this.SceneMenuTSB, "SceneMenuTSB");
            this.SceneMenuTSB.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.SceneMenuTSB.ForeColor = System.Drawing.Color.Beige;
            this.SceneMenuTSB.Image = global::Wingine.Editor.Properties.Resources.rubik;
            this.SceneMenuTSB.Name = "SceneMenuTSB";
            this.SceneMenuTSB.Click += new System.EventHandler(this.SceneMenuTSB_Click);
            // 
            // CurrentSceneNameTSTB
            // 
            resources.ApplyResources(this.CurrentSceneNameTSTB, "CurrentSceneNameTSTB");
            this.CurrentSceneNameTSTB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.CurrentSceneNameTSTB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CurrentSceneNameTSTB.ForeColor = System.Drawing.Color.Beige;
            this.CurrentSceneNameTSTB.Name = "CurrentSceneNameTSTB";
            this.CurrentSceneNameTSTB.TextChanged += new System.EventHandler(this.CurrentSceneNameTSTB_TextChanged);
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
            resources.ApplyResources(this.toolStrip1, "toolStrip1");
            this.toolStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.toolStrip1.CanOverflow = false;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PlayStopTSB});
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStrip1.Stretch = true;
            // 
            // PlayStopTSB
            // 
            resources.ApplyResources(this.PlayStopTSB, "PlayStopTSB");
            this.PlayStopTSB.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.PlayStopTSB.Image = global::Wingine.Editor.Properties.Resources.play2;
            this.PlayStopTSB.Name = "PlayStopTSB";
            this.PlayStopTSB.Click += new System.EventHandler(this.PlayStopTSB_Click);
            // 
            // StatusBar
            // 
            resources.ApplyResources(this.StatusBar, "StatusBar");
            this.StatusBar.BackColor = System.Drawing.Color.Transparent;
            this.StatusBar.ForeColor = System.Drawing.Color.Beige;
            this.StatusBar.Name = "StatusBar";
            // 
            // Window
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.Controls.Add(this.ToolsBar);
            this.Controls.Add(this.StatusBar);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.splitContainer1);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.Beige;
            this.HelpButton = true;
            this.Name = "Window";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
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
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.TabControl.ResumeLayout(false);
            this.ConsoleTabPage.ResumeLayout(false);
            this.ConsoleCMS.ResumeLayout(false);
            this.Assets.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.AssetLocationCMS.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.AssetBack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AssetHome)).EndInit();
            this.ResourcesTabPage.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
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
        private System.Windows.Forms.ToolStripMenuItem emptyToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem uIToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem canvasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem textToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem buttonToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cameraToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearOnPlayToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel ResourcesTable;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ToolStripTextBox CurrentSceneNameTSTB;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.RichTextBox rtb_threads;
        private System.Windows.Forms.ToolStripMenuItem changeProjectNameToolStripMenuItem;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripComboBox SceneCameraSpeedTSCB;
        private System.Windows.Forms.ToolStripButton SCPTSB;
        private System.Windows.Forms.ToolStripMenuItem changeApplicationTitleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem defaultSceneToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem showDiagnosticsToolStripMenuItem;
    }
}

