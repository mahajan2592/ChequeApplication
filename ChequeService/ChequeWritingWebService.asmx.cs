using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace ChequeService
{
    /// <summary>
    /// Summary description for ChequeWritingWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class ChequeWritingWebService : System.Web.Services.WebService
    {               

        public static String ones(String Number)
        {
            int _Number = Convert.ToInt32(Number);
            String name = "";
            switch (_Number)
            {
                case 1:
                    name = "One";
                    break;
                case 2:
                    name = "Two";
                    break;
                case 3:
                    name = "Three";
                    break;
                case 4:
                    name = "Four";
                    break;
                case 5:
                    name = "Five";
                    break;
                case 6:
                    name = "Six";
                    break;
                case 7:
                    name = "Seven";
                    break;
                case 8:
                    name = "Eight";
                    break;
                case 9:
                    name = "Nine";
                    break;
            }
            return name;
        }

        public static String tens(String Number)
        {
            int _Number = Convert.ToInt32(Number);
            String name = null;
            switch (_Number)
            {
                case 10:
                    name = "Ten";
                    break;
                case 11:
                    name = "Eleven";
                    break;
                case 12:
                    name = "Twelve";
                    break;
                case 13:
                    name = "Thirteen";
                    break;
                case 14:
                    name = "Fourteen";
                    break;
                case 15:
                    name = "Fifteen";
                    break;
                case 16:
                    name = "Sixteen";
                    break;
                case 17:
                    name = "Seventeen";
                    break;
                case 18:
                    name = "Eighteen";
                    break;
                case 19:
                    name = "Nineteen";
                    break;
                case 20:
                    name = "Twenty";
                    break;
                case 30:
                    name = "Thirty";
                    break;
                case 40:
                    name = "Fourty";
                    break;
                case 50:
                    name = "Fifty";
                    break;
                case 60:
                    name = "Sixty";
                    break;
                case 70:
                    name = "Seventy";
                    break;
                case 80:
                    name = "Eighty";
                    break;
                case 90:
                    name = "Ninety";
                    break;
                default:
                    if (_Number > 0)
                    {
                        name = tens(Number.Substring(0, 1) + "0") + "-" + ones(Number.Substring(1));
                    }
                    break;
            }
            return name;
        }

        public static String ConvertNumberToWords(String Number)
        {
            string word = "";
            double dblAmt = (Convert.ToDouble(Number));
            int numDigits = Number.Length;
            switch (numDigits)
            {

                case 1: word = ones(Number);
                    return word;
                case 2: word = tens(Number);
                    return word;
                case 3:
                    if (Number.Length == 3) 
                    {
                        word = ones(Number.Substring(0, 1)) + " Hundred AND " + tens(Number.Substring(1, 2));
                        return word;
                    }
                    else
                    {
                        word = ones(Number.Substring(0, 1)) + " Hundred AND" + tens(Number.Substring(1, 2))+" AND ";
                        return word;
                    }
                  
                case 4:
                    if (Number.Substring(1, 1).Equals("0"))
                    {
                        word = ones(Number.Substring(0, 1)) + " Thousand AND " + tens(Number.Substring(2, 2));
                        return word;
                    }
                    else
                    {
                        word = ones(Number.Substring(0, 1)) + " Thousand AND " + ones(Number.Substring(1, 1)) + " Hundred AND " + tens(Number.Substring(2, 2));
                        return word;
                    }
                case 5:
                    if (Number.Substring(2, 1).Equals("0") && (!(Number.Substring(3, 1).Equals("0"))))
                    {
                        word = tens(Number.Substring(0, 2)) + " Thousand AND " + tens(Number.Substring(3, 2));
                        return word;
                    }
                    else if(Number.Substring(2, 1).Equals("0") && Number.Substring(3, 1).Equals("0"))
                    {
                        word = tens(Number.Substring(0, 2)) + " Thousand AND " + ones(Number.Substring(4, 1));
                        return word;
                    }
                    else
                    {
                        word = tens(Number.Substring(0, 2)) + " Thousand AND " + ones(Number.Substring(2, 1)) + " Hundred " + tens(Number.Substring(3, 2));
                        return word;
                    }
            }

            return "";
        }

        [WebMethod]
        public string ChequeService(string InputNumber, string Name)
        {           
            InputNumber = Convert.ToDouble(InputNumber).ToString();
            if (InputNumber.Contains("-"))
            {
                return "The number entered is not in correct format";
            }
            if (InputNumber == "0")
            {
                return "The number entered is Zero";
            }
            else
            {
                 return ConvertNumberToWords(InputNumber);
            }
        }
    }
}
