using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Globalization;

namespace DCode_OpenAI
{
    public class OpenAIResponse
    {
        [JsonProperty("id")]
        public string? Id { get; set; }

        [JsonProperty("object")]
        public string? Object { get; set; }

        [JsonProperty("created")]
        public long? Created { get; set; }

        [JsonProperty("choices")]
        public Choice[]? Choices { get; set; }

        [JsonProperty("usage")]
        public Usage? Usage { get; set; }
    }

    public class Choice
    {
        [JsonProperty("index")]
        public long? Index { get; set; }

        [JsonProperty("message")]
        public Message? Message { get; set; }

        [JsonProperty("finish_reason")]
        public string? FinishReason { get; set; }
    }

    public  class Message
    {
        [JsonProperty("role")]
        public string? Role { get; set; }

        [JsonProperty("content")]
        public string? Content { get; set; }
    }

    public  class Usage
    {
        [JsonProperty("prompt_tokens")]
        public long? PromptTokens { get; set; }

        [JsonProperty("completion_tokens")]
        public long? CompletionTokens { get; set; }

        [JsonProperty("total_tokens")]
        public long? TotalTokens { get; set; }
    }

   

    public static class Serialize
    {
        public static string ToJson(this OpenAIResponse self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }

    public static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
