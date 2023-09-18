using System;

namespace InterviewTask
{
    internal class First
    {
        static void Main()
        {
            string firstStering = Console.ReadLine();
            string secondStering = Console.ReadLine();
            string[] data = firstStering.Split(new char[] { ' ' });
            string[] prices = secondStering.Split(new char[] { ' ' });
            int quantity = Convert.ToInt32(data[0]);
            int money = Convert.ToInt32(data[1]);
            int dearest = 0;
            int thisPrice = 0;
            for (int i = 0; i < quantity; i++)
            {
                thisPrice = Convert.ToInt32(prices[i]);
                if (money >= thisPrice)
                {
                    if (dearest < thisPrice) { dearest = thisPrice; }
                }
            }
            Console.WriteLine(dearest);
        }
    }
}
