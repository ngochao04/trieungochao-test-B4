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
    public partial class DirectorForm : Form
    {
        private Organization _organization;

        public DirectorForm(Organization org)
        {
            InitializeComponent();
            _organization = org;
        }

        private void DirectorForm_Load(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Organization received:\n" +
                "Name: " + _organization.OrgName
            );
        }
    }
}