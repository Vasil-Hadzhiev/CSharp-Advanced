using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12.MatrixStringRotation
{
    public class MatrixStringRotation
    {
        public static void Main()
        {
            var rotationDegrees = Console.ReadLine().
                Split(new char[] { '(', ')' },
                StringSplitOptions.RemoveEmptyEntries).
                ToArray();

            var degrees = rotationDegrees[1];

            var words = new List<string>();

            while (true)
            {
                var inputLine = Console.ReadLine();

                if (inputLine == "END")
                {
                    break;
                }

                words.Add(inputLine);
            }

            var maxStringLength = words.Max(x => x.Length);

            for (int i = 0; i < words.Count; i++)
            {
                if (words[i].Length != maxStringLength)
                {
                    for (int j = words[i].Length; j < maxStringLength; j++)
                    {
                        words[i] += " ";
                    }
                }
            }

            var rotationsCount = (int.Parse(degrees) / 90) % 4;

            switch (rotationsCount)
            {
                case 0: RotateMatrix360Degrees(words);
                    break;
                case 1: RotateMatrix90Degrees(words, maxStringLength);
                    break;
                case 2: RotateMatrix180Degrees(words);
                    break;
                case 3: RotateMatrix270Degrees(words, maxStringLength);
                    break;
            }
        }

        private static void RotateMatrix360Degrees(List<string> words)
        {
            foreach (var item in words)
            {
                Console.WriteLine(item);
            }
        }

        private static void RotateMatrix90Degrees(List<string> words, int maxStringLength)
        {
            var currentCharIndex = 0;

            for (int i = maxStringLength - 1; i >= 0; i--)
            {
                for (int j = words.Count -1; j >= 0; j--)
                {
                    Console.Write(words[j][currentCharIndex]);
                }
                Console.WriteLine();
                currentCharIndex++;
            }
        }

        private static void RotateMatrix180Degrees(List<string> words)
        {
            for (int i = words.Count - 1; i >= 0; i--)
            {
                var currentWord = words[i];
                var charArray = currentWord.ToCharArray();
                Array.Reverse(charArray);
                currentWord = new string(charArray);
                Console.WriteLine(currentWord);
            }
        }

        private static void RotateMatrix270Degrees(List<string> words, int maxStringLength)
        {
            var currentCharIndex = maxStringLength - 1;

            for (int i = 0; i < maxStringLength; i++)
            {
                for (int j = 0; j < words.Count; j++)
                {
                    Console.Write(words[j][currentCharIndex]);
                }
                Console.WriteLine();
                currentCharIndex--;
            }
        }
    }
}
