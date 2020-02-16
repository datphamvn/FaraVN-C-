namespace TrolyaoFara
{
    partial class ItemFoodMini
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ItemFoodMini));
            this.gunaPictureBox1 = new Guna.UI.WinForms.GunaPictureBox();
            this.lblName = new System.Windows.Forms.Label();
            this.gunaGradient2Panel2 = new Guna.UI.WinForms.GunaGradient2Panel();
            this.gunaElipse1 = new Guna.UI.WinForms.GunaElipse(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.gunaPictureBox1)).BeginInit();
            this.gunaGradient2Panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // gunaPictureBox1
            // 
            this.gunaPictureBox1.BaseColor = System.Drawing.Color.White;
            this.gunaPictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("gunaPictureBox1.Image")));
            this.gunaPictureBox1.Location = new System.Drawing.Point(0, 29);
            this.gunaPictureBox1.Name = "gunaPictureBox1";
            this.gunaPictureBox1.Size = new System.Drawing.Size(138, 92);
            this.gunaPictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.gunaPictureBox1.TabIndex = 0;
            this.gunaPictureBox1.TabStop = false;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.ForeColor = System.Drawing.Color.Black;
            this.lblName.Location = new System.Drawing.Point(1, 6);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(76, 17);
            this.lblName.TabIndex = 4;
            this.lblName.Text = "Tên món ăn";
            // 
            // gunaGradient2Panel2
            // 
            this.gunaGradient2Panel2.BackColor = System.Drawing.Color.Transparent;
            this.gunaGradient2Panel2.Controls.Add(this.lblName);
            this.gunaGradient2Panel2.GradientColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(186)))), ((int)(((byte)(171)))));
            this.gunaGradient2Panel2.GradientColor2 = System.Drawing.Color.White;
            this.gunaGradient2Panel2.Location = new System.Drawing.Point(0, 0);
            this.gunaGradient2Panel2.Name = "gunaGradient2Panel2";
            this.gunaGradient2Panel2.Size = new System.Drawing.Size(138, 30);
            this.gunaGradient2Panel2.TabIndex = 37;
            // 
            // gunaElipse1
            // 
            this.gunaElipse1.Radius = 2;
            this.gunaElipse1.TargetControl = this;
            // 
            // ItemFoodMini
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.gunaGradient2Panel2);
            this.Controls.Add(this.gunaPictureBox1);
            this.Name = "ItemFoodMini";
            this.Size = new System.Drawing.Size(138, 120);
            ((System.ComponentModel.ISupportInitialize)(this.gunaPictureBox1)).EndInit();
            this.gunaGradient2Panel2.ResumeLayout(false);
            this.gunaGradient2Panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI.WinForms.GunaPictureBox gunaPictureBox1;
        private System.Windows.Forms.Label lblName;
        private Guna.UI.WinForms.GunaGradient2Panel gunaGradient2Panel2;
        private Guna.UI.WinForms.GunaElipse gunaElipse1;
    }
}
