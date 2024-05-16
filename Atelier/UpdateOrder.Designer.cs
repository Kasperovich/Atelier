namespace Atelier
{
    partial class UpdateOrder
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Cancel = new System.Windows.Forms.Button();
            this.Save = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label17 = new System.Windows.Forms.Label();
            this.numericUporderSleeve = new System.Windows.Forms.NumericUpDown();
            this.numericUpOrderlong2 = new System.Windows.Forms.NumericUpDown();
            this.numericUpOrderLong1 = new System.Windows.Forms.NumericUpDown();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.numericUpOrderSize = new System.Windows.Forms.NumericUpDown();
            this.textOrderCustomerMaterialPrice = new System.Windows.Forms.TextBox();
            this.numericUpOrderCustomerMaterialCount = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.textOrderCustomerMaterial = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.textOrderCooficient = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.numericUpOrderProductCount = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.textOrderProductName = new System.Windows.Forms.TextBox();
            this.textOrderFIOcustomer = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.comboBoxOrderWorker = new System.Windows.Forms.ComboBox();
            this.workersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this._Atelier_Models_AtelierContextDataSet4 = new Atelier._Atelier_Models_AtelierContextDataSet4();
            this.label7 = new System.Windows.Forms.Label();
            this.dateTimeOrderOpen = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textOrderReceiptNumber = new System.Windows.Forms.TextBox();
            this.workersTableAdapter = new Atelier._Atelier_Models_AtelierContextDataSet4TableAdapters.WorkersTableAdapter();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUporderSleeve)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpOrderlong2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpOrderLong1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpOrderSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpOrderCustomerMaterialCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpOrderProductCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.workersBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._Atelier_Models_AtelierContextDataSet4)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel1.Controls.Add(this.Cancel);
            this.panel1.Controls.Add(this.Save);
            this.panel1.Location = new System.Drawing.Point(-3, 506);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(392, 58);
            this.panel1.TabIndex = 80;
            // 
            // Cancel
            // 
            this.Cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Cancel.Location = new System.Drawing.Point(237, 19);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(118, 23);
            this.Cancel.TabIndex = 58;
            this.Cancel.Text = "Отменить";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // Save
            // 
            this.Save.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Save.Location = new System.Drawing.Point(27, 19);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(118, 23);
            this.Save.TabIndex = 57;
            this.Save.Text = "Сохранить";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.numericUporderSleeve);
            this.groupBox1.Controls.Add(this.numericUpOrderlong2);
            this.groupBox1.Controls.Add(this.numericUpOrderLong1);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.numericUpOrderSize);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(11, 366);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(366, 134);
            this.groupBox1.TabIndex = 79;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Размеры изделия";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(205, 80);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(48, 16);
            this.label17.TabIndex = 54;
            this.label17.Text = "Рукав";
            // 
            // numericUporderSleeve
            // 
            this.numericUporderSleeve.Location = new System.Drawing.Point(208, 99);
            this.numericUporderSleeve.Name = "numericUporderSleeve";
            this.numericUporderSleeve.Size = new System.Drawing.Size(133, 22);
            this.numericUporderSleeve.TabIndex = 14;
            // 
            // numericUpOrderlong2
            // 
            this.numericUpOrderlong2.Location = new System.Drawing.Point(55, 99);
            this.numericUpOrderlong2.Name = "numericUpOrderlong2";
            this.numericUpOrderlong2.Size = new System.Drawing.Size(129, 22);
            this.numericUpOrderlong2.TabIndex = 13;
            // 
            // numericUpOrderLong1
            // 
            this.numericUpOrderLong1.Location = new System.Drawing.Point(208, 52);
            this.numericUpOrderLong1.Name = "numericUpOrderLong1";
            this.numericUpOrderLong1.Size = new System.Drawing.Size(133, 22);
            this.numericUpOrderLong1.TabIndex = 12;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(52, 80);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(67, 16);
            this.label16.TabIndex = 50;
            this.label16.Text = "Длинна 2";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(205, 32);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(67, 16);
            this.label15.TabIndex = 49;
            this.label15.Text = "Длинна 1";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(52, 32);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(58, 16);
            this.label14.TabIndex = 48;
            this.label14.Text = "Размер";
            // 
            // numericUpOrderSize
            // 
            this.numericUpOrderSize.Location = new System.Drawing.Point(55, 52);
            this.numericUpOrderSize.Name = "numericUpOrderSize";
            this.numericUpOrderSize.Size = new System.Drawing.Size(129, 22);
            this.numericUpOrderSize.TabIndex = 11;
            // 
            // textOrderCustomerMaterialPrice
            // 
            this.textOrderCustomerMaterialPrice.ForeColor = System.Drawing.SystemColors.WindowText;
            this.textOrderCustomerMaterialPrice.Location = new System.Drawing.Point(219, 340);
            this.textOrderCustomerMaterialPrice.Name = "textOrderCustomerMaterialPrice";
            this.textOrderCustomerMaterialPrice.Size = new System.Drawing.Size(69, 20);
            this.textOrderCustomerMaterialPrice.TabIndex = 67;
            this.textOrderCustomerMaterialPrice.Text = "0.00";
            this.textOrderCustomerMaterialPrice.Leave += new System.EventHandler(this.textOrderCustomerMaterialPrice_Leave);
            this.textOrderCustomerMaterialPrice.MouseDown += new System.Windows.Forms.MouseEventHandler(this.textOrderCustomerMaterialPrice_MouseDown);
            // 
            // numericUpOrderCustomerMaterialCount
            // 
            this.numericUpOrderCustomerMaterialCount.Location = new System.Drawing.Point(294, 340);
            this.numericUpOrderCustomerMaterialCount.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numericUpOrderCustomerMaterialCount.Name = "numericUpOrderCustomerMaterialCount";
            this.numericUpOrderCustomerMaterialCount.Size = new System.Drawing.Size(83, 20);
            this.numericUpOrderCustomerMaterialCount.TabIndex = 68;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label11.Location = new System.Drawing.Point(216, 320);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(76, 16);
            this.label11.TabIndex = 78;
            this.label11.Text = "Цена (руб)";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.Location = new System.Drawing.Point(291, 320);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(86, 16);
            this.label10.TabIndex = 77;
            this.label10.Text = "Количество";
            // 
            // textOrderCustomerMaterial
            // 
            this.textOrderCustomerMaterial.Location = new System.Drawing.Point(11, 340);
            this.textOrderCustomerMaterial.Name = "textOrderCustomerMaterial";
            this.textOrderCustomerMaterial.Size = new System.Drawing.Size(202, 20);
            this.textOrderCustomerMaterial.TabIndex = 66;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(9, 320);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(147, 16);
            this.label9.TabIndex = 76;
            this.label9.Text = "Материал заказчика";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label18.Location = new System.Drawing.Point(12, 270);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(95, 16);
            this.label18.TabIndex = 75;
            this.label18.Text = "Коофициент*";
            // 
            // textOrderCooficient
            // 
            this.textOrderCooficient.ForeColor = System.Drawing.SystemColors.WindowText;
            this.textOrderCooficient.Location = new System.Drawing.Point(12, 290);
            this.textOrderCooficient.Name = "textOrderCooficient";
            this.textOrderCooficient.Size = new System.Drawing.Size(365, 20);
            this.textOrderCooficient.TabIndex = 65;
            this.textOrderCooficient.Text = "0";
            this.textOrderCooficient.Leave += new System.EventHandler(this.textOrderCooficient_Leave);
            this.textOrderCooficient.MouseDown += new System.Windows.Forms.MouseEventHandler(this.textOrderCooficient_MouseDown);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label13.Location = new System.Drawing.Point(281, 220);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(91, 16);
            this.label13.TabIndex = 74;
            this.label13.Text = "Количество*";
            // 
            // numericUpOrderProductCount
            // 
            this.numericUpOrderProductCount.Location = new System.Drawing.Point(284, 240);
            this.numericUpOrderProductCount.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.numericUpOrderProductCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpOrderProductCount.Name = "numericUpOrderProductCount";
            this.numericUpOrderProductCount.Size = new System.Drawing.Size(93, 20);
            this.numericUpOrderProductCount.TabIndex = 64;
            this.numericUpOrderProductCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label12.Location = new System.Drawing.Point(12, 220);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(170, 16);
            this.label12.TabIndex = 73;
            this.label12.Text = "Наименование изделия*";
            // 
            // textOrderProductName
            // 
            this.textOrderProductName.Location = new System.Drawing.Point(12, 240);
            this.textOrderProductName.Name = "textOrderProductName";
            this.textOrderProductName.Size = new System.Drawing.Size(266, 20);
            this.textOrderProductName.TabIndex = 63;
            // 
            // textOrderFIOcustomer
            // 
            this.textOrderFIOcustomer.Location = new System.Drawing.Point(12, 190);
            this.textOrderFIOcustomer.Name = "textOrderFIOcustomer";
            this.textOrderFIOcustomer.Size = new System.Drawing.Size(365, 20);
            this.textOrderFIOcustomer.TabIndex = 62;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(12, 170);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(117, 16);
            this.label8.TabIndex = 72;
            this.label8.Text = "ФИО заказчика*";
            // 
            // comboBoxOrderWorker
            // 
            this.comboBoxOrderWorker.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxOrderWorker.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxOrderWorker.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.workersBindingSource, "WorkerId", true));
            this.comboBoxOrderWorker.DataSource = this.workersBindingSource;
            this.comboBoxOrderWorker.DisplayMember = "FIO";
            this.comboBoxOrderWorker.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxOrderWorker.FormattingEnabled = true;
            this.comboBoxOrderWorker.Location = new System.Drawing.Point(12, 140);
            this.comboBoxOrderWorker.Name = "comboBoxOrderWorker";
            this.comboBoxOrderWorker.Size = new System.Drawing.Size(365, 21);
            this.comboBoxOrderWorker.TabIndex = 61;
            this.comboBoxOrderWorker.ValueMember = "WorkerId";
            // 
            // workersBindingSource
            // 
            this.workersBindingSource.DataMember = "Workers";
            this.workersBindingSource.DataSource = this._Atelier_Models_AtelierContextDataSet4;
            // 
            // _Atelier_Models_AtelierContextDataSet4
            // 
            this._Atelier_Models_AtelierContextDataSet4.DataSetName = "_Atelier_Models_AtelierContextDataSet4";
            this._Atelier_Models_AtelierContextDataSet4.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(12, 120);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 16);
            this.label7.TabIndex = 71;
            this.label7.Text = "Мастер*";
            // 
            // dateTimeOrderOpen
            // 
            this.dateTimeOrderOpen.Location = new System.Drawing.Point(12, 90);
            this.dateTimeOrderOpen.Name = "dateTimeOrderOpen";
            this.dateTimeOrderOpen.Size = new System.Drawing.Size(365, 20);
            this.dateTimeOrderOpen.TabIndex = 60;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(12, 70);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(97, 16);
            this.label6.TabIndex = 70;
            this.label6.Text = "Дата приема*";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(12, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(129, 16);
            this.label5.TabIndex = 69;
            this.label5.Text = "Номер квитанции*";
            // 
            // textOrderReceiptNumber
            // 
            this.textOrderReceiptNumber.Location = new System.Drawing.Point(12, 40);
            this.textOrderReceiptNumber.Name = "textOrderReceiptNumber";
            this.textOrderReceiptNumber.Size = new System.Drawing.Size(365, 20);
            this.textOrderReceiptNumber.TabIndex = 59;
            // 
            // workersTableAdapter
            // 
            this.workersTableAdapter.ClearBeforeFill = true;
            // 
            // UpdateOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(389, 565);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.textOrderCustomerMaterialPrice);
            this.Controls.Add(this.numericUpOrderCustomerMaterialCount);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.textOrderCustomerMaterial);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.textOrderCooficient);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.numericUpOrderProductCount);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.textOrderProductName);
            this.Controls.Add(this.textOrderFIOcustomer);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.comboBoxOrderWorker);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dateTimeOrderOpen);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textOrderReceiptNumber);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "UpdateOrder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Редактировать заказ";
            this.Load += new System.EventHandler(this.UpdateOrder_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUporderSleeve)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpOrderlong2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpOrderLong1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpOrderSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpOrderCustomerMaterialCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpOrderProductCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.workersBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._Atelier_Models_AtelierContextDataSet4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.NumericUpDown numericUporderSleeve;
        private System.Windows.Forms.NumericUpDown numericUpOrderlong2;
        private System.Windows.Forms.NumericUpDown numericUpOrderLong1;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.NumericUpDown numericUpOrderSize;
        private System.Windows.Forms.TextBox textOrderCustomerMaterialPrice;
        private System.Windows.Forms.NumericUpDown numericUpOrderCustomerMaterialCount;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textOrderCustomerMaterial;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox textOrderCooficient;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.NumericUpDown numericUpOrderProductCount;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textOrderProductName;
        private System.Windows.Forms.TextBox textOrderFIOcustomer;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox comboBoxOrderWorker;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dateTimeOrderOpen;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textOrderReceiptNumber;
        private _Atelier_Models_AtelierContextDataSet4 _Atelier_Models_AtelierContextDataSet4;
        private System.Windows.Forms.BindingSource workersBindingSource;
        private _Atelier_Models_AtelierContextDataSet4TableAdapters.WorkersTableAdapter workersTableAdapter;
    }
}