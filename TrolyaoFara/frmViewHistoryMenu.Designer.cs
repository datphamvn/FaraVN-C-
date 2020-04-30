namespace TrolyaoFara
{
    partial class frmViewHistoryMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmViewHistoryMenu));
            this.btnMenuToday = new Guna.UI.WinForms.GunaGradientButton();
            this.pickDatetime = new Bunifu.Framework.UI.BunifuDatepicker();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSearch = new Guna.UI.WinForms.GunaGradientButton();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnMenuToday
            // 
            this.btnMenuToday.AnimationHoverSpeed = 0.07F;
            this.btnMenuToday.AnimationSpeed = 0.03F;
            this.btnMenuToday.BackColor = System.Drawing.Color.Transparent;
            this.btnMenuToday.BaseColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(68)))), ((int)(((byte)(83)))));
            this.btnMenuToday.BaseColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(33)))), ((int)(((byte)(107)))));
            this.btnMenuToday.BorderColor = System.Drawing.Color.Black;
            this.btnMenuToday.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnMenuToday.FocusedColor = System.Drawing.Color.Empty;
            this.btnMenuToday.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenuToday.ForeColor = System.Drawing.Color.White;
            this.btnMenuToday.Image = null;
            this.btnMenuToday.ImageAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnMenuToday.ImageSize = new System.Drawing.Size(20, 20);
            this.btnMenuToday.Location = new System.Drawing.Point(133, 127);
            this.btnMenuToday.Name = "btnMenuToday";
            this.btnMenuToday.OnHoverBaseColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.btnMenuToday.OnHoverBaseColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(68)))), ((int)(((byte)(173)))));
            this.btnMenuToday.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnMenuToday.OnHoverForeColor = System.Drawing.Color.White;
            this.btnMenuToday.OnHoverImage = null;
            this.btnMenuToday.OnPressedColor = System.Drawing.Color.Black;
            this.btnMenuToday.Radius = 5;
            this.btnMenuToday.Size = new System.Drawing.Size(99, 35);
            this.btnMenuToday.TabIndex = 59;
            this.btnMenuToday.Text = "Hôm nay";
            this.btnMenuToday.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnMenuToday.Click += new System.EventHandler(this.btnMenuToday_Click);
            // 
            // pickDatetime
            // 
            this.pickDatetime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(21)))), ((int)(((byte)(80)))));
            this.pickDatetime.BorderRadius = 4;
            this.pickDatetime.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pickDatetime.ForeColor = System.Drawing.Color.White;
            this.pickDatetime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.pickDatetime.FormatCustom = "dd/MM/yyyy";
            this.pickDatetime.Location = new System.Drawing.Point(89, 70);
            this.pickDatetime.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pickDatetime.Name = "pickDatetime";
            this.pickDatetime.Size = new System.Drawing.Size(181, 33);
            this.pickDatetime.TabIndex = 60;
            this.pickDatetime.Value = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label3.Location = new System.Drawing.Point(29, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 23);
            this.label3.TabIndex = 61;
            this.label3.Text = "Ngày";
            // 
            // btnSearch
            // 
            this.btnSearch.AnimationHoverSpeed = 0.07F;
            this.btnSearch.AnimationSpeed = 0.03F;
            this.btnSearch.BackColor = System.Drawing.Color.Transparent;
            this.btnSearch.BaseColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(68)))), ((int)(((byte)(83)))));
            this.btnSearch.BaseColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(33)))), ((int)(((byte)(107)))));
            this.btnSearch.BorderColor = System.Drawing.Color.Black;
            this.btnSearch.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnSearch.FocusedColor = System.Drawing.Color.Empty;
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.ImageAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnSearch.ImageSize = new System.Drawing.Size(20, 20);
            this.btnSearch.Location = new System.Drawing.Point(279, 69);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.OnHoverBaseColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.btnSearch.OnHoverBaseColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(68)))), ((int)(((byte)(173)))));
            this.btnSearch.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnSearch.OnHoverForeColor = System.Drawing.Color.White;
            this.btnSearch.OnHoverImage = null;
            this.btnSearch.OnPressedColor = System.Drawing.Color.Black;
            this.btnSearch.Radius = 5;
            this.btnSearch.Size = new System.Drawing.Size(57, 35);
            this.btnSearch.TabIndex = 62;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(110, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(157, 30);
            this.label5.TabIndex = 63;
            this.label5.Text = "LỊCH SỬ MENU";
            // 
            // frmViewHistoryMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(20)))), ((int)(((byte)(47)))));
            this.ClientSize = new System.Drawing.Size(373, 193);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.pickDatetime);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnMenuToday);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmViewHistoryMenu";
            this.Text = "Lịch sử Menu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Guna.UI.WinForms.GunaGradientButton btnMenuToday;
        private Bunifu.Framework.UI.BunifuDatepicker pickDatetime;
        private System.Windows.Forms.Label label3;
        private Guna.UI.WinForms.GunaGradientButton btnSearch;
        private System.Windows.Forms.Label label5;
    }
}