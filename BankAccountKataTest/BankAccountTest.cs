﻿using System;
using BankAccountKata;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BankAccountKataTest
{
    [TestClass]
    public class BankAccountTest
    {
        [TestMethod]
        public void ClientWithNewBankAccountShouldHaveAmountZero()
        {
            Client client = CreateClientWithNoBankAccount();

            double amount = client.BankAccount.GetAmount();

            amount.Should().Be(0);
        }

        [TestMethod]
        public void ClientMakesOneDepositOf10OnNewBankAccountGetAmountShouldGive10()
        {
            Client client = CreateClientWithNoBankAccount();

            client.BankAccount.MakeDepositOf(10);

            double amount = client.BankAccount.GetAmount();

            amount.Should().Be(10);
        }

        [TestMethod]
        public void ClientMakesOneWithdrawalOf10OnNewBankAccountGetAmountShouldGiveMinus10()
        {
            Client client = CreateClientWithNoBankAccount();

            client.BankAccount.MakeWithDrawalOf(10);

            double amount = client.BankAccount.GetAmount();

            amount.Should().Be(-10);
        }

        [TestMethod]
        public void ClientMakesOneDepositOf10OnExistingBankAccountGetAmountShouldGive20()
        {
            Client client = CreateClientWithExistingBankAccount();

            client.BankAccount.MakeDepositOf(10);

            double amount = client.BankAccount.GetAmount();

            amount.Should().Be(20);
        }

        [TestMethod]
        public void ClientMakesOneWithdrawalOf10OnExistingBankAccountShouldGiveZero()
        {
            Client client = CreateClientWithExistingBankAccount();
            double withDrawalAmount = 10;

            client.BankAccount.MakeWithDrawalOf(withDrawalAmount);
            double amount = client.BankAccount.GetAmount();

            amount.Should().Be(0);
        }

        private static Client CreateClientWithExistingBankAccount()
        {
            DateTime date = new DateTime(2019, 04, 26);
            Deposit deposit = new Deposit(date.AddHours(2), 10);
            Withdrawal withDrawal = new Withdrawal(date.AddHours(4), 5);
            Deposit deposit1 = new Deposit(date.AddHours(6), 10);
            Withdrawal withDrawal1 = new Withdrawal(date.AddHours(8), 5);

            Operations operations = new Operations();
            operations.AddOperation(deposit);
            operations.AddOperation(withDrawal);
            operations.AddOperation(deposit1);
            operations.AddOperation(withDrawal1);

            BankAccount bankAccount = BankAccount.CreateWithExistingOperations(operations);

            Client client = Client.CreateWithBankAccount(bankAccount);

            return client;
        }

        private static Client CreateClientWithNoBankAccount()
        {
            return new Client();
        }
    }
}
