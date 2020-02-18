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
            this.gunaPictureBox1 = new Guna.UI.WinForms.GunaPictureBox();
            this.lblNameFood = new System.Windows.Forms.Label();
            this.lblGr = new System.Windows.Forms.Label();
            this.gunaGradient2Panel2 = new Guna.UI.WinForms.GunaGradient2Panel();
            this.gunaPictureBox2 = new Guna.UI.WinForms.GunaPictureBox();
            this.lblTimer = new System.Windows.Forms.Label();
            this.btnInfo = new Guna.UI.WinForms.GunaGradientButton();
            this.lblID = new System.Windows.Forms.Label();
            this.gunaGradient2Panel1 = new Guna.UI.WinForms.GunaGradient2Panel();
            ((System.ComponentModel.ISupportInitialize)(this.gunaPictureBox1)).BeginInit();
            this.gunaGradient2Panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gunaPictureBox2)).BeginInit();
            this.gunaGradient2Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // borderItem
            // 
            this.borderItem.Radius = 5;
            this.borderItem.TargetControl = this;
            // 
            // gunaPictureBox1
            // 
            this.gunaPictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.gunaPictureBox1.BaseColor = System.Drawing.Color.White;
            this.gunaPictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("gunaPictureBox1.Image")));
            this.gunaPictureBox1.Location = new System.Drawing.Point(7, 7);
            this.gunaPictureBox1.Name = "gunaPictureBox1";
            this.gunaPictureBox1.Radius = 7;
            this.gunaPictureBox1.Size = new System.Drawing.Size(140, 130);
            this.gunaPictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.gunaPictureBox1.TabIndex = 0;
            this.gunaPictureBox1.TabStop = false;
            // 
            // lblNameFood
            // 
            this.lblNameFood.AutoSize = true;
            this.lblNameFood.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNameFood.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(21)))), ((int)(((byte)(80)))));
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
            this.gunaGradient2Panel2.GradientColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(68)))), ((int)(((byte)(173)))));
            this.gunaGradient2Panel2.Location = new System.Drawing.Point(225, 95);
            this.gunaGradient2Panel2.Name = "gunaGradient2Panel2";
            this.gunaGradient2Panel2.Radius = 7;
            this.gunaGradient2Panel2.Size = new System.Drawing.Size(103, 40);
            this.gunaGradient2Panel2.TabIndex = 3;
            // 
            // gunaPictureBox2
            // 
            this.gunaPictureBox2.BaseColor = System.Drawing.Color.White;
            this.gunaPictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("gunaPictureBox2.Image")));
            this.gunaPictureBox2.Location = new System.Drawing.Point(6, 5);
            this.gunaPictureBox2.Name = "gunaPictureBox2";
            this.gunaPictureBox2.Size = new System.Drawing.Size(30, 30);
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
            this.lblTimer.Location = new System.Drawing.Point(39, 11);
            this.lblTimer.Name = "lblTimer";
            this.lblTimer.Size = new System.Drawing.Size(48, 20);
            this.lblTimer.TabIndex = 34;
            this.lblTimer.Text = "Timer";
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
            this.btnInfo.ImageAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.btnInfo.ImageSize = new System.Drawing.Size(20, 20);
            this.btnInfo.Location = new System.Drawing.Point(160, 95);
            this.btnInfo.Name = "btnInfo";
            this.btnInfo.OnHoverBaseColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.btnInfo.OnHoverBaseColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(68)))), ((int)(((byte)(173)))));
            this.btnInfo.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnInfo.OnHoverForeColor = System.Drawing.Color.White;
            this.btnInfo.OnHoverImage = null;
            this.btnInfo.OnPressedColor = System.Drawing.Color.Black;
            this.btnInfo.Radius = 5;
            this.btnInfo.Size = new System.Drawing.Size(42, 40);
            this.btnInfo.TabIndex = 29;
            this.btnInfo.Click += new System.EventHandler(this.btnResetSetting_Click);
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(21)))), ((int)(((byte)(80)))));
            this.lblID.Location = new System.Drawing.Point(24, 106);
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
            this.gunaGradient2Panel1.GradientColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(68)))), ((int)(((byte)(173)))));
            this.gunaGradient2Panel1.Location = new System.Drawing.Point(160, 47);
            this.gunaGradient2Panel1.Name = "gunaGradient2Panel1";
            this.gunaGradient2Panel1.Radius = 7;
            this.gunaGradient2Panel1.Size = new System.Drawing.Size(168, 32);
            this.gunaGradient2Panel1.TabIndex = 35;
            // 
            // ItemFood
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Controls.Add(this.gunaGradient2Panel1);
            this.Controls.Add(this.lblID);
            this.Controls.Add(this.btnInfo);
            this.Controls.Add(this.gunaGradient2Panel2);
            this.Controls.Add(this.lblNameFood);
            this.Controls.Add(this.gunaPictureBox1);
            this.Name = "ItemFood";
            this.Size = new System.Drawing.Size(345, 144);
            this.Load += new System.EventHandler(this.ItemFood_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gunaPictureBox1)).EndInit();
            this.gunaGradient2Panel2.ResumeLayout(false);
            this.gunaGradient2Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gunaPictureBox2)).EndInit();
            this.gunaGradient2Panel1.ResumeLayout(false);
            this.gunaGradient2Panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI.WinForms.GunaElipse borderItem;
        private Guna.UI.WinForms.GunaPictureBox gunaPictureBox1;
        private System.Windows.Forms.Label lblNameFood;
        private Guna.UI.WinForms.GunaGradient2Panel gunaGradient2Panel2;
        private Guna.UI.WinForms.GunaGradientButton btnInfo;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Label lblTimer;
        private System.Windows.Forms.Label lblGr;
        private Guna.UI.WinForms.GunaPictureBox gunaPictureBox2;
        private Guna.UI.WinForms.GunaGradient2Panel gunaGradient2Panel1;
    }
}
