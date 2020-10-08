using System;
using System.Collections.Generic;

namespace Lab04
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] endSimbol = { '.', '!', '?', ';', ':', '(', ')' };
            //Пользователь вводит какой - то текст. +
            string text = Console.ReadLine();
            text = text.ToLower();
            //1.Посчитать кол - во знаков препинания в нем(точка, запятая и другие) +
            int countofpunct = CountPunctuationMarks(text, endSimbol);
            //2.Разбить текст на отдельные предложения +
            string[] sentencelist = ToSplitText(text, endSimbol);
            //3.Создать массив уникальных слов в тексте и вывести их на экран через запятую ++
            List<string> uniquewords = SearchUniqueWords(sentencelist);
            PrintUniqueWords(uniquewords);
            //4.Найдите самое длинное слово во всем тексте. Выведите его на экран.++
            string longestword = SearchLongestWord(uniquewords);
            //5.Если самое длинное слово имеет четную длину -выведите вторую половину на экран++
            DivisionOfTheLongestWord(longestword);
            //Если нечетное -замените центральный символ на символ * ++
        }
        static int CountPunctuationMarks(string text, char [] endsimbol)
        {
            int count = 0;
            foreach (char simbol in text)
            {
                for (int i=0; i < 7; i++)
                {
                    if (simbol == endsimbol[i])
                        count++;
                }
            }
            return count;
        }
        static string[] ToSplitText(string text, char[] endsimbol)
        {
            string[] sentencelist = text.Split(endsimbol);
            return sentencelist;
        }
        static List<string> SearchUniqueWords(string[] sentencelist)
        {
            List<string> uniquewords = new List<string>();
            List<string[]> words = new List<string[]>();
            for(int i=0; i < sentencelist.Length; i++)
            {
                words.Add(sentencelist[i].Split(new char[] { ' ' },StringSplitOptions.RemoveEmptyEntries));
            }
            for (int i = 0; i < words.Count; i++)
            {
                for (int j=0;j<words[i].Length; j++)
                {
                    uniquewords.Add(words[i][j]);
                }
            }
            for (int i = 0; i < uniquewords.Count; i++)
            {
                for (int j = i+1; j < uniquewords.Count; j++)
                {
                    if (uniquewords[i] == uniquewords[j])
                        uniquewords.Remove(uniquewords[j]);
                }
            }
            return uniquewords;
        }
        static void PrintUniqueWords(List<string> uniquewords)
        {
            Console.Write(uniquewords[0]);
            for(int i=1;i< uniquewords.Count; i++)
            {
                Console.Write(", ");
                Console.Write(uniquewords[i]);
            }
            Console.WriteLine();
        }
        static string SearchLongestWord(List<string> uniquewords)
        {
           string longestword = uniquewords[0];
           for (int i = 1; i < uniquewords.Count; i++)
           {
                if(uniquewords[i].Length > longestword.Length)
                {
                    longestword = uniquewords[i];
                }
           }
           Console.WriteLine(longestword);
           return longestword;
        }
        static void DivisionOfTheLongestWord(string longestword)
        {
            string half = "";
            if (longestword.Length % 2 == 0)
            {
                half = longestword.Substring(longestword.Length / 2);
                Console.WriteLine(half);
                Console.ReadKey();
            }
            else
            {
                longestword = longestword.Replace(longestword[longestword.Length / 2], '*');
                Console.WriteLine(longestword);
                Console.ReadKey();
            }
        }
    }
}
