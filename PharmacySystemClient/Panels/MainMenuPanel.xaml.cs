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
        public MainMenu()
        {
            InitializeComponent();
        }

       
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            UIRemote remote = new UIRemote();
            ViewMainMenu viewMenu = new ViewMainMenu();
            ViewOrder viewOrder = new ViewOrder();
            ViewModify modify = new ViewModify();
            ViewSales sales = new ViewSales();
            ViewLogin login = new ViewLogin();
            var button = sender as Button;
            if (button.Name.Equals("OrderBtn"))
            {
                remote.SetCommand(viewOrder);
                remote.ExecuteCommand();
                this.Close();
            }
            else if (button.Name.Equals("ModifyBtn"))
            {
                remote.SetCommand(modify);
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
