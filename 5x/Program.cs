using System;

namespace _5x
{
    class Program
    {
        
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

            int PetNum1 =0;
            Console.Write("Есть ли у вас питомец? (Да/Нет)");
            var HavAPet = Console.ReadLine();
            if(HavAPet == "Да")
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
            /* Ещё вариант, но мне больше понравился с условием
            switch (HavAPet)
            {
                case "Да":
                    string Pet;
                    int PetNum;
                    do
                    {
                        Console.Write("Сколько у вас питомцев?: ");
                        Pet = Console.ReadLine();
                    } while (CheckNum(Pet, out PetNum));                    
                    break;
                case "Нет":
                    break;              
            }
            */
            static string[] CreateArrayPets(int num)
            {
                var result = new string[num];
                for(int i = 0; i < num; i++)
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
        static void Main(string[] args)
        {
            Console.WriteLine(EnterByUser());
        }
    }
}
