using Atelier.Models;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Atelier.BL;
using Atelier.Models.ModelsForReports;

namespace Atelier
{
    public partial class frmPrint : Form
    {
        public frmPrint(CalculationForRepot _calculationData)
        {
            InitializeComponent();
            саlculation(_calculationData);
        }

        public frmPrint(List<CostOrder> _costOrders, string _registerDate)
        {
            InitializeComponent();
            registerOfSewingReport(_costOrders, _registerDate);
        }

        public frmPrint(List<OrderForReport> _ordersMaterials, decimal _allMateriaslPrice, string _firstDate, string _lastDate)
        {
            InitializeComponent();
            orderMaterialsForReport(_ordersMaterials,_allMateriaslPrice,_firstDate, _lastDate);
        }

        public frmPrint(List<MaterialForReport> _materials, string _allSum, string _firstDate, string _lastDate)
        {
            InitializeComponent();
            materialOrdersForReport(_materials, _allSum, _firstDate, _lastDate);
        }

        public frmPrint(List<WorkerForReport> workers, decimal allPriceReport, bool formOfPayment, string date)
        {
            InitializeComponent();
            workerOrderReport(workers, allPriceReport,formOfPayment, date);
        }

        public void workerOrderReport(List<WorkerForReport> workers, decimal allPriceReport, bool formOfPayment, string date)
        {
            string exeFolder = Application.StartupPath;
            string path = Path.Combine(exeFolder, @"Reports\WorkerOrderReport.rdlc");
            reportViewer3.LocalReport.ReportPath = path;

            reportViewer3.ProcessingMode = ProcessingMode.Local;
            ReportParameter[] param = new ReportParameter[]
            {
                    new ReportParameter("date", date),
                    new ReportParameter("name", formOfPayment?"ВЕДОМОСТЬ НЕВЫПОЛНЕННЫХ ЗАКАЗОВ ПО ИНДИВИДУАЛЬНОМУ ПОШИВУ"
                                                             :"ВЕДОМОСТЬ НЕВЫПОЛНЕННЫХ ЗАКАЗОВ ПО МАССОВОМУ ПОШИВУ"),
                     new ReportParameter("allPriceReport", allPriceReport.ToString()),
            };
            reportViewer3.LocalReport.SetParameters(param);

            reportViewer3.LocalReport.DataSources.Clear();
            ReportDataSource rd = new ReportDataSource("DataSet1", workers);
            reportViewer3.LocalReport.DataSources.Add(rd);
            reportViewer3.RefreshReport();

            reportViewer3.LocalReport.SubreportProcessing +=
                 new SubreportProcessingEventHandler(workerOrderReport_SubreportProcessing);

            reportViewer3.RefreshReport();
        }

        void workerOrderReport_SubreportProcessing(object sender, SubreportProcessingEventArgs e)
        {
            // get empID from the parameters
            int workerId = Convert.ToInt32(e.Parameters[0].Values[0]);
            bool formOfPayment = Convert.ToBoolean(e.Parameters[1].Values[0]);
            // remove all previously attached Datasources, since we want to attach a
            // new one
            e.DataSources.Clear();
            // Retrieve employeeFamily list based on EmpID
            var orders = OrderService.GetOrderByWorkerIdAndFormOfPayment(workerId, formOfPayment);

            List<OpenOrderForReport> ordersSubReport = new List<OpenOrderForReport>();
            foreach (Order order in orders)
            {
                decimal costOfSewing = OrderService.GetCostOfSewingByOrderId(order.OrderId);
                decimal materialsPrice = ListOfMaterialService.GetSumMaterialsByOrderId(order.OrderId);
                decimal orderPrice = Math.Round(costOfSewing + materialsPrice,2);

                ordersSubReport.Add(new OpenOrderForReport(order, orderPrice));
            }
            // add retrieved dataset or you can call it list to data source
            e.DataSources.Add(new ReportDataSource()
            {
                Name = "DataSet1",
                Value = ordersSubReport
            });
        }

        private void materialOrdersForReport(List<MaterialForReport> _materialOrders, string _allSum, string  _firstDate, string _lastDate)
        {
            string exeFolder = Application.StartupPath;
            string path = Path.Combine(exeFolder, @"Reports\MaterialOrdersReport.rdlc");
            reportViewer3.LocalReport.ReportPath = path;

            reportViewer3.ProcessingMode = ProcessingMode.Local;
            ReportParameter[] param = new ReportParameter[]{
                    new ReportParameter("DateFirst", _firstDate),
                    new ReportParameter("DateLast", _lastDate),
                    new ReportParameter("AllSum",_allSum)
                };
            reportViewer3.LocalReport.SetParameters(param);

            reportViewer3.LocalReport.DataSources.Clear();
            ReportDataSource rd = new ReportDataSource("DataSet1", _materialOrders);
            reportViewer3.LocalReport.DataSources.Add(rd);
            reportViewer3.RefreshReport();

            reportViewer3.LocalReport.SubreportProcessing +=
                new SubreportProcessingEventHandler(materialOrdersForReport_SubreportProcessing);

            reportViewer3.RefreshReport();
        }

