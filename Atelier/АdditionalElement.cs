using Atelier.BL;
using Atelier.Models;
using System;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Forms;


namespace Atelier
{
    public partial class АdditionalElement : Form
    {
        private int orderId;
        private bool editMinPrice = false;
        private bool editListOfMaterial = false;
        private bool editFinishingWork = false;
        private bool editElement = false;

        public АdditionalElement(int _orderId)
        {
            InitializeComponent();
            orderId = _orderId;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            FillTableListMaterials();
            FillTableFinishingWork();
            FillTableComplicatingElements();
            FillTableSets();
            string receiptNumber = OrderService.GetReceiptNumberByOrderId(orderId);
            if (receiptNumber != null) Text = "Номер квитанции: " + receiptNumber;
        }

        private void textOrderCustomerMaterialPrice_MouseDown(object sender, MouseEventArgs e)
        {
            if (textListOfMaterialPrice.Text == "0.00") textListOfMaterialPrice.Text = "";
        }

        private void textListOfMaterialPrice_Leave(object sender, EventArgs e)
        {
            if (textListOfMaterialPrice.Text == "") textListOfMaterialPrice.Text = "0.00";
        }

        private void buttonListOfMaterialAdd_Click(object sender, EventArgs e)
        {
            var materialCount = textListOfMaterialCount.Text.Replace(".", ",");
            var materialPrice = textListOfMaterialPrice.Text.Replace(",", ".");
            if (textMaterialCode.Text != "")
            {
                var material = MaterialService.getByCode(Convert.ToInt32(textMaterialCode.Text));
                if (material != null)
                {
                    if (Regex.IsMatch(materialCount, @"\A[0-9]{1,3}(?:[,][0-9]{1,3})?\z"))
                    {
                        if (Regex.IsMatch(materialPrice, @"\A(?:[0-9]{1,9}(?:[.][0-9]{1,2})?)?\z"))
                        {
                            if (textListOfMaterialCount.Text != "0.0")
                            {
                                string message;
                                if (editListOfMaterial)
                                {
                                    var list = ListOfMaterialService.GetById((int)dataGridListOfMaterial.CurrentRow.Cells[7].Value);
                                    list.MaterialId = MaterialService.getByCode(Convert.ToInt32(textMaterialCode.Text)).MaterialId;
                                    list.Quantity = Convert.ToDouble(materialCount);
                                    list.Price = Convert.ToDecimal(materialPrice, CultureInfo.InvariantCulture);
                                    message = ListOfMaterialService.Update(list);
                                }
                                else
                                {
                                    message = ListOfMaterialService.Create(new ListOfMaterial
                                    {
                                        MaterialId = material.MaterialId,
                                        Price = Convert.ToDecimal(materialPrice, CultureInfo.InvariantCulture),
                                        Quantity = Convert.ToDouble(materialCount),
                                        OrderId = orderId
                                    });
                                    textMaterialCode.Text = "";
                                    textListOfMaterialCount.Text = "0.0";
                                    textListOfMaterialPrice.Text = "0.00";
                                }
                                if (message != null)
                                {
                                    MessageBox.Show(message);
                                }
                                if (editListOfMaterial) { editByListOfMateria("", "0.0", "0.00"); }
                                FillTableListMaterials();
                            }
                            else MessageBox.Show("Заполните поле 'Количество'", "Ателье"); 
                        }
                        else MessageBox.Show("Неверный формат поля 'Цена'", "Ателье"); 
                    }
                    else MessageBox.Show("Неверный формат поля 'Количество'", "Ателье"); 
                }
                else MessageBox.Show("Материала с таки кодом не существует", "Ателье");
            }
            else MessageBox.Show("Заполните поле 'Код'", "Ателье"); 
        }

        private void textBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (textListOfMaterialCount.Text == "0.0")
            {
                textListOfMaterialCount.Text = "";
            }
        }

        private void textMaterialOfPriceCount_Leave(object sender, EventArgs e)
        {
            if (textListOfMaterialCount.Text == "")
            {
                textListOfMaterialCount.Text = "0.0";
            }
        }

