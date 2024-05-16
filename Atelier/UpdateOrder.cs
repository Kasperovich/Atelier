using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Atelier.Models;
using Atelier.BL;
using System.Text.RegularExpressions;
using System.Globalization;

namespace Atelier
{
    public partial class UpdateOrder : Form
    {
        public UpdateOrder(Order order)
        {
            this.order = order;
            InitializeComponent();
        }

        private Order order;

        private void fillField()
        {         
            textOrderReceiptNumber.Text = order.ReceiptNumber;
            dateTimeOrderOpen.Value = order.DateOfReceipt;
            textOrderFIOcustomer.Text = order.CustomerName;
            textOrderProductName.Text = order.NameProduct;
            numericUpOrderProductCount.Value = order.CountProduct;
            numericUpOrderSize.Value = order.SizeProduct;
            numericUpOrderLong1.Value = order.LongProduct1;
            numericUpOrderlong2.Value = order.LongProduct2;
            numericUporderSleeve.Value = order.LongSleeve;
            textOrderCustomerMaterial.Text = order.CustomerMaterial;
            numericUpOrderCustomerMaterialCount.Value = Convert.ToDecimal(order.CountCustomerMaterial);
            textOrderCustomerMaterialPrice.Text = order.PriceCustomerMaterial.ToString();
            textOrderCooficient.Text = order.Coefficient.ToString();
            workersBindingSource.Position = workersBindingSource.Find("WorkerId", order.Worker.WorkerId);
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
                                            order.ReceiptNumber = textOrderReceiptNumber.Text;
                                            order.DateOfReceipt = dateTimeOrderOpen.Value;
                                            order.ClosingDate = dateTimeOrderOpen.Value;
                                            order.Workerid = (int)comboBoxOrderWorker.SelectedValue;
                                            order.Worker = WorkerService.GetById((int)comboBoxOrderWorker.SelectedValue);
                                            order.CustomerName = textOrderFIOcustomer.Text;
                                            order.NameProduct = textOrderProductName.Text;
                                            order.CountProduct = (int)numericUpOrderProductCount.Value;
                                            order.SizeProduct = (int)numericUpOrderSize.Value;
                                            order.LongProduct1 = (int)numericUpOrderLong1.Value;
                                            order.LongProduct2 = (int)numericUpOrderlong2.Value;
                                            order.LongSleeve = (int)numericUporderSleeve.Value;
                                            order.Coefficient = Convert.ToDouble(cooficient);
                                            order.CustomerMaterial = textOrderCustomerMaterial.Text;
                                            order.CountCustomerMaterial = (int)numericUpOrderCustomerMaterialCount.Value;
                                            order.PriceCustomerMaterial = Convert.ToDecimal(customerMaterialPrice, CultureInfo.InvariantCulture);                                     
                                            var message = OrderService.Update(order);
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

        private void UpdateOrder_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "_Atelier_Models_AtelierContextDataSet4.Workers". При необходимости она может быть перемещена или удалена.
            this.workersTableAdapter.Fill(this._Atelier_Models_AtelierContextDataSet4.Workers);
            fillField();

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
            if (textOrderCustomerMaterialPrice.Text == "0,00") textOrderCustomerMaterialPrice.Text = "";
        }

        private void textOrderCustomerMaterialPrice_Leave(object sender, EventArgs e)
        {
            if (textOrderCustomerMaterialPrice.Text == "") textOrderCustomerMaterialPrice.Text = "0,00";
        }
    }
}
