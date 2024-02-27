using Shared.Models;


namespace AppLogic.Services.TagService
{
    public interface ITagService
    {
        public HttpClient Client { get; set; }

        public Task<List<TagModelAPIModel>> GetTags();


        public Task<TagModel> GetTagbyId(int id);


        public Task PostTag(TagModelAPIModel tag);
    }
}
