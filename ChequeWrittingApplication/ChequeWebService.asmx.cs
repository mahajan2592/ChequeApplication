using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace ChequeService
{
    /// <summary>
    /// Summary description for ChequeWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class ChequeWebService : System.Web.Services.WebService
    {
        //Word for every digit from 0 to 9
        string[] digits_words = {
            "Zero",
            "One",
            "Two",
            "Three",
            "Four",
            "Five",
            "Six",
            "Seven",
            "Eight",
            "Nine"
         };

        public string Tens(string tensdigit)
        {
            int _Number = Convert.ToInt32(tensdigit);
            if (_Number != 0)
            {
                switch (_Number)
                {
                    case 10:
                        return "Ten";

                    case 11:
                        return "Eleven";

                    case 12:
                        return "Twelve";

                    case 13:
                        return "Thirteen";

                    case 14:
                        return "Fourteen";

                    case 15:
                        return "Fifteen";

                    case 16:
                        return "Sixteen";

                    case 17:
                        return "Seventeen";

                    case 18:
                        return "Eighteen";

                    case 19:
                        return "Nineteen";

                    case 20:
                        return "Twenty";
                    case 30:
                        return "Thirty";
                    case 40:
                        return "Fourty";
                    case 50:
                        return "Fifty";
                    case 60:
                        return "Sixty";
                    case 70:
                        return "Seventy";
                    case 80:
                        return "Eighty";
                    case 90:
                        return "Ninety";
                    default:
                        if (_Number > 0)
                        {
                            string secondConvert = string.Empty;
                            string firstConvert = Tens(tensdigit.Substring(0, 1) + "0");
                            for (int k = 0; k < digits_words.Length; k++)
                            {
                                if (Convert.ToInt32(tensdigit.Substring(1)) == k)
                                {
                                    secondConvert = digits_words[k];
                                }
                            }

                            return firstConvert + " " + secondConvert;
                        }
                        break;
                }
            }
            return "";
        }

        public string Three(string hundredDigit)
        {
            int _Number = Convert.ToInt32(hundredDigit);
            if (_Number != 0)
            {
                string firstConvert = string.Empty;
                string secondConvert = string.Empty;

                for (int i = 0; i < digits_words.Length; i++)
                {
                    if (Convert.ToInt32(hundredDigit.Substring(0, 1)) == i && Convert.ToInt32(hundredDigit.Substring(0, 1)) != 0)
                    {
                        firstConvert = digits_words[i] + " Hundred";
                    }
                }

                secondConvert = Tens(hundredDigit.Substring(1, 2));
                return firstConvert + " " + secondConvert;
            }
            return "";
        }

        public string WithoutDecimalNumberInput(string Number)
        {
            int _Number = Convert.ToInt32(Number);
            if (_Number != 0)
            {
                if (Number.Length == 1)
                {
                    for (int k = 0; k < digits_words.Length; k++)
                    {
                        if (Convert.ToInt32(Number) == k)
                        {
                            return digits_words[k] + " Dollar";
                        }
                    }

                }
                else if (Number.Length == 2)
                {
                    return Tens(Number) + " Dollar";
                }
                else if (Number.Length == 3)
                {
                    return Three(Number) + " Dollar"; ;
                }
            }
            return "";
        }


        [WebMethod]
        public string ChequeDetails(string Name, string Number)
        {

            if (Number.Contains('.'))
            {
                //Get all the number after decimal
                string digits_after_decimal = Number.Substring(Number.LastIndexOf('.') + 1);

                //Convert 'digits_after_decimal' from string to int
                int digits_after_decimal_number = Int16.Parse(digits_after_decimal);

                // If entered number is only of one digit
                if (digits_after_decimal.Length == 1)
                {
                    for (int k = 0; k < digits_words.Length; k++)
                    {
                        if (digits_after_decimal_number == k)
                        {
                            return WithoutDecimalNumberInput(Number.Substring(0, Number.IndexOf('.'))) + " AND " + digits_words[k] + " Cents";
                        }
                    }
                }

                // If entered number is only of two digit
                else if (digits_after_decimal.Length == 2)
                {
                    if (Convert.ToInt32(digits_after_decimal) != 0)
                    {
                        return WithoutDecimalNumberInput(Number.Substring(0, Number.IndexOf('.'))) + " AND " + Tens(digits_after_decimal) + " Cents";
                    }
                    else
                    {
                        return WithoutDecimalNumberInput(Number.Substring(0, Number.IndexOf('.')));
                    }


                }

                // If entered number is only of hundred digit
                else if (digits_after_decimal.Length == 3)
                {
                    if (Convert.ToInt32(digits_after_decimal) != 0)
                    {
                        return WithoutDecimalNumberInput(Number.Substring(0, Number.IndexOf('.'))) + " AND " + Three(digits_after_decimal) + " Cents";
                    }
                    else
                    {
                        return WithoutDecimalNumberInput(Number.Substring(0, Number.IndexOf('.')));
                    }

                }

                // Same way more condition can be added for thousand, millions ,billions and so on

            }
            else
            {
                // If entered number is not only integer 
                if (Convert.ToInt32(Number) != 0)
                {
                    return WithoutDecimalNumberInput(Number);
                }
            }
            return "";
        }
    }
}
