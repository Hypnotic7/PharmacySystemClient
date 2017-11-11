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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using PharmacySystemClient.Checkout;
using PharmacySystemClient.Orders;

namespace PharmacySystemClient
{
    /// <summary>
    /// Interaction logic for OrderPanel.xaml
    /// </summary>
    public partial class OrderPanel : Window
    {
        private static double cost;
        private ProductResponse productResponse;
        public AccountResponse accountResponse;
        private CustomerResponse customerResponse;
        private ViewMainMenu viewMenu;
        private UIRemote remote;
        private  Originator _product;
        private ItemCollection emptyCartCollection;
        private string  previousCost;

        public Originator Product { get { return _product; } private set { _product = value;} }

        public OrderPanel()
        {
            InitializeComponent();
            DisplayProducts();
            Product = new Originator();
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            remote = new UIRemote();
            viewMenu = new ViewMainMenu(accountResponse);
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
            if (CustomerTextBox.Text != "")
            {
                string[] tmp = CustomerTextBox.Text.Split(' ');
                if (tmp.Length >= 2)
                {
                    Customer customer = new Customer();
                    customer.FirstName = tmp[0];
                    customer.LastName = tmp[1];
                    string[] items;
                    customerResponse = customer.GetCustomer();

                    if (customerResponse.IsValid)
                    {
                        if (customerResponse.PrescriptionEntity.Products.Contains(","))
                        {
                            var listOfItems = customerResponse.PrescriptionEntity.Products.Split(',');
                            foreach (var product in listOfItems)
                            {
                                items = product.Split(' ');
                                Cart.Items.Add(items[0] + " x" + items[1]);
                                Product.MomentoList.Add(items[0] + " x" + items[1]);
                            }
                        }
                        else
                        {
                            items = customerResponse.PrescriptionEntity.Products.Split(' ');
                            Cart.Items.Add(items[0] + " x" + items[1]);
                            Product.MomentoList.Add(items[0] + " x" + items[1]);
                        }
                        DisplayPrice();
                    }
                }
                else
                {
                    MessageBox.Show("Incorrect format");
                }
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
          
                    string productName = product.ToString();
                    bool check = CheckRequiresPrescription(productName);
                    string quantity = Quantity.Text;
                    if (product != null && quantity != "" && check)
                    {
                        int productQuantity = Convert.ToInt32(Quantity.Text);
                        string name = product.ToString();
                        string[] result = name.Split(' ');

                        Cart.Items.Add(result[0] + " x" + productQuantity);

                        cost += Convert.ToDouble(result[1]) * productQuantity;
                        Price.Text = cost.ToString();
                        Quantity.Text = "";
                        ProductList.UnselectAll();
                        Product.MomentoList.Add(result[0] + " x" + productQuantity);

                        CareTaker.Instance.Memento = Product.SaveOriginator();
                    
                }
            
        }

        private void CheckoutBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!Cart.Items.IsEmpty)
            {
                List<ProductEntity> listOfProducts = new List<ProductEntity>();
                string[] productName;
                string  customerName = CustomerTextBox.Text;
                string accountName = accountResponse.Account.AccountName;

                foreach (var products in Cart.Items)
                {
                    productName = products.ToString().Split(' ');
                    foreach (var item in productResponse.ProductEntities)
                    {
                        if (item.ProductName.Equals(productName[0]))
                        {
                            var tmp = item;
                            tmp.Quantity = Convert.ToInt32(productName[1].Substring(1));
                            listOfProducts.Add(tmp);
                        }
                    }
                }
                Checkout.Checkout checkout = new Checkout.Checkout();
                checkout.accountName = accountName;
                checkout.customerName = customerName;
                checkout.products = listOfProducts;
                OrderResponse response = checkout.ValidateOrder();
                if (response.OrderComplete)
                {
                    TransactionComplete(response,accountName,customerName);
                }
            }
        }

        private void TransactionComplete(OrderResponse response,string accountName,string customerName)
        {
            Console.WriteLine("Order Valid");
            var cost = response.OrderEntity.TotalCost;
            string result = "Name:\t\t\t" + customerName + "\n\nEmployee Name:\t\t" + accountName + "\n\nProducts:";
            foreach (var item in Cart.Items)
            {
                string name = item.ToString();
                result += "\t\t\t" + name + "\n";
            }
            result += "\nTotal Cost:\t\t" + cost;
            MessageBox.Show(result, "Transaction Complete");
            this.Close();
            remote = new UIRemote();
            viewMenu = new ViewMainMenu(accountResponse);
            remote.SetCommand(viewMenu);
            remote.ExecuteCommand();
        }

        private bool CheckRequiresPrescription(string product)
        {
            string[] products = product.Split(' ');
            foreach (var item in productResponse.ProductEntities)
            {
                if (item.ProductName == products[0]&& customerResponse.IsValid)
                {
                    if (customerResponse.PrescriptionEntity.Products.Contains(product) && item.RequiresPrescription)
                    {
                        return true;
                    }
                    if (!item.RequiresPrescription)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
           CareTaker.Instance.Memento = Product.SaveOriginator();
            Cart.Items.Clear();
            previousCost = Price.Text;
           Price.Text= "€0.00";
            // _product.Amount = emptyCartCollection;
        }

        //private void SaveAndUpdateState()
        //{
        //    var prodMemento = Product.SaveOriginator();
        //    Product.RestoreOriginator(CareTaker.Instance.Memento);
        //    Update();
        //    CareTaker.Instance.Memento = prodMemento;
        //}

        //private void Update()
        //{
        //    foreach (var item in Product.MomentoList)
        //    {
        //        Cart.Items.Add(item.ToString());
        //    }
        //    Price.Text = previousCost;
        //}

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var prodMemento = Product.SaveOriginator();
            Product.RestoreOriginator(CareTaker.Instance.Memento);
            foreach (var item in Product.MomentoList)
            {
                Cart.Items.Add(item.ToString());
            }
            Price.Text = previousCost;
            CareTaker.Instance.Memento = prodMemento;
        }
    }
}
