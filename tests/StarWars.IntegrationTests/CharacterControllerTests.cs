using StarWars.Core.Domain;
using StarWars.Infrastructure.DTO;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace StarWars.IntegrationTests
{
    public class CharacterControllerTests : IntegrationTest
    {
        [Fact]
        public async Task GetCharacters_ReturnCharacters()
        {
            //Arrange 

            // Act
            var response = await _testClient.GetAsync("api/Character");
            response.EnsureSuccessStatusCode();

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.IsType<List<CharacterDTO>>(await response.Content.ReadAsAsync<List<CharacterDTO>>());
        }

        [Fact]
        public async Task GetByPage_ReturnCharactersByPage()
        {
            //Arrange 
            var pageNumner = 2;
            var pageSize = 3;

            // Act
            var response = await _testClient.GetAsync($"/api/Character/{pageNumner}/{pageSize}");
            response.EnsureSuccessStatusCode();

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.IsType<List<CharacterDTO>>(await response.Content.ReadAsAsync<List<CharacterDTO>>());

        }

        [Fact]
        public async Task GetByID_ReturnCharacter()
        {
            //Arrange 
            var id = 3;

            // Act
            var response = await _testClient.GetAsync($"api/Character/{id}");
            response.EnsureSuccessStatusCode();

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.IsType<CharacterDTO>(await response.Content.ReadAsAsync<CharacterDTO>());
        }

        [Fact]
        public async Task Post_ReturnCreatedStatus()
        {
            //Arrange 
            var chrDTO = new CharacterDTO
            {
                Name = "R2-D2",
                Episodes = new string[] { "NEWHOPE", "EMPIRE", "JEDI" },
                Friends = new string[] { "Luke Skywalker", "Han Solo", "Leia Organa" }
            };

            // Act
            var response = await _testClient.PostAsJsonAsync<CharacterDTO>("api/Character", chrDTO);
            response.EnsureSuccessStatusCode();

            // Assert
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        }

        [Fact]
        public async Task Post_ReturnCharacterDTO()
        {
            //Arrange 
            var chrDTO = new CharacterDTO
            {
                Name = "R2-D2",
                Episodes = new string[] { "NEWHOPE", "EMPIRE", "JEDI" },
                Friends = new string[] { "Luke Skywalker", "Han Solo", "Leia Organa" }
            };

            // Act
            var response = await _testClient.PostAsJsonAsync<CharacterDTO>("api/Character", chrDTO);
            response.EnsureSuccessStatusCode();
            var postChr = await response.Content.ReadAsAsync<Character>();

            // Assert
            Assert.Equal(chrDTO.Name, postChr.Name);
        }

        [Fact]
        public async Task Put_ReturnCharacterDTO()
        {
            //Arrange 
            var chrID = 5;
            var friends = new string[] { "Luke Skywalker", "Han Solo" };
            var chrDTO = new CharacterDTO
            {
                Friends = friends
            };

            // Act
            var putResponse = await _testClient.PutAsJsonAsync<CharacterDTO>($"api/Character/{chrID}", chrDTO);
            putResponse.EnsureSuccessStatusCode();
            var chrPut = await putResponse.Content.ReadAsAsync<CharacterDTO>();

            // Assert
            Assert.Equal(friends, chrPut.Friends);
        }
    }
}
