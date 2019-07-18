using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace FSEDemo.Threading
{
    public class BankAccount
    {
        private object _lock = new object();
        public string AccountNumber { get; }
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public decimal Balance
        {
            get
            {
                decimal balance = 0;
                foreach (var item in allTransactions)
                {
                    balance += item.Amount;
                }

                return balance;
            }
        }

        private static int accountNumberSeed = 1000000501;
        public BankAccount(string name, decimal initialBalance)
        {
            this.AccountNumber = accountNumberSeed.ToString();
            accountNumberSeed++;

            this.CustomerName = name;
            Deposit(initialBalance, DateTime.Now, "Initial deposit.");
        }

        private List<Transaction> allTransactions = new List<Transaction>();

        /// <summary>
        /// Perform the 
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="date"></param>
        /// <param name="note"></param>
        public void Deposit(decimal amount, DateTime date, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of deposit must be positive");
            }

            bool lockTaken = false;
            Monitor.Enter(_lock, ref lockTaken);
            try
            {
                var deposit = new Transaction(amount, date, note);
                allTransactions.Add(deposit);
            }
            catch (Exception ex) { throw ex; }
            finally
            {
                if (lockTaken)
                    Monitor.Exit(_lock);
                lockTaken = false;
            }
        }

        /// <summary>
        /// Withdraw money
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="date"></param>
        /// <param name="note"></param>
        public void Withdraw(decimal amount, DateTime date, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of withdrawal must be positive");
            }
            if (Balance - amount < 0)
            {
                throw new InvalidOperationException("Not sufficient funds for this withdrawal");
            }

            bool lockTaken = false;
            Monitor.Enter(_lock, ref lockTaken);
            try
            {
                var withdrawal = new Transaction(-amount, date, note);
                allTransactions.Add(withdrawal);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (lockTaken)
                    Monitor.Exit(_lock);
                lockTaken = false;
            }
        }

        public string GetAccountHistory()
        {
            var report = new System.Text.StringBuilder();

            report.AppendLine("Date\tAmount\tNote");
            foreach (var item in allTransactions)
            {
                report.AppendLine($"{item.Date.ToShortDateString()}\t{item.Amount}\t{item.Notes}");
            }

            return report.ToString();
        }
    }

    public class Transaction
    {
        public decimal Amount { get; }
        public DateTime Date { get; }
        public string Notes { get; }

        public Transaction(decimal amount, DateTime date, string note)
        {
            this.Amount = amount;
            this.Date = date;
            this.Notes = note;
        }
    }


    public class AccountOperations
    {
        public static void PerformOperation()
        {
            var account = new BankAccount("Arvind Kumar", 1000);
            Console.WriteLine($"Account {account.AccountNumber} was created for {account.CustomerName} with {account.Balance} balance.");

            var operation1 = Task.Factory.StartNew(() => account.Withdraw(200, DateTime.Now, "Rent payment"));
            var operation2 = Task.Factory.StartNew(() => account.Withdraw(500, DateTime.Now, "Credit Card payment"));
            var operation3 = Task.Factory.StartNew(() => account.Deposit(100, DateTime.Now, "friend paid me back"));


            Task.WaitAll(operation1, operation2, operation3);

            Console.WriteLine(account.GetAccountHistory());

            Console.WriteLine($"Account Balance amount is : {account.Balance}");

        }
    }

}