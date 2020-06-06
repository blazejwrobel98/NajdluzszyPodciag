using System;
using System.Collections.Generic;

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
        LIS(array_input, n);
    }
    static void LIS(int[] arr, int n)
    {
        int[] lis_arr = new int[n];
        for (int i = 0; i < n; i++)
        {
            lis_arr[i] = 0;
        }
        int[] prevIndices = new int[n];
        for (int i = 0; i < n; i++)
        {
            prevIndices[i] = -1;
        }
        int len = 1;
        for (int i = 1; i < n; i++)
        {
            if (arr[i] < arr[lis_arr[0]])
            {
                lis_arr[0] = i;
            }
            else if (arr[i] > arr[lis_arr[len - 1]])
            {
                prevIndices[i] = lis_arr[len - 1];
                lis_arr[len++] = i;
            }
            else
            {
                int pos = GetCeilIndex(arr, lis_arr, -1, len - 1, arr[i]);

                prevIndices[i] = lis_arr[pos - 1];
                lis_arr[pos] = i;
            }
        }
        Console.WriteLine("Podany ciąg to:");
        foreach (int el in arr)
        {
            Console.Write(el + " ");
        }
        Console.Write("\n");
        Console.WriteLine("Najdłuższy podciąg rosnący to:");
        string output = "";
        for (int i = lis_arr[len - 1]; i >= 0; i = prevIndices[i])
        {
            output += (arr[i] + " ");
        }
        string[] output_arr = output.Split(' ');
        for (int x = (output_arr.Length) - 1; x >= 0; x--)
        {
            Console.Write(output_arr[x] + " ");
        }
        Console.Write("\n");
    }
    static int GetCeilIndex(int[] arr, int[] T, int l, int r, int key)
    {
        while (r - l > 1)
        {
            int m = l + (r - l) / 2;
            if (arr[T[m]] >= key)
                r = m;
            else
                l = m;
        }
        return r;
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