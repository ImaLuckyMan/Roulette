using System;
using System.Media;

namespace Roulette
{
    public class Game
    {
        static void Main()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Random ran = new Random();
            var r = new Random();
            string[] color = { "Red", "Black" };
            string choice;
            int attempts = 0;
            int bet;
            int money = 500;

            while (money != 0)
            {
                Console.WriteLine("Money:$" + money + " Attempts: " + attempts);
                Console.WriteLine("Type in any off the following letters below:");
                Console.WriteLine("a.Even    b.Odd    c.1 to 18    d.19 to 36");
                Console.WriteLine("e.Red     f.Black  g.1st 12     h.2nd 12");
                Console.WriteLine("i.3rd 12");
                choice = (Console.ReadLine());

                //guess verifier
                choice.ToLower();
                bool check = choice == "a" || choice == "b" || choice == "c" || choice == "d" || choice == "e" || choice == "f" || choice == "g" || choice == "h" || choice == "i";
                if (check == false)
                {
                    Console.WriteLine("You did not enter the correct input value (even/odd), Please try again!");
                    Console.ReadKey();
                    Console.Clear();
                    continue;
                }
                else
                {
                bet:
                    Console.WriteLine("Enter an amount to bet");
                    bet = Convert.ToInt32(Console.ReadLine());
                    //bet verifier
                    if (bet > money)
                    {
                        Console.WriteLine("You dont have enough money!");
                        Console.WriteLine("Press enter to try again.");
                        Console.ReadKey();
                        goto bet;
                    }
                    else
                    {
                        money -= bet;
                        int roll = ran.Next(0, 37);
                        string ranColor = color[r.Next(color.Length)];
                        bool even = roll % 2 == 0;
                        if ((((choice == "a") && (even == true))) || (((choice == "b") && (even == false))) || ((choice == "e") && (ranColor == "Red") || (choice == "f") && (ranColor == "Black")))
                        {
                            Console.WriteLine("The roulette rolled: " + ranColor + " " + roll);
                            Console.WriteLine("You won! +$" + bet * 2 + "!");
                            Console.WriteLine("<Press enter to continue>");
                            money += bet * 2;
                            attempts += 1;
                            Console.ReadKey();
                        }
                        else if ((choice == "c") && ((roll > 0) && (roll < 19)))
                        {
                            Console.WriteLine("The roulette rolled: " + ranColor + " " + roll);
                            Console.WriteLine("You won! +$" + bet * 2 + "!");
                            Console.WriteLine("<Press enter to continue>");
                            money += bet * 2;
                            attempts += 1;
                            Console.ReadKey();
                        }
                        else if ((choice == "d") && ((roll > 18) && (roll < 37)))
                        {
                            Console.WriteLine("The roulette rolled: " + ranColor + " " + roll);
                            Console.WriteLine("You won! +$" + bet * 2 + "!");
                            Console.WriteLine("<Press enter to continue>");
                            money += bet * 2;
                            attempts += 1;
                            Console.ReadKey();
                        }
                        else if ((choice == "g") && (roll > 0 && roll < 13) || (choice == "h") && (roll > 12 && roll < 25) || (choice == "i") && (roll > 24 && roll < 37))
                        {
                            Console.WriteLine("The roulette rolled: " + ranColor + " " + roll);
                            Console.WriteLine("You won! +$" + bet * 2 + "!");
                            Console.WriteLine("<Press enter to continue>");
                            money += bet * 3;
                            attempts += 1;
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("The roulette rolled: " + ranColor + " " + roll);
                            Console.WriteLine("You lost! -$" + bet + "!");
                            Console.WriteLine("<Press enter to continue>");
                            attempts += 1;
                            Console.ReadKey();
                            if (money == 0)
                            {
                                Console.WriteLine("You are out of money.");
                                Console.WriteLine("<Press enter to continue>");
                                Console.ReadKey();
                            }
                        }
                    }
                }
                Console.Clear();
            }
        }
    }
}
