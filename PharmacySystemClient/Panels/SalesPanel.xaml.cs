using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using PharmacySystemClient.Accounts;
using PharmacySystemClient.Sales;

namespace PharmacySystemClient
{
    /// <summary>
    /// Interaction logic for SalesPanel.xaml
    /// </summary>
    public partial class SalesPanel : Window
    {
        public AccountResponse Response;
        public SalesPanel()
        {
            InitializeComponent();
            DisplayChart();
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            UIRemote remote = new UIRemote();
            ViewMainMenu viewMenu = new ViewMainMenu(Response);
            remote.SetCommand(viewMenu);
            remote.ExecuteCommand();
            this.Close();
        }

        private void DisplayChart()
        {
            SalesService sales = new SalesService();
            var salesResponse =sales.ValidateSales();
            int medicalCard =salesResponse.SalesEntity.MedicalCardSales;
            int drugScheme = salesResponse.SalesEntity.DrugSchemeSales;
            int regularSale = salesResponse.SalesEntity.RegularSales;

            List<KeyValuePair<string, int>> valueList = new List<KeyValuePair<string, int>>();
            valueList.Add(new KeyValuePair<string, int>("Medical Card", medicalCard));
            valueList.Add(new KeyValuePair<string, int>("Drug Scheme", drugScheme));
            valueList.Add(new KeyValuePair<string, int>("Regular Sale", regularSale));
            PieChart.DataContext = valueList;
        }
    }
}
