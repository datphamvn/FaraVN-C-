namespace TrolyaoFara
{
    partial class frmLoading
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLoading));
            this.brd_frmLoading = new Guna.UI.WinForms.GunaElipse(this.components);
            this.lblContent = new System.Windows.Forms.Label();
            this.load1 = new TrolyaoFara.Load();
            this.SuspendLayout();
            // 
            // brd_frmLoading
            // 
            this.brd_frmLoading.Radius = 8;
            this.brd_frmLoading.TargetControl = this;
            // 
            // lblContent
            // 
            this.lblContent.AutoSize = true;
            this.lblContent.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContent.ForeColor = System.Drawing.Color.DimGray;
            this.lblContent.Location = new System.Drawing.Point(102, 232);
            this.lblContent.Name = "lblContent";
            this.lblContent.Size = new System.Drawing.Size(77, 23);
            this.lblContent.TabIndex = 1;
            this.lblContent.Text = "Loading...";
            // 
            // load1
            // 
            this.load1.Location = new System.Drawing.Point(79, 70);
            this.load1.Name = "load1";
            this.load1.Size = new System.Drawing.Size(115, 119);
            this.load1.TabIndex = 0;
            // 
            // frmLoading
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(293, 319);
            this.Controls.Add(this.lblContent);
            this.Controls.Add(this.load1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmLoading";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "frmLoading";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI.WinForms.GunaElipse brd_frmLoading;
        private System.Windows.Forms.Label lblContent;
        private Load load1;
    }
}