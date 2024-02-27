using Newtonsoft.Json;
using Shared.Models;
using System.Net.Http.Json;


namespace AppLogic.Services.TagService
{
    public class TagService : ITagService
    {
        public HttpClient Client { get; set; } = new()
        {
            BaseAddress = new Uri("https://localhost:7249/api/")
        };



        public async Task<TagModel> GetTagbyId(int id)
        {

            var response = await Client.GetAsync($"Tag/Tag/{id}");

            if (response.IsSuccessStatusCode)
            {
                string tagJson = await response.Content.ReadAsStringAsync();

                TagModel? tag = JsonConvert.DeserializeObject<TagModel>(tagJson);
                if (tag != null)
                {
                    return tag;
                }
                throw new JsonException();
            }

            throw new HttpRequestException($"Error getting tag with ID: {id}");
        }

        public async Task<List<TagModelAPIModel>> GetTags()
        {

            var response = await Client.GetAsync("Tag/Tags");

            if (response.IsSuccessStatusCode)
            {
                string tagjson = await response.Content.ReadAsStringAsync();

                List<TagModelAPIModel>? tags = JsonConvert.DeserializeObject<List<TagModelAPIModel>>(tagjson);

                if (tags != null)
                {
                    return tags;
                }

                throw new JsonException();
            }

            throw new HttpRequestException();
        }



        public async Task PostTag(TagModelAPIModel tag)
        {
            await Client.PostAsJsonAsync("Tag/PostTag", tag);
        }
    }
}

