using System;
using System.Collections.Generic;

namespace LargeNumberConverter
{
    public class NumberConverter : INumberConverter
    {
        private const string Negative = "negative";
        private const string And = "and";

        private readonly string[] _sizeValues = new[] { "hundred", "thousand", "million" };
        private readonly Dictionary<int, string> _allNonCompoundNumbers = new Dictionary<int, string>
            {
                {0, "zero"},{1, "one"},{2, "two"},{3, "three"},{4, "four"},{5, "five"},{6, "six"},{7, "seven"},{8, "eight"},{9, "nine"},{10, "ten"},
                {11, "eleven"},{12, "twelve"},{13, "thirteen"},{14, "fourteen"},{15, "fifteen"},{16, "sixteen"},{17, "seventeen"},{18, "eighteen"},{19, "nineteen"},{20, "twenty"},
                {30, "thirty"},{40, "forty"},{50, "fifty"},{60, "sixty"},{70, "seventy"},{80, "eighty"},{90, "ninety"},
            };

        public string Convert(int inputNumber)
        {
            var inputNumberGroups = CreateGroupsFromInputNumber(Math.Abs(inputNumber));

            var inputNumberStringGroups = ConvertNumberGroupsToStringGroups(inputNumberGroups);

            var absoluteNumberConvertedToString = CombineConvertedGroups(inputNumberGroups, inputNumberStringGroups);

            return inputNumber < 0 ? ConvertNumberIfNegative(absoluteNumberConvertedToString) : absoluteNumberConvertedToString;
        }

        private static int[] CreateGroupsFromInputNumber(int inputNumber)
        {
            var groups = new int[3];
            for (var i = 0; i < 3; i++)
            {
                groups[i] = inputNumber % 1000;
                inputNumber /= 1000;
            }
            return groups;
        }

        private string[] ConvertNumberGroupsToStringGroups(int[] numberGroups)
        {
            var groups = new string[3];
            for (var i = 0; i < 3; i++)
            {
                groups[i] = ConvertNumberBelow1000(numberGroups[i]);
            }
            return groups;
        }

        private string CombineConvertedGroups(int[] numberGroups, string[] numberStringGroups)
        {
            var convertedNumber = "";

            for (int i = 2; i >= 1; i--)
            {
                if (numberGroups[i] > 0)
                {
                    if (string.IsNullOrWhiteSpace(convertedNumber))
                    {
                        convertedNumber = string.Format("{0} {1}", numberStringGroups[i], _sizeValues[i]);
                    }
                    else
                    {
                        convertedNumber = string.Format("{0} {1} {2}", convertedNumber, numberStringGroups[i], _sizeValues[i]);
                    }
                }
            }

            if (string.IsNullOrWhiteSpace(convertedNumber))
            {
                convertedNumber = numberStringGroups[0];
            }
            else
            {
                if (numberGroups[0] > 0)
                {
                    if (numberGroups[0] < 100)
                    {
                        convertedNumber = string.Format("{0} {1} {2}", convertedNumber, And, numberStringGroups[0]);
                    }
                    else
                    {
                        convertedNumber = string.Format("{0} {1}", convertedNumber, numberStringGroups[0]);
                    }
                }
            }
            return convertedNumber;
        }

        private string ConvertNumberIfNegative(string convertedAbsoluteNumber)
        {
            return string.Format("{0} {1}", Negative, convertedAbsoluteNumber);
        }

        private string ConvertNumberBelow1000(int inputNumber)
        {
            string inputNumberConvertedToString;

            var hundreds = inputNumber - inputNumber % 100;
            if (hundreds == 0)
            {
                inputNumberConvertedToString = ConvertNumberBelow100(inputNumber);
            }
            else
            {
                var inputNumberWithHundredsRemoved = inputNumber - hundreds;
                var valueOfTensInNumber = inputNumberWithHundredsRemoved - inputNumberWithHundredsRemoved % 10;
                var valueOfUnitsInNumber = inputNumberWithHundredsRemoved - valueOfTensInNumber;

                var convertedCountOfHundreds = ConvertNumberBelow100(hundreds/100);
                inputNumberConvertedToString = string.Format("{0} {1}", convertedCountOfHundreds, _sizeValues[0]);

                if (valueOfTensInNumber > 0 || valueOfUnitsInNumber > 0)
                {
                    inputNumberConvertedToString = string.Format("{0} {1} {2}", inputNumberConvertedToString, And,
                                                                 ConvertNumberBelow10(valueOfTensInNumber,
                                                                                      valueOfUnitsInNumber));
                }
            }
            return inputNumberConvertedToString;
        }

        private string ConvertNumberBelow100(int inputNumber)
        {
            var tens = inputNumber - inputNumber % 10;
            var units = inputNumber - tens;

            return ConvertNumberBelow10(tens, units);
        }

        private string ConvertNumberBelow10(int tens, int units)
        {
            string inputNumberConvertedToString;
            if (tens == 0)
            {
                inputNumberConvertedToString = string.Format("{0}", ConvertNonCompoundNumber(units));
            }
            else if (units == 0)
            {
                inputNumberConvertedToString = string.Format("{0}", ConvertNonCompoundNumber(tens));
            }
            else
            {
                inputNumberConvertedToString = string.Format("{0} {1}", ConvertNonCompoundNumber(tens), ConvertNonCompoundNumber(units));
            }
            return inputNumberConvertedToString;
        }

        private string ConvertNonCompoundNumber(int inputNumber)
        {
            return _allNonCompoundNumbers[inputNumber];
        }
    }
}