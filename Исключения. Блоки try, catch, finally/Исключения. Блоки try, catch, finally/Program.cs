using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Исключения.Блоки_try__catch__finally
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /* 
             
             
                                    Задание «Обработка исключений»
            
            int num1;
            int num2;
            int result;

            while (true)
            {
                try
                {
                    Console.Write("Введите первое число: ");
                    num1 = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Введите второе число: ");
                    num2 = Convert.ToInt32(Console.ReadLine());

                    result = num1 / num2;
                    Console.WriteLine("Результат: " + result);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Это не число броуу");
                }
                catch (DivideByZeroException)
                {
                    Console.WriteLine("дурачье. на ноль делить нельзя");
                }
            }

            */







            //Задание «Вызов и обработка исключений»

            BankAccount account = new BankAccount("1350482024", 10000.00m);

            Console.WriteLine(string.Format(CultureInfo.GetCultureInfo("en-US"), "Номер счета: {0}, Баланс: {1:C}", account.AccountNumber, account.Balance));

            account.Withdraw(500.00m);

            account.Withdraw(-200.00m);

            account.Withdraw(100000.00m);
        }


        public class BankAccount
        {
            public string AccountNumber { get; }
            public decimal Balance { get; private set; }

            public BankAccount(string accountNumber, decimal initialBalance)
            {
                AccountNumber = accountNumber;
                Balance = initialBalance;
            }

            public void Withdraw(decimal amount)   //mетод для списания средств со счета
            {
                try
                {
                    if (amount < 0)
                    {
                        throw new ArgumentException("Сумма списания не может быть отрицательной.");
                    }

                    if (amount > Balance)
                    {
                        throw new InvalidOperationException("Недостаточно средств на счете.");
                    }

                    Balance -= amount;                          // Списание средств
                    Console.WriteLine(string.Format(CultureInfo.GetCultureInfo("en-US"), "Списано {0:C} со счета {1}. Ваш баланс: {2:C}", amount, AccountNumber, Balance));
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }

}
    
