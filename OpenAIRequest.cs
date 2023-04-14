using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DCode_OpenAI
{
    public abstract class OpenAIRequest 
    {
        [JsonIgnore]
        [Required(AllowEmptyStrings = false, ErrorMessage = "ApiKey não identificado!")]
        public string ApiKey { get; set; } = string.Empty;

        [JsonIgnore]
        [Required(AllowEmptyStrings = false, ErrorMessage = "EndPoint não identificado!")]
        public string EndPoint { get; set; } = string.Empty;

        [JsonProperty("max_tokens")]
        public int? Max_Tokens { get; set; }

        [JsonProperty("model")]
        [JsonRequired]
        [Required(AllowEmptyStrings =false, ErrorMessage ="Model is Required")]
        public string Model { get; set; } = string.Empty;

        [JsonProperty("nx")]
        public int N { get; set; } = 1;

        /// <summary>
        /// Temperatura de amostragem usar, entre 0 e 2. Valores mais altos, como 0,8, tornarão a saída mais aleatória, 
        /// enquanto valores mais baixos, como 0,2, a tornarão mais focada e determinística. Geralmente recomenda-se alterar isso ou top_pmas não ambos
        /// </summary>
        [JsonProperty("temperature")]
        [Range(minimum: 0, maximum: 2, ErrorMessage = "Valor mínimo 0, valor máximo 2 para o campo Temperature")]
        public double? Temperature { get; set; }
        /// <summary>
        /// Uma alternativa para amostragem com temperatura, chamada de amostragem de núcleo, onde o modelo considera os resultados dos tokens com massa de probabilidade top_p.
        /// Portanto, 0,1 significa que apenas os tokens que compõem a massa de probabilidade de 10% são considerados. Geralmente recomendamos alterar isso ou, temperaturemas não ambos
        /// </summary>
        [JsonProperty("top_p")]
        [Range(minimum:0,maximum:2,ErrorMessage ="Valor mínimo 0, valor máximo 2 para o campo Top_P")]
        public int? Top_P { get; set; }
       
        [JsonProperty("stream")]
        public bool Stream { get; set; } = false;     

        protected static async Task<HttpResponseMessage> GetOpenAIResponse(string endPoint, string apiKey, string jsonContent)
        {
            try
            {
                var httpClient = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Post, endPoint);
                request.Headers.Add("Authorization", $"Bearer {apiKey}");
                request.Content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                var response = await httpClient.SendAsync(request);
                var responseBody = await response.Content.ReadAsStringAsync();

                return response;
              //  return responseBody;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }
        protected void ValidObj()
        {
            StringBuilder msg = new StringBuilder();

            List<ValidationResult> result = new List<ValidationResult>();
            bool valid = Validator.TryValidateObject(this, new ValidationContext(this), result, true);

            if (!valid)
            {
                foreach (ValidationResult r in result)
                    msg.AppendLine(r.ErrorMessage);

                if (msg.Length > 0) throw new ArgumentException(msg.ToString());
            }
        }
    }
}
