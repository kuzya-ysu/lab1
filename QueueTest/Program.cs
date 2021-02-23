using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyQueueClass;
using System.IO;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace QueueTest
{
    internal class Program
    {
        private static MyQueue<string> GetMyQueue()
        {
            string fileName = "anna.txt";
            StreamReader streamReader = new StreamReader(fileName);
            string fullText = streamReader.ReadToEnd();
            Regex filter = new Regex(@"([А-Я]|[а-я])+");
            MyQueue<String> words = new MyQueue<string>();
            foreach (Match match in filter.Matches(fullText))
            {
                words.Enqueue(match.Value);
            }
            return words;
        }

        private static Queue<string> GetQueue()
        {
            string fileName = "anna.txt";
            StreamReader streamReader = new StreamReader(fileName);
            string fullText = streamReader.ReadToEnd();
            Regex filter = new Regex(@"([А-Я]|[а-я])+");
            Queue<String> words = new Queue<string>();
            foreach (Match match in filter.Matches(fullText))
            {
                words.Enqueue(match.Value);
            }
            return words;
        }

        private static void Main(string[] args)
        {
            MyQueue<int> myQueue = new MyQueue<int>();
            Queue<int> queue = new Queue<int>();
            StringBuilder enqueueTime = new StringBuilder();
            StringBuilder dequeueTime = new StringBuilder();
            StringBuilder peekTime = new StringBuilder();
            StringBuilder containsTime = new StringBuilder();
            Stopwatch stopwatch = new Stopwatch();

            #region enqueue

            stopwatch.Start();
            for (int i = 0; i < 10000; i++)
            {
                myQueue.Enqueue(i);
            }
            stopwatch.Stop();
            enqueueTime.Append("Enqueue - " + stopwatch.Elapsed.ToString());
            stopwatch.Restart();
            for (int i = 0; i < 10000; i++)
            {
                queue.Enqueue(i);
            }
            stopwatch.Stop();
            enqueueTime.Append(" vs " + stopwatch.Elapsed.ToString());
            Console.WriteLine(enqueueTime.ToString());

            #endregion enqueue

            #region peek

            stopwatch.Restart();
            for (int i = 0; i < 10000; i++)
            {
                myQueue.Peek();
            }
            stopwatch.Stop();
            peekTime.Append("Peek - " + stopwatch.Elapsed.ToString());
            stopwatch.Restart();
            for (int i = 0; i < 10000; i++)
            {
                queue.Peek();
            }
            stopwatch.Stop();
            peekTime.Append(" vs " + stopwatch.Elapsed.ToString());
            Console.WriteLine(peekTime.ToString());

            #endregion peek

            #region contains

            stopwatch.Restart();
            for (int i = 5000; i < 15000; i++)
            {
                myQueue.Contains(i);
            }
            stopwatch.Stop();
            containsTime.Append("Contains - " + stopwatch.Elapsed.ToString());
            stopwatch.Restart();
            for (int i = 5000; i < 15000; i++)
            {
                queue.Contains(i);
            }
            stopwatch.Stop();
            containsTime.Append(" vs " + stopwatch.Elapsed.ToString());
            Console.WriteLine(containsTime.ToString());

            #endregion contains

            #region dequeue

            stopwatch.Restart();
            for (int i = 0; i < 10000; i++)
            {
                myQueue.Dequeue();
            }
            stopwatch.Stop();
            dequeueTime.Append("Dequeue - " + stopwatch.Elapsed.ToString());
            stopwatch.Restart();
            for (int i = 0; i < 10000; i++)
            {
                queue.Dequeue();
            }
            stopwatch.Stop();
            dequeueTime.Append(" vs " + stopwatch.Elapsed.ToString());
            Console.WriteLine(dequeueTime.ToString());

            #endregion dequeue

            Console.ReadKey();
        }
    }
}