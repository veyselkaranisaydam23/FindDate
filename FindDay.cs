using System;

namespace Algorithm_Homework_1_Find_Day
{
    //Defines global variables
    public class Program
    {
        int dayOfWeek;
        int initialDay = -1;
        int initialMonth = -1;
        int initialYear = -1;
        int endDay = -1;
        int endMonth = -1;
        int endYear = -1;
        int n = -1;
        int currentSeason = -1;

        //This function calculates season
        public int calculateSeason()
        {
            if (initialMonth % 12 > 8) return 4;
            if (initialMonth % 12 > 5) return 3;
            if (initialMonth % 12 > 2) return 2;
            return 1;
        }

        public void setCurrentSeason()
        {
            currentSeason = calculateSeason();
        }

        //This function checks season should be update
        public bool shouldSeasonBeUpdated()
        {
            return currentSeason != calculateSeason();
        }

        //This function converts the season from int to string
        public string convertSeason()
        {
            if (currentSeason == 1) return "Winter";
            if (currentSeason == 2) return "Spring";
            if (currentSeason == 3) return "Summer";
            return "Autumn";
        }

        //This function converts the months from int to string
        public string convertMonthToString()
        {
            if (initialMonth == 1) return "January";
            if (initialMonth == 2) return "February";
            if (initialMonth == 3) return "March";
            if (initialMonth == 4) return "April";
            if (initialMonth == 5) return "May";
            if (initialMonth == 6) return "June";
            if (initialMonth == 7) return "July";
            if (initialMonth == 8) return "August";
            if (initialMonth == 9) return "September";
            if (initialMonth == 10) return "October";
            if (initialMonth == 11) return "November";
            return "December";
        }

        //This function converts the season from string to int
        public int convertMonthToInt(string month)
        {
            month = month.ToLower();

            if (month == "january") return 1;
            if (month == "february") return 2;
            if (month == "march") return 3;
            if (month == "april") return 4;
            if (month == "may") return 5;
            if (month == "june") return 6;
            if (month == "july") return 7;
            if (month == "august") return 8;
            if (month == "september") return 9;
            if (month == "october") return 10;
            if (month == "november") return 11;
            if (month == "december") return 12;
            return 0;
        }

        //This function converts the days which found by Zeller's algorithm from int to string
        public string convertDayOfWeek()
        {
            if (dayOfWeek == 0) return "Saturday";
            if (dayOfWeek == 1) return "Sunday";
            if (dayOfWeek == 2) return "Monday";
            if (dayOfWeek == 3) return "Tuesday";
            if (dayOfWeek == 4) return "Wednesday";
            if (dayOfWeek == 5) return "Thursday";
            return "Friday";
        }

        //This function finds day by using Zeller algorithm
        public void setDayOfWeek()
        {
            int q = initialDay;
            int m = initialMonth;
            int k = initialYear % 100;
            int j = initialYear / 100;

            if (m == 1 || m == 2)
            {
                m += 12;
                k = (initialYear - 1) % 100;
                j = (initialYear - 1) / 100;
            }

            dayOfWeek = q + 13 * (m + 1) / 5 + k + k / 4 + j / 4 + 5 * j;
            dayOfWeek %= 7;
        }

        //This function finds intial and end date
        public bool isInitialDateSmallerThanOrEqualEndDate()
        {
            if (initialYear > endYear) return false;
            if (initialYear < endYear) return true;
            if (initialMonth > endMonth) return false;
            if (initialMonth < endMonth) return true;
            if (initialDay > endDay) return false;
            return true;
        }

        public void printSeason()
        {
            Console.WriteLine();
            Console.WriteLine(convertSeason());
        }

        public void printDate()
        {
            Console.Write(initialDay);
            Console.Write(" ");
            Console.Write(convertMonthToString());
            Console.Write(" ");
            Console.Write(initialYear);
            Console.Write(" ");
            Console.WriteLine(convertDayOfWeek());
        }

        //This function calculates leap years
        public bool isYearLeap(int year)
        {
            return (year % 4 == 0 && year % 100 != 0) || year % 400 == 0;
        }

