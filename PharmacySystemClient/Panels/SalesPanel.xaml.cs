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
    /// Interaction logic for SalesPanel.xaml
    /// </summary>
    public partial class SalesPanel : Window
    {
        public SalesPanel()
        {
            InitializeComponent();
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            UIRemote remote = new UIRemote();
            ViewMainMenu viewMenu = new ViewMainMenu();
            remote.SetCommand(viewMenu);
            remote.ExecuteCommand();
            this.Close();
        }
    }
}
