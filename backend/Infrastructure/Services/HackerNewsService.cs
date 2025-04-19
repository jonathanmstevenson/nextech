using System.Net.Http.Json;
using Application.DTOs;
using Application.Interfaces;
using Microsoft.Extensions.Caching.Memory;

namespace Infrastructure.Services
{
    public class HackerNewsService : IHackerNewsService
    {
        private readonly IMemoryCache _cache;

        public HackerNewsService(IMemoryCache cache)
        {
            _cache = cache;
        }


        public async Task<IEnumerable<StoryDTO>> GetLatestStories(int pageNumber, int pageSize)
        {
            return await _cache.GetOrCreateAsync("latest_stories", async entry =>
            {
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5);
                return await FetchStoriesFromApi();
            }) ?? new List<StoryDTO>();
        }

        public Task<IEnumerable<StoryDTO>> SearchLatestStories(string term, int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }






        private async Task<List<StoryDTO>> FetchStoriesFromApi()
        {
            using var httpClient = new HttpClient();
            var ids = await httpClient.GetFromJsonAsync<List<int>>("https://hacker-news.firebaseio.com/v0/newstories.json?print=pretty");
            var tasks = ids/*.Take(10)*/.Select(id =>
                httpClient.GetFromJsonAsync<StoryDTO>($"https://hacker-news.firebaseio.com/v0/item/{id}.json?print=pretty")
            );
            var stories = await Task.WhenAll(tasks);
            return stories.Where(x => x != null).Cast<StoryDTO>().Where(x => x.Url != null).ToList();
        }

    }
}