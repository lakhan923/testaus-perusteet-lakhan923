using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public class BankCustomer
    {
        private readonly string m_CustomerName;
        private readonly List<BankAccount> a_accounts;

        public List<BankAccount> Accounts
        {
            get { return a_accounts; }
        }

        public string CustomerName
        {
            get { return m_CustomerName; }
        }

        public BankCustomer(string customerName)
        {
            m_CustomerName = customerName;
            a_accounts = new List<BankAccount>();
        }

        public void AddAccount(double initialBalance)
        {
            BankAccount account = new BankAccount("Mr. Bryan Walton", initialBalance);
            a_accounts.Add(account);
        }

        public void RemoveAccount(BankAccount account)
        {
            a_accounts.Remove(account);
        }

        //Additional method to get the total balance across all accounts
        public double GetTotalBalance()
        {
            return a_accounts.Sum(account => account.Balance);
        }
    }
}
