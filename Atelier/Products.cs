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
    public partial class Products : Form
    {
        public Products()
        {
            InitializeComponent();
        }

        private int productCode = -1;

        public int ProductCode
        {
            get { return productCode; }
        }

        private void Изделия_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "_Atelier_Models_AtelierContextDataSet5.Products". При необходимости она может быть перемещена или удалена.
            this.productsTableAdapter.Fill(this._Atelier_Models_AtelierContextDataSet5.Products);

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            productCode = (int)dataGridView1.CurrentRow.Cells[1].Value;
            this.Close();
        }



        private void dataGridView1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                productCode = (int)dataGridView1.CurrentRow.Cells[1].Value;
                this.Close();
            }
        }

        private void Products_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
