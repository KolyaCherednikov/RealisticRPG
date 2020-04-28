using System;
public class Item
{
    String name; // Имя оружия
    int Damage; // Урон оружия 
    int Level; // Уровень оружия
    int CritChanse; // Критический шанс оружия
    public Item(String n, int d, int l, int cc) // Конструктор
    {
        this.name = n;
        this.Damage = d;
        this.Level = l;
        this.CritChanse = cc;
    }
    
    public int getDamage() // Отдать урон оружия
    {
        return this.Damage;
    }

    public String getName() // Отдать имя оружия
    {
        return this.name;
    }

    public void setName() // Установить имя для оружия
    {
        Console.WriteLine("Введите название оружия");
        String n = Convert.ToString(Console.ReadLine());
        this.name = n;
    }

    public void Upgrade() // Улучшить оружие
    {
        this.Damage *= 2;
    }

    public int getCritChance() // Отдать критический шанс оружия
    {
        return CritChanse;
    }

    public String toString() // Отдать всю информацию про оружие
    {
        return getName()+" Урон: "+ getDamage();
    }
}
