using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heigan_Dance
{
    class Program
    {
        static void Main(string[] args)
        {

            double damage = double.Parse(Console.ReadLine());
            bool[,] array = new bool[15,15];
            string result = "";
            double heigan_health = 3000000;
            double player_health = 18500;
            int a = 7, b = 7;
            bool cloud = false;
            bool flag = false;
            string[] spell = new string[5];
            while (heigan_health>0&&player_health>0)
            {
                spell = Console.ReadLine().Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries).ToArray();
                int m = int.Parse(spell[1]);
                int n = int.Parse(spell[2]);
                heigan_health = heigan_health - damage;
                if (heigan_health <= 0)
                {
                    if (array[a,b]&&cloud){ player_health = player_health - 3500;
                        result = "Plague Cloud";
                    }
                    break;
                    
                }
                if (array[a, b] && cloud) {player_health = player_health - 3500;if (player_health <= 0) {result = "Plague Cloud";break;}}
                
                switch (spell[0])
                {
                    case "Cloud":
                    {
                        if (cloud)
                        {
                            for (int i = 0; i < 15; i++)
                            {
                                for (int j = 0; j < 15; j++)
                                {
                                    array[i, j] = false;
                                }
                            }
                        }
                        flag = true;
                        cloud = true;
                        if (m - 1 >= 0 && n - 1 >= 0 && m - 1 <= 14 && n - 1 <= 14) array[m - 1, n - 1] = true;
                        if (m - 1 >= 0 && n >= 0 & m - 1 <= 14 && n <= 14) array[m - 1, n] = true;
                        if (m - 1 >= 0 && n + 1 <= 14 && m - 1 <= 14 && n + 1 >= 0) array[m - 1, n + 1] = true;
                        if (n - 1 >= 0 && m >= 0 && n - 1 <= 14 && m <= 14) array[m, n - 1] = true;
                        if (n >= 0 && m >= 0 && n <= 14 && m <= 14) array[m, n] = true;
                        if (n + 1 >= 0 && m >= 0 && n + 1 <= 14 && m <= 14) array[m, n + 1] = true;
                        if (m + 1 >= 0 && n - 1 >= 0 && m + 1 <= 14 && n - 1 <= 14) array[m + 1, n - 1] = true;
                        if (m + 1 >= 0 && n >= 0 && m + 1 <= 14 && n <= 14) array[m + 1, n] = true;
                        if (n + 1 >= 0 && m + 1 >= 0 && n + 1 <= 14 && m + 1 <= 14) array[m + 1, n + 1] = true;
                            if (array[a, b])
                        {
                            if (a - 1 >= 0 && array[a - 1, b] == false)
                            {
                                a--;

                            }
                            else if (b + 1 <= 14 && array[a, b + 1] == false)
                            {
                                b++;

                            }
                            else if (a + 1 <= 14 && array[a + 1, b] == false)
                            {
                                a++;

                            }
                            else if (b - 1 >= 0 && array[a, b - 1] == false)
                            {
                                b--;

                            }
                            else player_health = player_health - 3500;
                        }
                        if (player_health <= 0) result = "Plague Cloud";
                        break;
                    }
                    case "Eruption":
                    {
                        
                        if (cloud == false)
                        {
                            if (flag)
                            {
                                for (int i = 0; i < 15; i++)
                                {
                                    for (int j = 0; j < 15; j++)
                                    {
                                        array[i, j] = false;
                                    }
                                }
                                flag = false;
                            }
                        }
                        else
                        {
                            for (int i = 0; i < 15; i++)
                            {
                                for (int j = 0; j < 15; j++)
                                {
                                    array[i, j] = false;
                                }
                            }
                                cloud = false;
                        }
                        if(m-1>=0&&n-1>=0&&m-1<=14&&n-1<=14)array[m - 1, n - 1] = true;
                        if (m - 1 >= 0 &&n>=0&m-1<=14&&n<=14) array[m - 1, n] = true;
                        if (m - 1 >= 0 && n + 1 <= 14&&m-1<=14&&n+1>=0) array[m - 1, n + 1] = true;
                        if ( n - 1 >= 0&& m>=0 && n-1<=14 && m<=14) array[m, n - 1] = true;
                        if (n >= 0 && m >= 0 && n  <= 14 && m <= 14) array[m, n] = true;
                        if (n + 1 >= 0 && m >= 0 && n + 1 <= 14 && m <= 14) array[m, n + 1] = true;
                        if (m + 1 >= 0 && n-1>= 0 && m + 1 <= 14 && n-1 <= 14) array[m + 1, n - 1] = true;
                        if (m + 1 >= 0 && n >= 0 && m + 1 <= 14 && n <= 14) array[m + 1, n] = true;
                        if (n + 1 >= 0 && m+1 >= 0 && n + 1 <= 14 && m+1 <= 14) array[m + 1, n + 1] = true;
                        if (array[a, b])
                        {
                            if (a - 1 >= 0 && array[a - 1, b] == false)
                            {
                                a--;

                            }
                            else if (b + 1 <= 14 && array[a, b + 1] == false)
                            {
                                b++;

                            }
                            else if (a + 1 <= 14 && array[a + 1, b] == false)
                            {
                                a++;

                            }
                            else if (b - 1 >= 0 && array[a, b - 1] == false)
                            {
                                b--;

                            }
                            
                            else player_health = player_health - 6000;
                        }
                        
                         for (int i = 0; i < 15; i++)
                        {
                            for (int j = 0; j < 15; j++)
                            {
                                array[i, j] = false;
                            }
                        }
                        if (player_health <= 0) result = "Eruption";
                            break;
                    }
                        
                }
                
                if (player_health <= 0) break;
                /*Console.WriteLine(heigan_health+" "+player_health+" "+a+" "+b);*/
            }
            if (heigan_health <= 0)
            {
                Console.WriteLine("Heigan: Defeated!");
                if(player_health>0)Console.WriteLine("Player: " + player_health);
                else Console.WriteLine("Player: Killed by "+result);
            }
            else
            {
                Console.WriteLine("Heigan: "+ heigan_health.ToString("F2"));
                Console.WriteLine("Player: Killed by "+result);
            }
            Console.WriteLine("Final position: "+a+", "+b);
        }
    }
}
