using System;
public class Battle
{
    Enemy e = new Enemy(); // Создать врага
    public void MainBattle(Player p) // Оснавная битва
	{
        do // Игрок и враг по очереди атакуют
        {
            if (p.getHealth() > 0)
            {
                Console.WriteLine("Ваше здоровье: "+ p.getHealth() + "\n" +"Здоровье "+e.getName()+": " + e.getHealth() + "\n"+"1-Удар\n2-Блок");
                int choose = Convert.ToInt32(Console.ReadLine());
                if (choose == 1)
                    p.DoDamage(e);
                else if (choose == 2)
                    p.DoBlock();
            }
            if (e.getHealth()>0)
                e.DoDamage(p);
        } while (e.getHealth() > 0 && p.getHealth() > 0);
        if (p.getHealth() <= 0)
        {
            Console.WriteLine("Вы умерли)) ");
            Environment.Exit(0);
        }
        else if (e.getHealth() <= 0)
        {
            Console.WriteLine("Вы убили монстра");
            p.ResiveExp(e.getExpYouTake());
        }
    }
}
