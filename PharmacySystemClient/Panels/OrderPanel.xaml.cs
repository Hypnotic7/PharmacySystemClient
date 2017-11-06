﻿using System;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PharmacySystemClient
{
    /// <summary>
    /// Interaction logic for OrderPanel.xaml
    /// </summary>
    public partial class OrderPanel : Window
    {
        private static double cost;
        private ProductResponse productResponse;
        public OrderPanel()
        {
            InitializeComponent();
            DisplayProducts();
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            UIRemote remote = new UIRemote();
            ViewMainMenu viewMenu = new ViewMainMenu();
            remote.SetCommand(viewMenu);
            remote.ExecuteCommand();
            this.Close();
        }

        private void DisplayProducts()
        {
            Order order = new Order();
            productResponse = order.GetProducts();

            foreach (var product in productResponse.ProductEntities)
            {
                ProductList.Items.Add(product.ProductName + " " + product.Price);
            }
        
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string[] tmp = CustomerTextBox.Text.Split(' ');
            Customer customer = new Customer();
            customer.FirstName = tmp[0];
            customer.LastName = tmp[1];
            string[] items;
            CustomerResponse response = customer.GetCustomer();
           
            if (response.IsValid)
            {
                if (response.PrescriptionEntity.Products.Contains(","))
                {
                    var listOfItems = response.PrescriptionEntity.Products.Split(',');
                    foreach (var product in listOfItems)
                    {
                        items = product.Split(' ');
                        Cart.Items.Add(items[0] + " x" + items[1]);
                    }
                }
                else
                {
                    items = response.PrescriptionEntity.Products.Split(' ');
                    Cart.Items.Add(items[0] + " x" + items[1]);
                }
                DisplayPrice();
            }
        }

       

        private void DisplayPrice()
        {
            var listOfProducts = ProductList.Items;
            var listOfProductsInCart = Cart.Items;
            string[] result,itemName;
            foreach (var product in listOfProducts)
            {
                result = product.ToString().Split(' ');
                foreach (var item in listOfProductsInCart)
                {
                    itemName = item.ToString().Split(' ');
                    if (result[0].Equals(itemName[0]))
                    {
                        string sub = itemName[1].Substring(1);
                        cost += Convert.ToDouble(result[1]) * Convert.ToDouble(sub);
                    }
                }
            }
            Price.Text = cost.ToString();
        }

      

        private void AddToCart_Click(object sender, RoutedEventArgs e)
        {
            var product = ProductList.SelectedItem;
            string quantity = Quantity.Text;
            if (product != null && quantity!=null)
            {
                int productQuantity = Convert.ToInt32(Quantity.Text);
                string name = product.ToString();
                string[] result = name.Split(' ');

                Cart.Items.Add(result[0] + " x" + productQuantity);

                cost += Convert.ToDouble(result[1])*productQuantity;
                Price.Text = cost.ToString();
                Quantity.Text = "";
                ProductList.UnselectAll();
            }
        }
    }
}
