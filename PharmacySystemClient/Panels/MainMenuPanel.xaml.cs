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

namespace PharmacySystemClient
{
    /// <summary>
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Window
    {
        private string loggedInAs;
        public AccountResponse Response;

        public MainMenu()
        {
            InitializeComponent();
        }

       
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            UIRemote remote = new UIRemote();
            ViewMainMenu viewMenu = new ViewMainMenu(Response);
            ViewOrder viewOrder = new ViewOrder(Response);
            ViewSales sales = new ViewSales(Response);
            ViewLogin login = new ViewLogin();
            var button = sender as Button;
            if (button.Name.Equals("OrderBtn"))
            {
                remote.SetCommand(viewOrder);
                remote.ExecuteCommand();
                this.Close();
            }
            else if (button.Name.Equals("LogoutBtn"))
            {
                remote.SetCommand(login);
                remote.ExecuteCommand();
                this.Close();
            }
            else if (button.Name.Equals("SalesBtn"))
            {
                remote.SetCommand(sales);
                remote.ExecuteCommand();
                this.Close();
            }
        }
        
        public void ShowEmployeeMenu()
        {
            SalesBtn.Visibility = Visibility.Hidden;
        }
    }
}
