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
        public MainMenu()
        {
            InitializeComponent();
        }
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button.Name.Equals("OrderBtn"))
            {
               Window orderPanel = new OrderPanel();
                orderPanel.Show();
                this.Close();
            }
            else if (button.Name.Equals("ModifyBtn"))
            {
                Window modifyPanel = new ModifyPanel();
                modifyPanel.Show();
                this.Close();
            }
            //else if (button.Name.Equals("SalesBtn"))
            //{
            //    Window salesPanel = new SalesPanel();
            //    salesPanel.Show();
            //    this.Close();
            //}
        }
    }
}
