namespace TrolyaoFara
{
    partial class frmAddData
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddData));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSend = new Guna.UI.WinForms.GunaGradientButton();
            this.lstIDData = new System.Windows.Forms.ListBox();
            this.imgLoading = new System.Windows.Forms.PictureBox();
            this.lstData = new System.Windows.Forms.ListBox();
            this.txtInput = new Guna.UI.WinForms.GunaTextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgLoading)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnSend);
            this.panel1.Controls.Add(this.lstIDData);
            this.panel1.Controls.Add(this.imgLoading);
            this.panel1.Controls.Add(this.lstData);
            this.panel1.Controls.Add(this.txtInput);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(316, 183);
            this.panel1.TabIndex = 0;
            // 
            // btnSend
            // 
            this.btnSend.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSend.AnimationHoverSpeed = 0.07F;
            this.btnSend.AnimationSpeed = 0.03F;
            this.btnSend.BackColor = System.Drawing.Color.Transparent;
            this.btnSend.BaseColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(68)))), ((int)(((byte)(83)))));
            this.btnSend.BaseColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(33)))), ((int)(((byte)(107)))));
            this.btnSend.BorderColor = System.Drawing.Color.Black;
            this.btnSend.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnSend.FocusedColor = System.Drawing.Color.Empty;
            this.btnSend.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSend.ForeColor = System.Drawing.Color.White;
            this.btnSend.Image = ((System.Drawing.Image)(resources.GetObject("btnSend.Image")));
            this.btnSend.ImageAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnSend.ImageSize = new System.Drawing.Size(20, 20);
            this.btnSend.Location = new System.Drawing.Point(225, 72);
            this.btnSend.MaximumSize = new System.Drawing.Size(90, 38);
            this.btnSend.MinimumSize = new System.Drawing.Size(90, 38);
            this.btnSend.Name = "btnSend";
            this.btnSend.OnHoverBaseColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.btnSend.OnHoverBaseColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(68)))), ((int)(((byte)(173)))));
            this.btnSend.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnSend.OnHoverForeColor = System.Drawing.Color.White;
            this.btnSend.OnHoverImage = null;
            this.btnSend.OnPressedColor = System.Drawing.Color.Black;
            this.btnSend.Radius = 5;
            this.btnSend.Size = new System.Drawing.Size(90, 38);
            this.btnSend.TabIndex = 66;
            // 
            // lstIDData
            // 
            this.lstIDData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstIDData.FormattingEnabled = true;
            this.lstIDData.Location = new System.Drawing.Point(157, 38);
            this.lstIDData.MaximumSize = new System.Drawing.Size(40, 140);
            this.lstIDData.MinimumSize = new System.Drawing.Size(40, 140);
            this.lstIDData.Name = "lstIDData";
            this.lstIDData.Size = new System.Drawing.Size(40, 134);
            this.lstIDData.TabIndex = 64;
            // 
            // imgLoading
            // 
            this.imgLoading.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.imgLoading.Image = ((System.Drawing.Image)(resources.GetObject("imgLoading.Image")));
            this.imgLoading.Location = new System.Drawing.Point(44, 55);
            this.imgLoading.MaximumSize = new System.Drawing.Size(130, 130);
            this.imgLoading.MinimumSize = new System.Drawing.Size(90, 90);
            this.imgLoading.Name = "imgLoading";
            this.imgLoading.Size = new System.Drawing.Size(90, 90);
            this.imgLoading.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgLoading.TabIndex = 65;
            this.imgLoading.TabStop = false;
            // 
            // lstData
            // 
            this.lstData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstData.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstData.FormattingEnabled = true;
            this.lstData.ItemHeight = 17;
            this.lstData.Location = new System.Drawing.Point(2, 38);
            this.lstData.MinimumSize = new System.Drawing.Size(195, 140);
            this.lstData.Name = "lstData";
            this.lstData.Size = new System.Drawing.Size(195, 140);
            this.lstData.TabIndex = 62;
            // 
            // txtInput
            // 
            this.txtInput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInput.BackColor = System.Drawing.Color.Transparent;
            this.txtInput.BaseColor = System.Drawing.Color.White;
            this.txtInput.BorderColor = System.Drawing.Color.Silver;
            this.txtInput.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtInput.FocusedBaseColor = System.Drawing.Color.White;
            this.txtInput.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(21)))), ((int)(((byte)(80)))));
            this.txtInput.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.txtInput.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtInput.Location = new System.Drawing.Point(2, 5);
            this.txtInput.MaximumSize = new System.Drawing.Size(0, 30);
            this.txtInput.MinimumSize = new System.Drawing.Size(195, 30);
            this.txtInput.MultiLine = true;
            this.txtInput.Name = "txtInput";
            this.txtInput.PasswordChar = '\0';
            this.txtInput.Radius = 4;
            this.txtInput.Size = new System.Drawing.Size(195, 30);
            this.txtInput.TabIndex = 63;
            this.txtInput.TextChanged += new System.EventHandler(this.txtInput_TextChanged);
            this.txtInput.Enter += new System.EventHandler(this.txtInput_Enter);
            this.txtInput.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtInput_KeyUp);
            this.txtInput.Leave += new System.EventHandler(this.txtInput_Leave);
            // 
            // frmAddData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(316, 183);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAddData";
            this.Text = "frmAddData";
            this.Load += new System.EventHandler(this.frmAddData_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imgLoading)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Guna.UI.WinForms.GunaGradientButton btnSend;
        private System.Windows.Forms.ListBox lstIDData;
        private System.Windows.Forms.PictureBox imgLoading;
        private System.Windows.Forms.ListBox lstData;
        private Guna.UI.WinForms.GunaTextBox txtInput;
    }
}