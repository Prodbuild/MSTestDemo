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
        public void Account_Deposit_ThrowsInvalidAmountException_When_Zero_Send_AsAmountToBeDeposisted()
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
        public void Account_Deposit_ThrowsInvalidAmountException_When_LessThanZeroAmount_SendAsInputToBeDeposisted()
        {
            // == Arrange ==
            var sampleAccount = new Account("SBI89273");
            var valueToBeDeposited = -2345;

            // == Act ==
            sampleAccount.Deposit(valueToBeDeposited);
        }

        [TestMethod()]
        [TestCategory("AccountDepositTest")]
        public void Account_Deposit_InputAmountGetSuccessfullyDeposited_When_GreaterThanZeroAmount_Is_Deposited()
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
        [TestCategory("TransferFundUnitTest")]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Account_TransferFund_ThrowsException_When_DestinationAccount_IsNull()
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
        [TestCategory("TransferFundUnitTest")]
        [ExpectedException(typeof(InvalidAmountException))]
        public void Account_TransferFund_ThrowsInvalidAmountException_When_ValueToBeTransferred_IsZero()
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
        [TestCategory("TransferFundUnitTest")]
        [ExpectedException(typeof(InvalidAmountException))]
        public void Account_TransferFund_ThrowsInvalidAmountException_When_ValueToBeTransferred_IsLessThanZero()
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
        [TestCategory("TransferFundUnitTest")]
        [ExpectedException(typeof(InsufficientFundsException))]
        public void Account_TransferFund_ThrowsInsufficientFundException_When_BalanceLeft_After_Fund_Transfer_IsLessThan_MinimumBalance()
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
        [TestCategory("TransferFundUnitTest")]
        public void Account_TransferFund_SourceAccountLeftWithProperBalance_When_AmountTransferred_From_OneAccount_ToAnotheAccount()
        {
            // == Arrange ==
            var sourceAccount = new Account("SBI89273");
            sourceAccount.Deposit(20000);

            var destinationAccount = new Account("SBI758384");

            var valueToBeTransferred = 5000;

            // == Act ==
            sourceAccount.TransferFund(destinationAccount, valueToBeTransferred);

            Assert.AreEqual(sourceAccount.Balance, 15000);
        }

        [TestMethod()]
        [TestCategory("TransferFundUnitTest")]
        public void Account_TransferFund_DestinationAccountHaveProperBalance_When_AmountTransferred_From_OneAccount_ToAnotheAccount()
        {
            // == Arrange ==
            var sourceAccount = new Account("SBI89273");
            sourceAccount.Deposit(20000);

            var destinationAccount = new Account("SBI758384");

            var valueToBeTransferred = 5000;

            // == Act ==
            sourceAccount.TransferFund(destinationAccount, valueToBeTransferred);

            Assert.AreEqual(destinationAccount.Balance, 5000);
        }



    }
}
