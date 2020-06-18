namespace TrolyaoFara
{
    partial class ItemFood
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ItemFood));
            this.borderItem = new Guna.UI.WinForms.GunaElipse(this.components);
            this.lblNameFood = new System.Windows.Forms.Label();
            this.lblGr = new System.Windows.Forms.Label();
            this.gunaGradient2Panel2 = new Guna.UI.WinForms.GunaGradient2Panel();
            this.gunaPictureBox2 = new Guna.UI.WinForms.GunaPictureBox();
            this.lblTimer = new System.Windows.Forms.Label();
            this.lblID = new System.Windows.Forms.Label();
            this.gunaGradient2Panel1 = new Guna.UI.WinForms.GunaGradient2Panel();
            this.btnInfo = new Guna.UI.WinForms.GunaGradientButton();
            this.imgFood = new Guna.UI.WinForms.GunaPictureBox();
            this.lblFactor = new System.Windows.Forms.Label();
            this.gunaGradient2Panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gunaPictureBox2)).BeginInit();
            this.gunaGradient2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgFood)).BeginInit();
            this.SuspendLayout();
            // 
            // borderItem
            // 
            this.borderItem.Radius = 5;
            this.borderItem.TargetControl = this;
            // 
            // lblNameFood
            // 
            this.lblNameFood.AutoSize = true;
            this.lblNameFood.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNameFood.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.lblNameFood.Location = new System.Drawing.Point(166, 11);
            this.lblNameFood.Name = "lblNameFood";
            this.lblNameFood.Size = new System.Drawing.Size(89, 20);
            this.lblNameFood.TabIndex = 1;
            this.lblNameFood.Text = "Tên món ăn";
            this.lblNameFood.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblGr
            // 
            this.lblGr.AutoSize = true;
            this.lblGr.BackColor = System.Drawing.Color.Transparent;
            this.lblGr.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGr.ForeColor = System.Drawing.Color.White;
            this.lblGr.Location = new System.Drawing.Point(48, 5);
            this.lblGr.Name = "lblGr";
            this.lblGr.Size = new System.Drawing.Size(24, 20);
            this.lblGr.TabIndex = 34;
            this.lblGr.Text = "gr";
            // 
            // gunaGradient2Panel2
            // 
            this.gunaGradient2Panel2.BackColor = System.Drawing.Color.Transparent;
            this.gunaGradient2Panel2.Controls.Add(this.gunaPictureBox2);
            this.gunaGradient2Panel2.Controls.Add(this.lblTimer);
            this.gunaGradient2Panel2.GradientColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(68)))), ((int)(((byte)(83)))));
            this.gunaGradient2Panel2.GradientColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(33)))), ((int)(((byte)(107)))));
            this.gunaGradient2Panel2.Location = new System.Drawing.Point(230, 99);
            this.gunaGradient2Panel2.Name = "gunaGradient2Panel2";
            this.gunaGradient2Panel2.Radius = 7;
            this.gunaGradient2Panel2.Size = new System.Drawing.Size(107, 38);
            this.gunaGradient2Panel2.TabIndex = 3;
            // 
            // gunaPictureBox2
            // 
            this.gunaPictureBox2.BaseColor = System.Drawing.Color.White;
            this.gunaPictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("gunaPictureBox2.Image")));
            this.gunaPictureBox2.Location = new System.Drawing.Point(6, 6);
            this.gunaPictureBox2.Name = "gunaPictureBox2";
            this.gunaPictureBox2.Size = new System.Drawing.Size(27, 27);
            this.gunaPictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.gunaPictureBox2.TabIndex = 35;
            this.gunaPictureBox2.TabStop = false;
            // 
            // lblTimer
            // 
            this.lblTimer.AutoSize = true;
            this.lblTimer.BackColor = System.Drawing.Color.Transparent;
            this.lblTimer.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimer.ForeColor = System.Drawing.Color.White;
            this.lblTimer.Location = new System.Drawing.Point(39, 10);
            this.lblTimer.Name = "lblTimer";
            this.lblTimer.Size = new System.Drawing.Size(48, 20);
            this.lblTimer.TabIndex = 34;
            this.lblTimer.Text = "Timer";
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.lblID.Location = new System.Drawing.Point(17, 11);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(24, 20);
            this.lblID.TabIndex = 33;
            this.lblID.Text = "ID";
            this.lblID.Visible = false;
            // 
            // gunaGradient2Panel1
            // 
            this.gunaGradient2Panel1.BackColor = System.Drawing.Color.Transparent;
            this.gunaGradient2Panel1.Controls.Add(this.lblGr);
            this.gunaGradient2Panel1.GradientColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(68)))), ((int)(((byte)(83)))));
            this.gunaGradient2Panel1.GradientColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(33)))), ((int)(((byte)(107)))));
            this.gunaGradient2Panel1.Location = new System.Drawing.Point(152, 48);
            this.gunaGradient2Panel1.Name = "gunaGradient2Panel1";
            this.gunaGradient2Panel1.Radius = 7;
            this.gunaGradient2Panel1.Size = new System.Drawing.Size(185, 32);
            this.gunaGradient2Panel1.TabIndex = 35;
            // 
            // btnInfo
            // 
            this.btnInfo.AnimationHoverSpeed = 0.07F;
            this.btnInfo.AnimationSpeed = 0.03F;
            this.btnInfo.BackColor = System.Drawing.Color.Transparent;
            this.btnInfo.BaseColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(68)))), ((int)(((byte)(83)))));
            this.btnInfo.BaseColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(33)))), ((int)(((byte)(107)))));
            this.btnInfo.BorderColor = System.Drawing.Color.Black;
            this.btnInfo.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnInfo.FocusedColor = System.Drawing.Color.Empty;
            this.btnInfo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInfo.ForeColor = System.Drawing.Color.White;
            this.btnInfo.Image = ((System.Drawing.Image)(resources.GetObject("btnInfo.Image")));
            this.btnInfo.ImageAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnInfo.ImageSize = new System.Drawing.Size(27, 26);
            this.btnInfo.Location = new System.Drawing.Point(153, 99);
            this.btnInfo.Name = "btnInfo";
            this.btnInfo.OnHoverBaseColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(33)))), ((int)(((byte)(107)))));
            this.btnInfo.OnHoverBaseColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(68)))), ((int)(((byte)(83)))));
            this.btnInfo.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnInfo.OnHoverForeColor = System.Drawing.Color.White;
            this.btnInfo.OnHoverImage = null;
            this.btnInfo.OnPressedColor = System.Drawing.Color.Black;
            this.btnInfo.Radius = 5;
            this.btnInfo.Size = new System.Drawing.Size(72, 38);
            this.btnInfo.TabIndex = 29;
            this.btnInfo.Click += new System.EventHandler(this.btnInfo_Click);
            // 
            // imgFood
            // 
            this.imgFood.BackColor = System.Drawing.Color.Transparent;
            this.imgFood.BaseColor = System.Drawing.Color.White;
            this.imgFood.ErrorImage = ((System.Drawing.Image)(resources.GetObject("imgFood.ErrorImage")));
            this.imgFood.Image = ((System.Drawing.Image)(resources.GetObject("imgFood.Image")));
            this.imgFood.Location = new System.Drawing.Point(7, 7);
            this.imgFood.Name = "imgFood";
            this.imgFood.Radius = 7;
            this.imgFood.Size = new System.Drawing.Size(140, 130);
            this.imgFood.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgFood.TabIndex = 0;
            this.imgFood.TabStop = false;
            // 
            // lblFactor
            // 
            this.lblFactor.AutoSize = true;
            this.lblFactor.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFactor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.lblFactor.Location = new System.Drawing.Point(47, 11);
            this.lblFactor.Name = "lblFactor";
            this.lblFactor.Size = new System.Drawing.Size(51, 20);
            this.lblFactor.TabIndex = 37;
            this.lblFactor.Text = "Factor";
            this.lblFactor.Visible = false;
            // 
            // ItemFood
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Controls.Add(this.lblFactor);
            this.Controls.Add(this.gunaGradient2Panel1);
            this.Controls.Add(this.lblID);
            this.Controls.Add(this.btnInfo);
            this.Controls.Add(this.gunaGradient2Panel2);
            this.Controls.Add(this.lblNameFood);
            this.Controls.Add(this.imgFood);
            this.Name = "ItemFood";
            this.Size = new System.Drawing.Size(345, 144);
            this.gunaGradient2Panel2.ResumeLayout(false);
            this.gunaGradient2Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gunaPictureBox2)).EndInit();
            this.gunaGradient2Panel1.ResumeLayout(false);
            this.gunaGradient2Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgFood)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI.WinForms.GunaElipse borderItem;
        private Guna.UI.WinForms.GunaPictureBox imgFood;
        private System.Windows.Forms.Label lblNameFood;
        private Guna.UI.WinForms.GunaGradient2Panel gunaGradient2Panel2;
        private Guna.UI.WinForms.GunaGradientButton btnInfo;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Label lblTimer;
        private System.Windows.Forms.Label lblGr;
        private Guna.UI.WinForms.GunaPictureBox gunaPictureBox2;
        private Guna.UI.WinForms.GunaGradient2Panel gunaGradient2Panel1;
        private System.Windows.Forms.Label lblFactor;
    }
}
