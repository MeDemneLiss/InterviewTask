using System;

namespace InterviewTask
{
    internal class Fourth
    {
        static void Main()
        {
            Console.Write("N M:");
            string[] data1 = Console.ReadLine().Split(' ');
            int n = Convert.ToInt32(data1[0]);              // how much money to snatch
            int m = Convert.ToInt32(data1[1]);              // count of nominals
            int m_count = m * 2;
            int[] bank = new int[m * 2];
            int[] john = { };
            Console.Write("Nominals:");
            string[] data2 = Console.ReadLine().Split(' ');
            for (int i = 0; i < m; i++)
            {
                int nom = Convert.ToInt32(data2[i]);
                bank[(i * 2)] = nom;
                bank[(i * 2) + 1] = nom;
            }
            int cur_sum = 0;
            for (int i = 0; i < m * 2; i++)
            {
                int res = remove_mn(bank, john, i, cur_sum, n);
                if (res == 0)
                {
                    return;
                }
            }
            Console.WriteLine("-1");
            return;
        }
                
            public static int remove_mn(int[] bank, int[] john, int mn_n, int cur_sum, int n)
            {
                int[] int_bank = new int[bank.Length - 1];
                int[] int_john = new int[john.Length + 1];
                int nom = 0;
                int bank_n = 0;
                for (int i = 0; i < bank.Length; i++)
                { // remove from bank
                    if (i != mn_n)
                    {
                        int_bank[bank_n] = bank[i];
                        bank_n = bank_n + 1;
                    }
                    else
                    {
                        nom = bank[i];
                    }
                }
                for (int i = 0; i < john.Length; i++)
                { // move to john
                    int_john[i] = john[i];
                }
                int_john[john.Length] = nom;
                cur_sum = cur_sum + nom;
                if (cur_sum > n)
                {
                    return (-1);
                }
                if (cur_sum == n)
                {
                    Console.WriteLine(int_john.Length);
                    for (int i = 0; i < int_john.Length; i++)
                    {
                        Console.Write(int_john[i]);
                        Console.Write(' ');
                    }
                    Console.WriteLine();
                    return (0);
                }
                for (int num = 0; num < int_bank.Length; num++)
                {
                    int res = remove_mn(int_bank, int_john, num, cur_sum, n);
                    if (res == 0)
                    {
                        return (0);
                    }
                }
                return (-1);
            }
        
    }
}
