# DCode_OpenAI

## Description

Lib - Integração com OpenAI.

- ⚡ C#
- ⚡ .Net 7.0

## Getting Started

### Dependencies

- ⚡ RestSharp - 110.2.0
- ⚡ Standard.AI.OpenAI - 0.3.0

### Example

```
var  res = await OpenAICompletionRequest.GetOpenAIResponseJson(new OpenAICompletionRequest(
       endPoint: "https://api.openai.com/v1/completions",
       apiKey: "xxxx",
       message: "Qual a raiz Quadrada de 25?"
       ));
```

## Authors

Igo Ferreira Pinheiro
[![Linkedin Badge](https://img.shields.io/badge/-LinkedIn-blue?style=flat-square&logo=Linkedin&logoColor=white&link=https://www.linkedin.com/in/igo-pinheiro-36b26255/)](https://www.linkedin.com/in/igo-pinheiro-36b26255/)

## Version History

* 0.1
    * Initial Release

## Acknowledgments

Inspiration, code snippets, etc.
* [API Reference OpenAI](https://platform.openai.com/docs/api-reference/)
