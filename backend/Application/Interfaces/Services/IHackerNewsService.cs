using Application.DTOs;

namespace Application.Interfaces
{
    public interface IHackerNewsService
    {
        Task<PaginationDTO<StoryDTO>> GetLatestStories(int pageNumber, int pageSize, string? searchTerm = null);
    }
}