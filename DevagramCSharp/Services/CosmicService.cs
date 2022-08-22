using DevagramCSharp.Dtos;
using System.Net.Http.Headers;

namespace DevagramCSharp.Services
{
    public class CosmicService
    {
        public string EnviarImagem(ImagemDto imagemdto)
        {
            Stream imagem;

            imagem =  imagemdto.Imagem.OpenReadStream();

            var client = new HttpClient();

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "KsOwFyH050F1Gxa6E0HFfsQ1nunSBtuTnGlbVIO0l9eskbOyx0");

            var request = new HttpRequestMessage(HttpMethod.Post, "file");
            var conteudo = new MultipartFormDataContent
            {
                {new StreamContent(imagem), "media", imagemdto.Nome }
            };

            request.Content = conteudo;
            var retornoreq = client.PostAsync("https://upload.cosmicjs.com/v2/buckets/cdc85520-1fea-11ed-89ff-b958cd48a9a7/media", request.Content).Result;

            var urlretorno = retornoreq.Content.ReadFromJsonAsync<CosmicRespostaDto>();
;
            return urlretorno.Result.media.url;
        }
    }
}
