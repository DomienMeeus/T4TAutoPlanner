using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PraktischeProefT4T.Classes
{
    public class InputValidator : IInputValidator
    {
        public bool ValidateTalk(string inputTitle, string inputDuration, out string title, out int duration)
        {
            duration = -1;
            if(inputDuration == "lightning")
            {
                duration = 5;
            }else if (!Int32.TryParse(inputDuration, out duration)){
                throw new Exception("Invalid Duration.");
            }
            if(inputTitle=="" || inputTitle == null)
            {
                throw new Exception("Title is empty");

            }
            else if (CheckStringForInt(inputTitle))
            {
                throw new Exception("Title has a number in it.");
            }else if (inputTitle.Contains("lightning"))
            {
                throw new Exception("You can't use the word 'lightning' in the title");

            }
            else
            {
                title = inputTitle;
            }
            if(title == null || duration < 0)
            {
                return false;
            }
            else
            {
                return true;
            }


        }
        public  bool CheckStringForInt(string input)
        {
            

            char[] charArr = input.ToCharArray();
            
            foreach (char teken in charArr)
            {
                if (Char.IsDigit(teken))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
