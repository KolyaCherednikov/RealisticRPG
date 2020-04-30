using System;

public class Player
{
    int Health; // Здоровье игрока
    int Damage; // Базовый урон игрока(зависит от характеристик)
    int Exp; // Значение опыта игрока при достижение определенного значения повышаеться уровень
    int Level; // Уровень зависит от опыта дает очки навыков
    int Skillpoints; // Очки навыков зависит от уровня
    int numofitemsinhands; // Количество занятых рук
    int Strength; // Характеристика увеличивает здоровье и урон
    int Agility; // Характеристика увеличивает шанс уклонений и доп крит шанс
    int ExtraCritChanse; // Дополнительный крит шанс зависит от ловкости
    Boolean Block; // Значение true/false для блока удара врага
    Item[] itemsinhands = new Item[2]; // Вещи в руках
    Random rnd = new Random(); // Рандомизация числа

    public Player() // Конструктор
	{
        this.Health = 100;
        this.Strength = 1;
        this.Agility = 1;
        this.Damage = Strength*2;
        this.Level = 1;
        this.Exp = 0;
        this.Skillpoints = 0;
        this.Block = false;
        this.numofitemsinhands = 0;
        this.ExtraCritChanse = Agility * 5;
    }

    public void TakeDamage(int Damage) // Нанести игроку урон и так же просчитать кол-во нанесенного урона по игроку
    {
        if (this.Block == true)
        {
            this.Health -= (Damage / 2);
            this.Block = false;
            Console.WriteLine("Вы заблокировали удар");
        }
        else
        {
            if (rnd.Next(0, 2) == 0)
            {
                this.Health -= Damage;
                Console.WriteLine("Вы не уклонились ");
            }
            else
                Console.WriteLine("Вы уклонились ");
        }
    }

    public void DoDamage(Enemy e) // Нанести урон
    {
        if (numofitemsinhands == 2) // Просчёт нанесенного урона для 2 занятых рук
        {
            if (rnd.Next(1, 101) < itemsinhands[0].getCritChance() + this.ExtraCritChanse && rnd.Next(1, 101) < itemsinhands[1].getCritChance() + this.ExtraCritChanse)
            {
                e.TakeDamage(this.Damage + itemsinhands[0].getDamage() * 2 + itemsinhands[1].getDamage() * 2);
                Console.WriteLine("Крит с 2 оружий");
            }
            else if (rnd.Next(1, 101) < itemsinhands[0].getCritChance() + this.ExtraCritChanse && rnd.Next(1, 101) > itemsinhands[1].getCritChance() + this.ExtraCritChanse)
            {
                e.TakeDamage(this.Damage + itemsinhands[0].getDamage() * 2 + itemsinhands[1].getDamage());
                Console.WriteLine("Крит с 1 оружия");
            }
            else if (rnd.Next(1, 101) > itemsinhands[0].getCritChance() + this.ExtraCritChanse && rnd.Next(1, 101) < itemsinhands[1].getCritChance() + this.ExtraCritChanse)
            {
                e.TakeDamage(this.Damage + itemsinhands[0].getDamage() + itemsinhands[1].getDamage() * 2);
                Console.WriteLine("Крит с 2 оружия");
            }
            else
                e.TakeDamage(this.Damage + itemsinhands[0].getDamage() + itemsinhands[1].getDamage());
        }
        else if (numofitemsinhands == 1) // для 1 руки
        {
            if (rnd.Next(1, 101) < itemsinhands[0].getCritChance() + this.ExtraCritChanse)
            {
                e.TakeDamage(this.Damage + itemsinhands[0].getDamage() * 2);
                Console.WriteLine("Крит");
            }
            else
                e.TakeDamage(this.Damage + itemsinhands[0].getDamage());
        }
        else // для свободных рук
            e.TakeDamage(this.Damage);
    }

    public void DoBlock() => this.Block = true; // Заблокировать удар

    public void checkALL() // Проверить все характеристики и просчитать всё
    {
        if (this.Exp >= this.Level * (50 * this.Level / 10))
        {
            for (int i = 0; i < 1;) {
                if (this.Exp >= this.Level * (50 * this.Level / 10))
                {
                    this.Exp -= this.Level * (50 * this.Level / 10);
                    this.Level += 1;
                    this.Skillpoints += 3;
                }
                else
                    i++;
            }
            Console.WriteLine("Уровень поднялся. Теперь ваш уровень: " + this.Level + "\n" + "Очков навыков: " + this.Skillpoints);
        }
        this.Damage = this.Strength * 2;
        this.ExtraCritChanse = this.Agility * 5;
    }

    public void ResiveExp(int exp) // Получить опыт
    {
        this.Exp = this.Exp + exp;
        checkALL();
    }

    public int getHealth() { // Отдать кол-во здоровья
        return this.Health;
    }

    public void CraftNewItem() // Скрафтить вещи
    {
        if (numofitemsinhands < 2)
        {
            Console.WriteLine("Выберайте оружие которое хотите создать: \n"+"1. Плохой меч\n"+"2. Меч\n"+"3. Идеальный меч");
            int choose = Convert.ToInt32(Console.ReadLine());
            if(choose == 1)
                itemsinhands[numofitemsinhands] = ItemTypes.CreateBadSword();
            if (choose == 2)
                itemsinhands[numofitemsinhands] = ItemTypes.CreateMediumSword();
            if (choose == 3)
                itemsinhands[numofitemsinhands] = ItemTypes.CreatePerfectSword();
            numofitemsinhands += 1;
            GetItems();
        }
    }

    public void UpgradeItem() // Улучшить вещи
    {
        if (numofitemsinhands > 0)
        {
            for (int i = 0; i < numofitemsinhands; i++)
                Console.WriteLine((i + 1) + ". " + itemsinhands[i].toString());
            Console.WriteLine("Выберайте оружие: ");
            int choose = Convert.ToInt32(Console.ReadLine())-1;
            itemsinhands[choose].Upgrade();
            GetItems();
        }
    }

    public void SetItemName() // Установить название вещи
    {
        if (numofitemsinhands > 0)
        {
            for (int i = 0; i < numofitemsinhands; i++)
                Console.WriteLine((i + 1) + ". " + itemsinhands[i].toString());
            Console.WriteLine("Выберайте оружие: ");
            int choose = Convert.ToInt32(Console.ReadLine())-1;
            itemsinhands[choose].setName();
            GetItems();
        }
    }

    public void GetItems() // Получить вещи которые в руках
    {
        if (numofitemsinhands > 0)
        {
            for (int i = 0; i < numofitemsinhands; i++)
                Console.WriteLine((i + 1) + ". " + itemsinhands[i].toString());
        }
    }

    public void UpSkillPoints()
    {
        int choose = 0;
        do
        {
            Console.WriteLine("Очки характеристик: " + this.Skillpoints + "\nОчки силы: " + this.Strength + "\nОчки ловкости: " + this.Agility);
            Console.WriteLine("1. Вкачать силу\n2. Вкачать ловкость\n3. Назад");
            choose = Convert.ToInt32(Console.ReadLine());
            if (choose == 1 && this.Skillpoints > 0)
            {
                this.Strength += 1;
                this.Skillpoints -= 1;
            }
            else if (choose == 2 && this.Skillpoints > 0)
            {
                this.Agility += 1;
                this.Skillpoints -= 1;
            }
        } while (choose != 3);
        checkALL();
    }
}
