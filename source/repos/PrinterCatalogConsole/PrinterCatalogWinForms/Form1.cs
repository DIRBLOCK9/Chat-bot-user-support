using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PrinterCatalogWinForms.Services;
using System.IO;


namespace PrinterCatalogWinForms
{
    public partial class Form1 : Form
    {
        private List<Printer> printers = new List<Printer>();
        private PrinterService service;

        public Form1()
        {
            InitializeComponent();
            service = new PrinterService("printers.json");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            service = new PrinterService();

            
            if (File.Exists("printers.json"))
                File.Delete("printers.json");

            
            printers = new List<Printer>();

            
            printers.Add(new LaserPrinter(
                1001,
                "LBP2900",
                "Canon",
                "Для дому",
                "A4",
                4500m
            ));

            printers.Add(new InkjetPrinter(
                2001,
                "L3150",
                "Epson",
                "Для студента",
                "A5",
                true,    
                5200m
            ));

            printers.Add(new LaserPrinter(
                 1002,
                 "HL-L2350DW",
                 "HP",
                 "Офіс",
                 "A4",
                 5600m
            ));

            printers.Add(new InkjetPrinter(
            
                2002,
                "Pixma TS3440",
                "Canon",
                "Для дому",
                "A4",
                true,
                16599m
            ));

            printers.Add(new LaserPrinter(
            
                 1003,
                 "M404dw",
                 "Samsung",
                 "Для студенту",
                 "A4",
                  12000m
            ));

            printers.Add(new InkjetPrinter(
            
                  2003,
                 "Expression Home XP-4100",
                 "Epson",
                 "Для дому",
                 "A4",
                 true,
                 4200m
            ));

            printers.Add(new LaserPrinter(
            
                1004,
                "SP 210SU",
                "Ricoh",
                "Для студента",
                "A4",
                5850m
            ));

            printers.Add(new InkjetPrinter(
            
                2004,
                "DeskJet 2720",
                "HP",
                "Для дому",
                "A4",
                false,
                3500m
            ));

            printers.Add(new LaserPrinter(
            
                 1005,
                 "HL-L5200DW",
                 "Brother",
                 "Великий офіс",
                 "A4",
                 17999m
            ));

            service.SaveToFile(printers);

            RefreshGrid();
        }


        private void btnShowJson_Click(object sender, EventArgs e)
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "printers.json");

