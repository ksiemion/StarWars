
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using StarWars.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
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
        public async Task Post_ReturnCharacter()
        {
            //Arrange 
            var chrJson = JsonConvert.SerializeObject(new CharacterDTO
            {
                Name = "R2-D2",
                Episodes = new string[] { "NEWHOPE", "EMPIRE", "JEDI" },
                Friends = new string[] { "Luke Skywalker", "Han Solo", "Leia Organa" }
            });

            // Act
            var response = await _testClient.PostAsJsonAsync($"api/Character", new StringContent(chrJson));
            response.EnsureSuccessStatusCode();

            // Assert
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        }
    }
}
