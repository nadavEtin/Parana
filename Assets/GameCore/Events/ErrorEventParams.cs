namespace GameCore.Events
{
    public class ErrorEventParams : BaseEventParams
    {
        private readonly string _errorMsg;
        public string ErrorMessage => _errorMsg;

        public ErrorEventParams(string errorMsg)
        {
            _errorMsg = errorMsg;
        }
    }
}