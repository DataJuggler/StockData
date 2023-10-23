using DataJuggler.UltimateHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockData
{
    internal class NumberToTextHelper
    {

        #region ConvertNumberToText(int number)
        /// <summary>
        /// returns the Number To Text
        /// </summary>
        public static string ConvertNumberToText(int number)
        {
            // initial value
            string text = "";

            if (number <= 12)
            {
                // Set the text for one - 12
                text = SetText0To12(number);
            }
            else if (NumericHelper.IsInRange(number, 13, 19))
            {
                // Set the text for one - 12
                text = SetText13To19(number);
            }
            else if (NumericHelper.IsInRange(number, 20, 99))
            {
                // Set the text for 20 through 99
                text = SetText20To99(number);
            }
            else if (NumericHelper.IsInRange(number, 100, 999))
            {
                // Set the text for 100 through 999
                text = SetText100To999(number);
            }
            else if (NumericHelper.IsInRange(number, 1000, 1099))
            {

            }
            else if (NumericHelper.IsInRange(number, 1100, 1299))
            {

            }
            else if (NumericHelper.IsInRange(number, 1300, 1999))
            {

            }
            else
            {
                // 2000 - 9,999
            }

            // return value
            return text;
        }
        #endregion

        #region GetDigitAsString(int number, int digit)
        /// <summary>
        /// returns the First Digit As String
        /// </summary>
        private static string GetDigitAsString(int number, int digit)
        {
            // initial value
            string text = "";

            // set the number as text
            string numberAsText = number.ToString();

            // ensure the string is long enough
            if (numberAsText.Length >= digit)
            {
                // return the digit char as a string
                text = numberAsText[digit - 1].ToString();
            }

            // return value
            return text;
        }
        #endregion

        #region GetDigitValue(int number, int digit, int defaultValue = -1, int errorValue = -2)
        /// <summary>
        /// returns the Digit Value
        /// </summary>
        public static int GetDigitValue(int number, int digit, int defaultValue = -1, int errorValue = -2)
        {
            // initial value
            int digitValue = 0;

            // get the digit as a string
            string digitAsText = GetDigitAsString(number, digit);

            // return the digitValue
            digitValue = NumericHelper.ParseInteger(digitAsText, defaultValue, errorValue);

            // return value
            return digitValue;
        }
        #endregion

        #region SetText100To999(int number)
        /// <summary>
        /// returns the Text 100 To 999
        /// </summary>
        private static string SetText100To999(int number)
        {
            // initial value
            string text = "";

            // Get the firstDigit
            int firstDigitValue = GetDigitValue(number, 1);

            // get the lastTwoDigits as a string
            string lastTwoDigits = number.ToString().Substring(1);

            // Get the last two digits value
            int lastTwoDigitsValue = NumericHelper.ParseInteger(lastTwoDigits, -1, -2);

            // if less than ten
            if (lastTwoDigitsValue < 10)
            {
                // set the return value with an and
                text = firstDigitValue + " hundred and " + ConvertNumberToText(lastTwoDigitsValue);
            }
            else
            {
                // set the return value
                text = ConvertNumberToText(firstDigitValue) + " hundred " + ConvertNumberToText(lastTwoDigitsValue);
            }

            // return value
            return text;
        }
        #endregion

        #region SetText13To19(int number)
        /// <summary>
        /// returns the Tex 13 To 19
        /// </summary>
        private static string SetText13To19(int number)
        {
            // initial value
            string text = "";

            if (number == 13)
            {
                // set the return value
                text = "thirteen";
            }
            else if (number == 15)
            {
                // set the return value
                text = "fifteen";
            }
            else
            {
                // get the first digit
                int firstDigitiValue = GetDigitValue(number, 1);

                // make sure the first digit is a 1
                if (firstDigitiValue == 1)
                {
                    // get the first digit
                    int secondDigitValue = GetDigitValue(number, 2);

                    // set the return value
                    text = SetText0To12(secondDigitValue) + "teen";
                }
            }

            // return value
            return text;
        }
        #endregion

        #region SetText0To12(int number)
        /// <summary>
        /// returns the Text 0 to 12
        /// </summary>
        private static string SetText0To12(int number)
        {
            // initial value
            string text = "";

            // Determine the action by the number
            switch (number)
            {
                case 0:

                    // set the return value
                    text = "zero";

                    // required
                    break;

                case 1:

                    // set the return value
                    text = "one";

                    // required
                    break;

                case 2:

                    // set the return value
                    text = "two";

                    // required
                    break;

                case 3:

                    // set the return value
                    text = "three";

                    // required
                    break;

                case 4:

                    // set the return value
                    text = "four";

                    // required
                    break;

                case 5:

                    // set the return value
                    text = "five";

                    // required
                    break;

                case 6:

                    // set the return value
                    text = "six";

                    // required
                    break;

                case 7:

                    // set the return value
                    text = "seven";

                    // required
                    break;

                case 8:

                    // set the return value
                    text = "eight";

                    // required
                    break;

                case 9:

                    // set the return value
                    text = "nine";

                    // required
                    break;

                case 10:

                    // set the return value
                    text = "ten";

                    // required
                    break;

                case 11:

                    // set the return value
                    text = "eleven";

                    // required
                    break;

                case 12:

                    // set the return value
                    text = "twelve";

                    // required
                    break;
            }

            // return value
            return text;
        }
        #endregion

        #region SetText20To99(int number)
        /// <summary>
        /// returns the Text 20 To 99
        /// </summary>
        private static string SetText20To99(int number)
        {
            // initial value
            string text = "";

            // get the first and second digit values
            int firstDigitValue = GetDigitValue(number, 1);            
            int secondDigitValue = GetDigitValue(number, 2);
            string firstWord = "";

            // Determine the action by the firstDigitValue
            switch (firstDigitValue)
            {
                case 2:

                    // set the return value
                    firstWord = "twenty";

                    // required
                    break;

                case 3:

                    // set the return value
                    firstWord = "thirty";

                    // required
                    break;

                case 4:

                    // set the return value
                    firstWord = "forty";

                    // required
                    break;

                case 5:

                    // set the return value
                    firstWord = "fifty";

                    // required
                    break;

                default:

                    // set the return value
                    firstWord = GetDigitAsString(number, 1) + "ty";

                    // required
                    break;
            }

            // if this is an even value like twenty, thirty, etc.
            if (secondDigitValue == 0)
            {
                // set the return value as is
                text = firstWord;
            }
            else
            {
                // set the return value with a hypen and secondDigit
                text = firstWord + "-" + ConvertNumberToText(secondDigitValue);
            }

            // return value
            return text;
        }
        #endregion

    }
}