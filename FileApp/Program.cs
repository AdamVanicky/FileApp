using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FileApp
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> liPositions = new List<int>();
            string path = "ThreeMenInABoatEnglish.txt";
            string returnPath = "returnFile.txt";

            if (File.Exists(path))
            {
                string[] rows = File.ReadAllLines(path);

                foreach (string s in rows)
                {
                    char[] charsToRemove = { ',', '.', '-', '[', '_', ']', '(', ')', '{', '}', '/' };
                    foreach (char z in charsToRemove)
                    {
                        s.Replace(z, ' ');
                    }
                    charsToRemove = new char[] { ' ' };
                    string[] spliter = s.Split(charsToRemove);
                    foreach (string str in spliter)
                    {
                        if(str.ToLower() == "no" || str.ToLower() == "is" || str.ToLower() == "of" || str.ToLower() == "and" || str.ToLower() == "a" || str.ToLower() == "by" || str.ToLower() == "in" || str.ToLower() == "at" || str.ToLower() == "while" || str.ToLower() == "after" || str.ToLower() == "even" || str.ToLower() == "on" || str.ToLower() == "in" || str.ToLower() == "it" || str.ToLower() == "he" || str.ToLower() == "she" || str.ToLower() == "they" || str.ToLower() == "me" || str.ToLower() == "you" || str.ToLower() == "but" || str.ToLower() == "the" || str.ToLower() == "" || str.ToLower() == " " || str.ToLower() == "if" || str.ToLower() == "so" || str.ToLower() == "yet" || str.ToLower() == "nor" || str.ToLower() == "for" || str.ToLower() == "or" || str.ToLower() == "to")
                        {
                            continue;
                        }
                        int position = 0;
                        foreach(string isThereAlso in rows)
                        {
                            if(isThereAlso.Contains(str))
                            {
                                liPositions.Add(position);
                            }
                            else
                            {
                                position++;
                            }
                        }
                        Console.Write($"{str} - ");
                        File.AppendAllText(returnPath, $"{str} - ");
                        foreach (int pos in liPositions.ToArray())
                        {
                            Console.Write($"{pos} ");
                            File.AppendAllText(returnPath, $"{pos} ");
                        }
                        Console.WriteLine("\n");
                        File.AppendAllText(returnPath, "\n");
                        liPositions = new List<int>();
                    }
                }
                Console.ReadLine();
            }
        }
    }
}
