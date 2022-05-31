using System;

namespace _5x
{
    class Program
    {
        
        /// <summary>
        /// Метод проверки на корректность ввода числовых значений
        /// </summary>
        /// <param name="number"></param>
        /// <param name="corrnumber"></param>
        /// <returns></returns>
        static bool CheckNum(string number, out int corrnumber)
        {

            if (int.TryParse(number, out int intnum))
            {
                if (intnum > 0)
                {
                    corrnumber = intnum;
                    return false;
                }
            }
            {
                corrnumber = 0;
                Console.WriteLine("Не верный ввод, повторите снова");
                return true;
            }

        }

        /// <summary>
        /// Метод забора данных пользователя с консоли в кортэж
        /// </summary>
        /// <returns></returns>
        static (string Name, string LastName, int Age, string[] IfPet, string[] FaveCollors) EnterByUser()
        {
            (string Name, string LastName, int Age, string[] IfPet, string[] FaveCollors) User;

            Console.Write("Введите ваше имя: ");
            User.Name = Console.ReadLine();
            Console.Write("Введите вашу фамилию: ");
            User.LastName = Console.ReadLine();
            string age;
            int intage;
            do
            {
                Console.Write("Введите ваш возраст циврами: ");
                age = Console.ReadLine();
            } while (CheckNum(age, out intage));
            User.Age = intage;

            int PetNum1 = 0;
            Console.Write("Есть ли у вас питомец? (Да/Нет)");
            var HavAPet = Console.ReadLine();
            if (HavAPet == "Да")
            {
                string Pet;
                int PetNum;
                do
                {
                    Console.Write("Сколько у вас питомцев?: ");
                    Pet = Console.ReadLine();
                } while (CheckNum(Pet, out PetNum));
                PetNum1 = PetNum;

            }
            User.IfPet = CreateArrayPets(Convert.ToInt32(PetNum1));

            static string[] CreateArrayPets(int num)
            {
                var result = new string[num];
                for (int i = 0; i < num; i++)
                {
                    Console.Write("Введите кличку вашего животного: ");
                    result[i] = Console.ReadLine();
                }
                return result;
            }

            string num;
            int CollorsNum;
            do
            {
                Console.Write("Сколько у вас любимых цветов?: ");
                num = Console.ReadLine();
            } while (CheckNum(num, out CollorsNum));
            User.FaveCollors = CreateArrayCollors(CollorsNum);

            static string[] CreateArrayCollors(int Collors)
            {
                var result = new string[Collors];
                for (int i = 0; i < Collors; i++)
                {
                    Console.Write("Введите ваш любимый цвет: ");
                    result[i] = Console.ReadLine();
                }
                return result;
            }


            return User;

        }
        /// <summary>
        /// Метод вывода данных пользователя на консоль
        /// </summary>
        static void PrinUserDate()
        {
            var temp = EnterByUser();
            Console.WriteLine(" ");
            Console.WriteLine("Вас зовут {0} {1} и вам {2}", temp.Name, temp.LastName, temp.Age);
            Console.WriteLine(" ");
            if (temp.IfPet.Length != 0)
            {
                Console.WriteLine("Ваш(и) питомец(и): ");
            }
            foreach (string pet in temp.IfPet)
            {
                Console.WriteLine(pet);
            }
            Console.WriteLine(" ");
            Console.WriteLine("Ващи любимые цвета:");
            foreach (string collors in temp.FaveCollors)
            {
                Console.WriteLine(collors);
            }
        }
        /// <summary>
        /// Вызов метода печати данных в консоль
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            PrinUserDate();
        }
    }
}

