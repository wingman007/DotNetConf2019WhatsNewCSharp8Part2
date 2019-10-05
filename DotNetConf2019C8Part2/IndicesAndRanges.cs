using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNetConf2019C8Part2
{
    class IndicesAndRanges
    {
        private static string[] words = { 
                    //Index fom start   index from end
            "The",  // 0                ^9
            "quick",// 1                ^8
            "brown",// 2                ^7
            "fox",  // 3                ^6
            "jumped", //4               ^5
            "over",  // 5               ^4
            "the",  // 6                ^3
            "lazy", // 7                ^2
            "dog"   // 8                ^1
        };
        public static void Demo1()
        {
            Console.WriteLine(words[^1]); // dog
        }

        public static void Demo2()
        {
            var lazyDog = words[^2..^0]; // head 0 or ^0 is the length of the array
            foreach (var word in lazyDog) Console.Write($"< {word} >");
            Console.WriteLine();
        }

        public static void Demo3()
        {
            var allWords = words[..];
            var firstPhrase = words[..4];
            var lastPhrase = words[6..];

            foreach (var word in allWords) Console.Write($"< {word} >");
            Console.WriteLine();
            foreach (var word in firstPhrase) Console.Write($"< {word} >");
            Console.WriteLine();
            foreach (var word in lastPhrase) Console.Write($"< {word} >");
            Console.WriteLine();
        }

        public static void Demo4()
        {
            Index the = ^3;
            Console.WriteLine(words[the]);

            Range phrase = 1..4;
            var text = words[phrase];
            foreach (var word in text) Console.WriteLine($"{word}");
            Console.WriteLine();
        }

        public static void Demo5()
        {
            var numbers = Enumerable.Range(0, 100).ToArray();
            int x = 12;
            int y = 25;
            int z = 36;

            Console.WriteLine("=============== ^0 is the same like Lenght =======");
            Console.WriteLine($"{numbers[^x]} is the same like as {numbers[numbers.Length - x]}");
            Console.WriteLine($"{numbers[x..y].Length} is the same like {y - x}");
            Console.WriteLine();

            // Span<int>
        }

        public static void Demo6()
        {
            int[] sequence = Enumerable.Range(0, 100).Select(x => (int)(Math.Sqrt(x) * 100)).ToArray();

            for (int start = 0; start < sequence.Length; start +=100)
            {
                Range r = start..(start + 10);
                var (min, max, average) = MovingAverage(sequence, r);
            }

            (int min, int max, double average) MovingAverage(int[] subSequence, Range range) =>
                (
                    subSequence[range].Min(),
                    subSequence[range].Max(),
                    subSequence[range].Average()
                );
            
            
        }
    }
}
