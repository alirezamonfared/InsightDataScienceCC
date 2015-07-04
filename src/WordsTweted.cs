using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.IO;

namespace InsightDataScienceCC
{
    public class WordsTweeted
    {
        private Dictionary<string, int> wordCount;
        public WordsTweeted()
        {
            wordCount = new Dictionary<string, int>();
        }

        public WordsTweeted(string inputFile)
        {
            wordCount = new Dictionary<string, int>();
            string line;
            StreamReader tweetInput = new StreamReader(inputFile);
            while ((line = tweetInput.ReadLine()) != null)
            {
                this.readLine(line);
            }
            tweetInput.Close();
        }

        public void readLine(string line) {
            string[] words = line.Split(null);
            if (words == null || words.Length == 0)
            {
                return;
            }
            else
            {
                foreach (string word in words)
                {
                    if (wordCount.ContainsKey(word))
                    {
                        wordCount[word]++;
                    }
                    else
                    {
                        wordCount[word] = 1;
                    }
                }
            }
        }
        public void printwordCount(string fileName) {
            StreamWriter tweetOutput = new StreamWriter(fileName);
            var list = wordCount.Keys.ToList();
            list.Sort();
            foreach (string word in list)
                //tweetOutput.WriteLine(word + "\t\t\t" + wordCount[word]);
                tweetOutput.WriteLine("{0,-30}{1,20}", word, wordCount[word]);
            tweetOutput.Close();
        }
    }
}
