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
    /// Interaction logic for OrderPanel.xaml
    /// </summary>
    public partial class OrderPanel : Window
    {
        public OrderPanel()
        {
            InitializeComponent();
        }

        private void CheckoutBtn_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button.Name.Equals("CheckoutBtn"))
            {
                
            }
            else if (button.Name.Equals("BackBtn"))
            {
                Window mainMenu = new MainMenu();
                mainMenu.Show();
                this.Close();
            }
        }
    }
}
