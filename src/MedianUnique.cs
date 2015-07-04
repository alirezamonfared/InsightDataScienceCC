using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace InsightDataScienceCC
{
    class MedianUnique
    {
        public MedianUnique(string inputFile, string outputFile)
        {
            int nUniqueWords = 0;
            double prevMedian = 0;
            List<double> medianValues = new List<double>();
            string line;
            StreamReader tweetInput = new StreamReader(inputFile);
            StreamWriter tweetOutput = new StreamWriter(outputFile);

            var minHeap = new MinHeap();
            var maxHeap = new MaxHeap();
            bool firstPass = true;
            while (( line = tweetInput.ReadLine()) != null)
            {
                nUniqueWords = this.processLine(line);
                if (firstPass)
                {
                    prevMedian = nUniqueWords;
                }
                prevMedian = updateMedian(nUniqueWords,prevMedian, maxHeap, minHeap);
                medianValues.Add(prevMedian);
                tweetOutput.WriteLine(prevMedian);
            }
            tweetInput.Close();
            tweetOutput.Close();
        }

        public int processLine(string line)
        {
            string[] words = line.Split(null);
            if (words == null || words.Length == 0)
            {
                return 0;
            }
            else
            {
                return words.Distinct().Count();
            }
        }

        private double updateMedian(int number, double prevMedian,  MaxHeap maxHeap, MinHeap minHeap) {
            int minCount = minHeap.GetCount();
            int maxCount = maxHeap.GetCount();
            if (maxCount > minCount) {
                if (number < prevMedian) {
                    minHeap.Insert(maxHeap.ExtractTop());
                    maxHeap.Insert(number);
                }
                else
                {
                    minHeap.Insert(number);
                }
                return 0.5 * (minHeap.GetTop() + maxHeap.GetTop());
            }

            if (minCount == maxCount) {
                if (number < prevMedian)
                {
                    maxHeap.Insert(number);
                    return maxHeap.GetTop();
                }
                else
                {
                    minHeap.Insert(number);
                    
                    return minHeap.GetTop();
                } 
            }

            if (maxCount < minCount)
            {
                if (number < prevMedian)
                {
                    maxHeap.Insert(number);
                }
                else
                {
                    maxHeap.Insert(minHeap.ExtractTop());
                    minHeap.Insert(number);
                }
                return 0.5 * (minHeap.GetTop() + maxHeap.GetTop());
            }
            return -1;
        }
    }


    public class MaxHeap : BaseHeap { protected override bool Compare(int a, int b) { return a > b; } }
    
    public class MinHeap : BaseHeap { protected override bool Compare(int a, int b) { return a < b; } }

    public abstract class BaseHeap
    {
        private readonly List<int> array = new List<int>(128);
        private int heapSize = -1;

        protected abstract Boolean Compare(int a, int b);

        public virtual void Insert(int key)
        {
            heapSize++;
            if (array.Count <= heapSize)
            {
                array.AddRange(
                    Enumerable.Range(0, heapSize - (array.Count - 1))
                              .Select(i => 0));
            }
            array[heapSize] = key;
            Heapify(heapSize);
        }

        public virtual int GetTop()
        {
            int max = -1;

            if (heapSize >= 0)
            {
                max = array[0];
            }

            return max;
        }

        public virtual int GetCount()
        {
            return heapSize + 1;
        }

        public virtual int ExtractTop()
        {
            var del = -1;

            if (heapSize > -1)
            {
                del = array[0];

                Swap(array, 0, heapSize);
                heapSize--;
                Heapify(GetParent(heapSize + 1));
            }

            return del;
        }

        private int GetParent(int i)
        {
            if (i <= 0)
            {
                return -1;
            }

            return (i - 1) / 2;
        }

        private void Heapify(int i)
        {
            int p = GetParent(i);

            if (p >= 0 && Compare(array[i], array[p]))
            {
                Swap(array, i, p);
                Heapify(p);
            }
        }

        private static void Swap(IList<int> array, int aIndex, int bIndex)
        {
            var aux = array[aIndex];
            array[aIndex] = array[bIndex];
            array[bIndex] = aux;
        }
    }
}
