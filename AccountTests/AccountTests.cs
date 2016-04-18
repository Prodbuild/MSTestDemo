using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Account;
using Account.BusinessExceptions;
using BankApplication;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BankApplication.Tests
{
    [TestClass()]
    public class AccountTests
    {
        [TestMethod()]
        [TestCategory("AccountDepositTest")]
        [ExpectedException(typeof(InvalidAmountException))]
        public void Account_Deposit_ThrowsInvalidAmountException_WhenZeroSendAsAmountToBeDeposisted()
        {
            // == Arranage  == 
            var sampleAccount = new Account("SBI4837");
            var valueTobeDeposited = 0;

            // == Act ==           
            sampleAccount.Deposit(valueTobeDeposited);

        }

        [TestMethod()]
        [TestCategory("AccountDepositTest")]
        [ExpectedException(typeof(InvalidAmountException))]
        public void Account_Deposit_ThrowsInvalidAmountException_WhenLessThanZeroAmountSendAsInputToBeDeposisted()
        {
            // == Arrange ==
            var sampleAccount = new Account("SBI89273");
            var valueToBeDeposited = -2345;

            // == Act ==
            sampleAccount.Deposit(valueToBeDeposited);
        }

        [TestMethod()]
        [TestCategory("AccountDepositTest")]
        public void Account_Deposit_InputAmountGetSuccessfullyDeposited_WhenGreaterThanZeroAmountIsDeposited()
        {
            // == Arrange ==
            var sampleAccount = new Account("SBI89273");
            var valueToBeDeposited = 20000;

            // == Act ==
            sampleAccount.Deposit(valueToBeDeposited);

            // == Assert ==
            Assert.AreEqual(sampleAccount.Balance, valueToBeDeposited);
        }

        [TestMethod()]
        [TestCategory("TransferFundTest")]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Account_TransferFund_ThrowsException_WhenDestinationAccountIsNull()
        {
            // == Arrange ==
            var sourceAccount = new Account("SBI89273");
            sourceAccount.Deposit(20000);

            Account destinationAccount = null;
            var valueToBeTransferred = 10000;
            
            // == Act ==
            sourceAccount.TransferFund(destinationAccount, valueToBeTransferred);
        }

        [TestMethod()]
        [TestCategory("TransferFundTest")]
        [ExpectedException(typeof(InvalidAmountException))]
        public void Account_TransferFund_ThrowsInvalidAmountException_WhenValueToBeTransferredIsZero()
        {
            // == Arrange ==
            var sourceAccount = new Account("SBI89273");
            sourceAccount.Deposit(20000);

            var destinationAccount = new Account("SBI758384");
            destinationAccount.Deposit(10000);

            var valueToBeTransferred = 0;

            // == Act ==
            sourceAccount.TransferFund(destinationAccount, valueToBeTransferred);
        }

        [TestMethod()]
        [TestCategory("TransferFundTest")]
        [ExpectedException(typeof(InvalidAmountException))]
        public void Account_TransferFund_ThrowsInvalidAmountException_WhenValueToBeTransferredIsLessThanZero()
        {
            // == Arrange ==
            var sourceAccount = new Account("SBI89273");
            sourceAccount.Deposit(20000);

            var destinationAccount = new Account("SBI758384");
            destinationAccount.Deposit(10000);

            var valueToBeTransferred = -10000;

            // == Act ==
            sourceAccount.TransferFund(destinationAccount, valueToBeTransferred);
        }

        [TestMethod()]
        [TestCategory("TransferFundTest")]
        [ExpectedException(typeof(InsufficientFundsException))]
        public void Account_TransferFund_ThrowsInsufficientFundException_WhenBalanceMinusFundTobeTransferredIsLessThanMinimumBalance()
        {
            // == Arrange ==
            var sourceAccount = new Account("SBI89273");
            sourceAccount.Deposit(20000);

            var destinationAccount = new Account("SBI758384");

            var valueToBeTransferred = 15000;

            // == Act ==
            sourceAccount.TransferFund(destinationAccount, valueToBeTransferred);
        }

        [TestMethod()]
        [TestCategory("TransferFundTest")]
        public void Account_TransferFund_SuccessfullyTransferFund_WhenAmountTobeTransferredIsGreaterThenZeroAndSufficientForSourceAccount()
        {
            // == Arrange ==
            var sourceAccount = new Account("SBI89273");
            sourceAccount.Deposit(20000);

            var destinationAccount = new Account("SBI758384");

            var valueToBeTransferred = 5000;

            // == Act ==
            sourceAccount.TransferFund(destinationAccount, valueToBeTransferred);

            Assert.AreEqual(sourceAccount.Balance, 15000);
            Assert.AreEqual(destinationAccount.Balance, 5000);
        }



    }
}
