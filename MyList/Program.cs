using LibraryClass;

namespace MyList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyList<BankCard> list = new MyList<BankCard>();
            int answer = 1;
            while (answer != 7)
            {
                try
                {
                    Console.WriteLine("1. Создать новый список");
                    Console.WriteLine("2. Напечатать список");
                    Console.WriteLine("3. Удалить элементы с четными номерами");
                    Console.WriteLine("4. Добавить элемент после элемента с заданным информационным полем");
                    Console.WriteLine("5. Глубокое копирование списка");
                    Console.WriteLine("6. Удалить из памяти");
                    Console.WriteLine("7. Выйти");
                    answer = int.Parse(Console.ReadLine());
                    switch (answer)
                    {
                        case 1:
                            Console.WriteLine("Задайте размер коллекции");
                            int size = int.Parse(Console.ReadLine());
                            list = new MyList<BankCard>(size);
                            Console.WriteLine("Лист создан");
                            break;
                        case 2:
                            list.Print();
                            break;
                        case 3:
                            list.RemoveEvenItems();
                            break;
                        case 4:
                            Console.WriteLine("Введите карту, после которой нужно добавить элемент:");
                            BankCard foundCard = new BankCard();
                            foundCard.Init();
                            BankCard addCard = new BankCard();
                            addCard.RandomInit();
                            if (list.AddAfter(foundCard, addCard))
                            {
                                Console.WriteLine("Карта добавлена");
                            }
                            else
                            {
                                Console.WriteLine("Карта не добавлена");
                            }
                            break;
                        case 5:
                            MyList<BankCard> clonedList = list.Clone();
                            Console.WriteLine("Список успешно скопирован.");
                            clonedList.Print();
                            Point<BankCard> begCard = clonedList.GetBeging();
                            begCard.Data.RandomInit();
                            Console.WriteLine("Клон изменён.");
                            clonedList.Print();
                            Console.WriteLine("Список изначальный.");
                            list.Print();
                            break;
                        case 6:
                            Console.WriteLine("Удаление списка из памяти...");
                            list.Clear();
                            Console.WriteLine("Список успешно удален из памяти.");
                            break;
                        case 7:
                            Console.WriteLine("Программа завершена.");
                            break;
                        default:
                            Console.WriteLine("Некорректный ввод. Попробуйте еще раз.");
                            break;
                    }
                }
                catch (Exception ex)
                { Console.WriteLine(ex.Message); }
            }
        }
    }
}