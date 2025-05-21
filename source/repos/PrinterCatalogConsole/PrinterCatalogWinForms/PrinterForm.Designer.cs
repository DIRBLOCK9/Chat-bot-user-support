namespace PrinterCatalogWinForms
{
    partial class PrinterForm
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
            this.txtCode = new System.Windows.Forms.TextBox();
            this.txtModel = new System.Windows.Forms.TextBox();
            this.txtBrand = new System.Windows.Forms.TextBox();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.cmbPrintSize = new System.Windows.Forms.ComboBox();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.chkDuplex = new System.Windows.Forms.CheckBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.cmbPurpose = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(64, 70);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(100, 20);
            this.txtCode.TabIndex = 0;
            this.txtCode.Text = "Введіть код";
            this.txtCode.TextChanged += new System.EventHandler(this.txtCode_TextChanged);
            this.txtCode.Enter += new System.EventHandler(this.txtCode_Enter);
            this.txtCode.Leave += new System.EventHandler(this.txtCode_Leave);
            // 
            // txtModel
            // 
            this.txtModel.Location = new System.Drawing.Point(64, 96);
            this.txtModel.Name = "txtModel";
            this.txtModel.Size = new System.Drawing.Size(100, 20);
            this.txtModel.TabIndex = 1;
            this.txtModel.Text = "Введіть модель";
            this.txtModel.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            this.txtModel.Enter += new System.EventHandler(this.txtModel_Enter);
            this.txtModel.Leave += new System.EventHandler(this.txtModel_Leave);
            // 
            // txtBrand
            // 
            this.txtBrand.Location = new System.Drawing.Point(64, 122);
            this.txtBrand.Name = "txtBrand";
            this.txtBrand.Size = new System.Drawing.Size(100, 20);
            this.txtBrand.TabIndex = 2;
            this.txtBrand.Text = "Введіть фірму";
            this.txtBrand.Enter += new System.EventHandler(this.txtBrand_Enter);
            this.txtBrand.Leave += new System.EventHandler(this.txtBrand_Leave);
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(64, 202);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(100, 20);
            this.txtPrice.TabIndex = 4;
            this.txtPrice.Text = "Ціна";
            this.txtPrice.Enter += new System.EventHandler(this.txtPrice_Enter);
            this.txtPrice.Leave += new System.EventHandler(this.txtPrice_Leave);
            // 
            // cmbPrintSize
            // 
            this.cmbPrintSize.FormattingEnabled = true;
            this.cmbPrintSize.Items.AddRange(new object[] {
            "A4",
            "A5"});
            this.cmbPrintSize.Location = new System.Drawing.Point(64, 175);
            this.cmbPrintSize.Name = "cmbPrintSize";
            this.cmbPrintSize.Size = new System.Drawing.Size(100, 21);
            this.cmbPrintSize.TabIndex = 5;
            this.cmbPrintSize.Text = "Розмір друку";
            // 
            // cmbType
            // 
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Items.AddRange(new object[] {
            "Laser",
            "Inkjet"});
            this.cmbType.Location = new System.Drawing.Point(64, 228);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(100, 21);
            this.cmbType.TabIndex = 6;
            this.cmbType.Text = "Тип принтера";
            this.cmbType.SelectedIndexChanged += new System.EventHandler(this.cmbType_SelectedIndexChanged);
            // 
            // chkDuplex
            // 
            this.chkDuplex.AutoSize = true;
            this.chkDuplex.Location = new System.Drawing.Point(13, 255);
            this.chkDuplex.Name = "chkDuplex";
            this.chkDuplex.Size = new System.Drawing.Size(194, 17);
            this.chkDuplex.TabIndex = 7;
            this.chkDuplex.Text = "Дуплекс (лише для струменевих)";
            this.chkDuplex.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(121, 284);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 8;
            this.btnOK.Text = "Зберегти";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(32, 284);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Скасувати";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // cmbPurpose
            // 
            this.cmbPurpose.FormattingEnabled = true;
            this.cmbPurpose.Items.AddRange(new object[] {
            "Для дому",
            "Для студенту"});
            this.cmbPurpose.Location = new System.Drawing.Point(64, 148);
            this.cmbPurpose.Name = "cmbPurpose";
            this.cmbPurpose.Size = new System.Drawing.Size(100, 21);
            this.cmbPurpose.TabIndex = 10;
            this.cmbPurpose.Text = "Призначення";
            // 
            // PrinterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(219, 310);
            this.Controls.Add(this.cmbPurpose);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.chkDuplex);
            this.Controls.Add(this.cmbType);
            this.Controls.Add(this.cmbPrintSize);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.txtBrand);
            this.Controls.Add(this.txtModel);
            this.Controls.Add(this.txtCode);
            this.Name = "PrinterForm";
            this.Text = "PrinterForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.TextBox txtModel;
        private System.Windows.Forms.TextBox txtBrand;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.ComboBox cmbPrintSize;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.CheckBox chkDuplex;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ComboBox cmbPurpose;
    }
}