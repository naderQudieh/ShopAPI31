using Newtonsoft.Json;

namespace Core.Middlewares
{
    public class ErrorDetails
    {
        public string ErrorMessage { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}