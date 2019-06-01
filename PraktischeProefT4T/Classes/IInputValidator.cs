namespace PraktischeProefT4T.Classes
{
    public interface IInputValidator
    {
        bool CheckStringForInt(string input);
        bool ValidateTalk(string inputTitle, string inputDuration, out string title, out int duration);
    }
}