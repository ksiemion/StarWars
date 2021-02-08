using AutoMapper;
using Moq;
using StarWars.Core.Domain;
using StarWars.Core.Repositories;
using StarWars.Infrastructure.DTO;
using StarWars.Infrastructure.Services;
using System.Collections.Generic;
using Xunit;

namespace StarWars.UnitTests
{
    public class CharacterServiceTests
    {
        private readonly CharacterService _characterService;
        private readonly Mock<IRepository> _repositoryMock;
        private readonly Mock<IMapper> _mapperMock;

        public CharacterServiceTests()
        {
            _repositoryMock = new Mock<IRepository>();
            _mapperMock = new Mock<IMapper>();
            _characterService = new CharacterService(_repositoryMock.Object, _mapperMock.Object);
        }

        [Fact]
        public void GetCharacterByID_ReturnCharacterIfNotNull()
        {
            //Arrange 
            var characterID = 1;
            var chr = CharactersForTests.GetCharacters()[0];
            var chrDTO = CharactersForTests.GetCharactersDTO()[0];

            _repositoryMock.Setup(x => x.GetById<Character>(characterID, x => x.Episodes, x => x.Friends, x => x.Planet)).Returns(chr);
            _mapperMock.Setup(x => x.Map<CharacterDTO>(chr)).Returns(chrDTO);

            // Act
            var result = _characterService.GetCharacter(1);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<CharacterDTO>(result);
        }

        [Fact]
        public void GetCharacters_ReturnCharactersNotNull()
        {
            //Arrange 
            var chrColl = CharactersForTests.GetCharacters();
            var chrDTOColl = CharactersForTests.GetCharactersDTO();

            _repositoryMock.Setup(x => x.GetAll<Character>(x => x.Episodes, x => x.Friends, x => x.Planet)).Returns(chrColl);
            _mapperMock.Setup(x => x.Map<IEnumerable<CharacterDTO>>(chrColl)).Returns(chrDTOColl);

            // Act
            IEnumerable<CharacterDTO> result = _characterService.GetCharacters();

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void Add_ReturnCharactersNotNull()
        {
            //Arrange 
            var chr = CharactersForTests.GetCharacters()[0];
            var chrDTO = CharactersForTests.GetCharactersDTO()[0];

            _repositoryMock.Setup(x => x.Add<Character>(chr)).Returns(chr);
            _mapperMock.Setup(x => x.Map<Character>(chrDTO)).Returns(chr);

            // Act
            var result = _characterService.Add(chrDTO);

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void Add_ReturnCharacterType()
        {
            //Arrange 
            var chr = CharactersForTests.GetCharacters()[0];
            var chrDTO = CharactersForTests.GetCharactersDTO()[0];

            _repositoryMock.Setup(x => x.Add<Character>(chr)).Returns(chr);
            _mapperMock.Setup(x => x.Map<Character>(chrDTO)).Returns(chr);

            // Act
            var result = _characterService.Add(chrDTO);

            // Assert
            Assert.IsType<Character>(result);
        }

    }
}
