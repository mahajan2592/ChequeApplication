using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChequeWritingApp
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void submitInput_Click(object sender, EventArgs e)
        {
            localhost.ChequeWritingWebService chqService = new localhost.ChequeWritingWebService();
            string Name = ChequeName.Text.ToString();
            string Number = ChequeValue.Text.ToString();
            if (Number.Length < 12)
            {
                if (Number.Contains('.'))
                {
                    string DecimalPlaceNumber = Number.Substring(Number.LastIndexOf('.') + 1);
                    string NonDecimalPlaceNumber= Number.Substring(0, Number.IndexOf('.'));
                    if (NonDecimalPlaceNumber.Length < 6)
                    {
                        string ConvertedNumberToWord = chqService.ChequeService(NonDecimalPlaceNumber, Name);
                        if (!(string.IsNullOrEmpty(Name)))
                        {
                            PersonName.Text = Name;
                        }
                        NumberWithDecimal.Text = ConvertedNumberToWord.ToUpper().ToString() +" DOLLARS AND ";
                    }
                    if (DecimalPlaceNumber.Length < 6)
                    {
                        string ConvertedNumberToWord = chqService.ChequeService(DecimalPlaceNumber, Name);
                        
                            NumberInWords.Text = ConvertedNumberToWord.ToUpper().ToString().Replace("AND CENTS", "") + " CENTS";
                       
                    }
                }
                else if(Number.Length < 6)
                {
                    string ConvertedNumberToWord = chqService.ChequeService(Number, Name);
                    if (!(string.IsNullOrEmpty(Name)))
                    {
                        PersonName.Text = Name;
                    }
                    NumberInWords.Text = ConvertedNumberToWord.ToString().Replace("AND DOLLARS","") + " DOLLARS";
                }
            }
            else
            {
                NumberWithDecimal.Text = "";
                NumberInWords.Text = "Please Enter the Number withing the range of 5 digits before and after decimal places ";
            }
            
        }
    }
}