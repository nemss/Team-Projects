namespace Models.Exceptions
{
    public class InvalidPasswordSpecialSymbol : InvalidPasswordDigitException
    {
        public override string Message
        {
            get
            {
                return "Password must containt at least 1 special symbol";
            }
        }
    }
}