using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsightDataScienceCC
{
    class MainClass
    {
        static void Main(string[] args)
        {
           string tweetInput = "..\\tweet_input\\tweets.txt";
           string tweetOutput1 ="ft1.txt";
           string tweetOutput2 = "ft2.txt";

            WordsTweeted wordsTweeted = new WordsTweeted(tweetInput);
            wordsTweeted.printwordCount(tweetOutput1);

            MedianUnique uniquewords = new MedianUnique(tweetInput, tweetOutput2);
            
            //Console.WriteLine("Press enter to close...");
            //Console.ReadLine();
        }
    }
}