        private void FillTableSets()
        {
            var sets = SetService.getSetsByOrderId(orderId);
            if (sets != null)
            {
                dataGridSets.Rows.Clear();
                foreach (Set set in sets)
                {
                    dataGridSets.Rows.Add(
                        set.Id,
                        set.Product.Code,
                        set.Product.Name,
                        set.MinimumPrice
                        );
                }
            }
        }
        private void FillTableListMaterials()
        {
            var listMaterials = ListOfMaterialService.GetByOrderId(orderId);
            if (listMaterials != null)
            {
                dataGridListOfMaterial.Rows.Clear();
                decimal _listOfMaterialsPrice = 0;
                foreach (ListOfMaterial list in listMaterials)
                {
                    dataGridListOfMaterial.Rows.Add(
                        list.Material.Code,
                        list.Material.Name,
                        list.Material.StringType,
                        list.Material.Unit,
                        list.Quantity,
                        list.Price,
                        (Convert.ToDecimal(list.Quantity) * list.Price).ToString("F"),
                        list.Id);
                    _listOfMaterialsPrice += Convert.ToDecimal(list.Price) * Convert.ToDecimal(list.Quantity);
                }
            }
        }

        private void FillTableComplicatingElements()
        {
            var complicatingElements = ComplicatingElementService.GetByOrderId(orderId);
            if (complicatingElements != null)
            {
                dataGridComplicatingElement.Rows.Clear();
                decimal _complicatingElementPrice = 0;
                foreach (ComplicatingElement element in complicatingElements)
                {
                    dataGridComplicatingElement.Rows.Add(
                        element.Id,
                        element.product.Code,
                        element.product.Name,
                        element.Name,
                        element.Count,
                        element.PriceOne,
                        (element.PriceOne*element.Count).ToString("F")
                        );
                    _complicatingElementPrice += Convert.ToDecimal(element.PriceOne) * element.Count;
                }
            }
        }

        private void FillTableFinishingWork()
        {
            var finishingWorks = FinishingWorkService.GetByOrderId(orderId);
            if (finishingWorks != null)
            {
                dataGridFinishingWork.Rows.Clear();
                decimal _finishingWorkPrice = 0;
                foreach (FinishingWork finishingWork in finishingWorks)
                {
                    dataGridFinishingWork.Rows.Add(
                        finishingWork.id,
                        finishingWork.Name,
                        finishingWork.Unit,
                        finishingWork.Count,
                        finishingWork.Price,
                        (finishingWork.Price * finishingWork.Count).ToString("F")
                        );
                    _finishingWorkPrice += Convert.ToDecimal(finishingWork.Price) * finishingWork.Count;
                }
            }
        }

