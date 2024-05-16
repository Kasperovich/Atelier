using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Atelier
{
    public partial class RegistryDate : Form
    {
        public RegistryDate()
        {
            InitializeComponent();
        }

        private DateTime date;
        public bool rezult = false;
        public DateTime Date
        {
            get { return date; }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            date = dateTimePicker1.Value;
            rezult = true;
            Close();
        }
    }
}
