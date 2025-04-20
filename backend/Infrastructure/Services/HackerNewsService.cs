using System.Net.Http.Json;
using Application.DTOs;
using Application.Interfaces;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Services
{
    public class HackerNewsService : IHackerNewsService
    {
        private readonly IMemoryCache _cache;
        private readonly ILogger<IHackerNewsService> _logger;

        public HackerNewsService(IMemoryCache cache, ILogger<IHackerNewsService> logger)
        {
            _cache = cache;
            _logger = logger;
        }


        public async Task<PaginationDTO<StoryDTO>> GetLatestStories(int pageNumber, int pageSize, string? searchTerm = null)
        {
            if (pageNumber < 1) pageNumber = 1;
            if (pageSize < 1) pageSize = 20;

            var latest = await _cache.GetOrCreateAsync("latest_stories", async entry =>
            {
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5);
                try
                {
                    return await FetchStoriesFromApi();
                }
                catch (Exception exc)
                {
                    _logger?.LogError(exc, "Failed to fetch stories from API.");
                    return Enumerable.Empty<StoryDTO>();
                }
            });

            if (!string.IsNullOrWhiteSpace(searchTerm))
                latest = latest?.Where(x => x.Title?.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) == true).ToList();

            latest ??= [];
            return new PaginationDTO<StoryDTO>(latest.Skip((pageNumber - 1) * pageSize).Take(pageSize), latest.Count());
        }




        private static async Task<List<StoryDTO>> FetchStoriesFromApi()
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