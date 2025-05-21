namespace PrinterCatalogWinForms
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing"
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridViewPrinters = new System.Windows.Forms.DataGridView();
            this.btnAddPrinter = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.txtBrandSearch = new System.Windows.Forms.TextBox();
            this.btnSearchByBrand = new System.Windows.Forms.Button();
            this.chkHome = new System.Windows.Forms.CheckBox();
            this.cmbSortByPrice = new System.Windows.Forms.ComboBox();
            this.chkLaserOnly = new System.Windows.Forms.CheckBox();
            this.btnBuy = new System.Windows.Forms.Button();
            this.btnShowJson = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkStudent = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPrinters)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewPrinters
            // 
            this.dataGridViewPrinters.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPrinters.Location = new System.Drawing.Point(102, 165);
            this.dataGridViewPrinters.Name = "dataGridViewPrinters";
            this.dataGridViewPrinters.Size = new System.Drawing.Size(458, 254);
            this.dataGridViewPrinters.TabIndex = 0;
            this.dataGridViewPrinters.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewPrinters_Click);
            // 
            // btnAddPrinter
            // 
            this.btnAddPrinter.Location = new System.Drawing.Point(12, 12);
            this.btnAddPrinter.Name = "btnAddPrinter";
            this.btnAddPrinter.Size = new System.Drawing.Size(75, 59);
            this.btnAddPrinter.TabIndex = 1;
            this.btnAddPrinter.Text = "Додати";
            this.btnAddPrinter.UseVisualStyleBackColor = true;
            this.btnAddPrinter.Click += new System.EventHandler(this.btnAddPrinter_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(12, 79);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 59);
            this.btnEdit.TabIndex = 2;
            this.btnEdit.Text = "Редагувати";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(12, 144);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 59);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Видалити";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(12, 209);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 59);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "Зберегти";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(12, 274);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 59);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Скасувати";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(102, 79);
            this.txtCode.Multiline = true;
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(158, 28);
            this.txtCode.TabIndex = 7;
            this.txtCode.Text = "Пошук за кодом";
            this.txtCode.Enter += new System.EventHandler(this.txtCode_Enter);
            this.txtCode.Leave += new System.EventHandler(this.txtCode_Leave);
            // 
            // txtBrandSearch
            // 
            this.txtBrandSearch.Location = new System.Drawing.Point(102, 32);
            this.txtBrandSearch.Multiline = true;
            this.txtBrandSearch.Name = "txtBrandSearch";
            this.txtBrandSearch.Size = new System.Drawing.Size(158, 28);
            this.txtBrandSearch.TabIndex = 12;
            this.txtBrandSearch.Text = "Пошук за фірмою";
            this.txtBrandSearch.TextChanged += new System.EventHandler(this.txtBrandSearch_TextChanged);
            this.txtBrandSearch.Enter += new System.EventHandler(this.txtBrandSearch_Enter);
            this.txtBrandSearch.Leave += new System.EventHandler(this.txtBrandSearch_Leave);
            // 
            // btnSearchByBrand
            // 
            this.btnSearchByBrand.BackColor = System.Drawing.SystemColors.Control;
            this.btnSearchByBrand.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSearchByBrand.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnSearchByBrand.Location = new System.Drawing.Point(281, 79);
            this.btnSearchByBrand.Name = "btnSearchByBrand";
            this.btnSearchByBrand.Size = new System.Drawing.Size(87, 28);
            this.btnSearchByBrand.TabIndex = 14;
            this.btnSearchByBrand.Text = "Знайти";
            this.btnSearchByBrand.UseVisualStyleBackColor = false;
            this.btnSearchByBrand.Click += new System.EventHandler(this.btnSearchByBrand_Click);
            // 
            // chkHome
            // 
            this.chkHome.AutoSize = true;
            this.chkHome.Location = new System.Drawing.Point(9, 118);
            this.chkHome.Name = "chkHome";
            this.chkHome.Size = new System.Drawing.Size(75, 17);
            this.chkHome.TabIndex = 16;
            this.chkHome.Text = "Для дому";
            this.chkHome.UseVisualStyleBackColor = true;
            // 
            // cmbSortByPrice
            // 
            this.cmbSortByPrice.FormattingEnabled = true;
            this.cmbSortByPrice.Items.AddRange(new object[] {
            "За зростанням ",
            "За спаданням"});
            this.cmbSortByPrice.Location = new System.Drawing.Point(266, 39);
            this.cmbSortByPrice.Name = "cmbSortByPrice";
            this.cmbSortByPrice.Size = new System.Drawing.Size(122, 21);
            this.cmbSortByPrice.TabIndex = 17;
            this.cmbSortByPrice.Text = "Сортувати за ціною";
            // 
            // chkLaserOnly
            // 
            this.chkLaserOnly.AutoSize = true;
            this.chkLaserOnly.Location = new System.Drawing.Point(188, 118);
            this.chkLaserOnly.Name = "chkLaserOnly";
            this.chkLaserOnly.Size = new System.Drawing.Size(100, 17);
            this.chkLaserOnly.TabIndex = 18;
            this.chkLaserOnly.Text = "Тільки лазерні";
            this.chkLaserOnly.UseVisualStyleBackColor = true;
            // 
            // btnBuy
            // 
            this.btnBuy.Location = new System.Drawing.Point(12, 339);
            this.btnBuy.Name = "btnBuy";
            this.btnBuy.Size = new System.Drawing.Size(75, 59);
            this.btnBuy.TabIndex = 19;
            this.btnBuy.Text = "Купити";
            this.btnBuy.UseVisualStyleBackColor = true;
            this.btnBuy.Click += new System.EventHandler(this.btnBuy_Click);
            // 
            // btnShowJson
            // 
            this.btnShowJson.Location = new System.Drawing.Point(12, 404);
            this.btnShowJson.Name = "btnShowJson";
            this.btnShowJson.Size = new System.Drawing.Size(75, 32);
            this.btnShowJson.TabIndex = 20;
            this.btnShowJson.Text = "ShowJson";
            this.btnShowJson.UseVisualStyleBackColor = true;
            this.btnShowJson.Click += new System.EventHandler(this.btnShowJson_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.Controls.Add(this.chkStudent);
            this.panel1.Controls.Add(this.chkLaserOnly);
            this.panel1.Controls.Add(this.chkHome);
            this.panel1.Location = new System.Drawing.Point(93, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(478, 417);
            this.panel1.TabIndex = 21;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // chkStudent
            // 
            this.chkStudent.AutoSize = true;
            this.chkStudent.Location = new System.Drawing.Point(90, 118);
            this.chkStudent.Name = "chkStudent";
            this.chkStudent.Size = new System.Drawing.Size(95, 17);
            this.chkStudent.TabIndex = 0;
            this.chkStudent.Text = "Для студента";
            this.chkStudent.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 441);
            this.Controls.Add(this.txtBrandSearch);
            this.Controls.Add(this.cmbSortByPrice);
            this.Controls.Add(this.btnSearchByBrand);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.dataGridViewPrinters);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnShowJson);
            this.Controls.Add(this.btnBuy);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAddPrinter);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPrinters)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewPrinters;
        private System.Windows.Forms.Button btnAddPrinter;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.TextBox txtBrandSearch;
        private System.Windows.Forms.Button btnSearchByBrand;
        private System.Windows.Forms.CheckBox chkHome;
        private System.Windows.Forms.ComboBox cmbSortByPrice;
        private System.Windows.Forms.CheckBox chkLaserOnly;
        private System.Windows.Forms.Button btnBuy;
        private System.Windows.Forms.Button btnShowJson;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox chkStudent;
    }
}

