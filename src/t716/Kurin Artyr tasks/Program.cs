using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;


namespace TRPOtask1
{

    class Program
    {
        public static void Main(string[] args)
        {

            Animal();

            Console.ReadKey();
        }
        public static void Animal()
        {
            repeat:
            Console.WriteLine("Введите рандомное число (1-3)");
            int temp = int.Parse(Console.ReadLine());

            if (temp == 1)
            {
                Console.WriteLine("Surprise! You choice Pickachy\n");
                Name(1);
                Console.Clear();

            }
            if (temp == 2)
            {
                Console.WriteLine("Surprise! You choice Motya\n");
                Name(2);
                Console.Clear();

            }
            if (temp == 3)
            {
                Console.WriteLine("Surprise! You choice Anime\n");
                Name(3);
                Console.Clear();

            }
            if (temp != 1 || temp != 2 || temp != 3)
            {
                goto repeat;

            }
        }
        public static void Name(int temp)
        {
            string NAME = Console.ReadLine();
            Console.WriteLine("Нажмите любую клавишу для продолжения");
            Console.ReadKey();
            Console.Clear();
            switch (temp)
            {
                case 1: Console.WriteLine(temp + "\n I {0}", NAME); break;
                case 2: Console.WriteLine(temp + "\n I {0}", NAME); break;
                case 3: Console.WriteLine(temp + "\n I {0}", NAME); break;
            }
            Stats stats1 = new Stats(temp);
            while (true)
            {
                stats1.Info();
                stats1.Help();
                stats1.Progress();
                Console.Clear();
            }
        }
    }
}

class Stats
{
    public static bool IsOver = false;
    private int health;
    private int satiety;
    private int sleep;
    public Stats(int gType)
    {
        
        health = 50;
        satiety = 50;
        sleep = 50;
    }

    public int Progress()
    {
        Thread thread = new Thread(Info);
        thread.Start();

        int doing = int.Parse(Console.ReadLine());
        if (doing == 1) // пожрать
        {

            health += 50;
            satiety += 20;
            sleep -= 20;
            if (health > 50)
            {
                health = 50;
            }
            if (satiety > 50)
            {
                satiety = 50;
            }
        }
        if (doing == 2) // поспать
        {

            sleep += 50;
            satiety -= 20;
            if (sleep > 50)
            {
                sleep = 50;
            }
        }
        if (doing == 3) // тренеровочка
        {

            health += 50;
            sleep -= 25;
            satiety -= 25;
            if (health > 50)
            {
                health = 50;
            }
        }

        if (doing == 9)
        {
            Console.WriteLine("Ну ты это, заходи, если что");
            Environment.Exit(0);
        }
        Console.Clear();
        return doing;
    }

    public void Info()
    {
        while (true)
        {
            Console.WriteLine("\n Состояние ЖИВОТНОГО  \n Здоровье {0}\n Сытость {1}\n Усталость {2}  ", health, satiety, sleep);
            Help();
            Console.WriteLine("\n");
            System.Threading.Thread.Sleep(200);
            health -= 1;
            satiety -= 1;
            sleep -= 1;
            if (sleep == 0 || health == 0 || satiety == 0 || sleep < 0 || health < 0 || satiety < 0)
            {
                Console.Clear();
                Console.WriteLine("#      #  ######  #     #   #####  ##### ######  ####   ######  ######  ####      ");
                Console.WriteLine(" #    #  #      # #     #  #     # #  #  #       #   #  #      #      # #   #     ");
                Console.WriteLine("  #  #   #      # #     #  #     # # #   #       #    # #      #      # #    #    ");
                Console.WriteLine("   #     #      # #     #  ####### ##    ####    #   #  ####   ######## #   #     ");
                Console.WriteLine("   #     #      # #     #  #     # # #   #       #  #   #      #      # #  #      ");
                Console.WriteLine("   #      #####    #####   #     # #  #  ######  ###    ###### #      # ###       ");
                break;
            }
            Console.Clear();
            Thread thread = new Thread(Info);
            thread.Abort();
            Progress();
        }
    }
    public void Help()
    {
        Console.WriteLine("\n 1 - покормить \n 2 - спать \n 3 - тренероваться \n 9 - Выход \n\n Ухвживать за ЖИВОТЫМ \n(номер нужного действия + Enter)");
    }
}


