namespace SimpleCalculator
{
    public class Result<T>
    {
        public T Value { get; private set; }
        public string Error { get; private set; }
        public bool IsSuccess { get; private set; }
        public bool IsFailure => !IsSuccess;

        private Result(T value)
        {
            Value = value;
            IsSuccess = true;
        }

        private Result(string error)
        {
            Error = error;
            IsSuccess = false;
        }

        public static Result<T> Ok(T value) => new Result<T>(value);
        public static Result<T> Fail(string error) => new Result<T>(error);

        public void Match(Action<T> onSuccess, Action<string> onFailure)
        {
            if (IsSuccess)
                onSuccess(Value);
            else
                onFailure(Error);
        }
    }
}
