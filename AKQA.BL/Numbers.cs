using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AKQA.BL
{
    public class Numbers
    {
        protected readonly IEnumerable<KeyValuePair<string, long>> numericalStructure;
        protected readonly string NUMBER_TEXT_APPEND_FORMAT;
        protected readonly string NUMBER_PATTERN;


        protected Numbers(string numbersText)
        {
            NUMBER_TEXT_APPEND_FORMAT = "{0} ";
            NUMBER_PATTERN = @"^\d(\d{0,}\.?)\d{0,}$";

            if (!Check(numbersText))
            {
                throw new FormatException("Invalid number text");
            }
            numericalStructure = NumericalStructure.Initialise().Reverse(); //Reverse the sorting order to allow retrieveing the first number description that has value smaller than the given number.
            NumberText = numbersText;
        }

        public static Numbers Convert<T>(T number)
        {
            string str = System.Convert.ToString(number);
            Numbers result = null;

            try
            {
                result = new Numbers(str);
            }
            catch
            {

            }
            return result;
        }
        
        protected bool Check(string numbersText)
        {
            var match = Regex.Match(numbersText, NUMBER_PATTERN);
            return match.Success;            
        }

        public override string ToString()
        {
            string[] arr = NumberText.Split('.');
            long characteristic = long.Parse(arr[0]);
            long mantissa = arr.Length == 2 ? long.Parse(arr[1]) : 0;

            StringBuilder sb = new StringBuilder();
            sb.Append(ToString(characteristic));
            sb.AppendFormat(" DOLLAR{0} AND ", characteristic>1? "S":"");
            sb.Append(ToString(mantissa));
            sb.AppendFormat(" CENT{0}.",mantissa>1?"S":"");

            return sb.ToString();
        }

        protected string ToString(long number)
        {
            //Get the first number description that has value smaller than the given number.
            var p = numericalStructure.First(n => number >= n.Value);
            long value = p.Value;
            string text = p.Key;
            
            if (number == 0) return text;

            long significantPart = number - (number % value);//Get the highest significant portion of the number.
            long remainder = number - significantPart;//Get the remainder to process later.
            long mostSignificantNumber = 0;
            StringBuilder sb = new StringBuilder();

            if (significantPart > value || significantPart >= 100)
            {
                mostSignificantNumber = significantPart / value;
                if (mostSignificantNumber > 10)
                {
                    sb.AppendFormat(NUMBER_TEXT_APPEND_FORMAT,ToString(mostSignificantNumber));
                }
                else
                {
                    var q = numericalStructure.First(n => mostSignificantNumber == n.Value);
                    sb.AppendFormat(NUMBER_TEXT_APPEND_FORMAT, q.Key);
                }
                sb.AppendFormat(NUMBER_TEXT_APPEND_FORMAT,p.Key);
                           
            }
            else
            {               
                mostSignificantNumber = significantPart;
                var q = numericalStructure.First(n => mostSignificantNumber == n.Value);
                sb.AppendFormat(NUMBER_TEXT_APPEND_FORMAT, q.Key);
            }

            if (remainder != 0)//if remaining number to convert.
            {
                if (value == 100 ||(value > 100 && remainder < 100))//Add AND text if the number is in the hundreds range (eg, 360 is THREE HUNDRED AND SIXTY) and numbers like 1002 (ONE THOUSAND AND TWO) or 1000007 (ONE MILLION AND SEVEN).
                {
                    sb.Append("AND ");
                }
                if(value > 19 && value < 100) //Add a hyphen to the numbers between 20 and 99. (eg, 34 is THIRTY-FOUR).
                {
                    sb.Remove(sb.Length - 1, 1);//Remove spacing at the end of the string.
                    sb.Append("-");//Add a Hyphen.
                }
                sb.Append(ToString(remainder));
            }

            return sb.ToString().Trim(' ');
        }

        protected string NumberText { get; set; }
               
    }
}
