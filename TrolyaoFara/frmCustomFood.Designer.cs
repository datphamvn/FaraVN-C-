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
            this.pnlAddData = new System.Windows.Forms.Panel();
            this.pnlItemFoodPreview = new System.Windows.Forms.Panel();
            this.btnSave = new Guna.UI.WinForms.GunaGradientButton();
            this.SuspendLayout();
            // 
            // pnlAddData
            // 
            this.pnlAddData.Location = new System.Drawing.Point(39, 68);
            this.pnlAddData.Name = "pnlAddData";
            this.pnlAddData.Size = new System.Drawing.Size(357, 224);
            this.pnlAddData.TabIndex = 0;
            // 
            // pnlItemFoodPreview
            // 
            this.pnlItemFoodPreview.Location = new System.Drawing.Point(420, 116);
            this.pnlItemFoodPreview.Name = "pnlItemFoodPreview";
            this.pnlItemFoodPreview.Size = new System.Drawing.Size(241, 144);
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
            this.btnSave.Location = new System.Drawing.Point(594, 313);
            this.btnSave.Name = "btnSave";
            this.btnSave.OnHoverBaseColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.btnSave.OnHoverBaseColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(68)))), ((int)(((byte)(173)))));
            this.btnSave.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnSave.OnHoverForeColor = System.Drawing.Color.White;
            this.btnSave.OnHoverImage = null;
            this.btnSave.OnPressedColor = System.Drawing.Color.Black;
            this.btnSave.Radius = 5;
            this.btnSave.Size = new System.Drawing.Size(75, 40);
            this.btnSave.TabIndex = 41;
            this.btnSave.Text = "Lưu";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // frmCustomFood
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(20)))), ((int)(((byte)(47)))));
            this.ClientSize = new System.Drawing.Size(681, 365);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.pnlItemFoodPreview);
            this.Controls.Add(this.pnlAddData);
            this.Name = "frmCustomFood";
            this.Text = "frmCustomFood";
            this.Load += new System.EventHandler(this.frmCustomFood_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlAddData;
        private System.Windows.Forms.Panel pnlItemFoodPreview;
        private Guna.UI.WinForms.GunaGradientButton btnSave;
    }
}