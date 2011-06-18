using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeeTimeFly
{
    class Program
    {
        static void Main(string[] args)
        {
            string Current = new TimeChecker().TicToc();
            Console.WriteLine(Current);
            Console.WriteLine("Length in Characters: " + Current.Length.ToString());
            string minutes = Current.Substring(11, 2);
            Console.WriteLine("The Current Minute: " + minutes);
            Console.ReadLine();

          
           
        }
    }

    public class TimeChecker
    {
        public string TicToc()
        {
            string MonthNYear;

            if (DateTime.UtcNow.Month > 9)
            {
                MonthNYear = String.Format("{0}{1}", System.DateTime.UtcNow.Year,
                    DateTime.UtcNow.Month);
            }
            else
            {
                MonthNYear = String.Format("{0}0{1}", System.DateTime.UtcNow.Year,
                    DateTime.UtcNow.Month);
            }
            String Today;

            if (DateTime.UtcNow.Day > 9)
            {
                Today = System.DateTime.UtcNow.Day.ToString();
            }
            else
            {
                Today = "0" + System.DateTime.UtcNow.Day.ToString();
            }

            string Hour;
            if (DateTime.UtcNow.Hour > 9)
            {
                Hour = DateTime.UtcNow.Hour.ToString();
            }
            else Hour = "0" + DateTime.UtcNow.Hour.ToString();

            string Minute;
            if (DateTime.UtcNow.Minute > 9)
                Minute = DateTime.UtcNow.Minute.ToString();
            else Minute = "0" + DateTime.UtcNow.Minute.ToString();

            string Second;
            if (DateTime.UtcNow.Second > 9)
                Second = DateTime.UtcNow.Second.ToString();
            else Second = "0" + DateTime.UtcNow.Second.ToString();


            String holder = MonthNYear + Today + "T" + Hour + Minute + Second + "Z";
            return holder;
        }
    }
}
