namespace UserApi.Exception
{
    public class InValidLogin : ApplicationException
    {
        public InValidLogin(string? message) : base(message)
        {
        }
    }
}
