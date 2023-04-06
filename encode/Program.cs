using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static string NicoCipher(string message, string key)
    {
        string input = key; //crazy
        char[] charArray = input.ToCharArray();
        Array.Sort(charArray);        //acryz
        string orderedString = new string(charArray);
        Console.WriteLine(orderedString);
        int[] numberArr = new int[orderedString.Length];
        for(int i = 0; i < orderedString.Length; i++)
        {
            for(int j = 0; j < orderedString.Length; j++)
            {
                if (charArray[i] == key[j])
                {
                    numberArr[j] = i+1;
                    break;
                }
            }
        }

        Dictionary<int,string> dictionary = new Dictionary<int,string>();
        for(int i = 0; i < numberArr.Length; i++)
        {
            dictionary.Add(numberArr[i], "");
        }
        int pointer = 0;
        int extra = message.Length % dictionary.Count;
        for(int i=0; i <message.Length/dictionary.Count; i++)
        {
            foreach(var Key in dictionary.Keys)
            {
                dictionary[Key] += message[pointer++];
            }
        }
        foreach (var Key in dictionary.Keys)
        {
            if (extra >0)
            {
                dictionary[Key] += message[pointer++];
            }
            else
            {
                dictionary[Key] += " ";
            }
            extra--;
        }
        SortedDictionary<int,string> alphabeticalDict = new SortedDictionary<int,string>(dictionary);

        string newString = "";
        for (int i = 0; i <= message.Length / dictionary.Count; i++)
        {
            foreach (var Key in alphabeticalDict.Keys)
            {
                newString+=alphabeticalDict[Key][i];
            }
        }
        
        return newString;
    }

    public static void Main()
    {
        Console.WriteLine(NicoCipher("mubashirhassan", "crazy")); // "bmusarhiahass n"
        //Console.WriteLine(NicoCipher("edabitisamazing", "matt")); // "deabtiismaaznig "
        Console.WriteLine(NicoCipher("iloveher", "612345")); // "lovehir    e"
    }
}
