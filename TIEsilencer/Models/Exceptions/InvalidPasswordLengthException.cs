namespace Models.Exceptions
{
    public class InvalidPasswordLengthException : InvalidPasswordException
    {
        public override string Message
        {
            get
            {
                return "Password must be at least 6 characters long";
            }
        }
    }
}