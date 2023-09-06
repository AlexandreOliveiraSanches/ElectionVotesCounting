using System;
using System.IO;
using System.Linq.Expressions;

namespace VotesCounting
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter file path: ");
            string path = Console.ReadLine();

            try
            {
                using (StreamReader sr = File.OpenText(path))
                {

                    Dictionary<string, int> dictionary = new Dictionary<string, int>();

                    while (!sr.EndOfStream)
                    {
                        string[] votingRecord = sr.ReadLine().Split(',');
                        string candidate = votingRecord[0];
                        int vote = int.Parse(votingRecord[1]);

                        if (dictionary.ContainsKey(candidate))
                        {
                            dictionary[candidate] += vote;
                        }
                        else
                        {
                            dictionary[candidate] = vote;
                        }

                    }

                    foreach (var item in dictionary)
                    {
                        Console.WriteLine(item.Key + ": " + item.Value);
                    }
                }
            }

            catch (IOException e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }
    }
}