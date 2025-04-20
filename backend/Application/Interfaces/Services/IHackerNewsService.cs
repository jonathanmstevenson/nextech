using Application.DTOs;

namespace Application.Interfaces
{
    public interface IHackerNewsService
    {
        Task<IEnumerable<StoryDTO>> GetLatestStories(int pageNumber, int pageSize, string? searchTerm = null);
    }
}