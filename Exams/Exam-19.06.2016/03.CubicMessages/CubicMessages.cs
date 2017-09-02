namespace _03.CubicMessages
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    public class CubicMessages
    {
        public static void Main()
        {
            while (true)
            {
                var encryptedMessage = Console.ReadLine();

                if (encryptedMessage == "Over!")
                {
                    break;
                }

                var length = int.Parse(Console.ReadLine());

                var pattern = @"(\d+)([A-z]{" + length + @"})(\d+)?";

                var regex = new Regex(pattern);

                var digitCounter = 0;

                var isValid = true;

                for (int i = 0; i < encryptedMessage.Length; i++)
                {
                    if (char.IsDigit(encryptedMessage[i]))
                    {
                        digitCounter++;
                    }
                    else
                    {
                        break;
                    }
                }

                if (digitCounter == 0)
                {
                    continue;
                }

                for (int i = digitCounter; i < digitCounter + length; i++)
                {
                    if (!char.IsLetter(encryptedMessage[i]))
                    {
                        isValid = false;
                        break;
                    }
                }

                for (int i = digitCounter + length; i < encryptedMessage.Length; i++)
                {
                    if (char.IsLetter(encryptedMessage[i]))
                    {
                        isValid = false;
                        break;
                    }
                }

                var verificationCode = string.Empty;
                var decryptedMessage = string.Empty;

                if (isValid)
                {
                    var matches = regex.Matches(encryptedMessage);

                    foreach (Match match in matches)
                    {
                        var digitsBefore = match.Groups[1].Value;
                        decryptedMessage = match.Groups[2].Value;
                        var digitsAfter = match.Groups[3].Value;

                        for (int i = 0; i < digitsBefore.Length; i++)
                        {
                            var currentDigit = int.Parse(digitsBefore[i].ToString());

                            if (currentDigit < length)
                            {
                                verificationCode += decryptedMessage[currentDigit];
                            }
                            else
                            {
                                verificationCode += " ";
                            }
                        }

                        for (int i = 0; i < digitsAfter.Length; i++)
                        {
                            var currentDigit = int.Parse(digitsAfter[i].ToString());

                            if (currentDigit < length)
                            {
                                verificationCode += decryptedMessage[currentDigit];
                            }
                            else
                            {
                                verificationCode += " ";
                            }
                        }
                    }

                    Console.WriteLine($"{decryptedMessage} == {verificationCode}");
                }             
            }
        }
    }
}