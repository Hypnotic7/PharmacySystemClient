using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using PharmacySystemClient.Command;

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
        
        public UIRemote()
        {
            
        }
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
       
        private Window window;
        private AccountResponse Response { get; }
        private MainMenu mainMenu;

        public ViewMainMenu(AccountResponse response)
        {
            Response = response;
             mainMenu = new MainMenu();
            mainMenu.Response = Response;

        }

        public void Execute()
        {
            if (Response.Account.AccountType == AccountTypeEnum.Employee)
            {
                window = mainMenu;
                mainMenu.ShowEmployeeMenu();
                window.Show();
            }
            else
            {
                window = mainMenu;
                window.Show();
            }
         
        }

        public void Undo()
        {
           // window 
        }
    }
    class ViewModify : ICommand
    {
        private ModifyPanel modify = new ModifyPanel();
        private Window window;

        public void Execute()
        {
            window = modify;
            window.Show();
        }

        public void Undo()
        {
            // window 
        }
    }

    class ViewOrder : ICommand
    {
        private OrderPanel order;
        private MainMenu menu;
        private Window window;
        private AccountResponse Response;

        public ViewOrder(AccountResponse response)
        {
            Response = response;
            order = new OrderPanel();
            order.accountResponse = response;
        }

        public void Execute()
        {
            window = order;
            window.Show();
        }

        public void Undo()
        {
            menu = new MainMenu();
            window = menu;
            window.Show();
        }
    }

    class ViewSales : ICommand
    {
        private SalesPanel sales = new SalesPanel();
        private MainMenu menu = new MainMenu();
        private Window window;

        public void Execute()
        {
            window = sales;
            window.Show();
        }

        public void Undo()
        {
            window = menu;
            window.Show();
        }
    }

    class ViewLogin : ICommand
    {
        private Loginwindow login = new Loginwindow();
        private Window window;

        public void Execute()
        {
            window = login;
            window.Show();
        }

        public void Undo()
        {
            // window 
        }
    }
}
   