            if (File.Exists(path))
            {
                try
                {
                    string jsonContent = File.ReadAllText(path);
                    MessageBox.Show(jsonContent, "Вміст printers.json");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Помилка при читанні файлу: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Файл printers.json не знайдено за шляхом: " + path);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    
    private void RefreshGrid()
        {
            dataGridViewPrinters.DataSource = null;
            dataGridViewPrinters.DataSource = printers;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var form = new PrinterForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    int code = int.Parse(form.Code);
                    string model = form.Model;
                    string brand = form.Brand;
                    string purpose = form.Purpose;
                    string size = form.PrintSize;
                    decimal price = decimal.Parse(form.Price);

                    Printer printer;

                    if (form.PrinterType == "Laser")
                    {
                        
                        printer = new LaserPrinter(code, model, brand, purpose, size, price);
                    }
                    else
                    {
                        
                        bool duplex = form.Duplex; 
                        printer = new InkjetPrinter(code, model, brand, purpose, size, duplex, price);
                    }

                    printers.Add(printer);
                    service.SaveToFile(printers);
                    RefreshGrid();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Помилка при додаванні: " + ex.Message);
                }
            }
        }


        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridViewPrinters.CurrentRow == null)
            {
                MessageBox.Show("Оберіть принтер для редагування.");
                return;
            }

            var selectedPrinter = dataGridViewPrinters.CurrentRow.DataBoundItem as Printer;
            if (selectedPrinter == null)
                return;

            var editForm = new PrinterForm(selectedPrinter);

            if (editForm.ShowDialog() == DialogResult.OK)
            {
                int index = printers.IndexOf(selectedPrinter);
                printers[index] = editForm.CreatedPrinter;
                service.SaveToFile(printers);
                RefreshGrid();
            }
        }

        private void dataGridViewPrinters_Click(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewPrinters.CurrentRow == null || dataGridViewPrinters.CurrentRow.Index < 0)
            {
                MessageBox.Show("Оберіть принтер для видалення.");
                return;
            }

            var selectedPrinter = dataGridViewPrinters.CurrentRow.DataBoundItem as Printer;
            if (selectedPrinter == null)
                return;

            var result = MessageBox.Show("Ви впевнені, що хочете видалити цей принтер?", "Підтвердження", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                printers.Remove(selectedPrinter);
                service.SaveToFile(printers);
                RefreshGrid();
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAddPrinter_Click(object sender, EventArgs e)
        {
            var form = new PrinterForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    int code = int.Parse(form.Code);
                    string model = form.Model;
                    string brand = form.Brand;
                    string purpose = form.Purpose;
                    string size = form.PrintSize;
                    decimal price = decimal.Parse(form.Price);

                    Printer printer;
                    if (form.PrinterType == "Laser")
                    {
                        printer = new LaserPrinter(code, model, brand, purpose, size, price);
                    }
                    else
                    {
                        printer = new InkjetPrinter(code, model, brand, purpose, size, form.Duplex, price);
                    }

                    printers.Add(printer);
                    service.SaveToFile(printers);
                    RefreshGrid();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Помилка при додаванні: " + ex.Message);
                }
            }
    }

        private void btnSortByPrice_Click(object sender, EventArgs e)
        {
            printers = printers.OrderBy(p => p.Price).ToList();
            RefreshGrid();
        }

        private void btnSearchByBrand_Click(object sender, EventArgs e)
        {
            string brandFilter = txtBrandSearch.Text.Trim();
            if (brandFilter == "Пошук за фірмою") brandFilter = "";

            string codeFilter = txtCode.Text.Trim();
            if (codeFilter == "Пошук за кодом") codeFilter = "";

            var filtered = printers.AsEnumerable();

            if (!string.IsNullOrEmpty(brandFilter))
            {
                filtered = filtered.Where(p => p.Brand != null && p.Brand.IndexOf(brandFilter, StringComparison.OrdinalIgnoreCase) >= 0);
            }

            if (!string.IsNullOrEmpty(codeFilter))
            {
                filtered = filtered.Where(p => p.Code.ToString().Contains(codeFilter));
            }

            if (chkLaserOnly.Checked)
            {
                filtered = filtered.Where(p => p is LaserPrinter);
            }

            if (chkHome.Checked)
            {
                filtered = filtered.Where(p => p.Purpose != null && p.Purpose.IndexOf("дом", StringComparison.OrdinalIgnoreCase) >= 0);
            }

            if (cmbSortByPrice.SelectedItem != null)
            {
                string sortOrder = cmbSortByPrice.SelectedItem.ToString();

                if (sortOrder == "За зростанням")
                    filtered = filtered.OrderBy(p => p.Price);
                else if (sortOrder == "За спаданням")
                    filtered = filtered.OrderByDescending(p => p.Price);
            }

            if (chkStudent.Checked)
            {
                filtered = filtered.Where(p => p.Purpose == "Для студента").ToList();
            }

            var resultList = filtered.ToList();

            if (resultList.Count == 0)
            {
                MessageBox.Show("Принтерів за вказаними параметрами не знайдено.");
            }

            dataGridViewPrinters.DataSource = null;
            dataGridViewPrinters.DataSource = resultList;
        }

        private void txtBrandSearch_Enter(object sender, EventArgs e)
        {
            if (txtBrandSearch.Text == "Пошук за фірмою")
                txtBrandSearch.Text = "";
        }

        private void txtBrandSearch_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBrandSearch.Text))
                txtBrandSearch.Text = "Пошук за фірмою";
        }

        private void txtCode_Enter(object sender, EventArgs e)
        {
            if (txtCode.Text == "Пошук за кодом")
                txtCode.Text = "";
        }

        private void txtCode_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCode.Text))
                txtCode.Text = "Пошук за кодом";
        }

        private void txtBrandSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void BuyPrinter(Printer selectedPrinter)
        {
            {
                if (selectedPrinter == null)
                {
                    MessageBox.Show("Виберіть принтер для покупки.");
                    return;
                }

                
                string printerInfo = $"Код: {selectedPrinter.Code}\n" +
                                     $"Модель: {selectedPrinter.Model}\n" +
                                     $"Бренд: {selectedPrinter.Brand}\n" +
                                     $"Призначення: {selectedPrinter.Purpose}\n" +
                                     $"Максимальний розмір друку: {selectedPrinter.MaxPrintSize}\n" +
                                     $"Ціна: {selectedPrinter.Price} грн";

                if (selectedPrinter is LaserPrinter laserPrinter)
                {
                    if (laserPrinter.Price > 15000m)
                    {
                        decimal discount = laserPrinter.Price * 0.05m;
                        decimal discountedPrice = laserPrinter.Price - discount;

                        MessageBox.Show(printerInfo + $"\n\nВи отримали знижку 5% на лазерний принтер!" +
                                        $"\nЗнижка: {discount} грн." +
                                        $"\nНова ціна: {discountedPrice} грн.");
                    }
                    else
                    {
                        MessageBox.Show(printerInfo + "\n\nЛазерний принтер без знижки.");
                    }
                }
                else if (selectedPrinter is InkjetPrinter)
                {
                    MessageBox.Show(printerInfo + "\n\nПри купівлі струменевого принтера ви отримуєте катридж у подарунок!");
                }
                else
                {
                    MessageBox.Show(printerInfo);
                }
            }
        }


        private void btnBuy_Click(object sender, EventArgs e)
        {
            if (dataGridViewPrinters.CurrentRow == null)
            {
                MessageBox.Show("Оберіть принтер для покупки.");
                return;
            }

            var selectedPrinter = dataGridViewPrinters.CurrentRow.DataBoundItem as Printer;

            BuyPrinter(selectedPrinter);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
    
}

    


