using System;

namespace DioBank
{

    class Program
    {

        static void Main()
        {
            const string LIST_ALL = "1";
            const string INSERT_ACCOUNT = "2";
            const string TRANSFER = "3";
            const string WITHDRAW = "4";
            const string DEPOSIT = "5";
            const string DELETE = "6";
            const string DETAIL = "7";
            const string CLEAR = "C";
            const string QUIT = "X";

            string userOption = GetUserOption();

            while (userOption.ToUpper() != QUIT)
            {
                switch (userOption)
                {
                    case LIST_ALL:
                        Account.ListAll();
                        break;
                    case INSERT_ACCOUNT:
                        {
                            Console.Write("Digite o tipo da conta Fisica = 0, Juridica = 1: ");
                            var accountType = int.Parse(Console.ReadLine());
                            Console.Write("Digite o nome da conta: ");
                            var accountName = Console.ReadLine();
                            Console.Write("Digite o saldo inicial da conta: ");
                            var balance = decimal.Parse(Console.ReadLine());
                            Console.Write("Digite o valor de crédito para a conta: ");
                            var credit = decimal.Parse(Console.ReadLine());
                            Account.InsertNewAccount(accountType == 0 ? AccountEnum.Individual : AccountEnum.Legal, accountName,
                                balance, credit);
                            break;
                        }
                    case TRANSFER:
                        {
                            if (Account.getListCount() < 2)
                            {
                                Console.WriteLine("Não é possível transferir, não existem duas contas cadatradas");
                                break;
                            }

                            Account.GetAvaliableAccount();
                            Console.WriteLine("Digite o codigo da conta de origem");
                            var sourceAccount = int.Parse(Console.ReadLine());
                            Console.WriteLine("Digite o codigo da conta de destino");
                            var targetAccount = int.Parse(Console.ReadLine());
                            Console.WriteLine("Digite o valor para transferir");
                            var value = decimal.Parse(Console.ReadLine());
                            Account.Transfer(value, targetAccount, sourceAccount);
                            break;
                        }

                    case WITHDRAW:
                        {
                            Account.GetAvaliableAccount();
                            Console.WriteLine("Digite o codigo da conta para saque");
                            var sourceAccount = int.Parse(Console.ReadLine());
                            Console.WriteLine("Digite o valor para saque");
                            var value = decimal.Parse(Console.ReadLine());
                            Account.Withdraw(sourceAccount, value);
                            break;
                        }
                    case DEPOSIT:
                        {
                            Account.GetAvaliableAccount();
                            Console.WriteLine("Digite o codigo da conta para depositar");
                            var sourceAccount = int.Parse(Console.ReadLine());
                            Console.WriteLine("Digite o valor para deposito");
                            var value = decimal.Parse(Console.ReadLine());
                            Account.Deposit(sourceAccount, value);
                            break;
                        }
                    case DELETE:
                        {
                            Account.GetAvaliableAccount();
                            Console.WriteLine("Digite o codigo da conta para excluir");
                            var sourceAccount = int.Parse(Console.ReadLine());
                            Account.DeleteAccount(sourceAccount);
                            break;
                        }
                    case DETAIL:
                        {
                            Account.GetAvaliableAccount();
                            Console.WriteLine("Digite o codigo da conta para listar os detalhes");
                            var sourceAccount = int.Parse(Console.ReadLine());
                            Account.GetDetail(sourceAccount);
                            break;
                        }
                    case CLEAR:
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }

                userOption = GetUserOption();
            }

            Console.WriteLine("Fim!");
        }

        private static string GetUserOption()
        {
            Console.WriteLine();
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1- Listar contas");
            Console.WriteLine("2- Inserir nova conta");
            Console.WriteLine("3- Transferir");
            Console.WriteLine("4- Sacar");
            Console.WriteLine("5- Depositar");
            Console.WriteLine("6- Excluir conta");
            Console.WriteLine("7- Detalhes conta");
            Console.WriteLine("C- Limpar Tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string userOption = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return userOption;
        }
    }
}
