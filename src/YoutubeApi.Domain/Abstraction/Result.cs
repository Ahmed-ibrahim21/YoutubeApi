namespace YoutubeApi.Domain.Abstraction
{
    public class Result<TEntity> where TEntity : BaseEntity
    {
        //Success
        private Result(
            TEntity? data,int statusCode)
        {
            Data = data;
            IsNotSuccessfull = false;
            StatusCode = statusCode;
        }

        //Success without Data
        private Result(int statusCode)
        {
            IsNotSuccessfull = false;
            StatusCode =statusCode;
        }

        //Fail with one Error
        private Result(
            int statusCode,string errorCode,string errorMessage)
        {
            IsNotSuccessfull = true;
            StatusCode =statusCode;
            Errors = new()
            {
                { errorCode,errorMessage }
            };
        }

        //Fail with Many error
        private Result(int statusCode,Dictionary<string,string> errors)
        {
            IsNotSuccessfull = true;
            StatusCode = statusCode;
            Errors = errors;
        }

        public TEntity? Data { get; set; }

        public int StatusCode { get; set; }

        public bool IsNotSuccessfull { get; set; }

        public Dictionary<string,string> Errors { get; set; }

        public static Result<TEntity> Success(
            TEntity data,
            int statusCode) => new(data,statusCode);

        public static Result<TEntity> Success(int statusCode) => new(statusCode);

        public static Result<TEntity> Failed(int statusCode,string errorCode, string errorMessage) => new(statusCode,errorCode,errorMessage);
        public static Result<TEntity> Failed(int statusCode,Dictionary<string,string> errors) => new(statusCode,errors);
    }

    public class NoContentDto;
}
