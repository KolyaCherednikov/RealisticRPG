using System;
public class Enemy
{
    int Health; // Здоровье врага
    int Damage; // Урон врага
    int Level; // Уровень врага
    int ExpYouTake; // Опыт который получит игрок
    String name; // Имя врага
    Random rnd = new Random(); // Рандомное число
    public Enemy()
    {
        this.Health = 50;
        this.Damage = 2;
        this.ExpYouTake = 5076;
        this.name = "Волк";
    }

    public void TakeDamage(int Damage) => this.Health -= Damage; // Получить урон

    public void DoDamage(Player p) // Нанести урон
    {
        int rand = rnd.Next(0, 2);
        if (rand == 0)
            p.TakeDamage(this.Damage);
        if (rand == 1)
        {
            Console.WriteLine("АУФ");
            p.TakeDamage(this.Damage*2);
        }
    }

    public int getHealth() // Отдать здоровье
    {
        return this.Health;
    }

    public String getName() // Отдать имя
    {
        return this.name;
    }

    public int getExpYouTake() // Отдать опыт который получит игрок
    {
        return this.ExpYouTake;
    }
}
