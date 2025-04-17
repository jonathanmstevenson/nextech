using Application.DTOs;

namespace Application.Interfaces
{
    public interface IHackerNewsService
    {
        Task<IEnumerable<StoryDTO>> GetLatestStories(int pageNumber, int pageSize);
        Task<IEnumerable<StoryDTO>> SearchLatestStories(string term, int pageNumber, int pageSize);
    }
}