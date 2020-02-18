namespace TrolyaoFara
{
    partial class FrmDashboard
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
            BunifuAnimatorNS.Animation animation2 = new BunifuAnimatorNS.Animation();
            BunifuAnimatorNS.Animation animation1 = new BunifuAnimatorNS.Animation();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDashboard));
            this.panel_Main = new System.Windows.Forms.TableLayoutPanel();
            this.panel_TopMenu = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnMinimize = new Bunifu.Framework.UI.BunifuImageButton();
            this.lblButton = new System.Windows.Forms.Label();
            this.btnClose = new Bunifu.Framework.UI.BunifuImageButton();
            this.btnFullScreen = new Bunifu.Framework.UI.BunifuImageButton();
            this.btnRestore_down = new Bunifu.Framework.UI.BunifuImageButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCustomSidebar = new Bunifu.Framework.UI.BunifuImageButton();
            this.lblDashboard = new System.Windows.Forms.Label();
            this.panelContent = new System.Windows.Forms.Panel();
            this.panelOpenform = new System.Windows.Forms.Panel();
            this.SidebarWapper = new System.Windows.Forms.Panel();
            this.Sidebar = new Bunifu.Framework.UI.BunifuGradientPanel();
            this.indicator = new System.Windows.Forms.PictureBox();
            this.btnAbout = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnSetting = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnAccount = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnMenu = new Bunifu.Framework.UI.BunifuFlatButton();
            this.ptLogo2 = new System.Windows.Forms.PictureBox();
            this.lblFara = new System.Windows.Forms.Label();
            this.ptLogo1 = new System.Windows.Forms.PictureBox();
            this.btnHome = new Bunifu.Framework.UI.BunifuFlatButton();
            this.LinearSidebar = new Bunifu.Framework.UI.BunifuSeparator();
            this.borderSidebar = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.AnimationSidebar = new BunifuAnimatorNS.BunifuTransition(this.components);
            this.AnimationSidebarBack = new BunifuAnimatorNS.BunifuTransition(this.components);
            this.bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.BoderfrmDashboard = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.gunaElipse1 = new Guna.UI.WinForms.GunaElipse(this.components);
            this.panel_Main.SuspendLayout();
            this.panel_TopMenu.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnFullScreen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRestore_down)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCustomSidebar)).BeginInit();
            this.panelContent.SuspendLayout();
            this.SidebarWapper.SuspendLayout();
            this.Sidebar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.indicator)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptLogo2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptLogo1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel_Main
            // 
            this.panel_Main.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(46)))));
            this.panel_Main.ColumnCount = 1;
            this.panel_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panel_Main.Controls.Add(this.panel_TopMenu, 0, 0);
            this.panel_Main.Controls.Add(this.panelContent, 0, 1);
            this.AnimationSidebar.SetDecoration(this.panel_Main, BunifuAnimatorNS.DecorationType.None);
            this.AnimationSidebarBack.SetDecoration(this.panel_Main, BunifuAnimatorNS.DecorationType.None);
            this.panel_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_Main.Location = new System.Drawing.Point(0, 0);
            this.panel_Main.Name = "panel_Main";
            this.panel_Main.RowCount = 2;
            this.panel_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.panel_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panel_Main.Size = new System.Drawing.Size(1000, 600);
            this.panel_Main.TabIndex = 0;
            // 
            // panel_TopMenu
            // 
            this.panel_TopMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(46)))));
            this.panel_TopMenu.ColumnCount = 2;
            this.panel_TopMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.53247F));
            this.panel_TopMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 82.46753F));
            this.panel_TopMenu.Controls.Add(this.panel2, 1, 0);
            this.panel_TopMenu.Controls.Add(this.panel1, 0, 0);
            this.AnimationSidebarBack.SetDecoration(this.panel_TopMenu, BunifuAnimatorNS.DecorationType.None);
            this.AnimationSidebar.SetDecoration(this.panel_TopMenu, BunifuAnimatorNS.DecorationType.None);
            this.panel_TopMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_TopMenu.Location = new System.Drawing.Point(3, 3);
            this.panel_TopMenu.Name = "panel_TopMenu";
            this.panel_TopMenu.RowCount = 1;
            this.panel_TopMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.panel_TopMenu.Size = new System.Drawing.Size(994, 44);
            this.panel_TopMenu.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnMinimize);
            this.panel2.Controls.Add(this.lblButton);
            this.panel2.Controls.Add(this.btnClose);
            this.panel2.Controls.Add(this.btnFullScreen);
            this.panel2.Controls.Add(this.btnRestore_down);
            this.AnimationSidebarBack.SetDecoration(this.panel2, BunifuAnimatorNS.DecorationType.None);
            this.AnimationSidebar.SetDecoration(this.panel2, BunifuAnimatorNS.DecorationType.None);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(177, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(814, 38);
            this.panel2.TabIndex = 1;
            // 
            // btnMinimize
            // 
            this.btnMinimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMinimize.BackColor = System.Drawing.Color.Transparent;
            this.btnMinimize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AnimationSidebarBack.SetDecoration(this.btnMinimize, BunifuAnimatorNS.DecorationType.None);
            this.AnimationSidebar.SetDecoration(this.btnMinimize, BunifuAnimatorNS.DecorationType.None);
            this.btnMinimize.Image = ((System.Drawing.Image)(resources.GetObject("btnMinimize.Image")));
            this.btnMinimize.ImageActive = null;
            this.btnMinimize.Location = new System.Drawing.Point(762, 3);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(22, 22);
            this.btnMinimize.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnMinimize.TabIndex = 13;
            this.btnMinimize.TabStop = false;
            this.btnMinimize.Zoom = 10;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // lblButton
            // 
            this.lblButton.AutoSize = true;
            this.lblButton.BackColor = System.Drawing.Color.White;
            this.AnimationSidebar.SetDecoration(this.lblButton, BunifuAnimatorNS.DecorationType.None);
            this.AnimationSidebarBack.SetDecoration(this.lblButton, BunifuAnimatorNS.DecorationType.None);
            this.lblButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(46)))));
            this.lblButton.Location = new System.Drawing.Point(53, 14);
            this.lblButton.Name = "lblButton";
            this.lblButton.Size = new System.Drawing.Size(48, 13);
            this.lblButton.TabIndex = 1;
            this.lblButton.Text = "lblButton";
            this.lblButton.Visible = false;
            this.lblButton.TextChanged += new System.EventHandler(this.lblButton_TextChanged);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AnimationSidebarBack.SetDecoration(this.btnClose, BunifuAnimatorNS.DecorationType.None);
            this.AnimationSidebar.SetDecoration(this.btnClose, BunifuAnimatorNS.DecorationType.None);
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageActive = null;
            this.btnClose.Location = new System.Drawing.Point(787, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(22, 22);
            this.btnClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnClose.TabIndex = 16;
            this.btnClose.TabStop = false;
            this.btnClose.Zoom = 10;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnFullScreen
            // 
            this.btnFullScreen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFullScreen.BackColor = System.Drawing.Color.Transparent;
            this.btnFullScreen.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AnimationSidebarBack.SetDecoration(this.btnFullScreen, BunifuAnimatorNS.DecorationType.None);
            this.AnimationSidebar.SetDecoration(this.btnFullScreen, BunifuAnimatorNS.DecorationType.None);
            this.btnFullScreen.Image = ((System.Drawing.Image)(resources.GetObject("btnFullScreen.Image")));
            this.btnFullScreen.ImageActive = null;
            this.btnFullScreen.Location = new System.Drawing.Point(762, 3);
            this.btnFullScreen.Name = "btnFullScreen";
            this.btnFullScreen.Size = new System.Drawing.Size(22, 22);
            this.btnFullScreen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnFullScreen.TabIndex = 15;
            this.btnFullScreen.TabStop = false;
            this.btnFullScreen.Zoom = 10;
            this.btnFullScreen.Click += new System.EventHandler(this.btnFullScreen_Click);
            // 
            // btnRestore_down
            // 
            this.btnRestore_down.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRestore_down.BackColor = System.Drawing.Color.Transparent;
            this.btnRestore_down.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AnimationSidebarBack.SetDecoration(this.btnRestore_down, BunifuAnimatorNS.DecorationType.None);
            this.AnimationSidebar.SetDecoration(this.btnRestore_down, BunifuAnimatorNS.DecorationType.None);
            this.btnRestore_down.Image = ((System.Drawing.Image)(resources.GetObject("btnRestore_down.Image")));
            this.btnRestore_down.ImageActive = null;
            this.btnRestore_down.Location = new System.Drawing.Point(762, 3);
            this.btnRestore_down.Name = "btnRestore_down";
            this.btnRestore_down.Size = new System.Drawing.Size(22, 22);
            this.btnRestore_down.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnRestore_down.TabIndex = 14;
            this.btnRestore_down.TabStop = false;
            this.btnRestore_down.Zoom = 10;
            this.btnRestore_down.Click += new System.EventHandler(this.btnRestore_down_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnCustomSidebar);
            this.panel1.Controls.Add(this.lblDashboard);
            this.AnimationSidebarBack.SetDecoration(this.panel1, BunifuAnimatorNS.DecorationType.None);
            this.AnimationSidebar.SetDecoration(this.panel1, BunifuAnimatorNS.DecorationType.None);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(168, 38);
            this.panel1.TabIndex = 0;
            // 
            // btnCustomSidebar
            // 
            this.btnCustomSidebar.BackColor = System.Drawing.Color.Transparent;
            this.btnCustomSidebar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AnimationSidebarBack.SetDecoration(this.btnCustomSidebar, BunifuAnimatorNS.DecorationType.None);
            this.AnimationSidebar.SetDecoration(this.btnCustomSidebar, BunifuAnimatorNS.DecorationType.None);
            this.btnCustomSidebar.Image = ((System.Drawing.Image)(resources.GetObject("btnCustomSidebar.Image")));
            this.btnCustomSidebar.ImageActive = null;
            this.btnCustomSidebar.Location = new System.Drawing.Point(9, 3);
            this.btnCustomSidebar.Name = "btnCustomSidebar";
            this.btnCustomSidebar.Size = new System.Drawing.Size(30, 30);
            this.btnCustomSidebar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnCustomSidebar.TabIndex = 12;
            this.btnCustomSidebar.TabStop = false;
            this.btnCustomSidebar.Zoom = 10;
            this.btnCustomSidebar.Click += new System.EventHandler(this.imgCustomSidebar_Click);
            // 
            // lblDashboard
            // 
            this.lblDashboard.AutoSize = true;
            this.lblDashboard.BackColor = System.Drawing.Color.Transparent;
            this.AnimationSidebar.SetDecoration(this.lblDashboard, BunifuAnimatorNS.DecorationType.None);
            this.AnimationSidebarBack.SetDecoration(this.lblDashboard, BunifuAnimatorNS.DecorationType.None);
            this.lblDashboard.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDashboard.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblDashboard.Location = new System.Drawing.Point(41, 5);
            this.lblDashboard.Name = "lblDashboard";
            this.lblDashboard.Size = new System.Drawing.Size(127, 25);
            this.lblDashboard.TabIndex = 13;
            this.lblDashboard.Text = "DASHBOARD";
            // 
            // panelContent
            // 
            this.panelContent.Controls.Add(this.panelOpenform);
            this.panelContent.Controls.Add(this.SidebarWapper);
            this.AnimationSidebarBack.SetDecoration(this.panelContent, BunifuAnimatorNS.DecorationType.None);
            this.AnimationSidebar.SetDecoration(this.panelContent, BunifuAnimatorNS.DecorationType.None);
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(3, 53);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(994, 544);
            this.panelContent.TabIndex = 1;
            // 
            // panelOpenform
            // 
            this.panelOpenform.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(46)))));
            this.AnimationSidebarBack.SetDecoration(this.panelOpenform, BunifuAnimatorNS.DecorationType.None);
            this.AnimationSidebar.SetDecoration(this.panelOpenform, BunifuAnimatorNS.DecorationType.None);
            this.panelOpenform.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelOpenform.Location = new System.Drawing.Point(212, 0);
            this.panelOpenform.Name = "panelOpenform";
            this.panelOpenform.Size = new System.Drawing.Size(782, 544);
            this.panelOpenform.TabIndex = 2;
            // 
            // SidebarWapper
            // 
            this.SidebarWapper.Controls.Add(this.Sidebar);
            this.AnimationSidebarBack.SetDecoration(this.SidebarWapper, BunifuAnimatorNS.DecorationType.None);
            this.AnimationSidebar.SetDecoration(this.SidebarWapper, BunifuAnimatorNS.DecorationType.None);
            this.SidebarWapper.Dock = System.Windows.Forms.DockStyle.Left;
            this.SidebarWapper.Location = new System.Drawing.Point(0, 0);
            this.SidebarWapper.Name = "SidebarWapper";
            this.SidebarWapper.Size = new System.Drawing.Size(212, 544);
            this.SidebarWapper.TabIndex = 1;
            // 
            // Sidebar
            // 
            this.Sidebar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.Sidebar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Sidebar.BackgroundImage")));
            this.Sidebar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Sidebar.Controls.Add(this.indicator);
            this.Sidebar.Controls.Add(this.btnAbout);
            this.Sidebar.Controls.Add(this.btnSetting);
            this.Sidebar.Controls.Add(this.btnAccount);
            this.Sidebar.Controls.Add(this.btnMenu);
            this.Sidebar.Controls.Add(this.ptLogo2);
            this.Sidebar.Controls.Add(this.lblFara);
            this.Sidebar.Controls.Add(this.ptLogo1);
            this.Sidebar.Controls.Add(this.btnHome);
            this.Sidebar.Controls.Add(this.LinearSidebar);
            this.AnimationSidebarBack.SetDecoration(this.Sidebar, BunifuAnimatorNS.DecorationType.None);
            this.AnimationSidebar.SetDecoration(this.Sidebar, BunifuAnimatorNS.DecorationType.None);
            this.Sidebar.GradientBottomLeft = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(21)))), ((int)(((byte)(80)))));
            this.Sidebar.GradientBottomRight = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(21)))), ((int)(((byte)(80)))));
            this.Sidebar.GradientTopLeft = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(21)))), ((int)(((byte)(80)))));
            this.Sidebar.GradientTopRight = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(46)))));
            this.Sidebar.Location = new System.Drawing.Point(7, 5);
            this.Sidebar.Name = "Sidebar";
            this.Sidebar.Quality = 10;
            this.Sidebar.Size = new System.Drawing.Size(200, 530);
            this.Sidebar.TabIndex = 0;
            // 
            // indicator
            // 
            this.indicator.BackColor = System.Drawing.Color.White;
            this.AnimationSidebar.SetDecoration(this.indicator, BunifuAnimatorNS.DecorationType.None);
            this.AnimationSidebarBack.SetDecoration(this.indicator, BunifuAnimatorNS.DecorationType.None);
            this.indicator.Location = new System.Drawing.Point(5, 82);
            this.indicator.Name = "indicator";
            this.indicator.Size = new System.Drawing.Size(4, 30);
            this.indicator.TabIndex = 5;
            this.indicator.TabStop = false;
            // 
            // btnAbout
            // 
            this.btnAbout.Active = false;
            this.btnAbout.Activecolor = System.Drawing.Color.Transparent;
            this.btnAbout.BackColor = System.Drawing.Color.Transparent;
            this.btnAbout.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAbout.BorderRadius = 0;
            this.btnAbout.ButtonText = "     THÔNG TIN";
            this.btnAbout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AnimationSidebarBack.SetDecoration(this.btnAbout, BunifuAnimatorNS.DecorationType.None);
            this.AnimationSidebar.SetDecoration(this.btnAbout, BunifuAnimatorNS.DecorationType.None);
            this.btnAbout.DisabledColor = System.Drawing.Color.Gray;
            this.btnAbout.Iconcolor = System.Drawing.Color.Transparent;
            this.btnAbout.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnAbout.Iconimage")));
            this.btnAbout.Iconimage_right = null;
            this.btnAbout.Iconimage_right_Selected = null;
            this.btnAbout.Iconimage_Selected = null;
            this.btnAbout.IconMarginLeft = 0;
            this.btnAbout.IconMarginRight = 0;
            this.btnAbout.IconRightVisible = true;
            this.btnAbout.IconRightZoom = 60D;
            this.btnAbout.IconVisible = true;
            this.btnAbout.IconZoom = 50D;
            this.btnAbout.IsTab = false;
            this.btnAbout.Location = new System.Drawing.Point(5, 289);
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Normalcolor = System.Drawing.Color.Transparent;
            this.btnAbout.OnHovercolor = System.Drawing.Color.Transparent;
            this.btnAbout.OnHoverTextColor = System.Drawing.Color.White;
            this.btnAbout.selected = false;
            this.btnAbout.Size = new System.Drawing.Size(185, 48);
            this.btnAbout.TabIndex = 8;
            this.btnAbout.Text = "     THÔNG TIN";
            this.btnAbout.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAbout.Textcolor = System.Drawing.Color.LightGray;
            this.btnAbout.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);
            // 
            // btnSetting
            // 
            this.btnSetting.Active = false;
            this.btnSetting.Activecolor = System.Drawing.Color.Transparent;
            this.btnSetting.BackColor = System.Drawing.Color.Transparent;
            this.btnSetting.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSetting.BorderRadius = 0;
            this.btnSetting.ButtonText = "     CÀI ĐẶT";
            this.btnSetting.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AnimationSidebarBack.SetDecoration(this.btnSetting, BunifuAnimatorNS.DecorationType.None);
            this.AnimationSidebar.SetDecoration(this.btnSetting, BunifuAnimatorNS.DecorationType.None);
            this.btnSetting.DisabledColor = System.Drawing.Color.Gray;
            this.btnSetting.Iconcolor = System.Drawing.Color.Transparent;
            this.btnSetting.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnSetting.Iconimage")));
            this.btnSetting.Iconimage_right = null;
            this.btnSetting.Iconimage_right_Selected = null;
            this.btnSetting.Iconimage_Selected = null;
            this.btnSetting.IconMarginLeft = 0;
            this.btnSetting.IconMarginRight = 0;
            this.btnSetting.IconRightVisible = true;
            this.btnSetting.IconRightZoom = 60D;
            this.btnSetting.IconVisible = true;
            this.btnSetting.IconZoom = 50D;
            this.btnSetting.IsTab = false;
            this.btnSetting.Location = new System.Drawing.Point(5, 235);
            this.btnSetting.Name = "btnSetting";
            this.btnSetting.Normalcolor = System.Drawing.Color.Transparent;
            this.btnSetting.OnHovercolor = System.Drawing.Color.Transparent;
            this.btnSetting.OnHoverTextColor = System.Drawing.Color.White;
            this.btnSetting.selected = false;
            this.btnSetting.Size = new System.Drawing.Size(185, 48);
            this.btnSetting.TabIndex = 7;
            this.btnSetting.Text = "     CÀI ĐẶT";
            this.btnSetting.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSetting.Textcolor = System.Drawing.Color.LightGray;
            this.btnSetting.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSetting.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // btnAccount
            // 
            this.btnAccount.Active = false;
            this.btnAccount.Activecolor = System.Drawing.Color.Transparent;
            this.btnAccount.BackColor = System.Drawing.Color.Transparent;
            this.btnAccount.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAccount.BorderRadius = 0;
            this.btnAccount.ButtonText = "     TÀI KHOẢN";
            this.btnAccount.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AnimationSidebarBack.SetDecoration(this.btnAccount, BunifuAnimatorNS.DecorationType.None);
            this.AnimationSidebar.SetDecoration(this.btnAccount, BunifuAnimatorNS.DecorationType.None);
            this.btnAccount.DisabledColor = System.Drawing.Color.Gray;
            this.btnAccount.Iconcolor = System.Drawing.Color.Transparent;
            this.btnAccount.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnAccount.Iconimage")));
            this.btnAccount.Iconimage_right = null;
            this.btnAccount.Iconimage_right_Selected = null;
            this.btnAccount.Iconimage_Selected = null;
            this.btnAccount.IconMarginLeft = 0;
            this.btnAccount.IconMarginRight = 0;
            this.btnAccount.IconRightVisible = true;
            this.btnAccount.IconRightZoom = 60D;
            this.btnAccount.IconVisible = true;
            this.btnAccount.IconZoom = 50D;
            this.btnAccount.IsTab = false;
            this.btnAccount.Location = new System.Drawing.Point(5, 181);
            this.btnAccount.Name = "btnAccount";
            this.btnAccount.Normalcolor = System.Drawing.Color.Transparent;
            this.btnAccount.OnHovercolor = System.Drawing.Color.Transparent;
            this.btnAccount.OnHoverTextColor = System.Drawing.Color.White;
            this.btnAccount.selected = false;
            this.btnAccount.Size = new System.Drawing.Size(185, 48);
            this.btnAccount.TabIndex = 6;
            this.btnAccount.Text = "     TÀI KHOẢN";
            this.btnAccount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAccount.Textcolor = System.Drawing.Color.LightGray;
            this.btnAccount.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAccount.Click += new System.EventHandler(this.btnAccount_Click);
            // 
            // btnMenu
            // 
            this.btnMenu.Active = false;
            this.btnMenu.Activecolor = System.Drawing.Color.Transparent;
            this.btnMenu.BackColor = System.Drawing.Color.Transparent;
            this.btnMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnMenu.BorderRadius = 0;
            this.btnMenu.ButtonText = "     THỰC ĐƠN";
            this.btnMenu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AnimationSidebarBack.SetDecoration(this.btnMenu, BunifuAnimatorNS.DecorationType.None);
            this.AnimationSidebar.SetDecoration(this.btnMenu, BunifuAnimatorNS.DecorationType.None);
            this.btnMenu.DisabledColor = System.Drawing.Color.Gray;
            this.btnMenu.Iconcolor = System.Drawing.Color.Transparent;
            this.btnMenu.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnMenu.Iconimage")));
            this.btnMenu.Iconimage_right = null;
            this.btnMenu.Iconimage_right_Selected = null;
            this.btnMenu.Iconimage_Selected = null;
            this.btnMenu.IconMarginLeft = 0;
            this.btnMenu.IconMarginRight = 0;
            this.btnMenu.IconRightVisible = true;
            this.btnMenu.IconRightZoom = 60D;
            this.btnMenu.IconVisible = true;
            this.btnMenu.IconZoom = 50D;
            this.btnMenu.IsTab = false;
            this.btnMenu.Location = new System.Drawing.Point(5, 127);
            this.btnMenu.Name = "btnMenu";
            this.btnMenu.Normalcolor = System.Drawing.Color.Transparent;
            this.btnMenu.OnHovercolor = System.Drawing.Color.Transparent;
            this.btnMenu.OnHoverTextColor = System.Drawing.Color.White;
            this.btnMenu.selected = false;
            this.btnMenu.Size = new System.Drawing.Size(185, 48);
            this.btnMenu.TabIndex = 5;
            this.btnMenu.Text = "     THỰC ĐƠN";
            this.btnMenu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMenu.Textcolor = System.Drawing.Color.LightGray;
            this.btnMenu.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenu.Click += new System.EventHandler(this.btnMenu_Click);
            // 
            // ptLogo2
            // 
            this.ptLogo2.BackColor = System.Drawing.Color.Transparent;
            this.AnimationSidebar.SetDecoration(this.ptLogo2, BunifuAnimatorNS.DecorationType.None);
            this.AnimationSidebarBack.SetDecoration(this.ptLogo2, BunifuAnimatorNS.DecorationType.None);
            this.ptLogo2.Image = ((System.Drawing.Image)(resources.GetObject("ptLogo2.Image")));
            this.ptLogo2.Location = new System.Drawing.Point(11, 12);
            this.ptLogo2.Name = "ptLogo2";
            this.ptLogo2.Size = new System.Drawing.Size(40, 40);
            this.ptLogo2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptLogo2.TabIndex = 4;
            this.ptLogo2.TabStop = false;
            this.ptLogo2.Visible = false;
            // 
            // lblFara
            // 
            this.lblFara.AutoSize = true;
            this.lblFara.BackColor = System.Drawing.Color.Transparent;
            this.AnimationSidebar.SetDecoration(this.lblFara, BunifuAnimatorNS.DecorationType.None);
            this.AnimationSidebarBack.SetDecoration(this.lblFara, BunifuAnimatorNS.DecorationType.None);
            this.lblFara.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFara.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblFara.Location = new System.Drawing.Point(82, 25);
            this.lblFara.Name = "lblFara";
            this.lblFara.Size = new System.Drawing.Size(51, 32);
            this.lblFara.TabIndex = 1;
            this.lblFara.Text = "ara";
            // 
            // ptLogo1
            // 
            this.ptLogo1.BackColor = System.Drawing.Color.Transparent;
            this.AnimationSidebar.SetDecoration(this.ptLogo1, BunifuAnimatorNS.DecorationType.None);
            this.AnimationSidebarBack.SetDecoration(this.ptLogo1, BunifuAnimatorNS.DecorationType.None);
            this.ptLogo1.Image = ((System.Drawing.Image)(resources.GetObject("ptLogo1.Image")));
            this.ptLogo1.Location = new System.Drawing.Point(56, 12);
            this.ptLogo1.Name = "ptLogo1";
            this.ptLogo1.Size = new System.Drawing.Size(40, 40);
            this.ptLogo1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptLogo1.TabIndex = 0;
            this.ptLogo1.TabStop = false;
            // 
            // btnHome
            // 
            this.btnHome.Active = false;
            this.btnHome.Activecolor = System.Drawing.Color.Transparent;
            this.btnHome.BackColor = System.Drawing.Color.Transparent;
            this.btnHome.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnHome.BorderRadius = 0;
            this.btnHome.ButtonText = "     TRANG CHỦ";
            this.btnHome.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AnimationSidebarBack.SetDecoration(this.btnHome, BunifuAnimatorNS.DecorationType.None);
            this.AnimationSidebar.SetDecoration(this.btnHome, BunifuAnimatorNS.DecorationType.None);
            this.btnHome.DisabledColor = System.Drawing.Color.Gray;
            this.btnHome.Iconcolor = System.Drawing.Color.Transparent;
            this.btnHome.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnHome.Iconimage")));
            this.btnHome.Iconimage_right = null;
            this.btnHome.Iconimage_right_Selected = null;
            this.btnHome.Iconimage_Selected = null;
            this.btnHome.IconMarginLeft = 0;
            this.btnHome.IconMarginRight = 0;
            this.btnHome.IconRightVisible = true;
            this.btnHome.IconRightZoom = 60D;
            this.btnHome.IconVisible = true;
            this.btnHome.IconZoom = 50D;
            this.btnHome.IsTab = false;
            this.btnHome.Location = new System.Drawing.Point(5, 73);
            this.btnHome.Name = "btnHome";
            this.btnHome.Normalcolor = System.Drawing.Color.Transparent;
            this.btnHome.OnHovercolor = System.Drawing.Color.Transparent;
            this.btnHome.OnHoverTextColor = System.Drawing.Color.White;
            this.btnHome.selected = false;
            this.btnHome.Size = new System.Drawing.Size(185, 48);
            this.btnHome.TabIndex = 3;
            this.btnHome.Text = "     TRANG CHỦ";
            this.btnHome.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHome.Textcolor = System.Drawing.Color.LightGray;
            this.btnHome.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // LinearSidebar
            // 
            this.LinearSidebar.BackColor = System.Drawing.Color.Transparent;
            this.AnimationSidebarBack.SetDecoration(this.LinearSidebar, BunifuAnimatorNS.DecorationType.None);
            this.AnimationSidebar.SetDecoration(this.LinearSidebar, BunifuAnimatorNS.DecorationType.None);
            this.LinearSidebar.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.LinearSidebar.LineThickness = 1;
            this.LinearSidebar.Location = new System.Drawing.Point(9, 44);
            this.LinearSidebar.Name = "LinearSidebar";
            this.LinearSidebar.Size = new System.Drawing.Size(180, 35);
            this.LinearSidebar.TabIndex = 2;
            this.LinearSidebar.Transparency = 255;
            this.LinearSidebar.Vertical = false;
            // 
            // borderSidebar
            // 
            this.borderSidebar.ElipseRadius = 7;
            this.borderSidebar.TargetControl = this.Sidebar;
            // 
            // AnimationSidebar
            // 
            this.AnimationSidebar.AnimationType = BunifuAnimatorNS.AnimationType.Leaf;
            this.AnimationSidebar.Cursor = null;
            animation2.AnimateOnlyDifferences = true;
            animation2.BlindCoeff = ((System.Drawing.PointF)(resources.GetObject("animation2.BlindCoeff")));
            animation2.LeafCoeff = 1F;
            animation2.MaxTime = 1F;
            animation2.MinTime = 0F;
            animation2.MosaicCoeff = ((System.Drawing.PointF)(resources.GetObject("animation2.MosaicCoeff")));
            animation2.MosaicShift = ((System.Drawing.PointF)(resources.GetObject("animation2.MosaicShift")));
            animation2.MosaicSize = 0;
            animation2.Padding = new System.Windows.Forms.Padding(0);
            animation2.RotateCoeff = 0F;
            animation2.RotateLimit = 0F;
            animation2.ScaleCoeff = ((System.Drawing.PointF)(resources.GetObject("animation2.ScaleCoeff")));
            animation2.SlideCoeff = ((System.Drawing.PointF)(resources.GetObject("animation2.SlideCoeff")));
            animation2.TimeCoeff = 0F;
            animation2.TransparencyCoeff = 0F;
            this.AnimationSidebar.DefaultAnimation = animation2;
            // 
            // AnimationSidebarBack
            // 
            this.AnimationSidebarBack.AnimationType = BunifuAnimatorNS.AnimationType.VertSlide;
            this.AnimationSidebarBack.Cursor = null;
            animation1.AnimateOnlyDifferences = true;
            animation1.BlindCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.BlindCoeff")));
            animation1.LeafCoeff = 0F;
            animation1.MaxTime = 1F;
            animation1.MinTime = 0F;
            animation1.MosaicCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.MosaicCoeff")));
            animation1.MosaicShift = ((System.Drawing.PointF)(resources.GetObject("animation1.MosaicShift")));
            animation1.MosaicSize = 0;
            animation1.Padding = new System.Windows.Forms.Padding(0);
            animation1.RotateCoeff = 0F;
            animation1.RotateLimit = 0F;
            animation1.ScaleCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.ScaleCoeff")));
            animation1.SlideCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.SlideCoeff")));
            animation1.TimeCoeff = 0F;
            animation1.TransparencyCoeff = 0F;
            this.AnimationSidebarBack.DefaultAnimation = animation1;
            // 
            // bunifuDragControl1
            // 
            this.bunifuDragControl1.Fixed = true;
            this.bunifuDragControl1.Horizontal = true;
            this.bunifuDragControl1.TargetControl = this.panel2;
            this.bunifuDragControl1.Vertical = true;
            // 
            // BoderfrmDashboard
            // 
            this.BoderfrmDashboard.ElipseRadius = 5;
            this.BoderfrmDashboard.TargetControl = this;
            // 
            // gunaElipse1
            // 
            this.gunaElipse1.Radius = 6;
            this.gunaElipse1.TargetControl = this.panelOpenform;
            // 
            // FrmDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Controls.Add(this.panel_Main);
            this.AnimationSidebar.SetDecoration(this, BunifuAnimatorNS.DecorationType.None);
            this.AnimationSidebarBack.SetDecoration(this, BunifuAnimatorNS.DecorationType.None);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Trợ lý ảo Fara";
            this.Load += new System.EventHandler(this.FrmDashboard_Load);
            this.panel_Main.ResumeLayout(false);
            this.panel_TopMenu.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnFullScreen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRestore_down)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCustomSidebar)).EndInit();
            this.panelContent.ResumeLayout(false);
            this.SidebarWapper.ResumeLayout(false);
            this.Sidebar.ResumeLayout(false);
            this.Sidebar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.indicator)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptLogo2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptLogo1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel panel_Main;
        private System.Windows.Forms.TableLayoutPanel panel_TopMenu;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private Bunifu.Framework.UI.BunifuImageButton btnClose;
        private Bunifu.Framework.UI.BunifuImageButton btnFullScreen;
        private Bunifu.Framework.UI.BunifuImageButton btnRestore_down;
        private Bunifu.Framework.UI.BunifuImageButton btnMinimize;
        private Bunifu.Framework.UI.BunifuImageButton btnCustomSidebar;
        private System.Windows.Forms.Panel panelContent;
        private Bunifu.Framework.UI.BunifuGradientPanel Sidebar;
        private System.Windows.Forms.PictureBox ptLogo1;
        private Bunifu.Framework.UI.BunifuSeparator LinearSidebar;
        private System.Windows.Forms.Label lblFara;
        private Bunifu.Framework.UI.BunifuElipse borderSidebar;
        private BunifuAnimatorNS.BunifuTransition AnimationSidebar;
        private BunifuAnimatorNS.BunifuTransition AnimationSidebarBack;
        private System.Windows.Forms.Panel panelOpenform;
        private System.Windows.Forms.Panel SidebarWapper;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl1;
        private System.Windows.Forms.Label lblDashboard;
        private System.Windows.Forms.PictureBox ptLogo2;
        private Bunifu.Framework.UI.BunifuElipse BoderfrmDashboard;
        private System.Windows.Forms.PictureBox indicator;
        private System.Windows.Forms.Label lblButton;
        private Bunifu.Framework.UI.BunifuFlatButton btnAbout;
        private Bunifu.Framework.UI.BunifuFlatButton btnSetting;
        private Bunifu.Framework.UI.BunifuFlatButton btnAccount;
        private Bunifu.Framework.UI.BunifuFlatButton btnMenu;
        private Bunifu.Framework.UI.BunifuFlatButton btnHome;
        private Guna.UI.WinForms.GunaElipse gunaElipse1;
    }
}

