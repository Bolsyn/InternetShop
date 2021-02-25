using InternetShop.Services;
using System;

namespace InternetShop.UI
{
    public class SignUpMenu
    {
        public void PrintSignUp()
        {
            Console.WriteLine("Регистрация? Нажмите 1");
            Console.WriteLine("Вход? Нажмите 2");
            Console.WriteLine("Выход? Нажмите 0");
            int signUp = Console.Read() - 48;

            var rand = new Random();
            int code = rand.Next() % 89999 + 10000;
            if (signUp == 1)
            {
                Console.WriteLine("Введите номер, (+XYYYZZZZZZZ)");
                Console.Write("где, X - код страны, Y - код опрератора, Z - номер телефона: ");
                Console.ReadLine();
                string phone = Console.ReadLine();

                Twillio.SendSms(phone, code);

                Console.Write("Напиште код который пришел на ваш телефон: ");
                string inputCode = Console.ReadLine();

                if (Int32.TryParse(inputCode, out int intCode))
                {
                    intCode = Int32.Parse(inputCode);
                }

                if (intCode == code)
                {
                    Console.WriteLine("Поздравляю, вы зарегистрировались!");
                }
                else
                {
                    Console.WriteLine("Заново!");
                }
            }
            if (signUp == 2)
            {
                Console.WriteLine("Введите номер, (+XYYYZZZZZZZ)");
                Console.Write("где, X - код страны, Y - код опрератора, Z - номер телефона: ");
                Console.ReadLine();
                string phone = Console.ReadLine();

                Twillio.SendSms(phone, code);

                Console.Write("Напиште код который пришел на ваш телефон: ");
                string inputCode = Console.ReadLine();

                if (Int32.TryParse(inputCode, out int intCode))
                {
                    intCode = Int32.Parse(inputCode);
                }

                if (intCode == code)
                {
                    Console.WriteLine("Поздравляю, вы зарегистрировались!");
                }
                else
                {
                    Console.WriteLine("Заново!");
                }
            }
            else if (signUp == 0)
            {
                Console.WriteLine("До свидания!");
            }
        }
    }
}
