using Newtonsoft.Json;

namespace DCode_OpenAI
{
    public class OpenAIChatCompletionRequest : OpenAIRequest
    {
        [JsonProperty("messages")]
        public List<Message>? Messages { get; set; }

        private OpenAIChatCompletionRequest() { }

        public OpenAIChatCompletionRequest(string endPoint, string apiKey, string message,string model = "gpt-3.5-turbo", double? temperature = null, int? qtOpCplt = null  )
        {
            this.ApiKey = apiKey;
            this.EndPoint = endPoint;
            this.Messages = new List<Message>() { new Message { Content = message, Role = "user" } };
            this.Model = model;
            this.N = qtOpCplt ?? 1;
            this.Temperature = temperature;
        }

        public static async Task<HttpResponseMessage> GetOpenAIResponse(OpenAIChatCompletionRequest modelRqst)
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

        public static async Task<string> GetOpenAIResponseJson(OpenAIChatCompletionRequest modelRqst)
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
