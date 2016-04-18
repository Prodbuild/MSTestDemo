using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Account;
using Account.BusinessExceptions;

namespace BankApplication
{
    public class Account
    {
        public readonly string AccountNumber;

        public Account(string accountNumber)
        {
            this.AccountNumber = accountNumber;
        }

        private int balance;
        private int minimumBalance = 10000;

        public int Balance
        {
            get { return balance; }
        }

        public int MinimumBalance
        {
            get { return minimumBalance; }
        }

        public void Deposit(int amount)
        {
            if (amount <= 0)
            { throw new InvalidAmountException("Amount cannot be less than zero for deposit  process"); }

            this.balance += amount;
        }

        public void Withdraw(int amount)
        {
            if (amount <= 0)
            { throw new InvalidAmountException("Amount cannot be less than zero for Withdral process"); }

            this.balance -= amount;
        }

        public void TransferFund(Account destinationAccount, int amountToBeTransferred)
        {
            if (destinationAccount == null)
            {
                throw new ArgumentNullException("Destination Account cannot be null");
            }

            if (amountToBeTransferred <= 0)
            {
                throw new InvalidAmountException("Amount cannot be zero or less than zero for tranerring funds");
            }

            if ((this.balance - amountToBeTransferred) < this.minimumBalance)
            {
                throw new InsufficientFundsException(string.Format("Insufficient fund in {0}", this.GetType().Name));
            }

            destinationAccount.Deposit(amountToBeTransferred);
            this.Withdraw(amountToBeTransferred);
        }


    }



}
