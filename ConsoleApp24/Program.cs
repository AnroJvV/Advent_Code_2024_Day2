using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("==========================================Data Set==================================");
        string filePath = "--File Path--";
        List<int[]> numberLists = ReadNumbersFromFile(filePath);

        foreach (var numberList in numberLists)
        {
            Console.WriteLine(string.Join(" ", numberList));
        }

        Console.WriteLine("===================================================================================");
        Console.ReadLine();
        int result = ProcessLines(numberLists);

        Console.WriteLine("Total amount of safe levels: " + result);
    }

    public static List<int[]> ReadNumbersFromFile(string filePath)
    {
        List<int[]> numberLists = new List<int[]>();

        try
        {           
            string[] lines = File.ReadAllLines(filePath);

            foreach (var line in lines)
            {                
                string[] numberStrings = line.Split(' ');
                int[] numbers = Array.ConvertAll(numberStrings, int.Parse);
                numberLists.Add(numbers);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error reading file: {ex.Message}");
        }

        return numberLists;
    }

    public static int ProcessLines(List<int[]> numberLists)
    {
        int result = 0;

        foreach (var numberList in numberLists)
        {
            List<string> totalLevel = new List<string>();
            for (int i = 0; i < numberList.Length; i++)
            {
                if (i == numberList.Length - 1)
                {
                    break;
                }
                else
                {
                    int currentNumber = numberList[i];
                    int nextNumber = numberList[i + 1];
                    int diff = currentNumber - nextNumber;

                    if (diff == 0)
                    {
                        totalLevel.Add("Same");
                    }
                    else if (diff > 0 && diff <= 3)
                    {
                        totalLevel.Add("Desc");
                    }
                    else if (diff < 0 && diff >= -3)
                    {
                        totalLevel.Add("Asc");
                    }
                    else
                    {
                        totalLevel.Add("Diff");
                    }
                }
            }

            int sameLevels = 0;

            for (int i = 0; i < totalLevel.Count; i++)
            {
                if (totalLevel.Contains("Same") || totalLevel.Contains("Diff"))
                {
                    break;  
                }
                if (i == totalLevel.Count - 1)
                {
                    if (sameLevels == totalLevel.Count - 1)
                    {
                        result++;
                    }
                    break;
                }
                else
                {
                    string currentLevel = totalLevel[i];
                    string nextLevel = totalLevel[i + 1];
                    if (currentLevel == nextLevel)
                    {
                        SameLevels++;
                    }
                }
            }
        }
        return result;
    }
}
