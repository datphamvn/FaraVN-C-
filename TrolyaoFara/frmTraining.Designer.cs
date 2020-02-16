namespace TrolyaoFara
{
    partial class frmTraining
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTraining));
            this.label2 = new System.Windows.Forms.Label();
            this.gunaDataGridView1 = new Guna.UI.WinForms.GunaDataGridView();
            this.lstIdFoodName = new System.Windows.Forms.ListBox();
            this.txtFoodName = new Guna.UI.WinForms.GunaTextBox();
            this.lstFoodName = new System.Windows.Forms.ListBox();
            this.txtID = new Guna.UI.WinForms.GunaTextBox();
            this.txtNamefood = new Guna.UI.WinForms.GunaTextBox();
            this.numRaing = new Guna.UI.WinForms.GunaNumeric();
            this.groupEdit = new Guna.UI.WinForms.GunaGroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtRating = new Guna.UI.WinForms.GunaNumeric();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnDelete = new Guna.UI.WinForms.GunaButton();
            this.btnUpdate = new Guna.UI.WinForms.GunaButton();
            this.picPreviewFood = new Guna.UI.WinForms.GunaPictureBox();
            this.btnSubmit = new Guna.UI.WinForms.GunaButton();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.namefood = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rating = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gunaDataGridView1)).BeginInit();
            this.groupEdit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPreviewFood)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(374, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(146, 30);
            this.label2.TabIndex = 3;
            this.label2.Text = "Huấn luyện AI";
            // 
            // gunaDataGridView1
            // 
            this.gunaDataGridView1.AllowUserToAddRows = false;
            this.gunaDataGridView1.AllowUserToDeleteRows = false;
            this.gunaDataGridView1.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(196)))), ((int)(((byte)(233)))));
            this.gunaDataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gunaDataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gunaDataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.gunaDataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gunaDataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.gunaDataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(58)))), ((int)(((byte)(183)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gunaDataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gunaDataGridView1.ColumnHeadersHeight = 40;
            this.gunaDataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.namefood,
            this.rating});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(215)))), ((int)(((byte)(240)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(123)))), ((int)(((byte)(207)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gunaDataGridView1.DefaultCellStyle = dataGridViewCellStyle3;
            this.gunaDataGridView1.EnableHeadersVisualStyles = false;
            this.gunaDataGridView1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(193)))), ((int)(((byte)(232)))));
            this.gunaDataGridView1.Location = new System.Drawing.Point(422, 120);
            this.gunaDataGridView1.Name = "gunaDataGridView1";
            this.gunaDataGridView1.ReadOnly = true;
            this.gunaDataGridView1.RowHeadersVisible = false;
            this.gunaDataGridView1.RowTemplate.DividerHeight = 1;
            this.gunaDataGridView1.RowTemplate.Height = 25;
            this.gunaDataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gunaDataGridView1.Size = new System.Drawing.Size(466, 186);
            this.gunaDataGridView1.TabIndex = 4;
            this.gunaDataGridView1.Theme = Guna.UI.WinForms.GunaDataGridViewPresetThemes.DeepPurple;
            this.gunaDataGridView1.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(196)))), ((int)(((byte)(233)))));
            this.gunaDataGridView1.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.gunaDataGridView1.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.gunaDataGridView1.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.gunaDataGridView1.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.gunaDataGridView1.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.gunaDataGridView1.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(193)))), ((int)(((byte)(232)))));
            this.gunaDataGridView1.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(58)))), ((int)(((byte)(183)))));
            this.gunaDataGridView1.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.gunaDataGridView1.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.gunaDataGridView1.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.gunaDataGridView1.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.gunaDataGridView1.ThemeStyle.HeaderStyle.Height = 40;
            this.gunaDataGridView1.ThemeStyle.ReadOnly = true;
            this.gunaDataGridView1.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(215)))), ((int)(((byte)(240)))));
            this.gunaDataGridView1.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.gunaDataGridView1.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.gunaDataGridView1.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.gunaDataGridView1.ThemeStyle.RowsStyle.Height = 25;
            this.gunaDataGridView1.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(123)))), ((int)(((byte)(207)))));
            this.gunaDataGridView1.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.gunaDataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gunaDataGridView1_CellContentClick);
            // 
            // lstIdFoodName
            // 
            this.lstIdFoodName.FormattingEnabled = true;
            this.lstIdFoodName.Location = new System.Drawing.Point(313, 110);
            this.lstIdFoodName.Name = "lstIdFoodName";
            this.lstIdFoodName.Size = new System.Drawing.Size(44, 186);
            this.lstIdFoodName.TabIndex = 49;
            // 
            // txtFoodName
            // 
            this.txtFoodName.BackColor = System.Drawing.Color.Transparent;
            this.txtFoodName.BaseColor = System.Drawing.Color.White;
            this.txtFoodName.BorderColor = System.Drawing.Color.Silver;
            this.txtFoodName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtFoodName.FocusedBaseColor = System.Drawing.Color.White;
            this.txtFoodName.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(21)))), ((int)(((byte)(80)))));
            this.txtFoodName.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.txtFoodName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtFoodName.Location = new System.Drawing.Point(62, 71);
            this.txtFoodName.MultiLine = true;
            this.txtFoodName.Name = "txtFoodName";
            this.txtFoodName.PasswordChar = '\0';
            this.txtFoodName.Radius = 4;
            this.txtFoodName.Size = new System.Drawing.Size(299, 32);
            this.txtFoodName.TabIndex = 46;
            this.txtFoodName.Enter += new System.EventHandler(this.txtFoodName_Enter);
            this.txtFoodName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtFoodName_KeyUp);
            this.txtFoodName.Leave += new System.EventHandler(this.txtFoodName_Leave);
            // 
            // lstFoodName
            // 
            this.lstFoodName.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstFoodName.FormattingEnabled = true;
            this.lstFoodName.ItemHeight = 17;
            this.lstFoodName.Location = new System.Drawing.Point(62, 108);
            this.lstFoodName.Name = "lstFoodName";
            this.lstFoodName.Size = new System.Drawing.Size(299, 191);
            this.lstFoodName.TabIndex = 45;
            this.lstFoodName.SelectedIndexChanged += new System.EventHandler(this.lstFoodName_SelectedIndexChanged);
            // 
            // txtID
            // 
            this.txtID.BackColor = System.Drawing.Color.Transparent;
            this.txtID.BaseColor = System.Drawing.Color.White;
            this.txtID.BorderColor = System.Drawing.Color.Silver;
            this.txtID.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtID.Enabled = false;
            this.txtID.FocusedBaseColor = System.Drawing.Color.White;
            this.txtID.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(21)))), ((int)(((byte)(80)))));
            this.txtID.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.txtID.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtID.Location = new System.Drawing.Point(74, 48);
            this.txtID.MultiLine = true;
            this.txtID.Name = "txtID";
            this.txtID.PasswordChar = '\0';
            this.txtID.Radius = 4;
            this.txtID.Size = new System.Drawing.Size(56, 32);
            this.txtID.TabIndex = 52;
            // 
            // txtNamefood
            // 
            this.txtNamefood.BackColor = System.Drawing.Color.Transparent;
            this.txtNamefood.BaseColor = System.Drawing.Color.White;
            this.txtNamefood.BorderColor = System.Drawing.Color.Silver;
            this.txtNamefood.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtNamefood.FocusedBaseColor = System.Drawing.Color.White;
            this.txtNamefood.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(21)))), ((int)(((byte)(80)))));
            this.txtNamefood.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.txtNamefood.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtNamefood.ForeColor = System.Drawing.Color.Black;
            this.txtNamefood.Location = new System.Drawing.Point(238, 48);
            this.txtNamefood.MultiLine = true;
            this.txtNamefood.Name = "txtNamefood";
            this.txtNamefood.PasswordChar = '\0';
            this.txtNamefood.Radius = 4;
            this.txtNamefood.Size = new System.Drawing.Size(208, 32);
            this.txtNamefood.TabIndex = 54;
            // 
            // numRaing
            // 
            this.numRaing.BackColor = System.Drawing.Color.Transparent;
            this.numRaing.BaseColor = System.Drawing.Color.White;
            this.numRaing.BorderColor = System.Drawing.Color.Silver;
            this.numRaing.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(21)))), ((int)(((byte)(80)))));
            this.numRaing.ButtonForeColor = System.Drawing.Color.White;
            this.numRaing.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.numRaing.ForeColor = System.Drawing.Color.Black;
            this.numRaing.Location = new System.Drawing.Point(377, 71);
            this.numRaing.Maximum = ((long)(5));
            this.numRaing.Minimum = ((long)(0));
            this.numRaing.Name = "numRaing";
            this.numRaing.Radius = 3;
            this.numRaing.Size = new System.Drawing.Size(71, 30);
            this.numRaing.TabIndex = 57;
            this.numRaing.Text = "gunaNumeric1";
            this.numRaing.Value = ((long)(5));
            // 
            // groupEdit
            // 
            this.groupEdit.BackColor = System.Drawing.Color.Transparent;
            this.groupEdit.BaseColor = System.Drawing.Color.White;
            this.groupEdit.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(21)))), ((int)(((byte)(80)))));
            this.groupEdit.BorderSize = 1;
            this.groupEdit.Controls.Add(this.label3);
            this.groupEdit.Controls.Add(this.txtRating);
            this.groupEdit.Controls.Add(this.label1);
            this.groupEdit.Controls.Add(this.label5);
            this.groupEdit.Controls.Add(this.txtID);
            this.groupEdit.Controls.Add(this.btnDelete);
            this.groupEdit.Controls.Add(this.txtNamefood);
            this.groupEdit.Controls.Add(this.btnUpdate);
            this.groupEdit.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupEdit.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupEdit.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(21)))), ((int)(((byte)(80)))));
            this.groupEdit.LineTop = 36;
            this.groupEdit.Location = new System.Drawing.Point(422, 325);
            this.groupEdit.Name = "groupEdit";
            this.groupEdit.Radius = 5;
            this.groupEdit.Size = new System.Drawing.Size(473, 196);
            this.groupEdit.TabIndex = 58;
            this.groupEdit.Text = "Chỉnh sửa";
            this.groupEdit.TextLocation = new System.Drawing.Point(10, 8);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(21)))), ((int)(((byte)(80)))));
            this.label3.Location = new System.Drawing.Point(173, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 20);
            this.label3.TabIndex = 60;
            this.label3.Text = "Món ăn";
            // 
            // txtRating
            // 
            this.txtRating.BackColor = System.Drawing.Color.Transparent;
            this.txtRating.BaseColor = System.Drawing.Color.White;
            this.txtRating.BorderColor = System.Drawing.Color.Silver;
            this.txtRating.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(21)))), ((int)(((byte)(80)))));
            this.txtRating.ButtonForeColor = System.Drawing.Color.White;
            this.txtRating.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtRating.ForeColor = System.Drawing.Color.Black;
            this.txtRating.Location = new System.Drawing.Point(97, 99);
            this.txtRating.Maximum = ((long)(5));
            this.txtRating.Minimum = ((long)(0));
            this.txtRating.Name = "txtRating";
            this.txtRating.Radius = 3;
            this.txtRating.Size = new System.Drawing.Size(71, 30);
            this.txtRating.TabIndex = 59;
            this.txtRating.Text = "gunaNumeric1";
            this.txtRating.Value = ((long)(5));
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(21)))), ((int)(((byte)(80)))));
            this.label1.Location = new System.Drawing.Point(44, 104);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 20);
            this.label1.TabIndex = 58;
            this.label1.Text = "Rate";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(21)))), ((int)(((byte)(80)))));
            this.label5.Location = new System.Drawing.Point(44, 54);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(24, 20);
            this.label5.TabIndex = 57;
            this.label5.Text = "ID";
            // 
            // btnDelete
            // 
            this.btnDelete.AnimationHoverSpeed = 0.07F;
            this.btnDelete.AnimationSpeed = 0.03F;
            this.btnDelete.BackColor = System.Drawing.Color.Transparent;
            this.btnDelete.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(21)))), ((int)(((byte)(80)))));
            this.btnDelete.BorderColor = System.Drawing.Color.Black;
            this.btnDelete.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnDelete.FocusedColor = System.Drawing.Color.Empty;
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Image = global::TrolyaoFara.Properties.Resources.minus;
            this.btnDelete.ImageSize = new System.Drawing.Size(20, 20);
            this.btnDelete.Location = new System.Drawing.Point(366, 147);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(68)))), ((int)(((byte)(83)))));
            this.btnDelete.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnDelete.OnHoverForeColor = System.Drawing.Color.White;
            this.btnDelete.OnHoverImage = null;
            this.btnDelete.OnPressedColor = System.Drawing.Color.Black;
            this.btnDelete.Radius = 7;
            this.btnDelete.Size = new System.Drawing.Size(91, 35);
            this.btnDelete.TabIndex = 56;
            this.btnDelete.Text = "    Xóa";
            this.btnDelete.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.AnimationHoverSpeed = 0.07F;
            this.btnUpdate.AnimationSpeed = 0.03F;
            this.btnUpdate.BackColor = System.Drawing.Color.Transparent;
            this.btnUpdate.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(21)))), ((int)(((byte)(80)))));
            this.btnUpdate.BorderColor = System.Drawing.Color.Black;
            this.btnUpdate.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnUpdate.FocusedColor = System.Drawing.Color.Empty;
            this.btnUpdate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.ForeColor = System.Drawing.Color.White;
            this.btnUpdate.Image = global::TrolyaoFara.Properties.Resources.tick;
            this.btnUpdate.ImageSize = new System.Drawing.Size(20, 20);
            this.btnUpdate.Location = new System.Drawing.Point(19, 147);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(68)))), ((int)(((byte)(83)))));
            this.btnUpdate.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnUpdate.OnHoverForeColor = System.Drawing.Color.White;
            this.btnUpdate.OnHoverImage = null;
            this.btnUpdate.OnPressedColor = System.Drawing.Color.Black;
            this.btnUpdate.Radius = 7;
            this.btnUpdate.Size = new System.Drawing.Size(91, 35);
            this.btnUpdate.TabIndex = 55;
            this.btnUpdate.Text = "    Sửa";
            this.btnUpdate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // picPreviewFood
            // 
            this.picPreviewFood.BackColor = System.Drawing.Color.Transparent;
            this.picPreviewFood.BaseColor = System.Drawing.Color.White;
            this.picPreviewFood.Location = new System.Drawing.Point(75, 316);
            this.picPreviewFood.Name = "picPreviewFood";
            this.picPreviewFood.Radius = 6;
            this.picPreviewFood.Size = new System.Drawing.Size(276, 157);
            this.picPreviewFood.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picPreviewFood.TabIndex = 50;
            this.picPreviewFood.TabStop = false;
            this.picPreviewFood.UseTransfarantBackground = true;
            // 
            // btnSubmit
            // 
            this.btnSubmit.AnimationHoverSpeed = 0.07F;
            this.btnSubmit.AnimationSpeed = 0.03F;
            this.btnSubmit.BackColor = System.Drawing.Color.Transparent;
            this.btnSubmit.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(21)))), ((int)(((byte)(80)))));
            this.btnSubmit.BorderColor = System.Drawing.Color.Black;
            this.btnSubmit.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnSubmit.FocusedColor = System.Drawing.Color.Empty;
            this.btnSubmit.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmit.ForeColor = System.Drawing.Color.White;
            this.btnSubmit.Image = global::TrolyaoFara.Properties.Resources.plus;
            this.btnSubmit.ImageSize = new System.Drawing.Size(20, 20);
            this.btnSubmit.Location = new System.Drawing.Point(470, 70);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(68)))), ((int)(((byte)(83)))));
            this.btnSubmit.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnSubmit.OnHoverForeColor = System.Drawing.Color.White;
            this.btnSubmit.OnHoverImage = null;
            this.btnSubmit.OnPressedColor = System.Drawing.Color.Black;
            this.btnSubmit.Radius = 7;
            this.btnSubmit.Size = new System.Drawing.Size(119, 35);
            this.btnSubmit.TabIndex = 48;
            this.btnSubmit.Text = "      Đánh giá";
            this.btnSubmit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::TrolyaoFara.Properties.Resources.search;
            this.pictureBox4.Location = new System.Drawing.Point(24, 71);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(32, 32);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 47;
            this.pictureBox4.TabStop = false;
            // 
            // ID
            // 
            this.ID.FillWeight = 76.14214F;
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            // 
            // namefood
            // 
            this.namefood.FillWeight = 166.1283F;
            this.namefood.HeaderText = "Món ăn";
            this.namefood.Name = "namefood";
            this.namefood.ReadOnly = true;
            // 
            // rating
            // 
            this.rating.FillWeight = 57.72959F;
            this.rating.HeaderText = "Rating";
            this.rating.Name = "rating";
            this.rating.ReadOnly = true;
            // 
            // frmTraining
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(23)))), ((int)(((byte)(48)))));
            this.ClientSize = new System.Drawing.Size(921, 538);
            this.Controls.Add(this.groupEdit);
            this.Controls.Add(this.numRaing);
            this.Controls.Add(this.picPreviewFood);
            this.Controls.Add(this.lstIdFoodName);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.txtFoodName);
            this.Controls.Add(this.lstFoodName);
            this.Controls.Add(this.gunaDataGridView1);
            this.Controls.Add(this.label2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmTraining";
            this.Text = "Training";
            this.Load += new System.EventHandler(this.frmTraining_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gunaDataGridView1)).EndInit();
            this.groupEdit.ResumeLayout(false);
            this.groupEdit.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPreviewFood)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private Guna.UI.WinForms.GunaDataGridView gunaDataGridView1;
        private Guna.UI.WinForms.GunaPictureBox picPreviewFood;
        private System.Windows.Forms.ListBox lstIdFoodName;
        private Guna.UI.WinForms.GunaButton btnSubmit;
        private System.Windows.Forms.PictureBox pictureBox4;
        private Guna.UI.WinForms.GunaTextBox txtFoodName;
        private System.Windows.Forms.ListBox lstFoodName;
        private Guna.UI.WinForms.GunaTextBox txtID;
        private Guna.UI.WinForms.GunaTextBox txtNamefood;
        private Guna.UI.WinForms.GunaButton btnUpdate;
        private Guna.UI.WinForms.GunaButton btnDelete;
        private Guna.UI.WinForms.GunaNumeric numRaing;
        private Guna.UI.WinForms.GunaGroupBox groupEdit;
        private System.Windows.Forms.Label label3;
        private Guna.UI.WinForms.GunaNumeric txtRating;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn namefood;
        private System.Windows.Forms.DataGridViewTextBoxColumn rating;
    }
}