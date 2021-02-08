using Microsoft.AspNetCore.Mvc;
using Moq;
using StarWars.Controllers;
using StarWars.Core.Domain;
using StarWars.Infrastructure.DTO;
using StarWars.Infrastructure.Services;
using System.Collections.Generic;
using Xunit;

namespace StarWars.UnitTests
{
    public class CharacterControllerTests
    {
        private readonly CharacterController _characterController;
        private readonly Mock<ICharacterService> _characterServiceMock;

        public CharacterControllerTests()
        {
            _characterServiceMock = new Mock<ICharacterService>();
            _characterController = new CharacterController(_characterServiceMock.Object);
        }

        [Fact]
        public void Get_ReturnOkResult()
        {
            //Arrange 
            _characterServiceMock.Setup(x => x.GetCharacters());

            // Act
            var result = _characterController.Get();

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void Get_ReturnAllCharacters()
        {
            //Arrange 
            var chrDTO = CharactersForTests.GetCharactersDTO();
            _characterServiceMock.Setup(x => x.GetCharacters()).Returns(chrDTO);

            // Act
            var result = _characterController.Get() as OkObjectResult;

            // Assert
            var items = Assert.IsType<List<CharacterDTO>>(result.Value);
            Assert.Equal(7, items.Count);
        }

        [Fact]
        public void GetById_ReturnNotFound()
        {
            //Arrange 
            var chrID = 1;
            var chrDTO = CharactersForTests.GetCharactersDTO()[chrID];
            _characterServiceMock.Setup(x => x.GetCharacter(chrID)).Returns(chrDTO);

            // Act
            var result = _characterController.Get(2);

            // Assert
            Assert.IsType<NotFoundObjectResult>(result);
        }

        [Fact]
        public void GetById_ReturnOkResult()
        {
            //Arrange 
            var chrID = 1;
            var chrDTO = CharactersForTests.GetCharactersDTO()[chrID];
            _characterServiceMock.Setup(x => x.GetCharacter(chrID)).Returns(chrDTO);

            // Act
            var result = _characterController.Get(chrID);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void GetById_ReturnCharacter()
        {
            // Arrange
            var chrID = 3;
            var chrDTO = CharactersForTests.GetCharactersDTO()[chrID];
            _characterServiceMock.Setup(x => x.GetCharacter(chrID)).Returns(chrDTO);

            // Act
            var result = _characterController.Get(chrID) as OkObjectResult;

            // Assert
            Assert.IsType<CharacterDTO>(result.Value);
        }

        [Fact]
        public void Post_ReturnsNotFound()
        {
            // Arrange
            var chrID = 5;
            var chrDTO = CharactersForTests.GetCharactersDTO()[chrID];
            _characterController.ModelState.AddModelError("Name", "Character Name is Required");

            // Act
            var result = _characterController.Post(chrDTO);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public void Post_ReturneCreatedItem()
        {
            // Arrange
            var chrID = 5;
            var chrDTO = CharactersForTests.GetCharactersDTO()[chrID];
            var chr = CharactersForTests.GetCharacters()[chrID];
            _characterServiceMock.Setup(x => x.Add(chrDTO)).Returns(chr);

            // Act
            var result = _characterController.Post(chrDTO) as CreatedAtActionResult;

            // Assert
            Assert.Equal("C-3PO", Assert.IsType<Character>(result.Value).Name);
        }

        [Fact]
        public void Put_ReturnOkResult()
        {
            // Arrange
            var chrID = 4;
            var chrDTO = CharactersForTests.GetCharactersDTO()[chrID];
            _characterServiceMock.Setup(x => x.Update(chrID, chrDTO));

            // Act
            var result = _characterController.Put(chrID, chrDTO);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void Put_ReturnCharacter()
        {
            // Arrange
            var chrID = 5;
            var chrDTO = CharactersForTests.GetCharactersDTO()[chrID];
            _characterServiceMock.Setup(x => x.Update(chrID, chrDTO));

            // Act
            var result = _characterController.Put(chrID, chrDTO) as OkObjectResult;

            // Assert
            Assert.IsType<CharacterDTO>(result.Value);
        }
    }
}
