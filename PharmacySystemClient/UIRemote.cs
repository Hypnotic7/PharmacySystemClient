
using System.Windows;
using PharmacySystemClient.Accounts;

namespace PharmacySystemClient
{
    interface ICommand
    {
        void Execute();
        void Undo();
    }

    class UIRemote
    {
         ICommand icommand;
        
  
        public void SetCommand(ICommand icommand)
        {
            this.icommand = icommand;
        }
        public void ExecuteCommand()
        {
            icommand.Execute();
        }
    }

    class ViewMainMenu : ICommand
    { 
        private UIReciever reciever;

        public ViewMainMenu(AccountResponse response)
        {
            reciever = new UIReciever(response);

        }

        public void Execute()
        {
            reciever.SwitchToMainMenu(); 
        }

        public void Undo()
        {
           // window 
        }
    }
   
    class ViewOrder : ICommand
    {
        private UIReciever reciever;
       
        public ViewOrder(AccountResponse response)
        {
            reciever = new UIReciever(response);
        }

        public void Execute()
        {
            reciever.SwitchToOrder();
        }

        public void Undo()
        {
            reciever.SwitchToMainMenu();
        }
    }

    class ViewSales : ICommand
    {
        private UIReciever reciever;

        public ViewSales(AccountResponse response)
        {
           reciever = new UIReciever(response);
        }
        public void Execute()
        {
            reciever.SwitchToSales();
        }

        public void Undo()
        {
            reciever.SwitchToMainMenu();   
        }
    }

    class ViewLogin : ICommand
    {
        private UIReciever reciever;
        public ViewLogin(AccountResponse response)
        {
            reciever = new UIReciever(response);
        }

        public void Execute()
        {
           reciever.SwitchToLogin();   
        }

        public void Undo()
        {
            // window 
        }
    }

    class UIReciever
    {
        private Window window;
        private MainMenu mainMenu;
        private OrderPanel orderPanel;
        private Loginwindow login;
        private SalesPanel sales;
        private UIReciever reciever;
        private AccountResponse Response;

        public UIReciever(AccountResponse response)
        {
            Response = response;
        }

        public void SwitchToMainMenu()
        {
            if (Response.Account.AccountType == AccountTypeEnum.Employee)
            {
                mainMenu = new MainMenu();
                window = mainMenu;
                mainMenu.Response = Response;
                mainMenu.ShowEmployeeMenu();
                window.Show();
            }
            else
            {
                mainMenu = new MainMenu();
                window = mainMenu;
                mainMenu.Response = Response;
                window.Show();
            }
        }

        public void SwitchToOrder()
        {
            orderPanel = new OrderPanel();
            window = orderPanel;
            orderPanel.accountResponse = Response;
            window.Show();
        }

        public void SwitchToLogin()
        {
            login = new Loginwindow();
            window = login;
            window.Show();    
        }

        public void SwitchToSales()
        {
            sales = new SalesPanel();
            window = sales;
            sales.Response = Response;
            window.Show();
        }
    }
}
   