using System;
using System.Collections.Generic;


namespace DioBank
{
    class Account
    {

        static int counter = 0;
        static List<Account> accountList = new List<Account>();

        public int Id { get; set; }
        public AccountEnum Type { get; set; }
        public string Name { get; set; }
        public decimal Balance { get; set; }
        public decimal Credit { get; set; }
        public string Status { get; set; }

        public Account(int id, AccountEnum type, string name, decimal balance, decimal credit)
        {
            Id = id;
            Type = type;
            Name = name;
            Balance = balance;
            Credit = credit;
        }
         
        public static void ListAll()
        {
            foreach (var account in accountList)
            {
                Console.WriteLine($"{account}");
            }
            Console.WriteLine();
        }

        public static void GetAvaliableAccount()
        {
            foreach (var account in accountList)
            {
                var totalAvaliableValue = account.Balance + account.Credit;
                Console.WriteLine($"{account.Id} | {account.Name} | {totalAvaliableValue}");
            }
            Console.WriteLine();
        }

        public static void InsertNewAccount(AccountEnum type, string name, decimal balance, decimal credit)
        {
            var account = new Account(counter + 1, type, name, balance, credit);
            accountList.Add(account);
            Console.WriteLine($"Conta Inserida: {account}");
            counter += 1;
        }

        public static bool Withdraw(int accountId, decimal value)
        {
            foreach (var account in accountList)
            {

                if (account.Id == accountId)
                {
                    if (account.Balance >= value)
                    {
                        account.Balance -= value;
                        Console.WriteLine($"Saque realizado na conta {account.Name} de {value} reais");
                        return true;
                    }

                    if (account.Balance + account.Credit >= value)
                    {
                        var valueCredit = value - account.Balance;
                        account.Balance = 0;
                        account.Credit -= valueCredit;
                        Console.WriteLine($"Saque realizado na conta {account.Name} de {value} reais utilizando o crédito");
                        return true;
                    }

                    Console.WriteLine("Saldo insuficiente para saque.");
                    return false;
                }

            }
            return false;
        }

        public static void Deposit(int accountId, decimal value)
        {
            foreach (var account in accountList)
            {
                if (account.Id == accountId)
                {
                    account.Balance += value;

                    Console.WriteLine($"Depósito realizado na conta {account.Name} de {value} reais");
                    break;
                }
            }
        }

        public static void Transfer(decimal transferValue, int targetAccount, int sourceAccount)
        {
            Account source = null;
            Account target = null;

            foreach (var account in accountList)
            {
                if (account.Id == sourceAccount)
                    source = account;

                if (account.Id == targetAccount)
                    target = account;

                if (source != null && target != null)
                {
                    break;
                }
            }

            if (Withdraw(sourceAccount, transferValue))
                Account.Deposit(targetAccount, transferValue);
            Console.WriteLine($"Transferência de {transferValue} reais realizada da conta {source.Name} para {target.Name}");

        }

        public static void DeleteAccount(int accountId)
        {
            foreach (var account in accountList)
            {
                if (account.Id == accountId)
                {
                    accountList.Remove(account);
                    Console.WriteLine($"Conta deletada com sucesso.");
                    break;
                }

            }
        }

        public static void GetDetail(int accountId)
        {
            foreach (var account in accountList)
            {
                if (account.Id == accountId)
                    Console.WriteLine(account);
            }
        }

        public static int getListCount()
        {
            return accountList.Count;
        }

        public override string ToString()
        {
            Console.WriteLine();
            string _return = "";
            _return += $"Id: {this.Id}" + Environment.NewLine;
            _return += $"Tipo da conta: {this.Type}" + Environment.NewLine;
            _return += $"Nome: {this.Name}" + Environment.NewLine;
            _return += $"Saldo: {this.Balance}" + Environment.NewLine;
            _return += $"Crédito: {this.Credit}" + Environment.NewLine;
            return _return;
        }

    }

}
