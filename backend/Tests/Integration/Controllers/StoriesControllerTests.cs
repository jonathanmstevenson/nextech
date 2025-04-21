using Application.DTOs;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System.Net;
using System.Text.Json;
using Xunit;

namespace Tests.Integration.Controllers
{
    public class StoriesControllerTests : IntegrationTestBase
    {
        public StoriesControllerTests(WebApplicationFactory<Program> factory) : base(factory) { }

        [Fact]
        public async Task GetStories_ShouldReturnOk_WithExpectedData()
        {
            // Arrange
            var term = "angular";
            var page = 1;
            var size = 50;

            // Act
            var response = await _client.GetAsync($"/api/stories?pgNumber={page}&pgSize={size}");

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var json = await response.Content.ReadAsStringAsync();
            var stories = JsonSerializer.Deserialize<PaginationDTO<StoryDTO>>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            stories.Should().NotBeNull();
            // stories.Should().OnlyContain(s => s.Title.Contains(search, StringComparison.OrdinalIgnoreCase));
        }
    }
}