        private void buttonListOfmaterialUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridListOfMaterial.CurrentCell != null)
            {
                if (!editListOfMaterial)
                {
                    editByListOfMateria(dataGridListOfMaterial.CurrentRow.Cells[0].Value.ToString(),
                                        dataGridListOfMaterial.CurrentRow.Cells[4].Value.ToString(),
                                        dataGridListOfMaterial.CurrentRow.Cells[5].Value.ToString().Replace(",", "."));
                }
                else editByListOfMateria("", "0.0", "0.00");
            }
            else MessageBox.Show("Запись не выбрана", "Ателье");
        }

        private void editByListOfMateria(string materialCode, string materialCount, string materialPrice)
        {
            editListOfMaterial = !editListOfMaterial;
            if (editListOfMaterial)
            {
                buttonListOfMaterialAdd.Text = "Сохранить";
                buttonListOfmaterialUpdate.Text = "Отмена";
                buttonListOfMaterialDelete.Visible = false;
                dataGridListOfMaterial.Enabled = false;
            }
            else
            {
                buttonListOfMaterialAdd.Text = "Добавить";
                buttonListOfmaterialUpdate.Text = "Редактировать";
                buttonListOfMaterialDelete.Visible = true;
                dataGridListOfMaterial.Enabled = true;
            }
            textMaterialCode.Text = materialCode;
            textListOfMaterialCount.Text = materialCount;
            textListOfMaterialPrice.Text = materialPrice;
        }

        private void buttonListOfMaterialDelete_Click(object sender, EventArgs e)
        {
            if (dataGridListOfMaterial.CurrentCell != null)
            {
                if (MessageBox.Show("Вы действительно хотите удалить запись?", "Ателье", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    var message = ListOfMaterialService.Delete((int)dataGridListOfMaterial.CurrentRow.Cells[7].Value);
                    if (message != null)
                    {
                        MessageBox.Show(message);
                    }
                    FillTableListMaterials();
                }
            }
            else MessageBox.Show("Запись не выбрана","Ателье");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var finishingWorkPrice = textFinishingWorkPrice.Text.Replace(",", ".");
            if (textFinishingWorkName.Text != "")
            {
                if (textFinishingWorkUnit.Text != "")
                {
                    if (textFinishingWorkPrice.Text != "")
                    {
                        if (Regex.IsMatch(finishingWorkPrice, @"\A(?:[0-9]{1,9}(?:[.][0-9]{1,2})?)?\z"))
                        {
                            string message = null;
                            if (editFinishingWork)
                            {
                                var finishingWork = FinishingWorkService.GetById((int)dataGridFinishingWork.CurrentRow.Cells[0].Value);
                                if (finishingWork != null)
                                {
                                    finishingWork.Name = textFinishingWorkName.Text;
                                    finishingWork.Unit = textFinishingWorkUnit.Text;
                                    finishingWork.Count = (int)numericFinishingWorkCount.Value;
                                    finishingWork.Price = Convert.ToDecimal(finishingWorkPrice, CultureInfo.InvariantCulture);
                                    message = FinishingWorkService.Update(finishingWork);
                                }
                            }
                            else
                            {
                                var finishingWork = new FinishingWork
                                {
                                    Name = textFinishingWorkName.Text,
                                    Unit = textFinishingWorkUnit.Text,
                                    Count = (int)numericFinishingWorkCount.Value,
                                    Price = Convert.ToDecimal(finishingWorkPrice, CultureInfo.InvariantCulture),
                                    OrderId = orderId
                                };
                                message = FinishingWorkService.Create(finishingWork);
                                textFinishingWorkName.Text = "";
                                textFinishingWorkUnit.Text = "";
                                numericFinishingWorkCount.Value = 1;
                                textFinishingWorkPrice.Text = "";
                            }
                            if (message != null)
                            {
                                MessageBox.Show(message, "Ошибка");
                            }
                            if (editFinishingWork) { editByFinishingWork("", "", 1, "0.00"); }
                            FillTableFinishingWork();
                        }
                        else MessageBox.Show("Неверный формат поля 'Цена'", "Ателье");
                    }
                    else MessageBox.Show("Заполните поле 'Цена'", "Ателье");
                }
                else MessageBox.Show("Заполните поле 'Еденица измерения'", "Ателье");
            }
            else MessageBox.Show("Заполните поле 'Наименование'", "Ателье");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridFinishingWork.CurrentCell != null)
            {
                if (!editFinishingWork)
                {
                    editByFinishingWork(dataGridFinishingWork.CurrentRow.Cells[1].Value.ToString(),
                                        dataGridFinishingWork.CurrentRow.Cells[2].Value.ToString(),
                                       (int)dataGridFinishingWork.CurrentRow.Cells[3].Value,
                                       dataGridFinishingWork.CurrentRow.Cells[4].Value.ToString().Replace(",", "."));
                }
                else editByFinishingWork("", "", 1, "0.00");
            }
            else MessageBox.Show("Запись не выбрана", "Ателье");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridFinishingWork.CurrentCell != null)
            {
                if (MessageBox.Show("Вы действительно хотите удалить запись?", "Ателье", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    var message = FinishingWorkService.Delete((int)dataGridFinishingWork.CurrentRow.Cells[0].Value);
                    FillTableFinishingWork();
                    if (message != null)
                    {
                        MessageBox.Show(message, "Ошибка");
                    }
                }
            }
            else MessageBox.Show("Запись не выбрана", "Ателье");
        }

        private void editByFinishingWork(string workName, string workUnit,int workCount, string workPrice)
        {
            editFinishingWork = !editFinishingWork;
            if (editFinishingWork)
            {
                button3.Text = "Сохранить";
                button1.Text = "Отмена";
                button2.Visible = false;
                dataGridFinishingWork.Enabled = false;
            }
            else
            {
                button3.Text = "Добавить";
                button1.Text = "Редактировать";
                button2.Visible = true;
                dataGridFinishingWork.Enabled = true;
            }
            textFinishingWorkName.Text = workName;
            textFinishingWorkUnit.Text = workUnit;
            numericFinishingWorkCount.Value = workCount;
            textFinishingWorkPrice.Text = workPrice;
        }

        private void textFinishingWorkPrice_MouseDown(object sender, MouseEventArgs e)
        {
            if (textFinishingWorkPrice.Text == "0.00") textFinishingWorkPrice.Text = "";
        }

        private void textFinishingWorkPrice_Leave(object sender, EventArgs e)
        {
            if (textFinishingWorkPrice.Text == "") textFinishingWorkPrice.Text = "0.00";
        }

        private void textBox1_MouseDown_1(object sender, MouseEventArgs e)
        {
            if (textElementPrice.Text == "0.00") textElementPrice.Text = "";
        }

        private void textComplicatingElementPrice_Leave(object sender, EventArgs e)
        {
            if (textElementPrice.Text == "") textElementPrice.Text = "0.00";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (textElementCode.Text != "")
            {
                var product = ProductService.getByCode(Convert.ToInt32(textElementCode.Text));
                if (product != null)
                {
                    if (textElementCipher.Text != "")
                    {
                        if (textElementPrice.Text != "")
                        {
                            var elementPrice = textElementPrice.Text.Replace(",", ".");
                            if (Regex.IsMatch(elementPrice, @"\A(?:[0-9]{1,9}(?:[.][0-9]{1,2})?)?\z"))
                            {
                                string message;
                                if (editElement)
                                {
                                    var oldElement = ComplicatingElementService.GetById((int)dataGridComplicatingElement.CurrentRow.Cells[0].Value);
                                    oldElement.Name = textElementCipher.Text;
                                    oldElement.ProductId = product.ProductId;
                                    oldElement.Count = (int)numericElementsCount.Value;
                                    oldElement.PriceOne = Convert.ToDecimal(elementPrice, CultureInfo.InvariantCulture);
                                    message = ComplicatingElementService.Update(oldElement);
                                    if (message != null)
                                    {
                                        MessageBox.Show(message, "Ошибка");
                                    }
                                    FillTableComplicatingElements();
                                }
                                else
                                {
                                    var newElement = new ComplicatingElement
                                    {
                                        Name = textElementCipher.Text,
                                        Count = (int)numericElementsCount.Value,
                                        ProductId = product.ProductId,
                                        PriceOne = Convert.ToDecimal(elementPrice, CultureInfo.InvariantCulture),
                                        OrderId = orderId
                                    };
                                    message = ComplicatingElementService.Create(newElement);
                                    textElementCode.Text = "";
                                    textElementCipher.Text = "";
                                    numericElementsCount.Value = 1;
                                    textElementPrice.Text = "0.00";

                                }
                                if (message != null)
                                {
                                    MessageBox.Show(message, "Ошибка");
                                }
                                if (editElement) { editByElement("", "", 1, "0.00"); }
                                FillTableComplicatingElements();
                            }
                            else MessageBox.Show("Неверный формат поля 'Цена'", "Ателье");
                        }
                        else MessageBox.Show("Заполните поле 'Цена'", "Ателье");
                    }
                    else MessageBox.Show("Заполните поле 'Шифр'", "Ателье");
                }
                else MessageBox.Show("Изделия с таким кодом не существует", "Ателье");
            }
            else MessageBox.Show("Заполните поле 'Код изделия'", "Ателье");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridComplicatingElement.CurrentCell != null)
            {
                if (!editElement)
                {
                    editByElement(dataGridComplicatingElement.CurrentRow.Cells[1].Value.ToString(),
                                  dataGridComplicatingElement.CurrentRow.Cells[3].Value.ToString(),
                                  (int)dataGridComplicatingElement.CurrentRow.Cells[4].Value,
                                  dataGridComplicatingElement.CurrentRow.Cells[5].Value.ToString().Replace(",", "."));
                }
                else editByElement("", "", 1, "0.00");
            }
            else MessageBox.Show("Запись не выбрана", "Ателье");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (dataGridComplicatingElement.CurrentCell != null)
            {
                if (MessageBox.Show("Вы действительно хотите изменить запись?", "Ателье", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    var message = ComplicatingElementService.Delete((int)dataGridComplicatingElement.CurrentRow.Cells[0].Value);
                    if (message != null)
                    {
                        MessageBox.Show(message, "Ошибка");
                    }
                    FillTableComplicatingElements();
                }
            }
            else MessageBox.Show("Запись не выбрана", "Ателье");
        }

        private void editByElement(string elementCode, string elementCipher, int elementCount, string elementPrice)
        {
            editElement = !editElement;
            if (editElement)
            {
                button6.Text = "Сохранить";
                button4.Text = "Отмена";
                button5.Visible = false;
                dataGridComplicatingElement.Enabled = false;
            }
            else
            {
                button6.Text = "Добавить";
                button4.Text = "Редактировать";
                button5.Visible = true;
                dataGridComplicatingElement.Enabled = true;
            }
            textElementCode.Text = elementCode;
            textElementCipher.Text = elementCipher;
            numericElementsCount.Value = elementCount;
            textElementPrice.Text = elementPrice;
        }

        private void textProduct_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!char.IsDigit(number) && number != 8)
            {
                e.Handled = true;
            }
            //Нажатие клавиши Enter
            if(number == 13)
            {
                textProductCode.Text = opentProductsForm().ToString();
            }
        }

        private void textProduct_TextChanged(object sender, EventArgs e)
        {
            if (textProductCode.Text != "")
            {
                labelProductName.Text = ProductService.getNameByCode(Convert.ToInt32(textProductCode.Text));
            }
            else labelProductName.Text = "";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (textProductCode.Text != "" && textProductPrice.Text != "")
            {
                string message;
                var productPrice = textProductPrice.Text.Replace(",", ".");
                var product = ProductService.getByCode(Convert.ToInt32(textProductCode.Text));
                if (product != null)
                {
                    if (Regex.IsMatch(productPrice, @"\A(?:[0-9]{1,9}(?:[.][0-9]{1,2})?)?\z"))
                    {
                        if (editMinPrice)
                        {
                            message = SetService.Update(new Set
                            {
                                Id = (int)dataGridSets.CurrentRow.Cells[0].Value,
                                OrderId = orderId,
                                ProductId = product.ProductId,
                                MinimumPrice = Convert.ToDecimal(productPrice, CultureInfo.InvariantCulture)
                            });
                        }
                        else
                        {
                            message = SetService.Create(new Set
                            {
                                OrderId = orderId,
                                ProductId = product.ProductId,
                                MinimumPrice = Convert.ToDecimal(productPrice, CultureInfo.InvariantCulture)
                            });
                            textProductCode.Text = "";
                            textProductPrice.Text = "0.00";
                        }
                        if (message != null)
                        {
                            MessageBox.Show(message, "Ошибка");
                        }
                        if (editMinPrice) { editByMinPrice("", "0.00"); }
                        FillTableSets();
                    }
                    else MessageBox.Show("Неверный формат поля 'Цена'", "Ателье"); 
                }
                else MessageBox.Show("Изделия с таким кодом не существует", "Ателье"); 
            }
            else MessageBox.Show("Заполните все поля", "Ателье"); 
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (dataGridSets.CurrentCell != null)
            {
                if (!editMinPrice)
                {
                    var productPrice = dataGridSets.CurrentRow.Cells[3].Value.ToString().Replace(",", ".");
                    editByMinPrice(dataGridSets.CurrentRow.Cells[1].Value.ToString(), productPrice);
                }
                else editByMinPrice("", "0.00");
            }
            else MessageBox.Show("Запись не выбрана", "Ателье");
        }
        private void editByMinPrice(string productCode, string productMinPrice)
        {
            editMinPrice = !editMinPrice;
            if (editMinPrice)
            {
                button9.Text = "Сохранить";
                button7.Text = "Отмена";
                button8.Visible = false;
                dataGridSets.Enabled = false;
            }
            else
            {
                button9.Text = "Добавить";
                button7.Text = "Редактировать";
                button8.Visible = true;
                dataGridSets.Enabled = true;
            }
            textProductCode.Text = productCode.ToString();
            textProductPrice.Text = productMinPrice.ToString();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (dataGridSets.CurrentCell != null)
            {
                if (MessageBox.Show("Вы действительно хотите удалить запись?", "Ателье", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    var message = SetService.Delete((int)dataGridSets.CurrentRow.Cells[0].Value);
                    if (message != null)
                    {
                        MessageBox.Show(message, "Ателье");
                    }
                    FillTableSets();
                }
            }
        }

        private void textElementCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!Char.IsDigit(number) && number != 8)
            {
                e.Handled = true;
            }
            if(number == 13)
            {
                    textElementCode.Text = opentProductsForm();
            }
        }

        private void textElementCode_TextChanged(object sender, EventArgs e)
        {
            if (textElementCode.Text != "")
            {
                labelElementProduct.Text = ProductService.getNameByCode(Convert.ToInt32(textElementCode.Text));
            }
            else labelElementProduct.Text = "";
        }

        private void textMaterialCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            char keyCode = e.KeyChar;

            if (!Char.IsDigit(keyCode) && keyCode != 8)
            {
                e.Handled = true;
            }

            if(keyCode == 13)
            {
                textMaterialCode.Text = openMaterialsForm().ToString();
            }
        }

        private void textMaterialCode_TextChanged(object sender, EventArgs e)
        {
            if (textMaterialCode.Text != "")
            {
                labelMaterialtext.Text = MaterialService.getNameByCode(Convert.ToInt32(textMaterialCode.Text));
            }
            else labelMaterialtext.Text = "";
        }

        private void textProductPrice_Leave(object sender, EventArgs e)
        {
            if (textProductPrice.Text == "") textProductPrice.Text = "0.00";
        }

        private void textProductPrice_MouseDown(object sender, MouseEventArgs e)
        {
            if (textProductPrice.Text == "0.00") textProductPrice.Text = "";
        }

        private void textElementCode_MouseDoubleClick(object sender, MouseEventArgs e)
        {
                textElementCode.Text = opentProductsForm();
        }

        private string opentProductsForm()
        {
            Products productsForm = new Products();
            productsForm.ShowDialog();
            int productCode = productsForm.ProductCode;
            if(productCode != -1) {return productCode.ToString();}
            else { return ""; }
        }

        private string openMaterialsForm()
        {
            Materials materialsForm = new Materials();
            materialsForm.ShowDialog();
            int materialCode = materialsForm.MaterialCode;
            if(materialCode != -1) { return materialCode.ToString(); }
            else return ""; 
        }

        private void textProduct_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            textProductCode.Text = opentProductsForm().ToString();
        }

        private void textMaterialCode_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            textMaterialCode.Text = openMaterialsForm();
        }

        private void Form2_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if(editMinPrice) editByMinPrice("", "0.00");
            if(editListOfMaterial)editByListOfMateria("", "0.0", "0.00");
            if(editFinishingWork)editByFinishingWork("", "", 1, "0.00");
            if(editElement)editByElement("", "", 1, "0.00");
        }
    }
}