using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SouthAfricanID
{
    class Program
    {
        public static void Main()
        {
            Console.WriteLine("Please input your ID number:");
            string id = Console.ReadLine();
            if(isID(id)){
                Console.WriteLine("Valid ID Number");
            }else{
                Console.WriteLine("Invalid ID Number");
            }
        }
        private static bool isID(string id)
        {
            try
            {
                //removes every spaces maybe contained in the input
                id = id.Replace(" ", "");
                if (id.Length != 13)
                {
                    return false;
                }
                else
                {
                    //check if id contains only digits
                    long j = Convert.ToInt64(id);
                }

                //ensuring no date (day) is above 31 and month above 12
                if (Convert.ToInt16(id.Substring(4, 2)) > 31 || Convert.ToInt16(id.Substring(2, 2)) > 12)
                {
                    return false;
                }

                //ensures that Jan, Mar, May, Jul, Aug, Oct, Dec are the only months can end on the 31st
                if ((Convert.ToInt16(id.Substring(2, 3)) == 02 || Convert.ToInt16(id.Substring(2, 3)) == 04 || Convert.ToInt16(id.Substring(2, 3)) == 06 ||
                    Convert.ToInt16(id.Substring(2, 3)) == 09 || Convert.ToInt16(id.Substring(2, 3)) == 11 && (Convert.ToInt16(id.Substring(4, 2)) >= 31)))
                {
                    return false;
                }

                //ensures that Feb can only ends on the 29th
                if (Convert.ToInt16(id.Substring(2, 2)) == 2 && (Convert.ToInt16(id.Substring(4, 2))) > 29)
                {
                    return false;
                }

                //if the date of birth is 29 Feb, check if it's a leap year
                if (Convert.ToInt16(id.Substring(2, 2)) == 2 && (Convert.ToInt16(id.Substring(4, 2))) == 29)
                {
                    int yy = Convert.ToInt16(id.Substring(0, 2));
                    DateTime currentDate = DateTime.Today;
                    int currentYear = Convert.ToInt16(((currentDate.ToString()).Substring(8, 2)));
                    if (yy > currentYear)
                    {
                        yy = Convert.ToInt16("19" + yy);
                    }
                    else
                    {
                        yy = Convert.ToInt16("20" + yy);
                    }
                    if (yy.ToString().Length < 4)
                    {
                        yy *= 10;
                    }
                    if (!(yy % 400 == 0 && yy % 4 == 0))
                    {
                        return false;
                    }
                }

                int sum = 0; bool even = false;
                for (int i = 0; i < 13; ++i)
                {
                    if (even == false)
                    {
                        sum += Convert.ToInt16(id.Substring(i, 1));
                    }
                    else
                    {
                        int x = Convert.ToInt16(id.Substring(i, 1)) * 2;
                        if (x.ToString().Length > 1)
                        {
                            sum += Convert.ToInt16(Convert.ToInt16(x.ToString().Substring(0, 1)) + Convert.ToInt16(x.ToString().Substring(1, 1)));
                        }
                        else
                        {
                            sum += x;
                        }
                    }
                    even = !even;
                }
                if (sum % 10 != 0)
                {
                    return false;
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
