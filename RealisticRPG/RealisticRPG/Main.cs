using System;

namespace MyGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Player p = new Player(); // Создать игрока при заходе в игру
            int choose; // Выбор
            int chooseininventory; // Выбор в инвентаре
            do
            {
                Console.Clear();
                Console.WriteLine("Главное меню");
                Console.WriteLine("1-Подготовка к бою\n2-Бой\n3-Выйти");
                choose = Convert.ToInt32(Console.ReadLine());
                if (choose == 1)
                {
                    Console.WriteLine("Добро пожаловать в мою ТАВЕРНУ!");
                    Console.ReadKey();
                    do
                    {
                        Console.Clear();
                        Console.WriteLine("Таверна");
                        Console.WriteLine("1-Крафт оружия\n2-Назвать оружие\n3-Улучшение\n4-Посмотреть вещи\n5-Вкачать характеристики\n6-Назад");
                        chooseininventory = Convert.ToInt32(Console.ReadLine());
                        if (chooseininventory == 1)
                            p.CraftNewItem();
                        else if (chooseininventory == 2)
                            p.SetItemName();
                        else if (chooseininventory == 3)
                            p.UpgradeItem();
                        else if (chooseininventory == 4)
                            p.GetItems();
                        else if (chooseininventory == 5)
                            p.UpSkillPoints();
                        else if (chooseininventory == 6)
                            Console.WriteLine("Выход в меню");
                        Console.ReadKey();
                    } while (chooseininventory != 6);
                }
                if (choose == 2)
                {
                    Battle b = new Battle();
                    b.MainBattle(p);
                    Console.ReadKey();
                }
                if (choose == 3)
                {
                    Console.WriteLine("Вы вышли!");
                    Console.ReadKey();
                }
            } while (choose != 3);
        }
    }
}