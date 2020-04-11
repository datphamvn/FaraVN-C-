namespace TrolyaoFara
{
    partial class frmGuideForFood
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            BunifuAnimatorNS.Animation animation1 = new BunifuAnimatorNS.Animation();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGuideForFood));
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.gunaDataGridView2 = new Guna.UI.WinForms.GunaDataGridView();
            this.nameCompostion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amout = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlSidebar = new Guna.UI.WinForms.GunaGradient2Panel();
            this.btnShowSidebar = new Guna.UI.WinForms.GunaCircleButton();
            this.btnHideSidebar = new Guna.UI.WinForms.GunaCircleButton();
            this.pnlComposition = new Guna.UI.WinForms.GunaGradient2Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panelLoad = new System.Windows.Forms.Panel();
            this.lblLoading = new System.Windows.Forms.Label();
            this.loading = new TrolyaoFara.Load();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.gunaGradient2Panel2 = new Guna.UI.WinForms.GunaGradient2Panel();
            this.AnimationFooterBack = new BunifuAnimatorNS.BunifuTransition(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.gunaDataGridView2)).BeginInit();
            this.pnlSidebar.SuspendLayout();
            this.pnlComposition.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panelLoad.SuspendLayout();
            this.panel1.SuspendLayout();
            this.gunaGradient2Panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // webBrowser1
            // 
            this.AnimationFooterBack.SetDecoration(this.webBrowser1, BunifuAnimatorNS.DecorationType.None);
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser1.Location = new System.Drawing.Point(0, 0);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(654, 491);
            this.webBrowser1.TabIndex = 8;
            // 
            // gunaDataGridView2
            // 
            this.gunaDataGridView2.AllowUserToAddRows = false;
            this.gunaDataGridView2.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.WhiteSmoke;
            this.gunaDataGridView2.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gunaDataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gunaDataGridView2.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.gunaDataGridView2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gunaDataGridView2.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.gunaDataGridView2.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(21)))), ((int)(((byte)(80)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gunaDataGridView2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gunaDataGridView2.ColumnHeadersHeight = 40;
            this.gunaDataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameCompostion,
            this.Amout,
            this.unit});
            this.AnimationFooterBack.SetDecoration(this.gunaDataGridView2, BunifuAnimatorNS.DecorationType.None);
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gunaDataGridView2.DefaultCellStyle = dataGridViewCellStyle3;
            this.gunaDataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gunaDataGridView2.EnableHeadersVisualStyles = false;
            this.gunaDataGridView2.GridColor = System.Drawing.Color.White;
            this.gunaDataGridView2.Location = new System.Drawing.Point(0, 0);
            this.gunaDataGridView2.Name = "gunaDataGridView2";
            this.gunaDataGridView2.ReadOnly = true;
            this.gunaDataGridView2.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.gunaDataGridView2.RowHeadersVisible = false;
            this.gunaDataGridView2.RowTemplate.DividerHeight = 1;
            this.gunaDataGridView2.RowTemplate.Height = 25;
            this.gunaDataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gunaDataGridView2.Size = new System.Drawing.Size(265, 448);
            this.gunaDataGridView2.TabIndex = 9;
            this.gunaDataGridView2.Theme = Guna.UI.WinForms.GunaDataGridViewPresetThemes.DeepPurple;
            this.gunaDataGridView2.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.WhiteSmoke;
            this.gunaDataGridView2.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.gunaDataGridView2.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.gunaDataGridView2.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.WhiteSmoke;
            this.gunaDataGridView2.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.gunaDataGridView2.ThemeStyle.BackColor = System.Drawing.Color.WhiteSmoke;
            this.gunaDataGridView2.ThemeStyle.GridColor = System.Drawing.Color.White;
            this.gunaDataGridView2.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(21)))), ((int)(((byte)(80)))));
            this.gunaDataGridView2.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.gunaDataGridView2.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gunaDataGridView2.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.gunaDataGridView2.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.gunaDataGridView2.ThemeStyle.HeaderStyle.Height = 40;
            this.gunaDataGridView2.ThemeStyle.ReadOnly = true;
            this.gunaDataGridView2.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.gunaDataGridView2.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.gunaDataGridView2.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gunaDataGridView2.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.gunaDataGridView2.ThemeStyle.RowsStyle.Height = 25;
            this.gunaDataGridView2.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.White;
            this.gunaDataGridView2.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            // 
            // nameCompostion
            // 
            this.nameCompostion.FillWeight = 166.1283F;
            this.nameCompostion.HeaderText = "Thành phần";
            this.nameCompostion.Name = "nameCompostion";
            this.nameCompostion.ReadOnly = true;
            // 
            // Amout
            // 
            this.Amout.HeaderText = "Số lượng";
            this.Amout.Name = "Amout";
            this.Amout.ReadOnly = true;
            // 
            // unit
            // 
            this.unit.HeaderText = "Đơn vị";
            this.unit.Name = "unit";
            this.unit.ReadOnly = true;
            // 
            // pnlSidebar
            // 
            this.pnlSidebar.BackColor = System.Drawing.Color.White;
            this.pnlSidebar.Controls.Add(this.btnShowSidebar);
            this.pnlSidebar.Controls.Add(this.btnHideSidebar);
            this.pnlSidebar.Controls.Add(this.pnlComposition);
            this.AnimationFooterBack.SetDecoration(this.pnlSidebar, BunifuAnimatorNS.DecorationType.None);
            this.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSidebar.GradientColor1 = System.Drawing.Color.White;
            this.pnlSidebar.GradientColor2 = System.Drawing.Color.White;
            this.pnlSidebar.Location = new System.Drawing.Point(0, 0);
            this.pnlSidebar.Name = "pnlSidebar";
            this.pnlSidebar.Size = new System.Drawing.Size(300, 491);
            this.pnlSidebar.TabIndex = 10;
            // 
            // btnShowSidebar
            // 
            this.btnShowSidebar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnShowSidebar.Animated = true;
            this.btnShowSidebar.AnimationHoverSpeed = 0.1F;
            this.btnShowSidebar.AnimationSpeed = 0.1F;
            this.btnShowSidebar.BackColor = System.Drawing.Color.White;
            this.btnShowSidebar.BaseColor = System.Drawing.Color.Transparent;
            this.btnShowSidebar.BorderColor = System.Drawing.Color.Black;
            this.AnimationFooterBack.SetDecoration(this.btnShowSidebar, BunifuAnimatorNS.DecorationType.None);
            this.btnShowSidebar.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnShowSidebar.FocusedColor = System.Drawing.Color.Empty;
            this.btnShowSidebar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnShowSidebar.ForeColor = System.Drawing.Color.White;
            this.btnShowSidebar.Image = ((System.Drawing.Image)(resources.GetObject("btnShowSidebar.Image")));
            this.btnShowSidebar.ImageSize = new System.Drawing.Size(35, 35);
            this.btnShowSidebar.Location = new System.Drawing.Point(265, 221);
            this.btnShowSidebar.Name = "btnShowSidebar";
            this.btnShowSidebar.OnHoverBaseColor = System.Drawing.Color.Transparent;
            this.btnShowSidebar.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnShowSidebar.OnHoverForeColor = System.Drawing.Color.White;
            this.btnShowSidebar.OnHoverImage = ((System.Drawing.Image)(resources.GetObject("btnShowSidebar.OnHoverImage")));
            this.btnShowSidebar.OnPressedColor = System.Drawing.Color.Black;
            this.btnShowSidebar.Size = new System.Drawing.Size(35, 35);
            this.btnShowSidebar.TabIndex = 11;
            this.btnShowSidebar.Click += new System.EventHandler(this.btnShowSidebar_Click);
            // 
            // btnHideSidebar
            // 
            this.btnHideSidebar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHideSidebar.Animated = true;
            this.btnHideSidebar.AnimationHoverSpeed = 0.1F;
            this.btnHideSidebar.AnimationSpeed = 0.1F;
            this.btnHideSidebar.BackColor = System.Drawing.Color.White;
            this.btnHideSidebar.BaseColor = System.Drawing.Color.Transparent;
            this.btnHideSidebar.BorderColor = System.Drawing.Color.Black;
            this.AnimationFooterBack.SetDecoration(this.btnHideSidebar, BunifuAnimatorNS.DecorationType.None);
            this.btnHideSidebar.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnHideSidebar.FocusedColor = System.Drawing.Color.Empty;
            this.btnHideSidebar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnHideSidebar.ForeColor = System.Drawing.Color.White;
            this.btnHideSidebar.Image = ((System.Drawing.Image)(resources.GetObject("btnHideSidebar.Image")));
            this.btnHideSidebar.ImageSize = new System.Drawing.Size(35, 35);
            this.btnHideSidebar.Location = new System.Drawing.Point(265, 221);
            this.btnHideSidebar.Name = "btnHideSidebar";
            this.btnHideSidebar.OnHoverBaseColor = System.Drawing.Color.Transparent;
            this.btnHideSidebar.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnHideSidebar.OnHoverForeColor = System.Drawing.Color.White;
            this.btnHideSidebar.OnHoverImage = ((System.Drawing.Image)(resources.GetObject("btnHideSidebar.OnHoverImage")));
            this.btnHideSidebar.OnPressedColor = System.Drawing.Color.Black;
            this.btnHideSidebar.Size = new System.Drawing.Size(35, 35);
            this.btnHideSidebar.TabIndex = 10;
            this.btnHideSidebar.Click += new System.EventHandler(this.btnHideSidebar_Click);
            // 
            // pnlComposition
            // 
            this.pnlComposition.BackColor = System.Drawing.Color.Transparent;
            this.pnlComposition.Controls.Add(this.panel2);
            this.pnlComposition.Controls.Add(this.panel1);
            this.AnimationFooterBack.SetDecoration(this.pnlComposition, BunifuAnimatorNS.DecorationType.None);
            this.pnlComposition.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlComposition.GradientColor1 = System.Drawing.Color.White;
            this.pnlComposition.GradientColor2 = System.Drawing.Color.White;
            this.pnlComposition.Location = new System.Drawing.Point(0, 0);
            this.pnlComposition.Name = "pnlComposition";
            this.pnlComposition.Size = new System.Drawing.Size(265, 491);
            this.pnlComposition.TabIndex = 9;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panelLoad);
            this.panel2.Controls.Add(this.gunaDataGridView2);
            this.AnimationFooterBack.SetDecoration(this.panel2, BunifuAnimatorNS.DecorationType.None);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 43);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(265, 448);
            this.panel2.TabIndex = 13;
            // 
            // panelLoad
            // 
            this.panelLoad.Controls.Add(this.lblLoading);
            this.panelLoad.Controls.Add(this.loading);
            this.AnimationFooterBack.SetDecoration(this.panelLoad, BunifuAnimatorNS.DecorationType.None);
            this.panelLoad.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelLoad.Location = new System.Drawing.Point(0, 0);
            this.panelLoad.Name = "panelLoad";
            this.panelLoad.Size = new System.Drawing.Size(265, 448);
            this.panelLoad.TabIndex = 24;
            // 
            // lblLoading
            // 
            this.lblLoading.AutoSize = true;
            this.lblLoading.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AnimationFooterBack.SetDecoration(this.lblLoading, BunifuAnimatorNS.DecorationType.None);
            this.lblLoading.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoading.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblLoading.Location = new System.Drawing.Point(63, 215);
            this.lblLoading.Name = "lblLoading";
            this.lblLoading.Size = new System.Drawing.Size(134, 20);
            this.lblLoading.TabIndex = 23;
            this.lblLoading.Text = "Đang tải dữ liệu ...";
            // 
            // loading
            // 
            this.AnimationFooterBack.SetDecoration(this.loading, BunifuAnimatorNS.DecorationType.None);
            this.loading.Location = new System.Drawing.Point(70, 77);
            this.loading.Name = "loading";
            this.loading.Size = new System.Drawing.Size(111, 111);
            this.loading.TabIndex = 22;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(150)))), ((int)(((byte)(97)))));
            this.panel1.Controls.Add(this.lblTitle);
            this.AnimationFooterBack.SetDecoration(this.panel1, BunifuAnimatorNS.DecorationType.None);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(265, 43);
            this.panel1.TabIndex = 12;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.AnimationFooterBack.SetDecoration(this.lblTitle, BunifuAnimatorNS.DecorationType.None);
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(67, 10);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(116, 25);
            this.lblTitle.TabIndex = 4;
            this.lblTitle.Text = "Nguyên liệu";
            // 
            // gunaGradient2Panel2
            // 
            this.gunaGradient2Panel2.BackColor = System.Drawing.Color.Transparent;
            this.gunaGradient2Panel2.Controls.Add(this.webBrowser1);
            this.AnimationFooterBack.SetDecoration(this.gunaGradient2Panel2, BunifuAnimatorNS.DecorationType.None);
            this.gunaGradient2Panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gunaGradient2Panel2.GradientColor1 = System.Drawing.Color.White;
            this.gunaGradient2Panel2.GradientColor2 = System.Drawing.Color.White;
            this.gunaGradient2Panel2.Location = new System.Drawing.Point(300, 0);
            this.gunaGradient2Panel2.Name = "gunaGradient2Panel2";
            this.gunaGradient2Panel2.Size = new System.Drawing.Size(654, 491);
            this.gunaGradient2Panel2.TabIndex = 11;
            // 
            // AnimationFooterBack
            // 
            this.AnimationFooterBack.AnimationType = BunifuAnimatorNS.AnimationType.HorizBlind;
            this.AnimationFooterBack.Cursor = null;
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
            this.AnimationFooterBack.DefaultAnimation = animation1;
            this.AnimationFooterBack.TimeStep = 0.08F;
            // 
            // frmGuideForFood
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(954, 491);
            this.Controls.Add(this.gunaGradient2Panel2);
            this.Controls.Add(this.pnlSidebar);
            this.AnimationFooterBack.SetDecoration(this, BunifuAnimatorNS.DecorationType.None);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmGuideForFood";
            this.Text = "frmGuideForFood";
            ((System.ComponentModel.ISupportInitialize)(this.gunaDataGridView2)).EndInit();
            this.pnlSidebar.ResumeLayout(false);
            this.pnlComposition.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panelLoad.ResumeLayout(false);
            this.panelLoad.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.gunaGradient2Panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser webBrowser1;
        private Guna.UI.WinForms.GunaDataGridView gunaDataGridView2;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameCompostion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amout;
        private System.Windows.Forms.DataGridViewTextBoxColumn unit;
        private Guna.UI.WinForms.GunaGradient2Panel pnlSidebar;
        private Guna.UI.WinForms.GunaGradient2Panel gunaGradient2Panel2;
        private Guna.UI.WinForms.GunaGradient2Panel pnlComposition;
        private Guna.UI.WinForms.GunaCircleButton btnHideSidebar;
        private BunifuAnimatorNS.BunifuTransition AnimationFooterBack;
        private Guna.UI.WinForms.GunaCircleButton btnShowSidebar;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panelLoad;
        private System.Windows.Forms.Label lblLoading;
        private Load loading;
    }
}