        //This function calculates last day of month
        public int getLastDayOfMonth(int month, int year)
        {
            if (month == 2)
            {
                return isYearLeap(year) ? 29 : 28;
            }

            if (month % 2 != 0 && month < 8 || month % 2 == 0 && month > 7)
            {
                return 31;
            }

            return 30;
        }

        public int getLastDayOfInitialMonth()
        {
            return getLastDayOfMonth(initialMonth, initialYear);
        }

        public int getLastDayOfEndMonth()
        {
            return getLastDayOfMonth(endMonth, endYear);
        }

        //This function calculates increments
        public void incrementDate()
        {
            for (int i = 0; i < n; ++i)
            {
                if (initialDay != getLastDayOfInitialMonth())
                {
                    initialDay++;
                }
                else
                {
                    initialDay = 1;

                    if (initialMonth != 12)
                    {
                        initialMonth++;
                    }
                    else
                    {
                        initialMonth = 1;
                        initialYear++;
                    }
                }
            }
        }

        public bool checkParams()
        {
            if (initialYear != -1 && initialYear < 2015)
            {
                Console.WriteLine("First year is invalid.");
                return false;
            }

            if (initialMonth == 0)
            {
                Console.WriteLine("First month is invalid.");
                return false;
            }

            if (initialDay != -1 && (initialDay < 1 || initialDay > getLastDayOfInitialMonth()))
            {
                Console.WriteLine("First day is invalid.");
                return false;
            }

            if (endYear != -1 && endYear < 2015)
            {
                Console.WriteLine("Second year is invalid.");
                return false;
            }

            if (endMonth == 0)
            {
                Console.WriteLine("Second month is invalid.");
                return false;
            }

            if (endDay != -1 && (endDay < 1 || endDay > getLastDayOfEndMonth()))
            {
                Console.WriteLine("Second day is invalid.");
                return false;
            }

            if (n != -1 && n == 0)
            {
                Console.WriteLine("N must be a positive integer.");
                return false;
            }

            return true;
        }

        //This function swaps dates if initial date comes after end date
        public void swapDatesIfNecessary()
        {
            if (!isInitialDateSmallerThanOrEqualEndDate())
            {
                int temp;

                temp = initialYear;
                initialYear = endYear;
                endYear = temp;

                temp = initialMonth;
                initialMonth = endMonth;
                endMonth = temp;

                temp = initialDay;
                initialDay = endDay;
                endDay = temp;
            }
        }

        //This function gets parameters from user
        public void getParams()
        {
            do
            {
                Console.Write("Enter first year: ");
                initialYear = Convert.ToInt32(Console.ReadLine());
            }
            while (!checkParams());

            do
            {
                Console.Write("Enter first month: ");
                initialMonth = convertMonthToInt(Console.ReadLine());
            }
            while (!checkParams());

            do
            {
                Console.Write("Enter first day: ");
                initialDay = Convert.ToInt32(Console.ReadLine());
            }
            while (!checkParams());

            do
            {
                Console.Write("Enter second year: ");
                endYear = Convert.ToInt32(Console.ReadLine());
            }
            while (!checkParams());

            do
            {
                Console.Write("Enter second month: ");
                endMonth = convertMonthToInt(Console.ReadLine());
            }
            while (!checkParams());

            do
            {
                Console.Write("Enter second day: ");
                endDay = Convert.ToInt32(Console.ReadLine());
            }
            while (!checkParams());

            do
            {
                Console.Write("Enter N: ");
                n = Convert.ToInt32(Console.ReadLine());
            }
            while (!checkParams());

            swapDatesIfNecessary();
        }

        //This function calculates and prints to console everything
        public void initializeTask()
        {
            getParams();

            while (isInitialDateSmallerThanOrEqualEndDate())
            {
                if (shouldSeasonBeUpdated())
                {
                    setCurrentSeason();
                    printSeason();
                }

                setDayOfWeek();
                printDate();
                incrementDate();
            }
        }

        public static void Main(string[] args)
        {
            Program task = new Program();
            task.initializeTask();
        }
    }
}
