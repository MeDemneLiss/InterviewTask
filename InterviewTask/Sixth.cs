using System;

namespace InterviewTask
{
    internal class Sixth
    {
        static void Main()
        {
            string[] data1 = Console.ReadLine().Split(new char[] { ' ' });
            int dyx = Convert.ToInt32(data1[0]);
            int num = Convert.ToInt32(data1[1]);
            int[,] ints = new int[dyx, dyx + 1];
            int[,] qustion = new int[num, 3];
            for (int j = 0; j < dyx; j++)
            {
                for (int k = 0; k < dyx; k++)
                {
                    if (k == j) { ints[j, k]++; }
                }
                ints[j, dyx] = 1;
            }
            for (int i = 0; i < num; i++)
            {
                string[] data2 = Console.ReadLine().Split(new char[] { ' ' });
                for (int j = 0; j < data2.Length; j++)
                {
                    qustion[i, j] = Convert.ToInt32(data2[j]);
                }
            }
            for (int f = 0; f < num; f++)
            {
                if (qustion[f, 0] == 1)
                {

                    if (ints[qustion[f, 1] - 1, qustion[f, 2] - 1] != 1)
                    {
                        ints[qustion[f, 1] - 1, dyx]++;
                        ints[qustion[f, 2] - 1, dyx]++;

                        for (int k = 0; k < dyx; k++)
                        {
                            if (qustion[f, 1] - 1 != k)
                            {
                                if (ints[qustion[f, 1] - 1, k] == 1)
                                {
                                    ints[k, qustion[f, 1] - 1] = 1;
                                    ints[k, dyx]++;
                                    ints[qustion[f, 2] - 1, k] = 1;
                                }
                            }
                            if (qustion[f, 2] - 1 != k)
                            {
                                if (ints[qustion[f, 2] - 1, k] == 1)
                                {
                                    ints[k, qustion[f, 2] - 1] = 1;
                                    ints[k, dyx]++;
                                    ints[qustion[f, 1] - 1, k] = 1;
                                }
                            }
                        }
                        ints[qustion[f, 1] - 1, qustion[f, 2] - 1] = 1;
                        ints[qustion[f, 2] - 1, qustion[f, 1] - 1] = 1;
                    }

                }
                if (qustion[f, 0] == 2)
                {
                    if (ints[qustion[f, 1] - 1, qustion[f, 2] - 1] == 1)
                    {
                        Console.WriteLine("YES");
                    }
                    else
                    {
                        Console.WriteLine("NO");
                    }
                }
                if (qustion[f, 0] == 3)
                {
                    Console.WriteLine(ints[qustion[f, 1] - 1, dyx]);
                }
            }
        }
    }
}
