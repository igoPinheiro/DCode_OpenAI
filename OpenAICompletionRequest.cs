using Newtonsoft.Json;
namespace DCode_OpenAI
{
    public class OpenAICompletionRequest : OpenAIRequest
    {
        [JsonProperty("prompt")]
        public string Prompt { get; set; } = string.Empty;

        private OpenAICompletionRequest() { }

        public OpenAICompletionRequest(string endPoint, string apiKey, string message, string model = "text-davinci-003", double? temperature = null, int? qtOpCplt = null)
        {
            this.ApiKey = apiKey;
            this.EndPoint = endPoint;
            this.Model = model;
            this.N = qtOpCplt ?? 1;
            this.Prompt = message;
            this.Temperature = temperature;
        }

        public static async Task<HttpResponseMessage> GetOpenAIResponse(OpenAICompletionRequest modelRqst)
        {
            try
            {
                modelRqst.ValidObj();

                String jsonRequest = JsonConvert.SerializeObject(modelRqst, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });

                return await GetOpenAIResponse(modelRqst.EndPoint, modelRqst.ApiKey, jsonRequest);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static async Task<string> GetOpenAIResponseJson(OpenAICompletionRequest modelRqst)
        {
            try
            {
                var response = await GetOpenAIResponse(modelRqst);

                var responseBody = await response.Content.ReadAsStringAsync();
                return responseBody;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
