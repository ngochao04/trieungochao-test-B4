using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Baitapbuoi4
{
    public partial class Form1 : Form
    {
        private Organization _savedOrganization = null;
        private OrganizationService _service;
        public Form1()
        {
            InitializeComponent();
            _service = new OrganizationService();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Organization org = new Organization
                {
                    OrgName = txtOrgName.Text.Trim(),
                    Address = txtAddress.Text.Trim(),
                    Phone = txtPhone.Text.Trim(),
                    Email = txtEmail.Text.Trim()
                };

                _service.Save(org);

                MessageBox.Show("Save successfully");

                btnDirector.Enabled = true;
                _savedOrganization = org; // lưu để truyền sang Director
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDirector_Click(object sender, EventArgs e)
        {
            if (_savedOrganization == null)
            {
                MessageBox.Show("Please save Organization first");
                return;
            }

            DirectorForm frm = new DirectorForm(_savedOrganization);
            frm.Show();
        }

        private void lblOrgName_Click(object sender, EventArgs e)
        {

        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }
    }
}
