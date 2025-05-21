using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrinterCatalogWinForms
{
    public partial class PrinterForm : Form
    {
        public string PrinterType => cmbType.Text;
        public string Code => txtCode.Text;
        public string Model => txtModel.Text;
        public string Brand => txtBrand.Text;
        public string Purpose => cmbPurpose.Text;
        public string PrintSize => cmbPrintSize.Text;
        public string Price => txtPrice.Text;
        public bool Duplex => chkDuplex.Checked;
        public Printer CreatedPrinter { get; private set; }


        public PrinterForm() 
        {
            InitializeComponent();

            
            cmbPrintSize.Items.Clear();
            cmbPrintSize.Items.Add("A4");
            cmbPrintSize.Items.Add("A5");

            
            cmbType.Items.Clear();
            cmbType.Items.Add("Laser");
            cmbType.Items.Add("Inkjet");

            cmbPurpose.Items.Clear();
            cmbPurpose.Items.Add("Для дому");
            cmbPurpose.Items.Add("Для студента");

            cmbPrintSize.SelectedIndex = 0; 
            cmbType.SelectedIndex = 0;

            
            chkDuplex.Visible = cmbType.Text == "Inkjet";
        }

        public PrinterForm(Printer printer) : this()
        {
            if (printer == null) return;

            txtCode.Text = printer.Code.ToString();
            txtModel.Text = printer.Model;
            txtBrand.Text = printer.Brand;
            cmbPurpose.Text = printer.Purpose;
            cmbPrintSize.Text = printer.MaxPrintSize;
            txtPrice.Text = printer.Price.ToString();

            if (printer is LaserPrinter)
            {
                cmbType.Text = "Laser";
                chkDuplex.Visible = false;
            }
            else if (printer is InkjetPrinter inkjet)
            {
                cmbType.Text = "Inkjet";
                chkDuplex.Visible = true;
                chkDuplex.Checked = inkjet.Duplex;
            }
        }


        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            chkDuplex.Visible = cmbType.Text == "Inkjet";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void txtCode_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtCode_Enter(object sender, EventArgs e)
        {
            if (txtCode.Text == "Введіть код")
                txtCode.Text = "";
        }

        private void txtCode_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCode.Text))
                txtCode.Text = "Введіть код";
        }

        private void txtModel_Enter(object sender, EventArgs e)
        {
            if (txtModel.Text == "Введіть модель")
                txtModel.Text = "";
        }

        private void txtModel_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtModel.Text))
                txtModel.Text = "Введіть модель";
        }

        private void txtBrand_Enter(object sender, EventArgs e)
        {
            if (txtBrand.Text == "Введіть фірму")
                txtBrand.Text = "";
        }

        private void txtBrand_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBrand.Text))
                txtBrand.Text = "Введіть фірму";
        }

        private void txtPrice_Enter(object sender, EventArgs e)
        {
            if (txtPrice.Text == "ціна")
                txtPrice.Text = "";
        }

        private void txtPrice_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPrice.Text))
                txtPrice.Text = "ціна";
        }
    }
}
