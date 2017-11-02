namespace Models.Exceptions
{
    public class InvalidNameAndPasswordMatchException : CustomLogInException
    {
        public override string Message
        {
            get
            {
                return "Name And Password don't match!";
            }
        }
    }
}