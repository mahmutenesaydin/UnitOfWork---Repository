using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnitOfWork.BusinessLayer.Business;

namespace UnitOfWork.PresentationLayer
{
    public partial class ShippersForm : Form
    {
        public ShippersForm()
        {
            InitializeComponent();
        }

        ShipperBusiness shipperBusiness = new ShipperBusiness();

        private void ShippersForm_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = shipperBusiness.GetShippers();
            shipperBusiness.GetShippers();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            shipperBusiness.AddShipper(new DataLayer.Shipper
            {
                CompanyName = txtCompanyName.Text,
                Phone = txtPhone.Text
            });
            dataGridView1.DataSource = shipperBusiness.GetShippers();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            shipperBusiness.Remove(Convert.ToInt32(txtId.Text));
            dataGridView1.DataSource = shipperBusiness.GetShippers();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            shipperBusiness.Edit(new DataLayer.Shipper
            {
                ShipperID = Convert.ToInt32(txtId.Text),
                CompanyName=txtCompanyName.Text,
                Phone=txtPhone.Text
            });
            dataGridView1.DataSource = shipperBusiness.GetShippers();
        }
    }
}
