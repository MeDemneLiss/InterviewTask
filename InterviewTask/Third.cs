using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewTask
{
    internal class Third
    {
        static void Main()
        {
            string first = Console.ReadLine();
            int num = Convert.ToInt32(first);
            string[] data1 = Console.ReadLine().Split(new char[] { ' ' });
            string[] data2 = Console.ReadLine().Split(new char[] { ' ' });
            int[] availableSequence = new int[num];
            int[] winSequence = new int[num];
            string result = "NO";
            int firstNot = 0;
            int finishNot = 0;
            for (int i = 0; i < data1.Length; i++)
            {
                availableSequence[i] = Convert.ToInt32(data1[i]);
                winSequence[i] = Convert.ToInt32(data2[i]);
            }
            if (availableSequence[num - 1] == winSequence[num - 1] && availableSequence[0] == winSequence[0])
            {
                for (int i = 0; i < availableSequence.Length; i++)
                {
                    if (availableSequence[i] != winSequence[i])
                    {
                        firstNot = i;
                        break;
                    }
                }
                for (int i = 0; i < availableSequence.Length; i++)
                {
                    if (availableSequence[i] != winSequence[i])
                    {
                        finishNot = i;
                    }
                }
                if ((firstNot != 0) && (finishNot != 0) && (firstNot != finishNot))
                {
                    for (int i = firstNot; i <= finishNot; i++)
                    {
                        for (int j = firstNot; j < finishNot; j++)
                        {
                            if (availableSequence[j] > availableSequence[j + 1])
                            {
                                int x = availableSequence[j];
                                availableSequence[j] = availableSequence[j + 1];
                                availableSequence[j + 1] = x;
                            }
                        }
                    }
                }
                for (int i = 0; i < availableSequence.Length; i++)
                {
                    if (availableSequence[i] == winSequence[i])
                    {
                        result = "YES";
                    }
                    else
                    {
                        result = "NO";
                        break;
                    }
                }
            }
            Console.WriteLine(result);
        }
    }
}
