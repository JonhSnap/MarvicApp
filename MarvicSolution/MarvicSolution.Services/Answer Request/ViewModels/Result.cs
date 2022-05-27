namespace MarvicSolution.Services.Answer_Request.ViewModels
{
    public class Result
    {
        public double Score { get; set; }
        public string CreateDate { get; set; }
        public Result()
        {
            Score = 0;
            CreateDate = string.Empty;
        }
    }
}
