using System;
using System.Globalization;

namespace Ex04.Menus.Test
{
    public static class TestMethods
    {
        private static readonly CultureInfo sr_Culture;

        static TestMethods()
        {
            sr_Culture = CultureInfo.CurrentCulture;
        }

        public static void CountCapitals()
        {
            int numberOfCapitals = 0;

            Console.WriteLine("Enter a sentence: ");
            string sentence = Console.ReadLine();

            foreach(char character in sentence)
            {
                if (char.IsUpper(character))
                {
                    ++numberOfCapitals;
                }
            }

            Console.WriteLine(string.Format("There are {0} capital lettes in the input.", numberOfCapitals));
        }

        public static void ShowVersion()
        {
            string version = "30620.4.2.20";

            Console.WriteLine(string.Format("Version: {0}", version));
        }

        public static void ShowTime()
        {
            showTimeBySpecfier("t", "Time:");
        }

        public static void ShowDate()
        {
            showTimeBySpecfier("d", "Date:");
        }

        private static void showTimeBySpecfier(string i_Specifier, string i_Message)
        {
            DateTime date = DateTime.Now;

            Console.WriteLine(string.Format("{0} {1}", i_Message, date.ToString(i_Specifier, sr_Culture)));
        }
    }
}
