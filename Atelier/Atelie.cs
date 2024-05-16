using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Atelier.BL;
using Atelier.Models;
using Atelier.Models.ModelsForReports;

namespace Atelier
{
    public partial class Atelie : Form
    {

        public Atelie()
        {
            InitializeComponent();
        }

        private List<Order> _orders;
        private bool _editWorker = false;
        private bool _editProduct = false;
        private bool _editMaterial = false;
        private List<Order> _deleteOrders;

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                // TODO: данная строка кода позволяет загрузить данные в таблицу "_Atelier_Models_AtelierContextDataSet2.Workers". При необходимости она может быть перемещена или удалена.
                this.workersTableAdapter.Fill(this._Atelier_Models_AtelierContextDataSet2.Workers);
                // TODO: данная строка кода позволяет загрузить данные в таблицу "_Atelier_Models_AtelierContextDataSet1.Products". При необходимости она может быть перемещена или удалена.
                this.productsTableAdapter.Fill(this._Atelier_Models_AtelierContextDataSet1.Products);
                // TODO: данная строка кода позволяет загрузить данные в таблицу "_Atelier_Models_AtelierContextDataSet.Materials". При необходимости она может быть перемещена или удалена.
                this.materialsTableAdapter.Fill(this._Atelier_Models_AtelierContextDataSet.Materials);

