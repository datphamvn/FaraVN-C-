namespace TrolyaoFara
{
    partial class frmMenuFood
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMenuFood));
            this.gunaGradientButton1 = new Guna.UI.WinForms.GunaGradientButton();
            this.pnlFullMenu = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlBreakfast = new System.Windows.Forms.Panel();
            this.pnlLoadBreakfast = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlTitleBreakfast = new Guna.UI.WinForms.GunaGradient2Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.pnlLunch = new System.Windows.Forms.Panel();
            this.pnlLoadLunch = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlTitleLunch = new Guna.UI.WinForms.GunaGradient2Panel();
            this.lblLunch = new System.Windows.Forms.Label();
            this.pnlDinner = new System.Windows.Forms.Panel();
            this.pnlLoadDinner = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlTitleDinner = new Guna.UI.WinForms.GunaGradient2Panel();
            this.lblDinner = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.gunaElipse1 = new Guna.UI.WinForms.GunaElipse(this.components);
            this.gunaElipsePanel1 = new Guna.UI.WinForms.GunaElipsePanel();
            this.pnlAdv = new Guna.UI.WinForms.GunaGradient2Panel();
            this.btnExportComposition = new Guna.UI.WinForms.GunaGradientButton();
            this.btnExportMenu = new Guna.UI.WinForms.GunaGradientButton();
            this.pnlHeading = new System.Windows.Forms.Panel();
            this.lblTab = new System.Windows.Forms.Label();
            this.pnlFullMenu.SuspendLayout();
            this.pnlBreakfast.SuspendLayout();
            this.pnlTitleBreakfast.SuspendLayout();
            this.pnlLunch.SuspendLayout();
            this.pnlTitleLunch.SuspendLayout();
            this.pnlDinner.SuspendLayout();
            this.pnlTitleDinner.SuspendLayout();
            this.gunaElipsePanel1.SuspendLayout();
            this.pnlAdv.SuspendLayout();
            this.pnlHeading.SuspendLayout();
            this.SuspendLayout();
            // 
            // gunaGradientButton1
            // 
            this.gunaGradientButton1.AnimationHoverSpeed = 0.07F;
            this.gunaGradientButton1.AnimationSpeed = 0.03F;
            this.gunaGradientButton1.BackColor = System.Drawing.Color.Transparent;
            this.gunaGradientButton1.BaseColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(68)))), ((int)(((byte)(83)))));
            this.gunaGradientButton1.BaseColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(33)))), ((int)(((byte)(107)))));
            this.gunaGradientButton1.BorderColor = System.Drawing.Color.Black;
            this.gunaGradientButton1.DialogResult = System.Windows.Forms.DialogResult.None;
            this.gunaGradientButton1.FocusedColor = System.Drawing.Color.Empty;
            this.gunaGradientButton1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gunaGradientButton1.ForeColor = System.Drawing.Color.White;
            this.gunaGradientButton1.Image = global::TrolyaoFara.Properties.Resources.reset;
            this.gunaGradientButton1.ImageAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.gunaGradientButton1.ImageSize = new System.Drawing.Size(20, 20);
            this.gunaGradientButton1.Location = new System.Drawing.Point(632, 5);
            this.gunaGradientButton1.Name = "gunaGradientButton1";
            this.gunaGradientButton1.OnHoverBaseColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.gunaGradientButton1.OnHoverBaseColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(68)))), ((int)(((byte)(173)))));
            this.gunaGradientButton1.OnHoverBorderColor = System.Drawing.Color.Black;
            this.gunaGradientButton1.OnHoverForeColor = System.Drawing.Color.White;
            this.gunaGradientButton1.OnHoverImage = null;
            this.gunaGradientButton1.OnPressedColor = System.Drawing.Color.Black;
            this.gunaGradientButton1.Radius = 5;
            this.gunaGradientButton1.Size = new System.Drawing.Size(110, 33);
            this.gunaGradientButton1.TabIndex = 29;
            this.gunaGradientButton1.Text = "Thiết lập";
            this.gunaGradientButton1.Click += new System.EventHandler(this.gunaGradientButton1_Click);
            // 
            // pnlFullMenu
            // 
            this.pnlFullMenu.AutoScroll = true;
            this.pnlFullMenu.Controls.Add(this.pnlBreakfast);
            this.pnlFullMenu.Controls.Add(this.pnlLunch);
            this.pnlFullMenu.Controls.Add(this.pnlDinner);
            this.pnlFullMenu.Location = new System.Drawing.Point(8, 42);
            this.pnlFullMenu.Name = "pnlFullMenu";
            this.pnlFullMenu.Size = new System.Drawing.Size(767, 450);
            this.pnlFullMenu.TabIndex = 6;
            // 
            // pnlBreakfast
            // 
            this.pnlBreakfast.Controls.Add(this.pnlLoadBreakfast);
            this.pnlBreakfast.Controls.Add(this.pnlTitleBreakfast);
            this.pnlBreakfast.Location = new System.Drawing.Point(3, 3);
            this.pnlBreakfast.Name = "pnlBreakfast";
            this.pnlBreakfast.Size = new System.Drawing.Size(742, 201);
            this.pnlBreakfast.TabIndex = 5;
            // 
            // pnlLoadBreakfast
            // 
            this.pnlLoadBreakfast.AutoScroll = true;
            this.pnlLoadBreakfast.Location = new System.Drawing.Point(7, 42);
            this.pnlLoadBreakfast.Name = "pnlLoadBreakfast";
            this.pnlLoadBreakfast.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.pnlLoadBreakfast.Size = new System.Drawing.Size(725, 150);
            this.pnlLoadBreakfast.TabIndex = 5;
            // 
            // pnlTitleBreakfast
            // 
            this.pnlTitleBreakfast.BackColor = System.Drawing.Color.Transparent;
            this.pnlTitleBreakfast.Controls.Add(this.label6);
            this.pnlTitleBreakfast.GradientColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(33)))), ((int)(((byte)(107)))));
            this.pnlTitleBreakfast.GradientColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(68)))), ((int)(((byte)(83)))));
            this.pnlTitleBreakfast.Location = new System.Drawing.Point(9, 3);
            this.pnlTitleBreakfast.Name = "pnlTitleBreakfast";
            this.pnlTitleBreakfast.Radius = 5;
            this.pnlTitleBreakfast.Size = new System.Drawing.Size(705, 38);
            this.pnlTitleBreakfast.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(13, 6);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 25);
            this.label6.TabIndex = 4;
            this.label6.Text = "Bữa sáng";
            // 
            // pnlLunch
            // 
            this.pnlLunch.Controls.Add(this.pnlLoadLunch);
            this.pnlLunch.Controls.Add(this.pnlTitleLunch);
            this.pnlLunch.Location = new System.Drawing.Point(3, 210);
            this.pnlLunch.Name = "pnlLunch";
            this.pnlLunch.Size = new System.Drawing.Size(742, 201);
            this.pnlLunch.TabIndex = 6;
            // 
            // pnlLoadLunch
            // 
            this.pnlLoadLunch.AllowDrop = true;
            this.pnlLoadLunch.AutoScroll = true;
            this.pnlLoadLunch.Location = new System.Drawing.Point(7, 42);
            this.pnlLoadLunch.Name = "pnlLoadLunch";
            this.pnlLoadLunch.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.pnlLoadLunch.Size = new System.Drawing.Size(725, 150);
            this.pnlLoadLunch.TabIndex = 5;
            // 
            // pnlTitleLunch
            // 
            this.pnlTitleLunch.BackColor = System.Drawing.Color.Transparent;
            this.pnlTitleLunch.Controls.Add(this.lblLunch);
            this.pnlTitleLunch.GradientColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(33)))), ((int)(((byte)(107)))));
            this.pnlTitleLunch.GradientColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(68)))), ((int)(((byte)(83)))));
            this.pnlTitleLunch.Location = new System.Drawing.Point(9, 3);
            this.pnlTitleLunch.Name = "pnlTitleLunch";
            this.pnlTitleLunch.Radius = 5;
            this.pnlTitleLunch.Size = new System.Drawing.Size(705, 38);
            this.pnlTitleLunch.TabIndex = 4;
            // 
            // lblLunch
            // 
            this.lblLunch.AutoSize = true;
            this.lblLunch.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLunch.ForeColor = System.Drawing.Color.White;
            this.lblLunch.Location = new System.Drawing.Point(13, 6);
            this.lblLunch.Name = "lblLunch";
            this.lblLunch.Size = new System.Drawing.Size(86, 25);
            this.lblLunch.TabIndex = 4;
            this.lblLunch.Text = "Bữa trưa";
            // 
            // pnlDinner
            // 
            this.pnlDinner.Controls.Add(this.pnlLoadDinner);
            this.pnlDinner.Controls.Add(this.pnlTitleDinner);
            this.pnlDinner.Location = new System.Drawing.Point(3, 417);
            this.pnlDinner.Name = "pnlDinner";
            this.pnlDinner.Size = new System.Drawing.Size(742, 201);
            this.pnlDinner.TabIndex = 7;
            // 
            // pnlLoadDinner
            // 
            this.pnlLoadDinner.AllowDrop = true;
            this.pnlLoadDinner.AutoScroll = true;
            this.pnlLoadDinner.Location = new System.Drawing.Point(7, 42);
            this.pnlLoadDinner.Name = "pnlLoadDinner";
            this.pnlLoadDinner.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.pnlLoadDinner.Size = new System.Drawing.Size(725, 150);
            this.pnlLoadDinner.TabIndex = 5;
            // 
            // pnlTitleDinner
            // 
            this.pnlTitleDinner.BackColor = System.Drawing.Color.Transparent;
            this.pnlTitleDinner.Controls.Add(this.lblDinner);
            this.pnlTitleDinner.GradientColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(33)))), ((int)(((byte)(107)))));
            this.pnlTitleDinner.GradientColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(68)))), ((int)(((byte)(83)))));
            this.pnlTitleDinner.Location = new System.Drawing.Point(9, 3);
            this.pnlTitleDinner.Name = "pnlTitleDinner";
            this.pnlTitleDinner.Radius = 5;
            this.pnlTitleDinner.Size = new System.Drawing.Size(705, 38);
            this.pnlTitleDinner.TabIndex = 4;
            // 
            // lblDinner
            // 
            this.lblDinner.AutoSize = true;
            this.lblDinner.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDinner.ForeColor = System.Drawing.Color.White;
            this.lblDinner.Location = new System.Drawing.Point(13, 6);
            this.lblDinner.Name = "lblDinner";
            this.lblDinner.Size = new System.Drawing.Size(73, 25);
            this.lblDinner.TabIndex = 4;
            this.lblDinner.Text = "Bữa tối";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(218, 3);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(194, 30);
            this.lblTitle.TabIndex = 3;
            this.lblTitle.Text = "Thực đơn hôm nay";
            // 
            // gunaElipse1
            // 
            this.gunaElipse1.Radius = 5;
            this.gunaElipse1.TargetControl = this;
            // 
            // gunaElipsePanel1
            // 
            this.gunaElipsePanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(23)))), ((int)(((byte)(48)))));
            this.gunaElipsePanel1.BaseColor = System.Drawing.Color.Transparent;
            this.gunaElipsePanel1.Controls.Add(this.pnlAdv);
            this.gunaElipsePanel1.Controls.Add(this.pnlHeading);
            this.gunaElipsePanel1.Controls.Add(this.pnlFullMenu);
            this.gunaElipsePanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gunaElipsePanel1.Location = new System.Drawing.Point(0, 0);
            this.gunaElipsePanel1.Name = "gunaElipsePanel1";
            this.gunaElipsePanel1.Size = new System.Drawing.Size(782, 544);
            this.gunaElipsePanel1.TabIndex = 2;
            // 
            // pnlAdv
            // 
            this.pnlAdv.BackColor = System.Drawing.Color.Transparent;
            this.pnlAdv.Controls.Add(this.btnExportComposition);
            this.pnlAdv.Controls.Add(this.gunaGradientButton1);
            this.pnlAdv.Controls.Add(this.btnExportMenu);
            this.pnlAdv.GradientColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(68)))), ((int)(((byte)(83)))));
            this.pnlAdv.GradientColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(33)))), ((int)(((byte)(107)))));
            this.pnlAdv.Location = new System.Drawing.Point(12, 499);
            this.pnlAdv.Name = "pnlAdv";
            this.pnlAdv.Radius = 6;
            this.pnlAdv.Size = new System.Drawing.Size(755, 42);
            this.pnlAdv.TabIndex = 57;
            // 
            // btnExportComposition
            // 
            this.btnExportComposition.AnimationHoverSpeed = 0.07F;
            this.btnExportComposition.AnimationSpeed = 0.03F;
            this.btnExportComposition.BackColor = System.Drawing.Color.Transparent;
            this.btnExportComposition.BaseColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(106)))), ((int)(((byte)(138)))));
            this.btnExportComposition.BaseColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(120)))), ((int)(((byte)(113)))));
            this.btnExportComposition.BorderColor = System.Drawing.Color.Black;
            this.btnExportComposition.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnExportComposition.FocusedColor = System.Drawing.Color.Empty;
            this.btnExportComposition.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportComposition.ForeColor = System.Drawing.Color.White;
            this.btnExportComposition.Image = ((System.Drawing.Image)(resources.GetObject("btnExportComposition.Image")));
            this.btnExportComposition.ImageAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.btnExportComposition.ImageSize = new System.Drawing.Size(25, 25);
            this.btnExportComposition.Location = new System.Drawing.Point(137, 5);
            this.btnExportComposition.Name = "btnExportComposition";
            this.btnExportComposition.OnHoverBaseColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.btnExportComposition.OnHoverBaseColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(68)))), ((int)(((byte)(173)))));
            this.btnExportComposition.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnExportComposition.OnHoverForeColor = System.Drawing.Color.White;
            this.btnExportComposition.OnHoverImage = null;
            this.btnExportComposition.OnPressedColor = System.Drawing.Color.Black;
            this.btnExportComposition.Radius = 5;
            this.btnExportComposition.Size = new System.Drawing.Size(167, 33);
            this.btnExportComposition.TabIndex = 58;
            this.btnExportComposition.Text = "Xuất nguyên liệu";
            this.btnExportComposition.Click += new System.EventHandler(this.btnExportComposition_Click);
            // 
            // btnExportMenu
            // 
            this.btnExportMenu.AnimationHoverSpeed = 0.07F;
            this.btnExportMenu.AnimationSpeed = 0.03F;
            this.btnExportMenu.BackColor = System.Drawing.Color.Transparent;
            this.btnExportMenu.BaseColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(106)))), ((int)(((byte)(138)))));
            this.btnExportMenu.BaseColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(120)))), ((int)(((byte)(113)))));
            this.btnExportMenu.BorderColor = System.Drawing.Color.Black;
            this.btnExportMenu.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnExportMenu.FocusedColor = System.Drawing.Color.Empty;
            this.btnExportMenu.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportMenu.ForeColor = System.Drawing.Color.White;
            this.btnExportMenu.Image = ((System.Drawing.Image)(resources.GetObject("btnExportMenu.Image")));
            this.btnExportMenu.ImageAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.btnExportMenu.ImageSize = new System.Drawing.Size(25, 25);
            this.btnExportMenu.Location = new System.Drawing.Point(7, 5);
            this.btnExportMenu.Name = "btnExportMenu";
            this.btnExportMenu.OnHoverBaseColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.btnExportMenu.OnHoverBaseColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(68)))), ((int)(((byte)(173)))));
            this.btnExportMenu.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnExportMenu.OnHoverForeColor = System.Drawing.Color.White;
            this.btnExportMenu.OnHoverImage = null;
            this.btnExportMenu.OnPressedColor = System.Drawing.Color.Black;
            this.btnExportMenu.Radius = 5;
            this.btnExportMenu.Size = new System.Drawing.Size(124, 33);
            this.btnExportMenu.TabIndex = 57;
            this.btnExportMenu.Text = "Xuất Menu";
            this.btnExportMenu.Click += new System.EventHandler(this.btnExportMenu_Click);
            // 
            // pnlHeading
            // 
            this.pnlHeading.Controls.Add(this.lblTitle);
            this.pnlHeading.Controls.Add(this.lblTab);
            this.pnlHeading.Location = new System.Drawing.Point(8, 3);
            this.pnlHeading.Name = "pnlHeading";
            this.pnlHeading.Size = new System.Drawing.Size(767, 36);
            this.pnlHeading.TabIndex = 58;
            // 
            // lblTab
            // 
            this.lblTab.AutoSize = true;
            this.lblTab.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTab.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(21)))), ((int)(((byte)(80)))));
            this.lblTab.Location = new System.Drawing.Point(63, 14);
            this.lblTab.Name = "lblTab";
            this.lblTab.Size = new System.Drawing.Size(49, 20);
            this.lblTab.TabIndex = 56;
            this.lblTab.Text = "lblTab";
            this.lblTab.Visible = false;
            // 
            // frmMenuFood
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(23)))), ((int)(((byte)(48)))));
            this.ClientSize = new System.Drawing.Size(782, 544);
            this.Controls.Add(this.gunaElipsePanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmMenuFood";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmMenuFood";
            this.Load += new System.EventHandler(this.frmMenuFood_Load);
            this.pnlFullMenu.ResumeLayout(false);
            this.pnlBreakfast.ResumeLayout(false);
            this.pnlTitleBreakfast.ResumeLayout(false);
            this.pnlTitleBreakfast.PerformLayout();
            this.pnlLunch.ResumeLayout(false);
            this.pnlTitleLunch.ResumeLayout(false);
            this.pnlTitleLunch.PerformLayout();
            this.pnlDinner.ResumeLayout(false);
            this.pnlTitleDinner.ResumeLayout(false);
            this.pnlTitleDinner.PerformLayout();
            this.gunaElipsePanel1.ResumeLayout(false);
            this.pnlAdv.ResumeLayout(false);
            this.pnlHeading.ResumeLayout(false);
            this.pnlHeading.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI.WinForms.GunaElipse gunaElipse1;
        private Guna.UI.WinForms.GunaElipsePanel gunaElipsePanel1;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlBreakfast;
        private System.Windows.Forms.FlowLayoutPanel pnlLoadBreakfast;
        private Guna.UI.WinForms.GunaGradient2Panel pnlTitleBreakfast;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.FlowLayoutPanel pnlFullMenu;
        private System.Windows.Forms.Panel pnlLunch;
        private System.Windows.Forms.FlowLayoutPanel pnlLoadLunch;
        private Guna.UI.WinForms.GunaGradient2Panel pnlTitleLunch;
        private System.Windows.Forms.Label lblLunch;
        private System.Windows.Forms.Panel pnlDinner;
        private System.Windows.Forms.FlowLayoutPanel pnlLoadDinner;
        private Guna.UI.WinForms.GunaGradient2Panel pnlTitleDinner;
        private System.Windows.Forms.Label lblDinner;
        private Guna.UI.WinForms.GunaGradientButton gunaGradientButton1;
        private System.Windows.Forms.Label lblTab;
        private Guna.UI.WinForms.GunaGradientButton btnExportMenu;
        private System.Windows.Forms.Panel pnlHeading;
        private Guna.UI.WinForms.GunaGradient2Panel pnlAdv;
        private Guna.UI.WinForms.GunaGradientButton btnExportComposition;
    }
}