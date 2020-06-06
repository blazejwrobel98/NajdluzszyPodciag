using System;
using System.Collections.Generic;
using System.Linq;
class Program
{
    public static void Main()
    {
        Console.Write("Podaj ilość liczb w ciągu: ");
        int counter = GetInt();
        Console.Write("\n");
        var int_input = new List<int>();
        for (int i = 0; i < counter; i++)
        {
            Console.Write($"Podaj {i + 1} liczbę: ");
            int_input.Add(GetInt());
        }
        int[] array_input = int_input.ToArray();
        int n = array_input.Length;
        int[] result = LIS(array_input, n);
        foreach(int el in result)
        {
            Console.Write(el + " ");
        }
    }
    static int[] LIS(int[] arr, int n)
    {
        int[] thelowest = GetLowest(arr, n); //Pobieram punkty gdzie funkcja ma startować
        List<int[]> foundsubstrings = new List<int[]>();
        foreach (int el in thelowest)
        {
            foundsubstrings.Add(FindSub(arr, el, n));
        }
        List<int> subs_length = new List<int>();
        int x = foundsubstrings.Count;
        for (int y = 0; y < x; y++)
        {
            subs_length.Add(foundsubstrings[y].Length);
        }
        int[] subs_len = subs_length.ToArray();
        int v = subs_len.Max();
        int pos = 0;
        for(int b = 0; b < subs_len.Length; b++)
        {
            if (subs_len[b] == v)
            {
                pos = b;
                break;
            }
        }
        return foundsubstrings[pos];

    }
    static int[] FindSub(int[] arr, int pos, int n)
    {
        List<int> temp = new List<int>();
        for (int i = pos; i < n; i++)
        {
            if (i + 1 < n)
            {
                if (arr[i] < arr[i + 1])
                {
                    temp.Add(arr[i]);
                }
            }
            else if(i+1==n)
            {
                if (arr[n-2] < arr[n-1])
                {
                    temp.Add(arr[n-1]);
                }
            }
            else
            {
                break;
            }
        }
        int[] output = temp.ToArray();
        return output;
    }
    static int[] GetLowest(int[] arr, int n)
    {
        var low_position = new List<int>();
        int min = arr[0];
        //Szukam wartości minimalnej
        for (int i = 0; i < n; i++)
        {
            if (arr[i] < min)
            {
                min = arr[i];
            }
        }
        //Szukam powtórzeń wartości minimalnej np {1,2,3,1}
        for (int i = 0; i < n; i++)
        {
            if (arr[i] == min)
            {
                low_position.Add(i);
            }
        }
        //Zwracam pozycje najniższych wartości
        int[] low_arr = low_position.ToArray();
        return low_arr;
    }
    static int GetInt()
    {
        while (true)
        {
            string x = Console.ReadLine();
            if (int.TryParse(x, out int y))
            {
                return y;
            }
            else
            {
                Console.WriteLine("Błędne dane, podaj liczbę całkowitą");
            }
        }
    }
}