        void materialOrdersForReport_SubreportProcessing(object sender, SubreportProcessingEventArgs e)
        {
            // get empID from the parameters
            int materialId = Convert.ToInt32(e.Parameters[0].Values[0]);
            decimal price = Convert.ToDecimal(e.Parameters[1].Values[0]);
            // remove all previously attached Datasources, since we want to attach a
            // new one
            e.DataSources.Clear();
            // Retrieve employeeFamily list based on EmpID
            var materials = ListOfMaterialService.GetMaterialsByMaterialIdAndPrice(materialId,price);
            List<MaterialForSubreport> materialsSubReport = new List<MaterialForSubreport>();
            foreach (ListOfMaterial material in materials)
            {
                materialsSubReport.Add(new MaterialForSubreport(material));
            }
            materialsSubReport = materialsSubReport.OrderByDescending(m => m.ReceiptNumber).ToList();
            // add retrieved dataset or you can call it list to data source
            e.DataSources.Add(new ReportDataSource()
            {
                Name = "DataSet1",
                Value = materialsSubReport
            });
        }

        private void  orderMaterialsForReport(List<OrderForReport> _ordersMaterials, decimal _allMateriaslPrice, string _firstDate,string _lastDate)
        {
            string exeFolder = Application.StartupPath;
            string path = Path.Combine(exeFolder, @"Reports\OrderMaterialsReport.rdlc");
            reportViewer3.LocalReport.ReportPath = path;

            reportViewer3.ProcessingMode = ProcessingMode.Local;
            ReportParameter[] param = new ReportParameter[]{
                    new ReportParameter("DateFirst",_firstDate),
                    new ReportParameter("DateLast",_lastDate),
                    new ReportParameter("AllSum",_allMateriaslPrice.ToString("F"))
                };
            reportViewer3.LocalReport.SetParameters(param);

            reportViewer3.LocalReport.DataSources.Clear();
            ReportDataSource rd = new ReportDataSource("DataSet1", _ordersMaterials);
            reportViewer3.LocalReport.DataSources.Add(rd);
            reportViewer3.RefreshReport();

            reportViewer3.LocalReport.SubreportProcessing +=
                new SubreportProcessingEventHandler(orderMaterialsForRepor_SubreportProcessing);

            reportViewer3.RefreshReport();
        }

        void orderMaterialsForRepor_SubreportProcessing(object sender, SubreportProcessingEventArgs e)
        {
            // get empID from the parameters
            int OrderId = Convert.ToInt32(e.Parameters[0].Values[0]);
            // remove all previously attached Datasources, since we want to attach a
            // new one
            e.DataSources.Clear();
            // Retrieve employeeFamily list based on EmpID
            var materials = ListOfMaterialService.GetByOrderId(OrderId);
            List<ListOfMaterialReport> materialsReport = new List<ListOfMaterialReport>();
            foreach(ListOfMaterial material in materials)    
            {
                int productCount = OrderService.GetProductCountByOrderId(OrderId);
                materialsReport.Add(new ListOfMaterialReport(material,OrderId,productCount));
            }
            materialsReport = materialsReport.OrderByDescending(m => m.Type).ToList();
            // add retrieved dataset or you can call it list to data source
            e.DataSources.Add(new ReportDataSource()
            {
                Name = "DataSet1",
                Value = materialsReport
            });
        }

        private void registerOfSewingReport(List<CostOrder> costOrders, string registerDate)
        {
            string exeFolder = Application.StartupPath;
            string path = Path.Combine(exeFolder, @"Reports\RegisterOfsewingReport.rdlc");
            reportViewer3.LocalReport.ReportPath = path;

            reportViewer3.ProcessingMode = ProcessingMode.Local;
            ReportParameter[] param = new ReportParameter[1];
            param[0] = new ReportParameter("pDate", registerDate, true);
            reportViewer3.LocalReport.SetParameters(param);

            reportViewer3.LocalReport.DataSources.Clear();
            ReportDataSource rd = new ReportDataSource("DataSet1", costOrders);
            reportViewer3.LocalReport.DataSources.Add(rd);
            reportViewer3.RefreshReport();
        }

        private void frmPrint_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        public void саlculation(CalculationForRepot calculationData)
        {
            string exeFolder = Application.StartupPath;
            string path = Path.Combine(exeFolder, @"Reports\CalculationReport.rdlc");
            reportViewer3.LocalReport.ReportPath = path;

            reportViewer3.ProcessingMode = ProcessingMode.Local;
            ReportParameter[] para = new ReportParameter[]{
                    new ReportParameter("pOrderReceipt",calculationData.order.ReceiptNumber),
                    new ReportParameter("pCustomer",calculationData.order.CustomerName),
                    new ReportParameter("pOrderName",calculationData.order.NameProduct),
                    new ReportParameter("pWorker",calculationData.order.Worker.FIO),
                    new ReportParameter("pCoefficient",calculationData.order.Coefficient.ToString()),
                    new ReportParameter("pSetCount",calculationData.order.CountProduct.ToString()),
                    new ReportParameter("pDateRegistration",calculationData.order.DateOfReceipt.ToShortDateString()),
                    new ReportParameter("pCostOfSewingPrice",calculationData.costOfSewingPrice.ToString("F")),
                    new ReportParameter("pOrderSumm",calculationData.orderSumm)
                };
            reportViewer3.LocalReport.SetParameters(para);

            reportViewer3.LocalReport.DataSources.Clear();
            ReportDataSource rd = new ReportDataSource("DataSet1", calculationData.materials.OrderByDescending(m => m.Type));
            ReportDataSource rd2 = new ReportDataSource("DataSet3", calculationData.elements);
            reportViewer3.LocalReport.DataSources.Add(rd);
            reportViewer3.LocalReport.DataSources.Add(rd2);
            reportViewer3.RefreshReport();
        }

        private void frmPrint_Load(object sender, EventArgs e)
        {

        }
    }
}
