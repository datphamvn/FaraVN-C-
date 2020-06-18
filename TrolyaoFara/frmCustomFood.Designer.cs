namespace TrolyaoFara
{
    partial class frmCustomFood
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCustomFood));
            this.pnlAddData = new System.Windows.Forms.Panel();
            this.pnlItemFoodPreview = new System.Windows.Forms.Panel();
            this.btnSave = new Guna.UI.WinForms.GunaGradientButton();
            this.lblTitle = new System.Windows.Forms.Label();
            this.cbxTime = new Guna.UI.WinForms.GunaComboBox();
            this.lblNameFood = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // pnlAddData
            // 
            this.pnlAddData.Location = new System.Drawing.Point(29, 82);
            this.pnlAddData.Name = "pnlAddData";
            this.pnlAddData.Size = new System.Drawing.Size(350, 202);
            this.pnlAddData.TabIndex = 0;
            // 
            // pnlItemFoodPreview
            // 
            this.pnlItemFoodPreview.Location = new System.Drawing.Point(399, 140);
            this.pnlItemFoodPreview.Name = "pnlItemFoodPreview";
            this.pnlItemFoodPreview.Size = new System.Drawing.Size(345, 144);
            this.pnlItemFoodPreview.TabIndex = 1;
            // 
            // btnSave
            // 
            this.btnSave.AnimationHoverSpeed = 0.07F;
            this.btnSave.AnimationSpeed = 0.03F;
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.BaseColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(68)))), ((int)(((byte)(83)))));
            this.btnSave.BaseColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(33)))), ((int)(((byte)(107)))));
            this.btnSave.BorderColor = System.Drawing.Color.Black;
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnSave.FocusedColor = System.Drawing.Color.Empty;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Image = global::TrolyaoFara.Properties.Resources.tick;
            this.btnSave.ImageAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.btnSave.ImageSize = new System.Drawing.Size(20, 20);
            this.btnSave.Location = new System.Drawing.Point(664, 311);
            this.btnSave.Name = "btnSave";
            this.btnSave.OnHoverBaseColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.btnSave.OnHoverBaseColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(68)))), ((int)(((byte)(173)))));
            this.btnSave.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnSave.OnHoverForeColor = System.Drawing.Color.White;
            this.btnSave.OnHoverImage = null;
            this.btnSave.OnPressedColor = System.Drawing.Color.Black;
            this.btnSave.Radius = 5;
            this.btnSave.Size = new System.Drawing.Size(80, 40);
            this.btnSave.TabIndex = 41;
            this.btnSave.Text = "Lưu";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(292, 10);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(175, 30);
            this.lblTitle.TabIndex = 42;
            this.lblTitle.Text = "Thay đổi món ăn";
            // 
            // cbxTime
            // 
            this.cbxTime.AllowDrop = true;
            this.cbxTime.BackColor = System.Drawing.Color.Transparent;
            this.cbxTime.BaseColor = System.Drawing.Color.White;
            this.cbxTime.BorderColor = System.Drawing.Color.Silver;
            this.cbxTime.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbxTime.DropDownHeight = 200;
            this.cbxTime.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxTime.FocusedColor = System.Drawing.Color.Empty;
            this.cbxTime.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxTime.ForeColor = System.Drawing.Color.Black;
            this.cbxTime.FormattingEnabled = true;
            this.cbxTime.IntegralHeight = false;
            this.cbxTime.Items.AddRange(new object[] {
            "Bữa sáng",
            "Bữa trưa",
            "Bữa tối"});
            this.cbxTime.Location = new System.Drawing.Point(545, 82);
            this.cbxTime.Name = "cbxTime";
            this.cbxTime.OnHoverItemBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.cbxTime.OnHoverItemForeColor = System.Drawing.Color.White;
            this.cbxTime.Radius = 4;
            this.cbxTime.Size = new System.Drawing.Size(158, 28);
            this.cbxTime.TabIndex = 59;
            // 
            // lblNameFood
            // 
            this.lblNameFood.AutoSize = true;
            this.lblNameFood.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNameFood.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.lblNameFood.Location = new System.Drawing.Point(446, 85);
            this.lblNameFood.Name = "lblNameFood";
            this.lblNameFood.Size = new System.Drawing.Size(77, 20);
            this.lblNameFood.TabIndex = 60;
            this.lblNameFood.Text = "Thời điểm";
            this.lblNameFood.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmCustomFood
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(20)))), ((int)(((byte)(47)))));
            this.ClientSize = new System.Drawing.Size(768, 372);
            this.Controls.Add(this.lblNameFood);
            this.Controls.Add(this.cbxTime);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.pnlItemFoodPreview);
            this.Controls.Add(this.pnlAddData);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCustomFood";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thay đổi món ăn";
            this.Load += new System.EventHandler(this.frmCustomFood_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlAddData;
        private System.Windows.Forms.Panel pnlItemFoodPreview;
        private Guna.UI.WinForms.GunaGradientButton btnSave;
        private System.Windows.Forms.Label lblTitle;
        private Guna.UI.WinForms.GunaComboBox cbxTime;
        private System.Windows.Forms.Label lblNameFood;
    }
}