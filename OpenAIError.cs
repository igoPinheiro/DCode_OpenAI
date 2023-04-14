﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCode_OpenAI
{
    public class OpenAIError
    {
        [JsonProperty("message")]
        public string? Message { get; set; }
        [JsonProperty("type")]
        public string? Type { get; set; }
        [JsonProperty("code")]
        public string? Code { get; set; }
        [JsonProperty("param")]
        public string? Param { get; set; }
    }
}

