using Bank;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BankTests
{
    [TestClass]
    public class BankAccountTest
    {
        [TestMethod]
        public void Debit_WithValidAmount_UpdatesBalance()
        {
            // Arrange
            double beginningBalance = 11.99;
            double debitAmount = 4.55;
            double expected = 7.44;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

            // Act
            account.Debit(debitAmount);

            // Assert
            double actual = account.Balance;
            Assert.AreEqual(expected, actual, 0.001, "Account not debited correctly");
        }

        [TestMethod]
        public void Debit_WhenAmountIsLessThanZero_ShouldThrowArgumentOutOfRange()
        {
            // Arrange
            double beginningBalance = 11.99;
            double debitAmount = -100.00;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

            // Act and assert
            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => account.Debit(debitAmount));
        }


        [TestMethod]
        public void Debit_WhenAmountIsMoreThanBalance_ShouldThrowArgumentOutOfRange()
        {
            // Arrange
            double beginningBalance = 11.99;
            double debitAmount = 20.0;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

            // Act
            try
            {
                account.Debit(debitAmount);
            }
            catch (System.ArgumentOutOfRangeException e)
            {
                // Assert
                StringAssert.Contains(e.Message, BankAccount.DebitAmountExceedsBalanceMessage);
                return;
            }

            Assert.Fail("The expected exception was not thrown.");
        }

        [TestMethod]
        public void Credit_WithPositiveAmount_ShouldIncreaseBalance()
        {
            //Arrange
            double initialBalance = 11.99;
            BankAccount account = new BankAccount("Mr. Bryan Walton", initialBalance);

            // Act
            account.Credit(110);

            // Assert
            double expectedBalance = initialBalance + 110;
            double actualBalance = account.Balance;
            Assert.AreEqual(expectedBalance, actualBalance, "The balance should be increased by the credited amount.");
        }

        [TestMethod]
        public void Credit_WithNegativeAmount_ShouldThrowException()
        {
            // Arrange
            double initialBalance = 11.99;
            BankAccount account = new BankAccount("Mr. Bryan Walton", initialBalance);

            // Act & Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => account.Credit(-50), "Credit with a negative amount should throw an ArgumentOutOfRangeException.");
        }

        [TestMethod]
        public void AddAccount_ShouldIncreaseAccountCount()
        {
            // Arrange
            BankCustomer customer = new BankCustomer("Laiba khan");

            // Act
            customer.AddAccount(500);

            // Assert
            Assert.AreEqual(1, customer.Accounts.Count, "The account count should be increased after adding an account.");
        }

        [TestMethod]
        public void RemoveAccount_ShouldDecreaseAccountCount()
        {
            // Arrange
            BankCustomer customer = new BankCustomer("Laiba");
            BankAccount account = new BankAccount("Mr. Bryan Walton", 600);

            // Act
            customer.RemoveAccount(account);

            // Assert
            Assert.AreEqual(0, customer.Accounts.Count, "The account count should be decreased after deleting an account.");
        }

        [TestMethod]
        public void GetTotalBalance_ShouldReturnSumOfAccountBalances()
        {
            // Arrange
            BankCustomer customer = new BankCustomer("Laiba khan");
            customer.AddAccount(1000);
            customer.AddAccount(2000);

            // Act
            double totalBalance = customer.GetTotalBalance();

            // Assert
            Assert.AreEqual(3000, totalBalance, "The total balance should be the sum of individual account balances.");
        }


        [TestMethod]
        public void Transfer_ValidAmount_ShouldTransferSuccessfully()
        {
            // Arrange
            var account1 = new BankAccount("Mr. Bryan Walton", 500.0);
            var account2 = new BankAccount("Laiba khan", 300.0);

            // Act
            account1.MoneyTransfer(account2, 200.0);

            // Assert
            Assert.AreEqual(300.0, account1.Balance, "Account 1 balance should be 300.0 after sending money");
            Assert.AreEqual(500.0, account2.Balance, "Account 2 balance should be 500.0 after recieving money");
        }

    }
}