using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSEDemo.Banking
{
    public class Account
    {
        public int AccountNo { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public double AccountBalance { get; set; }

        public double Withdraw(double amount)
        {
            if (this.AccountBalance > amount)
                this.AccountBalance -= amount;
            return this.AccountBalance;
        }

        public double Deposit(double depositAmount)
        {
            if (this.AccountBalance > 0)
                this.AccountBalance += depositAmount;
            return this.AccountBalance;
        }
    }

    public class JointAccount : Account
    {

    }

    public class BankAccount
    {
        public string name;
        int accountNum;
        public double balance = 0;
        double interest = 0;
        public BankAccount(string namae, double firstDep)
        {
            name = namae;
            balance += firstDep;
        }

        public void setIntRate(double per)
        {
            interest = per;
        }

        public double getBal()
        {
            return balance;
        }

        public string getName()
        {
            return this.name;
        }

        public void deposit(double addAmt)
        {
            balance += addAmt;
        }

        public bool withdraw(double outAmt)
        {
            bool chk = true;
            if (outAmt <= balance)
            {
                balance -= outAmt;
            }
            else if (outAmt > balance)
            {
                chk = false;
            }
            return chk;
        }

        public double getBalAfter(int mos)
        {
            double prin = balance;
            double intFeed;
            for (int g = 1; g <= mos; g++)
            {
                intFeed = prin * interest;
                prin += intFeed;
            }
            return prin;
        }
    }
}
