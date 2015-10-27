using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemons
{
    class Program
    {
        static void Main(string[] args)
        {
            int n,k=0;
            string s;
            string NamePok=null;
            int i = 1;
            int t = 0;
            int H = 0;
            int Damage = 0;
            int Spell = 0;
            int fear = 0;
            Console.WriteLine("Choose your pokemon");
            do
            {
                k = 0;
                Console.WriteLine("Player 1 input number from 1 to 5");
                s = Console.ReadLine();
                n = Convert.ToByte(s);
                switch (n)
                {
                    case 1:
                        H = 1000; Damage = 50; Spell = 0;
                        NamePok = "Antonyuk";
                        Console.WriteLine("You  choose {0}", NamePok);
                        break;
                    case 2:
                        H = 800; Damage = 40; Spell = 0;
                        NamePok = "Artem";
                        Console.WriteLine("You choose {0}", NamePok);
                        break;
                    case 3:
                        H = 750; Damage = 60; Spell = 0; 
                        NamePok = "Morozov";
                        Console.WriteLine("You choose {0}", NamePok);
                        break;
                    case 4:
                        H = 10; Damage = 5; Spell = 0; 
                        NamePok = "Bilodid";
                        Console.WriteLine("You choose {0}", NamePok);
                        break;
                    case 5:
                        H = 500; Damage = 500; Spell = 0;
                        NamePok = "Pasha";
                        Console.WriteLine("You choose {0}", NamePok);
                        break;
                    default:
                        Console.WriteLine("Try again");
                        k = 1;
                        break;
                }
            }
            while (k == 1);
            Player1 pl1 = new Player1(H, Damage, Spell,NamePok);
            do
            {
                k = 0;
                Console.WriteLine("Player 2 input nubmber from 1 to 5");
                s = Console.ReadLine();
                n = Convert.ToByte(s);
                switch (n)
                {
                    case 1:
                        H = 1000; Damage = 30; Spell = 6;
                        NamePok = "Antonyuk";
                        Console.WriteLine("You  choose {0}", NamePok);
                        break;
                    case 2:
                        H = 800; Damage = 40; Spell = 2; 
                        NamePok = "Artem";
                        Console.WriteLine("You choose {0}", NamePok);
                        break;
                    case 3:
                        H = 750; Damage = 60; Spell = 5; 
                        NamePok = "Morozov";
                        Console.WriteLine("You choose {0}", NamePok);
                        break;
                    case 4:
                        H = 10; Damage = 5; Spell = 1; 
                        NamePok = "Bilodid";
                        Console.WriteLine("You choose {0}", NamePok);
                        break;
                    case 5:
                        H = 500; Damage = 500; Spell = 10; 
                        NamePok = "Pasha";
                        Console.WriteLine("You choose {0}", NamePok);
                        break;
                    default:
                        Console.WriteLine("Try again");
                        k = 1;
                        break;
                }
            }
            while (k == 1);

            Player2 pl2 = new Player2(H, Damage, Spell, NamePok);
            do
            {
                Console.WriteLine("Turn {0}",i);
                if (t % 2 == 0)
                {
                    Console.WriteLine("Player1 Press any to key for Hit");
                    Console.ReadLine();
                    Console.WriteLine("Your HP {0} ",pl1.HP1);
                    Console.WriteLine();
                    pl1.Hit(ref pl2.HP2, ref pl1.damage);
                    pl1.Krit(ref pl2.HP2);
                    pl1.Miss(ref pl2.HP2);
                    pl1.Spel(ref pl2.HP2, ref pl1.Spell);
                }
                else
                {
                    Console.WriteLine("Player2 Press any to key for Hit");
                    Console.ReadLine();
                    Console.WriteLine("Your HP {0} ", pl2.HP2);
                    Console.WriteLine();
                    pl2.Hit(ref pl1.HP1, ref pl2.damage);
                    pl2.Krit(ref pl1.HP1);
                    pl2.Miss(ref pl1.HP1);
                    pl1.Spel(ref pl1.HP1, ref pl2.Spell);
                }
                i++; t++;
            } while ((pl1.HP1 > 0) && (pl2.HP2 > 0));
            Console.WriteLine("Game Over");
        }

    }
    class Player1
    {
        public string NamePokemons;
        public int HP1;
        public int damage;
        public int Spell;
        public int z;
        public int m;
        public int EnemyHP1;
        public string koefProseraniya;
        public int Health = 20;
        public Player1(int HP1,int damage,int Spell,string NamePokemons)
        {
            this.HP1 = HP1;
            this.damage = damage;
            this.Spell = Spell;
            this.NamePokemons = NamePokemons;
        }
        public void Hit(ref int EnemyHP1, ref int damage)
        {
           EnemyHP1-= damage;
        }
        public void Krit( ref int EnemyHP1,string koefProseraniya="Tu proigral")
        {
            if (damage >= HP1 / 2)
            {
                EnemyHP1 -= damage;
                Console.WriteLine("Player1 {0}",koefProseraniya);
                Environment.Exit(0);
            }
        }
        public void  Miss(ref int EnemyHP1)
        {
            Random r = new Random();
            z = r.Next(0, 2);
            if(z==1) Console.WriteLine("Ta nu tebya naher!(Silniy udar)");
            EnemyHP1 += Health*z;
        }
        public void Spel(ref int EnemyHP1,ref int Spell)
        {
            Random n = new Random();
            m = n.Next(0, 3);
            if (m == 1) Console.WriteLine("Dop uron!(Spell)");
            EnemyHP1 -= Spell;
        }
    }
    class Player2
    {
        public string NamePokemons;
        public int HP2;
        public int damage;
        public int Spell;
        public int EnemyHP2;
        public int z;
        public int m;
        public string koefProseraniya;
        public int Health = 20;
        public Player2(int HP2, int damage, int Spell, string NamePokemons)
        {
            this.HP2 = HP2;
            this.damage = damage;
            this.Spell = Spell;
            this.NamePokemons = NamePokemons;
        }
        public void Hit(ref int EnemyHP2,ref int damage)
        {
            EnemyHP2 -= damage;
        }
        public void Krit(ref int EnemyHP2, string koefProseraniya = "Tu proigral")
        {
            if (damage >= HP2 / 2)
            {
                EnemyHP2 -= damage;
                Console.WriteLine("Player2 {0}", koefProseraniya);
                Environment.Exit(0);
            }
        }
        public void Miss(ref int EnemeHP2)
        {
            Random r = new Random();
            z = r.Next(0, 2);
            if (z == 1) Console.WriteLine("Ta nu tebya naher!(Silniy udar)");
            EnemyHP2 += Health*z;
        }
        public void Spel(ref int EnemyHP2, ref int Spell)
        {
            Random n = new Random();
            m = n.Next(0, 3);
            if (m == 1) Console.WriteLine("Dop uron!(Spell)");
            EnemyHP2 -= Spell*m;
        }
    }
}
