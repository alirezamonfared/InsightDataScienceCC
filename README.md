Insight Data Engineering - Coding Challenge
===========================================================

For this challenge, I have used C#.
I realize that Python is the best language of choice for this kind of assignment and I am a proficient Python programmer. As a result, using Python would have been the easiest choice for me. Instead, I used the hard route for the following reason:

I am currently, finishing my PhD and throughout my thesis, I have used C/C++/Python heavily. I have also worked on Java repositories for my internship work and side projects and hence, I am very comfortable with all the above languages. Recently though, I have been considering an offer from Microsoft for my post-PhD career. Knowing that C# is a language of much favoritisim in Microsoft, I have always wondered to have an opportunity to test my abilities in C#. 

The Insight Data Engineering Challenge happened to be a good start for me. I had no previous experience with C#. As a result, this assignment was my first experience with C#. I believe this could have been a good challenge for me personally to test my learning curve on a new language. It took me half a day to complete the challenge most of which was spent on details of figuring out the correct C# syntax and getting comfortable with coding C# on Visual Studio.

## Implementation Details

The structure of the project 'tree' is as follows:

	+-- README.md  
	+-- run.bat
	+-- InsightDataScienceCC.exe
	+-- src  
	¦   +-- MainClass.cs
	¦   +-- MedianUnique.cs
	¦   +-- WordsTweeted.cs
	+-- tweet_input  
	¦   +-- tweets.txt  
	+-- tweet_output  
	    +-- ft1.txt  
	    +-- ft2.txt  
		
Below is a description of the important files:

1. **src/MainClass.cs** This is the entry point for the program. This file contains proper calls to the other two C# classes.
2. **WordsTweeted.cs** This file contains the class that updates the number of words. This is simply done by maintaining a hash map. For any new word in anty new tweet, we simply check if this word exists in the hash map as a key. If it does, the value is incremented, if not an entry with value of 1 is created. Finally, the contents of hash map are written to /tweet_output/ft1.txt sorted by key.
3. **MedianUnique.cs** This class maintains a running median of the number of unique words in each tweet. For each tweet read, it is first split into words and the number of unique words in it is calculated using C#'s internal libraries. Then, we maintain two heap structures, one for the lower half of the numbers of the unique words and one for the upper half. We maintain the former as a max heap and the latter as a mean heap. With these heaps, all that is needed is to get the top values of the two heaps, if the total number of values is odd, one of these tops is the median, otherwise we report the average of the two tops. Adding each number of calculated unique words shall be done into the proper heap depending on whether the number is in the upper or lower half. Note that a naive solution can be to keep the calculated unique word count in an array, each time sort that array and report the median. But this constant sorting is not scalable. Hence, the maintenance of values in two heaps looks to be more accommodating for the cases that there are a large number of tweets to be read.
4. **run.bat** This file contains the proper run commands. This file first wipes off the contents of the tweet_output and also the executable InsightDataScienceCC.exe. It also makes sure that csc.exe which is the compiler for C# is in your PATH. It then compiles the source code and creates a new executable InsightDataScienceCC.exe and then runs it. It also makes sure the created output files are in tweet_output directory.
5. **InsightDataScienceCC.exe** This is  the executable for the codes in src folder. You do not need to worry about this file as it will be re-created when you call run.bat.

## How to Run:

To run the code, you need to have a Windows Machine or have workarounds to make C# work on another OS. If you are on a Windows machine, simply open the command line by typing cmd in your start menu. Go to the folder where you have cloned the GitHub repository and type "run".

## Troubleshoot

If your run statement does not work, you may need to slightly modify lines 1 and 2 of the run.bat to point to the correct location of your C# compiler. But it shall work as-is if you have .NET Framework version 3.5 installed on your system. In case that the problem persists, send me an email at alrieza@gatech.edu.