                fillTableOrders(OrderService.GetOrdersByFormOfPayment(true));
                tableOrder_CellClick();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message,"Ошибка");
            }
        }

        private void fillTableOrders(List<Order> orders)
        {
            _orders = orders;
            if (orders != null)
            {
                dataGridOrders.Rows.Clear();
                foreach (Order order in orders)
                {
                    dataGridOrders.Rows.Add(
                        order.OrderId,
                        order.isClosed ? "Завершен" : "Открыт",
                        order.ReceiptNumber,
                        order.Worker.FIO,
                        order.CustomerName,
                        order.NameProduct,
                        order.DateOfReceipt.ToShortDateString(),
                        order.isClosed ? order.ClosingDate.ToShortDateString() : "",
                        order.CountProduct,
                        order.SizeProduct,
                        order.LongProduct1,
                        order.LongProduct2,
                        order.LongSleeve,
                        order.FormOfPayment ? "Нал." : "Безнал.",
                        order.CustomerMaterial,
                        order.CountCustomerMaterial,
                        order.PriceCustomerMaterial,
                        order.Coefficient);
                    if (!order.isClosed)
                    {
                        dataGridOrders.Rows[dataGridOrders.Rows.Count - 1].DefaultCellStyle.BackColor = Color.Azure;
                    }
                    else
                    {
                        dataGridOrders.Rows[dataGridOrders.Rows.Count - 1].DefaultCellStyle.BackColor = Color.LightPink;
                    }
                }
                ChangePrice();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textMaterialName.Text != "")
            {
                if (textMaterialUnit.Text != "")
                {
                    string message;
                    var materialType = radioButtonPrimarMaterial.Checked ? true : false;
                    //Проверяем, происходит ли в данный момент изменение записи изделия
                    if (_editMaterial)
                    {
                        message = MaterialService.Update(new Material((int)dataGridMaterial.CurrentRow.Cells[0].Value,
                                                                      (int)numericMaterialId.Value,
                                                                      textMaterialName.Text,
                                                                      materialType,
                                                                      textMaterialUnit.Text));
                    }
                    else
                    {
                        message = MaterialService.Create(new Material((int)numericMaterialId.Value, 
                                                                      textMaterialName.Text,
                                                                      materialType, 
                                                                      textMaterialUnit.Text));
                        textMaterialName.Text = "";
                        textMaterialUnit.Text = "";
                        numericMaterialId.Value = 1;
                    }
                    if (message == null)
                    {
                        materialsTableAdapter.Fill(_Atelier_Models_AtelierContextDataSet.Materials);
                        dataGridMaterial.Refresh();
                        if (_editMaterial) editByMaterial(1, "", true, "");
                    }
                    else MessageBox.Show(message, "Ателье"); 
                }
                else MessageBox.Show("Заполните поле 'Еденица измерения'", "Ателье"); 
            }
            else MessageBox.Show("Заполните поле 'Наименование'", "Ателье"); 
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridMaterial.CurrentCell != null)
            {
                if (MessageBox.Show("Вы действительно хотит удалить запись?", "Ателье", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    var message = MaterialService.Delete((int)dataGridMaterial.CurrentRow.Cells[0].Value);
                    if (message == null)
                    {
                        materialsTableAdapter.Fill(_Atelier_Models_AtelierContextDataSet.Materials);
                        dataGridMaterial.Refresh();
                    }
                    else MessageBox.Show(message, "Ошибка"); 
                }
            }
            else MessageBox.Show("Материал не выбран", "Ошибка"); 
        }

        private void buttonProductDelete_Click(object sender, EventArgs e)
        {
            if (dataGridProduct.CurrentCell != null)
            {
                if (MessageBox.Show("Вы действительно хотит удалить запись?", "Ателье", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    var message = ProductService.Delete((int)dataGridProduct.CurrentRow.Cells[0].Value);
                    if (message == null)
                    {
                        productsTableAdapter.Fill(_Atelier_Models_AtelierContextDataSet1.Products);
                        dataGridProduct.Refresh();
                    }
                    else MessageBox.Show(message, "Ошибка"); 
                }
            }
            else MessageBox.Show("Изделие не выбрано", "Ошибка"); 
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (dataGridMaterial.CurrentCell != null)
            {
                if (!_editMaterial)
                {
                    editByMaterial((int)dataGridMaterial.CurrentRow.Cells[1].Value,
                                       (string)dataGridMaterial.CurrentRow.Cells[2].Value,
                                       radioButtonPrimarMaterial.Checked ? true : false,
                                       (string)dataGridMaterial.CurrentRow.Cells[5].Value);
                }
                else editByMaterial(1, "",true, "");
            }
            else MessageBox.Show("Материал не выбран", "Ателье"); 
        }

        private void editByMaterial(int materialCode, string materialName,bool materialType, string materialUnit)
        {
            _editMaterial = !_editMaterial;
            if (_editMaterial)
            {
                button2.Text = "Сохранить";
                button5.Text = "Отмена";
                button3.Visible = false;
                dataGridMaterial.Enabled = false;
            }
            else
            {
                button2.Text = "Добавить";
                button5.Text = "Редактировать";
                button3.Visible = true;
                dataGridMaterial.Enabled = true;
            }
            numericMaterialId.Value = materialCode;
            textMaterialName.Text = materialName;
            radioButtonPrimarMaterial.Checked = materialType;
            textMaterialUnit.Text = materialUnit;
        }

        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            radioButtonPrimarMaterial.Checked = true;
            if(_editWorker) { editByWorker(1, ""); }
            if(_editProduct) { editByProduct(1, ""); }
            if(_editMaterial) {editByMaterial(1, "", true, "");}
        }


        private void buttonProductAdd_Click(object sender, EventArgs e)
        {
            if (textProductName.Text != "")
            {
                string message;
                //Проверяем, происходит ли в данный момент изменение записи изделия
                if (_editProduct)
                {
                    message = ProductService.Update(new Product((int)dataGridProduct.CurrentRow.Cells[0].Value, 
                                                                (int)numericProductCode.Value, 
                                                                textProductName.Text));
                }
                else
                {
                    message = ProductService.Create(new Product((int)numericProductCode.Value, textProductName.Text));
                    textProductName.Text = "";
                    numericProductCode.Value = 1;
                }
                if (message == null)
                {
                    productsTableAdapter.Fill(_Atelier_Models_AtelierContextDataSet1.Products);
                    dataGridProduct.Refresh();
                    if(_editProduct) editByProduct(1, "");
                }
                else MessageBox.Show(message, "Ателье"); 
            }
            else MessageBox.Show("Заполните поле 'Наименование изделия'", "Ателье");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridProduct.CurrentCell != null)
            {
                if (!_editProduct)
                {
                    editByProduct((int)dataGridProduct.CurrentRow.Cells[1].Value,
                                       (string)dataGridProduct.CurrentRow.Cells[2].Value);
                }
                else
                {
                    editByProduct(1, "");
                }
            }
            else MessageBox.Show("Изделие не выбрано", "Ателье");
        }
        private void editByProduct(int productCode, string productName)
        {
            _editProduct = !_editProduct;
            if (_editProduct)
            {
                buttonProductAdd.Text = "Сохранить";
                button4.Text = "Отмена";
                buttonProductDelete.Visible = false;
                dataGridProduct.Enabled = false;
            }
            else
            {
                buttonProductAdd.Text = "Добавить";
                button4.Text = "Редактировать";
                buttonProductDelete.Visible = true;
                dataGridProduct.Enabled = true;
            }
            numericProductCode.Value = productCode;
            textProductName.Text = productName;
        }


        private void button8_Click(object sender, EventArgs e)
        {
            if (textWorkerFullName.Text != "")
            {
                string message;
                //Проверяем, происходит ли в данный момент изменение записи мастера
                if (_editWorker)
                {
                    message = WorkerService.Update(new Worker((int)dataGridWorker.CurrentRow.Cells[0].Value, 
                                                              (int)numericWorkerCode.Value, 
                                                              textWorkerFullName.Text));
                }
                else
                {
                    message = WorkerService.Create(new Worker((int)numericWorkerCode.Value, textWorkerFullName.Text));
                    textWorkerFullName.Text = "";
                    numericProductCode.Value = 1;
                }
                if (message == null)
                {
                    workersTableAdapter.Fill(_Atelier_Models_AtelierContextDataSet2.Workers);
                    dataGridWorker.Refresh();
                    if(_editWorker) editByWorker(1, "");
                }
                else MessageBox.Show(message, "Ателье");
            }
            else MessageBox.Show("Заполните поле 'ФИО'", "Ателье");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (dataGridWorker.CurrentCell != null)
            {
                if (!_editWorker)
                {

                    editByWorker(Convert.ToDecimal(dataGridWorker.CurrentRow.Cells[1].Value),
                                       (string)dataGridWorker.CurrentRow.Cells[2].Value);
                }
                else editByWorker(1, "");
            }
            else MessageBox.Show("Мастер не выбран", "Ателье");
        }

        private void editByWorker(decimal workerCode, string workerName)
        {
            _editWorker = !_editWorker;
            if (_editWorker)
            {
                button8.Text = "Сохранить";
                button6.Text = "Отмена";
                button7.Visible = false;
                dataGridWorker.Enabled = false;
            }
            else
            {
                button8.Text = "Добавить";
                button6.Text = "Редактировать";
                button7.Visible = true;
                dataGridWorker.Enabled = true;
            }
            numericWorkerCode.Value = workerCode;
            textWorkerFullName.Text = workerName;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (dataGridWorker.CurrentCell != null)
            {
                if (MessageBox.Show("Вы действительно хотие Удалить запись ?", "Ателье", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    var message = WorkerService.Delete((int)dataGridWorker.CurrentRow.Cells[0].Value);
                    if (message == null)
                    {
                        workersTableAdapter.Fill(_Atelier_Models_AtelierContextDataSet2.Workers);
                        dataGridWorker.Refresh();
                    }
                    else  MessageBox.Show(message, "Ателье"); 
                }
            }
            else MessageBox.Show("Заись не выбрана" , "Ателье");
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                AddOrder addOrder = new AddOrder(radioButtonOrderCash);
                addOrder.ShowDialog();

                var orders = OrderService.GetOrdersByFormOfPaymentAndReceiptNumber(radioButtonOrderCash.Checked, textFindByReceiptNumber.Text);
                fillTableOrders(orders);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }

        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridOrders.CurrentRow != null)
                {
                    var idOrder = Convert.ToInt32(dataGridOrders.CurrentRow.Cells[0].Value);
                    Order order = _orders.Where(o => o.OrderId == idOrder).FirstOrDefault();
                    if (!order.isClosed)
                    {
                        UpdateOrder updateOrder = new UpdateOrder(order);
                        updateOrder.ShowDialog();

                        var orders = OrderService.GetOrdersByFormOfPaymentAndReceiptNumber(radioButtonOrderCash.Checked, textFindByReceiptNumber.Text);
                        fillTableOrders(orders);
                    }
                    else MessageBox.Show("Невозможно редактировать, заказ закрыт", "Ателье");
                }
                else MessageBox.Show("Заказ не выбран", "Ошибка"); 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }
        }

        private void textOrderCustomerMaterialPrice_MouseDown(object sender, MouseEventArgs e)
        {
            if (textCustomerMaterialPrice.Text == "0.00") textCustomerMaterialPrice.Text = "";
        }

        private void textOrderCustomerMaterialPrice_Leave(object sender, EventArgs e)
        {
            if (textCustomerMaterialPrice.Text == "") textCustomerMaterialPrice.Text = "0.00";
        }

        private void textOrderCooficient_MouseDown(object sender, MouseEventArgs e)
        {
            if (textCooficient.Text == "0.0") textCooficient.Text = "";
        }

        private void textOrderCooficient_Leave(object sender, EventArgs e)
        {
            if (textCooficient.Text == "")
            {
                textCooficient.ForeColor = SystemColors.ActiveBorder;
                textCooficient.Text = "0.0";
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (_deleteOrders == null)
            {
                if (dataGridOrders.CurrentRow != null)
                {
                    if (MessageBox.Show("Вы действительно хотит удалить запись?", "Ателье", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                    {
                        var message = OrderService.Delete((int)dataGridOrders.CurrentRow.Cells[0].Value);
                        if (message == null)
                        {
                            var orders = OrderService.GetOrdersByFormOfPaymentAndReceiptNumber(radioButtonOrderCash.Checked, textFindByReceiptNumber.Text);
                            fillTableOrders(orders);
                        }
                        else MessageBox.Show(message, "Ошибка");
                    }
                }
                else MessageBox.Show("Заказ не выбран", "Ателье");
            }
            else
            {
                foreach(Order order in _deleteOrders)
                {
                    OrderService.Delete(order.OrderId);
                }
                cancelDeleted();
                MessageBox.Show("Заказы успешно удалены", "Ателье");
            }
        }

        public void tableOrder_CellClick()
        {
            if (dataGridOrders.Rows.Count == 0) return;

            //ID заказа, из таблицы
            var idOrder = Convert.ToInt32(dataGridOrders.CurrentRow.Cells[0].Value);
            Order order = _orders.Where(o=>o.OrderId == idOrder).FirstOrDefault();

            if (order != null)
            {
                textReceiptNumber.Text = order.ReceiptNumber;
                textDateOpen.Text = order.DateOfReceipt.ToShortDateString();
                textWorking.Text = order.Worker.FIO;
                textFIOCustomer.Text = order.CustomerName;
                textOrderProductName.Text = order.NameProduct;
                textProductCount.Text = order.CountProduct.ToString();
                textCooficient.Text = order.Coefficient.ToString();
                textCustomerMaterial.Text = order.CustomerMaterial;
                textCustomerMaterialCount.Text = order.CountCustomerMaterial.ToString();
                textCustomerMaterialPrice.Text = order.PriceCustomerMaterial.ToString();
                textProductSize.Text = order.SizeProduct.ToString();
                textSleeve.Text = order.LongSleeve.ToString();
                textLong1.Text = order.LongProduct1.ToString();
                textLong2.Text = order.LongProduct2.ToString();
                buttonCloseOrder.Text = order.isClosed ? "Открыть" : "Закрыть";

                ChangePrice();
            }
            else
            {
                textReceiptNumber.Text = "";
                textDateOpen.Text = ""; ;
                textWorking.Text = "";
                textFIOCustomer.Text = "";
                textOrderProductName.Text = "";
                textProductCount.Text = "";
                textCooficient.Text = "";
                textCustomerMaterial.Text = "";
                textCustomerMaterialCount.Text = "";
                textCustomerMaterialPrice.Text = "";
                textProductSize.Text = "";
                textSleeve.Text = "";
                textLong1.Text = "";
                textLong2.Text = "";
            }
        }
        private void dataGridOrders_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridOrders.Rows.Count != 0)
            {
                int focusOrderId = (int)dataGridOrders.CurrentRow.Cells[0].Value;
                tableOrder_CellClick();
            }
        }

        private void radioButtonOrderCash_CheckedChanged(object sender, EventArgs e)
        {
            var orders = OrderService.GetOrdersByFormOfPaymentAndReceiptNumber(radioButtonOrderCash.Checked, textFindByReceiptNumber.Text);
            fillTableOrders(orders);
        }

        private void buttonOrderClose_Click(object sender, EventArgs e)
        {
            if (dataGridOrders.CurrentRow != null)
            {
                if (MessageBox.Show("Вы действительно хотите изменить статус заказа?", "Ателье", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    var order = OrderService.getOrderById((int)dataGridOrders.CurrentRow.Cells[0].Value);
                    order.isClosed = !order.isClosed;
                    order.ClosingDate = DateTime.Now;
                    OrderService.Update(order);

                    var orders = OrderService.GetOrdersByFormOfPaymentAndReceiptNumber(radioButtonOrderCash.Checked, textFindByReceiptNumber.Text);
                    fillTableOrders(orders);
                }
            }
            else MessageBox.Show("Заказ не выбран", "Ошибка");
        }

        private void dataGridOrders_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridOrders.CurrentRow != null)
            {
                if (_deleteOrders == null)
                {

                    АdditionalElement((int)dataGridOrders.CurrentRow.Cells[0].Value);
                }
                else
                {
                    var orderId = (int)dataGridOrders.CurrentRow.Cells[0].Value;
                    var order = _deleteOrders.Where(o => o.OrderId == orderId).FirstOrDefault();
                    _deleteOrders.Remove(order);
                    fillTableOrders(_deleteOrders);
                }
            }
        }

        private void АdditionalElement(int currentOrderId)
        {
            try
            {
                Order order = _orders.Where(o => o.OrderId == currentOrderId).FirstOrDefault();
                if (!order.isClosed)
                {
                    АdditionalElement form2 = new АdditionalElement(currentOrderId);
                    form2.ShowDialog();
                    ChangePrice();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }
        }

        //Подсчет стоимости заказа
        private void ChangePrice()
        {
            if (dataGridOrders.CurrentCell != null)
            {
                int currentOrderId = (int)dataGridOrders.CurrentRow.Cells[0].Value;
                int productCount = _orders.Where(o => o.OrderId == currentOrderId).FirstOrDefault().CountProduct;
                var minPrice = SetService.coutingMinPrice(currentOrderId)*productCount;
                if (minPrice != 0)
                {
                    labelMinPrice.Text = minPrice + " руб.";
                }
                else
                {
                    labelMinPrice.Text = "0,00 руб.";
                }
                labelMinPrice.Text = minPrice.ToString("F") + " руб.";
                //Стоимость усложняющих элементов
                decimal complicatingElementsPrice = ComplicatingElementService.coutingComplicatingElements(currentOrderId)*productCount;
                //Стоимость основных материалов
                decimal basicMaterialsPrice = ListOfMaterialService.MaterialsPriceByOrderIdAndMaterialType(currentOrderId, true) * productCount;
                //стоимость прикладных материалов
                decimal apliedMaterialPrice = ListOfMaterialService.MaterialsPriceByOrderIdAndMaterialType(currentOrderId, false) * productCount;
                //стоимость отделочных материалов
                decimal finishingWork = Convert.ToDecimal(FinishingWorkService.coutingFinishingWorkPrice(currentOrderId)) * productCount;
                //Стоимость пошива
                decimal costOfSewingPrice = OrderService.GetCostOfSewingByOrderId(currentOrderId);
                labelCostOfSewing.Text = costOfSewingPrice.ToString("F") + " руб.";
                labelBasicMaterials.Text = basicMaterialsPrice.ToString("F") + " руб.";
                labelAppliedMaterial.Text = apliedMaterialPrice.ToString("F") + " руб.";
                labelComplicatingElements.Text = complicatingElementsPrice.ToString("F") + " руб.";
                labelSumm.Text = (costOfSewingPrice + basicMaterialsPrice + apliedMaterialPrice).ToString("F") + " руб.";
                labelFinishingWork.Text = finishingWork.ToString("F")+" руб.";
            }
            else
            {
                labelMinPrice.Text = "0.00 руб.";
                labelCostOfSewing.Text = "0.00 руб.";
                labelBasicMaterials.Text = "0.00 руб.";
                labelAppliedMaterial.Text = "0.00 руб.";
                labelComplicatingElements.Text = "0.00 руб.";
                labelSumm.Text = "0.00 руб.";
                labelFinishingWork.Text = "0.00 руб.";
            }
        }

        private void dataGridOrders_SelectionChanged_1(object sender, EventArgs e)
        {
            tableOrder_CellClick();
        }

        //Формирование калькуляции
        private void button11_CreateCalculatedReport(object sender, EventArgs e)
        {
            try
            {
                if (dataGridOrders.CurrentCell != null)
                {
                    int currentOrderId = (int)dataGridOrders.CurrentRow.Cells[0].Value;
                    Order order = _orders.Where(o => o.OrderId == currentOrderId).FirstOrDefault();
                    if (!order.isClosed)
                    {
                        decimal materialsPrice = ListOfMaterialService.MaterialsPriceByOrderId(currentOrderId)*order.CountProduct;
                        decimal costOfSewingPrice = OrderService.GetCostOfSewingByOrderId(currentOrderId);
                        string orderSumm = (costOfSewingPrice + materialsPrice).ToString("F");

                        CalculationForRepot calculation = new CalculationForRepot
                        {
                            order = order,
                            costOfSewingPrice = costOfSewingPrice,
                            orderSumm = orderSumm
                        };
                        calculation.materials.AddRange(ListOfMaterialService.GetListOfMaterialReports(currentOrderId));

                        calculation.elements.AddRange(ComplicatingElementService.GetElementPrintByOrderId(currentOrderId));
                        calculation.elements.AddRange(FinishingWorkService.GetFinishingWorkPrintByOrderId(currentOrderId));
                        calculation.elements.AddRange(SetService.GetSetsPrintByOrderId(currentOrderId));

                        frmPrint frm = new frmPrint(calculation);
                        frm.ShowDialog();
                    }
                    else MessageBox.Show("Невозможно построить отчет, заказ закрыт", "Ателье");
                }
                else MessageBox.Show("Заказ не выбран", "Ошибка");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridOrders_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                if (dataGridOrders.CurrentRow != null)
                {
                    АdditionalElement((int)dataGridOrders.CurrentRow.Cells[0].Value);
                }
            }
        }

        private void реестрПоИндивидуальномуПошивуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegistryDate day = new RegistryDate();
            day.ShowDialog();
            if (day.rezult)
            {
                DateTime date = day.Date;
                List<CostOrder> costOrders = new List<CostOrder>();

                var registerOrders = OrderService.GetAllOrders();
                registerOrders = registerOrders.Where(o => o.DateOfReceipt.Date == date.Date && o.FormOfPayment).ToList();
                if (registerOrders.Count != 0)
                {
                    foreach (Order order in registerOrders)
                    {
                        costOrders.Add(new CostOrder(order.ReceiptNumber, order.NameProduct, order.CustomerName,
                                                       ListOfMaterialService.MaterialsPriceByOrderIdAndMaterialType(order.OrderId, true),
                                                       ListOfMaterialService.MaterialsPriceByOrderIdAndMaterialType(order.OrderId, false),
                                                       OrderService.GetCostOfSewingByOrderId(order.OrderId)));
                    }
                    frmPrint fp = new frmPrint(costOrders, date.Date.ToString("dd/MM/yyyy"));
                    fp.ShowDialog();
                }
                else MessageBox.Show("На " + date.Date.ToString("dd/MM/yyyy") + " нет заказов", "Ателье");
            }
        }

        private void отчетПоКалькуляциямToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportDates dates = new ReportDates();
            dates.ShowDialog();

            if (dates.rezult)
            {
                DateTime first = dates.FirstDay.Date;
                DateTime last = dates.LastDay.Date;
                List<OrderForReport> ordersForReport = new List<OrderForReport>();
                var orders = OrderService.GetOrdersForPeriod(first, last);
                decimal allMaterialsPrice = 0;

                if (orders.Count != 0)
                {
                    foreach (Order order in orders)
                    {
                        ordersForReport.Add(new OrderForReport(order.ReceiptNumber, order.DateOfReceipt, order.OrderId));
                        allMaterialsPrice += ListOfMaterialService.GetSumMaterialsByOrderId(order.OrderId);
                    }

                    frmPrint fp = new frmPrint(ordersForReport, allMaterialsPrice, first.ToString("dd/MM/yyyy"), last.ToString("dd/MM/yyyy"));
                    fp.ShowDialog();
                }
                else { MessageBox.Show("Отчет не содержит ни одной записи", "Ателье"); }
            }
        }

        private void отчетПоМатериаламToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportDates dates = new ReportDates();
            dates.ShowDialog();
            if (dates.rezult)
            {
                DateTime first = dates.FirstDay.Date;
                DateTime last = dates.LastDay.Date;
                List<MaterialForReport> materialReports = ListOfMaterialService.GetAllGroupByIdAndPrice(first, last)
                                     .OrderBy(m => m.MaterialId)
                                     .OrderByDescending(m => m.Type)
                                     .ToList();
                if (materialReports.Count != 0)
                {
                    decimal allSum = 0;
                    foreach (MaterialForReport material in materialReports)
                    {
                        allSum += ListOfMaterialService.GetSumMaterialsByMaterialIdAndPrice(material.MaterialId, material.Price);
                    }
                    frmPrint fp = new frmPrint(materialReports, allSum.ToString("F"), first.ToString("dd/MM/yyyy"), last.ToString("dd/MM/yyyy"));
                    fp.ShowDialog();
                }
                else { MessageBox.Show("Отчет не содержит ни одной записи","Ателье"); }
            }
        }

        private void ведомостьНевыполненыхЗаказовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingForReport settingForm = new SettingForReport();
            settingForm.ShowDialog();

            if (settingForm.result)
            {
                bool formOfPayment = settingForm.formOfPayment;
                decimal allPriceReport = 0;
                List<Worker> workers = new List<Worker>();

                if (settingForm.allWorkers)
                {
                    workers = WorkerService.GetWorkerByOpenOrders(formOfPayment);
                }
                else
                {
                    int workerId = settingForm.workerId;
                    workers = WorkerService.GetWorkerByOpenOrders(formOfPayment).Where(w => w.WorkerId == workerId).ToList();
                }

                if (workers.Count == 0)
                {
                    MessageBox.Show("Отчет не содержит ни одной записи", "Ателье");
                    return;
                }

                List<WorkerForReport> workerReports = new List<WorkerForReport>();

                foreach (Worker worker in workers)
                {
                    workerReports.Add(new WorkerForReport(worker, formOfPayment));
                    var orders = worker.Orders.Where(o => o.FormOfPayment == formOfPayment &&
                                                     o.isClosed == false).ToList();
                    foreach (Order order in orders)
                    {
                        decimal costOfSewing = OrderService.GetCostOfSewingByOrderId(order.OrderId);
                        decimal materialsPrice = ListOfMaterialService.GetSumMaterialsByOrderId(order.OrderId);
                        allPriceReport += Math.Round(costOfSewing + materialsPrice, 2);
                    }
                }
                frmPrint fp = new frmPrint(workerReports, allPriceReport, formOfPayment, DateTime.Now.ToString("dd/MM/yyyy"));
                fp.ShowDialog();
            }
        }

        private void удалитьВсеЗавершенныеЗаказыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотит удалить все завершенные заказы?", "Ателье", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                var message = OrderService.DeleteAllIsClosed();
                if (message != null)
                {
                    MessageBox.Show(message, "Ателье");
                }

                var orders = OrderService.GetOrdersByFormOfPayment(radioButtonOrderCash.Checked);
                fillTableOrders(orders);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (_deleteOrders == null)
            {
                var orders = OrderService.GetOrdersByFormOfPaymentAndReceiptNumber(radioButtonOrderCash.Checked, textFindByReceiptNumber.Text);
                fillTableOrders(orders);
            }
        }

        private void формироватьСписокЗаказовДляУдаленияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            buttonAddToListDeleted.Visible = true;
            buttonCancelListdeleted.Visible = true;
            buttonAddOrder.Enabled = false;
            buttonUddateOrder.Enabled = false;
            buttonCloseOrder.Enabled = false;
            buttonCalculated.Enabled = false;
            radioButtonOrderCash.Enabled = false;
            radioButtonOrderNonCash.Enabled = false;

            _deleteOrders = new List<Order>();
            fillTableOrders(_deleteOrders);

        }

        private void buttonCancelListdeleted_Click(object sender, EventArgs e)
        {
            cancelDeleted();
        }

        private void cancelDeleted()
        {
            buttonAddToListDeleted.Visible = false;
            buttonCancelListdeleted.Visible = false;
            buttonAddOrder.Enabled = true;
            buttonUddateOrder.Enabled = true;
            buttonCloseOrder.Enabled = true;
            buttonCalculated.Enabled = true;
            radioButtonOrderCash.Enabled = true;
            radioButtonOrderNonCash.Enabled = true;
            textFindByReceiptNumber.Text = "";

            var orders = OrderService.GetOrdersByFormOfPaymentAndReceiptNumber(radioButtonOrderCash.Checked, textFindByReceiptNumber.Text);
            fillTableOrders(orders);

            _deleteOrders = null;
        }

        private void addToListDeleted()
        {
            if (textFindByReceiptNumber.Text != "")
            {
                var order = OrderService.GetOrdersByReceiptNumber(textFindByReceiptNumber.Text);
                if (order != null)
                {
                    foreach (Order elem in _deleteOrders)
                    {
                        if (elem.OrderId == order.OrderId)
                        {
                            MessageBox.Show("Заказ уже внесен в список для удаления", "Ателье");
                            return;
                        }
                    }
                    _deleteOrders.Add(order);
                    fillTableOrders(_deleteOrders);
                    textFindByReceiptNumber.Text = "";
                }
                else MessageBox.Show("Заказа с таким номером квитанции не существуте", "Ателье");
            }
            else MessageBox.Show("Введите номер квитанции", "Ателье");
        }

        private void buttonAddToListDeleted_Click(object sender, EventArgs e)
        {
            addToListDeleted();
        }

        private void textFindByReceiptNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                addToListDeleted();
            }
        }
    }
}
