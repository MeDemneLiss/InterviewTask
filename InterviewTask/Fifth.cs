using System;

namespace Five_Quest
{
    internal class Program
    {
        static int Num_shtat(int[] shtat, int[,] data, int start)
        {
            int num = 1;
            shtat[data[start, 0]] = num; 
            shtat[data[start, 1]] = num;
            for (int i = start; i < data.GetLength(0); i++)
            {
                if (data[i, 0] != 0 && data[i, 1] != 0)
                {
                    if (shtat[data[i, 0]] == 0 && shtat[data[i, 0]] == 0)
                    {
                        num++;
                        shtat[data[i, 0]] = num;
                        shtat[data[i, 1]] = num;
                    }
                    else if (shtat[data[i, 0]] == 0)
                    {
                        shtat[data[i, 0]] = shtat[data[i, 1]];
                    }
                    else
                    {
                        shtat[data[i, 1]] = shtat[data[i, 0]];
                    }
                }
            }
            return num;
        }
        //Всю енту херню надо заменить на быструю сортировку а то нихуя в 3 секунды не уложиться
        static void Swap(ref int e1, ref int e2)
        {
            var temp = e1;
            e1 = e2;
            e2 = temp;
        }
        static void ShakerSort(ref int[,] array,in int n)
        {
            for (var i = 0; i < n / 2; i++)
            {
                var swapFlag = false;
                //проход слева направо
                for (var j = i; j < n - i - 1; j++)
                {
                    if (array[j,0] > array[j + 1,0])
                    {
                        Swap(ref array[j,0], ref array[j + 1,0]);
                        Swap(ref array[j, 1], ref array[j + 1, 1]);
                        Swap(ref array[j, 2], ref array[j + 1, 2]);
                        swapFlag = true;
                    }
                }

                //проход справа налево
                for (var j = n - 2 - i; j > i; j--)
                {
                    if (array[j - 1,0] > array[j,0])
                    {
                        Swap(ref array[j - 1,0], ref array[j,0]);
                        Swap(ref array[j - 1, 1], ref array[j, 1]);
                        Swap(ref array[j - 1, 2], ref array[j, 2]);
                        swapFlag = true;
                    }
                }

                //если обменов не было выходим
                if (!swapFlag)
                {
                    break;
                }
            }
        }
        //вот до сюда заменить

        static int Sort_Data(ref int[,] data, int m)
        {
            for (int i = 0; i < m; i++)
            {
                if (data[i, 0]> data[i, 1]){
                    int temp = data[i, 0];
                    data[i,0] = data[i, 1];
                    data[i, 1] = temp;
                }
                if (data[i, 1] == data[i, 0])
                {
                    data[i, 0] = 0;
                    data[i, 1] = 0;
                    data[i, 2] = 0;
                }
            }
            ShakerSort(ref data, m);
            int num_road = m;
            for (int i = 0; i < m-1; i++)
            {
                if((data[i, 0] == data[i+1, 0]) && (data[i, 1] == data[i+1, 1]))
                {
                    if (data[i, 2]> data[i+1, 2])
                    {
                        data[i + 1, 0] = 0;
                        data[i + 1, 1] = 0;
                        data[i + 1, 2] = 0;
                    }
                    else
                    {
                        data[i, 0] = 0;
                        data[i, 1] = 0;
                        data[i, 2] = 0;
                        i--;
                    }
                    num_road--;
                    ShakerSort(ref data, m);
                }
            }
            return num_road;
        }

        //Нужно доделать обработку города - штата
        static void Main()
        {
            string[] data = Console.ReadLine().Split(' ');
            int n = int.Parse(data[0]);     //count sity
            int m = int.Parse(data[1]);     //count road
            int[] shtat = new int[n+1];
            int[,] road = new int[m,3];
            for(int i = 0; i< m; i++)
            {
                string[] vuw = Console.ReadLine().Split(' ');
                road[i, 0] = int.Parse(vuw[0]);
                road[i, 1] = int.Parse(vuw[1]);
                road[i, 2] = int.Parse(vuw[2]);
            }
            int num_road = Sort_Data(ref road, m);
            for(int i = 0;i< m;i++) 
            { 
                for(int j = 0;j< 3;j++) 
                {
                    Console.Write(road[i,j]+ " "); 
                }
                Console.WriteLine();
            }
            Console.WriteLine(Num_shtat(shtat, road, m-num_road));
            int num_stat = Num_shtat(shtat, road, m - num_road);
            int l = m - num_road;
            while (num_road > n - 1)
            {
                int temp1 = road[l, 0];
                int temp2 = road[l, 1];
                int temp3 = road[l, 2]; 
                road[l, 0] = 0;
                road[l, 1] = 0; 
                road[l, 2] = 0;
                if(num_stat == Num_shtat(shtat, road, m - num_road))
                {
                    num_road = Sort_Data(ref road, m);
                }
                else
                {
                    road[l, 0] = temp1;
                    road[l, 1] = temp2;
                    road[l, 2] = temp3;
                }
                l++;
            }
            int max = 108;
            for(int i = m - num_road; i < m; i++) 
            { 
                if (road[i, 2]<= max) max = road[i, 2] -1;
            }
            Console.WriteLine(max);
            Console.ReadKey();
        }
    }
}
