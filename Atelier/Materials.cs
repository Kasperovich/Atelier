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
    public partial class Materials : Form
    {
        public Materials()
        {
            InitializeComponent();
        }

        private int materialCode = -1;

        public int MaterialCode
        {
            get
            {
                return materialCode;
            }
        }

        private void Materials_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "_Atelier_Models_AtelierContextDataSet6.Materials". При необходимости она может быть перемещена или удалена.
            this.materialsTableAdapter.Fill(this._Atelier_Models_AtelierContextDataSet6.Materials);

        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            materialCode = (int)dataGridView1.CurrentRow.Cells[1].Value;
            this.Close();
        }

        private void dataGridView1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                materialCode = (int)dataGridView1.CurrentRow.Cells[1].Value;
                this.Close();
            }
        }

        private void Materials_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

    }
}
