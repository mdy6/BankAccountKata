using System;

namespace BankAccountKata
{
    class Program
    {
        static void Main(string[] args)
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

            DateTime from = new DateTime(2019, 04, 26);
            DateTime to = from.AddHours(6);

            Client client = Client.CreateWithBankAccount(bankAccount);
            Console.WriteLine(client.BankAccount.PrintOperationsHistoryBetween(from, to));
            Console.ReadKey();
        }
    }
}
