using System;
using System.Threading;

namespace jointAccount
{

    internal class BankAccount
    {
        private int balance = 100;

        public virtual int Balance
        {
            get
            {
                return balance;
            }
        }
        public virtual void withdraw(int amount)
        {
            balance = balance - amount;
        }
    }

    public class JointAccountApp 
    {
        private BankAccount account = new BankAccount();

        public static void Mainn(string[] args)
        {
            JointAccountApp theJob = new JointAccountApp();
            Thread one = new Thread(theJob);
            Thread two = new Thread(theJob);
            one.Name = "Ryan";
            two.Name = "Monica";
            one.Start();
            two.Start();
        }

        public virtual void run()
        {
            for (int x = 0; x < 10; x++)
            {
                makeWithdrawal(10);
                if (account.Balance < 0)
                {
                    Console.WriteLine("Overdrawn");
                }
            }
        }
        private void makeWithdrawal(int amount)
        {
            if (account.Balance >= amount)
            {
                Console.WriteLine(Thread.CurrentThread.Name + " is about to withdraw");
                try
                {
                    Console.WriteLine(Thread.CurrentThread.Name + " is going to sleep");
                    Thread.Sleep(500);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    Console.Write(ex.StackTrace);
                }
                Console.WriteLine(Thread.CurrentThread.Name + " woke up.");
                account.withdraw(amount);
                Console.WriteLine(Thread.CurrentThread.Name + "completes the withdrawal");
                Console.WriteLine(account.Balance);
            }
            else
            {
                Console.WriteLine("Sorry, not enough for " + Thread.CurrentThread.Name);
            }
        }
    }
}
