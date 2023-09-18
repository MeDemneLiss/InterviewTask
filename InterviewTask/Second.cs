using System;

namespace InterviewTask
{
    internal class Second
    {
        static void Main()
        {
            string firstStering = Console.ReadLine();
            int maxWorlds = 0;
            do
            {
                int indexS = firstStering.IndexOf('s');
                if (indexS == -1)
                { break; }
                firstStering = firstStering.Remove(indexS, 1);
                int indexH = firstStering.IndexOf('h');
                if (indexH == -1) { break; }
                int indexE = firstStering.IndexOf('e');
                if (indexE == -1) { break; }
                firstStering = firstStering.Remove(indexE, 1);
                int indexR = firstStering.IndexOf('r');
                if (indexR == -1) { break; }
                firstStering = firstStering.Remove(indexR, 1);
                int indexI = firstStering.IndexOf('i');
                if (indexI == -1) { break; }
                firstStering = firstStering.Remove(indexI, 1);
                int indexF = firstStering.IndexOf('f');
                if (indexF == -1)
                { break; }
                firstStering = firstStering.Remove(indexF, 1);
                int index2F = firstStering.IndexOf('f');
                if (index2F == -1) { break; }
                firstStering = firstStering.Remove(index2F, 1);
                maxWorlds++;

            } while (firstStering != "");
            Console.WriteLine(maxWorlds);
        }
    }
}
