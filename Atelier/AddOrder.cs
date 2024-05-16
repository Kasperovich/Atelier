using System;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using Atelier.BL;
using Atelier.Models;
using System.Globalization;

namespace Atelier
{
    public partial class AddOrder : Form
    {
        public AddOrder(RadioButton radioButtonOrderCash)
        {
            InitializeComponent();
            this.radioButtonOrderCash = radioButtonOrderCash;
        }

        RadioButton radioButtonOrderCash;

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Save_Click(object sender, EventArgs e)
        {
            var cooficient = textOrderCooficient.Text.Replace(".", ",");
            var customerMaterialPrice = textOrderCustomerMaterialPrice.Text.Replace(",", ".");
            if (textOrderReceiptNumber.Text != "")
            {
                if (comboBoxOrderWorker.Text != "")
                {
                    if (textOrderFIOcustomer.Text != "")
                    {
                        if (textOrderProductName.Text != "")
                        {
                            if (numericUpOrderProductCount.Value > 0)
                            {
                                if (cooficient != "")
                                {
                                    if (Regex.IsMatch(cooficient, @"\A[0-9]{1,3}(?:[,][0-9]{1,2})?\z"))
                                    {
                                        if (Regex.IsMatch(customerMaterialPrice, @"\A(?:[0-9]{1,9}(?:[.][0-9]{1,2})?)?\z"))
                                        {
                                            Order order = new Order();
                                            var message = OrderService.Create(new Order
                                            {
                                                ReceiptNumber = textOrderReceiptNumber.Text,
                                                DateOfReceipt = dateTimeOrderOpen.Value,
                                                ClosingDate = dateTimeOrderOpen.Value,
                                                Workerid = (int)comboBoxOrderWorker.SelectedValue,
                                                FormOfPayment = radioButtonOrderCash.Checked,
                                                CustomerName = textOrderFIOcustomer.Text,
                                                NameProduct = textOrderProductName.Text,
                                                CountProduct = (int)numericUpOrderProductCount.Value,
                                                SizeProduct = (int)numericUpOrderSize.Value,
                                                LongProduct1 = (int)numericUpOrderLong1.Value,
                                                LongProduct2 = (int)numericUpOrderlong2.Value,
                                                LongSleeve = (int)numericUporderSleeve.Value,
                                                Coefficient = Convert.ToDouble(cooficient),
                                                CustomerMaterial = textOrderCustomerMaterial.Text,
                                                CountCustomerMaterial = (int)numericUpOrderCustomerMaterialCount.Value,
                                                PriceCustomerMaterial = Convert.ToDecimal(customerMaterialPrice, CultureInfo.InvariantCulture)
                                            });
                                            if (message != null)
                                            {
                                                MessageBox.Show(message, "Ошибка");
                                            }
                                            else
                                            {
                                                this.Close();
                                            }
                                        }
                                        else { MessageBox.Show("Неверный формат поля 'Цена'", "Предупреждение"); }
                                    }
                                    else { MessageBox.Show("Неверный формат поля 'Коофициент'", "Предупреждение"); }
                                }
                                else { MessageBox.Show("Заполните поле 'Коофициент'", "Предупреждение"); }
                            }
                            else { MessageBox.Show("Поле 'Количество' не может быть равным 0", "Предупреждение"); }
                        }
                        else { MessageBox.Show("Заполните поле 'Наименование изделия'", "Предупреждение"); }
                    }
                    else { MessageBox.Show("Заполните поле 'ФИО заказчика'", "Предупреждение"); }
                }
                else { MessageBox.Show("Заполните поле 'Подотчетник'", "Предупреждение"); }
            }
            else { MessageBox.Show("Заполните поле 'Номер квитанции'", "Предупреждение"); }
        }

        private void AddOrder_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "_Atelier_Models_AtelierContextDataSet3.Workers". При необходимости она может быть перемещена или удалена.
            this.workersTableAdapter.Fill(this._Atelier_Models_AtelierContextDataSet3.Workers);

        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textOrderCooficient_MouseDown(object sender, MouseEventArgs e)
        {
            if (textOrderCooficient.Text == "0") textOrderCooficient.Text = "";
        }

        private void textOrderCooficient_Leave(object sender, EventArgs e)
        {
            if (textOrderCooficient.Text == "") textOrderCooficient.Text = "0";
        }

        private void textOrderCustomerMaterialPrice_MouseDown(object sender, MouseEventArgs e)
        {
            if (textOrderCustomerMaterialPrice.Text == "0.00") textOrderCustomerMaterialPrice.Text = "";
        }

        private void textOrderCustomerMaterialPrice_Leave(object sender, EventArgs e)
        {
            if (textOrderCustomerMaterialPrice.Text == "") textOrderCustomerMaterialPrice.Text = "0.00";
        }
    }
}
