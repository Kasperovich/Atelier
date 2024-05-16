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
    public partial class SettingForReport : Form
    {
        public  bool result;
        public bool formOfPayment;
        public bool allWorkers;
        public int workerId;
        public SettingForReport()
        {
            InitializeComponent();
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked) comboBox1.Visible = true;
            else comboBox1.Visible = false;
        }

        private void SettingForReport_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "_Atelier_Models_AtelierContextDataSet2.Workers". При необходимости она может быть перемещена или удалена.
            this.workersTableAdapter.Fill(this._Atelier_Models_AtelierContextDataSet2.Workers);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            result = true;
            formOfPayment = radioButton2.Checked;
            allWorkers = radioButton3.Checked;
            if (radioButton4.Checked)
            {
                workerId = (int)comboBox1.SelectedValue;
            }
            Close();
        }
    }
}
