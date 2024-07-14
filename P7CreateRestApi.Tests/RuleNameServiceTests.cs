using Dot.Net.WebApi.Domain;
using Moq;
using P7CreateRestApi.Models.InputModel;
using P7CreateRestApi.Repositories;
using P7CreateRestApi.Services;

namespace P7CreateRestApi.Tests
{
    public class RuleNameServiceTests
    {
        private readonly RuleNameService _ruleNameService;
        private readonly Mock<IRuleNameRepository> _ruleNameRepositoryMock = new();

        public RuleNameServiceTests()
        {
            _ruleNameService = new RuleNameService(_ruleNameRepositoryMock.Object);
        }
        /// <summary>RuleName test unit for Create method. 
        /// Check if created RuleName has an Output Model correctly filled.</summary> 
        /// <remarks></remarks>
        [Fact]
        public void CreateRuleName_ShouldHaveRuleNameOutputModelReturned()
        {
            // Arrange
            var inputModel = new RuleNameInputModel
            {
                Name = "RuleName",
                Description = "RuleDescription",
                Json = "Json",
                Template = "Template",
                SqlStr = "SqlStr",
                SqlPart = "SqlPart"
            };
            _ruleNameRepositoryMock.Setup(m => m.Create(It.IsAny<RuleName>()));

            // Act
            var outputModel = _ruleNameService.Create(inputModel);

            // Assert
            Assert.NotNull(outputModel);
            Assert.Equal(inputModel.Name, outputModel.Name);
            Assert.Equal(inputModel.Description, outputModel.Description);
            Assert.Equal(inputModel.Json, outputModel.Json);
            Assert.Equal(inputModel.Template, outputModel.Template);
            Assert.Equal(inputModel.SqlStr, outputModel.SqlStr);
            Assert.Equal(inputModel.SqlPart, outputModel.SqlPart);
            _ruleNameRepositoryMock.Verify(m => m.Create(It.IsAny<RuleName>()), Times.Once);
        }
        /// <summary>RuleName test unit for Delete method.
        /// Check if deleted RuleName has an OutputModel correctly filled.</summary> 
        /// <remarks></remarks>
        [Fact]
        public void DeleteRuleName_ShouldHaveRuleNameOutputModelReturned()
        {
            // Arrange
            var ruleNameExcepted = new RuleName()
            {
                Id = 1,
                Name = "RuleName",
                Description = "RuleDescription",
                Json = "Json",
                Template = "Template",
                SqlStr = "SqlStr",
                SqlPart = "SqlPart"
            };
            _ruleNameRepositoryMock.Setup(m => m.Delete(1)).Returns(ruleNameExcepted);

            // Act
            var outputModel = _ruleNameService.Delete(1);

            // Assert
            Assert.NotNull(outputModel);
            Assert.Equal(ruleNameExcepted.Id, outputModel.Id);
            Assert.Equal(ruleNameExcepted.Name, outputModel.Name);
            Assert.Equal(ruleNameExcepted.Description, outputModel.Description);
            Assert.Equal(ruleNameExcepted.Json, outputModel.Json);
            Assert.Equal(ruleNameExcepted.Template, outputModel.Template);
            Assert.Equal(ruleNameExcepted.SqlStr, outputModel.SqlStr);
            Assert.Equal(ruleNameExcepted.SqlPart, outputModel.SqlPart);
            _ruleNameRepositoryMock.Verify(m => m.Delete(1), Times.Once);
        }
        /// <summary>RuleName test unit for Delete method.
        /// Check if deleted RuleName does'nt return Output Model (null).</summary> 
        /// <remarks></remarks>
        [Fact]
        public void DeleteRuleNameThatDoesntExist_ShoulReturnNull()
        {
            // Arrange
            _ruleNameRepositoryMock.Setup(m => m.Delete(1));

            // Act
            var outputModel = _ruleNameService.Delete(1);

            // Assert
            Assert.Null(outputModel);
            _ruleNameRepositoryMock.Verify(m => m.Delete(1), Times.Once);
        }
        /// <summary>RuleName test unit for Get method.
        /// Check if RuleName OutputModel item properties sent back from Get method
        /// is identical to requested item properties.</summary> 
        /// <remarks></remarks>
        [Fact]
        public void GetExistingRuleName_ShouldHaveRuleNameOutputModelReturned()
        {
            // Arrange
            var ruleNameExcepted = new RuleName()
            {
                Id = 1,
                Name = "RuleName",
                Description = "RuleDescription",
                Json = "Json",
                Template = "Template",
                SqlStr = "SqlStr",
                SqlPart = "SqlPart"
            };
            _ruleNameRepositoryMock.Setup(m => m.Get(1)).Returns(ruleNameExcepted);

            // Act
            var outputModel = _ruleNameService.Get(1);

            // Assert
            Assert.NotNull(outputModel);
            Assert.Equal(ruleNameExcepted.Id, outputModel.Id);
            Assert.Equal(ruleNameExcepted.Name, outputModel.Name);
            Assert.Equal(ruleNameExcepted.Description, outputModel.Description);
            Assert.Equal(ruleNameExcepted.Json, outputModel.Json);
            Assert.Equal(ruleNameExcepted.Template, outputModel.Template);
            Assert.Equal(ruleNameExcepted.SqlStr, outputModel.SqlStr);
            Assert.Equal(ruleNameExcepted.SqlPart, outputModel.SqlPart);
            _ruleNameRepositoryMock.Verify(m => m.Get(1), Times.Once);
        }
        /// <summary>RuleName test unit for Get method.
        /// Check if not existing RuleName item with Get method send 
        /// back null result.</summary> 
        /// <remarks></remarks>
        [Fact]
        public void GetRuleNameThatDoesntExist_ShouldReturnNull()
        {
            // Arrange
            _ruleNameRepositoryMock.Setup(m => m.Get(1));

            // Act
            var outputModel = _ruleNameService.Get(1);

            // Assert
            Assert.Null(outputModel);
            _ruleNameRepositoryMock.Verify(m => m.Get(1), Times.Once);
        }
        /// <summary>RuleName test unit for List method.
        /// Check if List method send back correct RuleName item properties.</summary> 
        /// <remarks></remarks>
        [Fact]
        public void ListRuleNameWithOneRuleName_ShouldHaveOneRuleNameInListReturned()
        {
            // Arrange
            var ruleNameExcepted = new RuleName()
            {
                Id = 1,
                Name = "RuleName",
                Description = "RuleDescription",
                Json = "Json",
                Template = "Template",
                SqlStr = "SqlStr",
                SqlPart = "SqlPart"
            };
            _ruleNameRepositoryMock.Setup(m => m.List()).Returns(new List<RuleName> { ruleNameExcepted });

            // Act
            var list = _ruleNameService.List();

            // Assert
            Assert.NotNull(list);
            Assert.Single(list);
            Assert.Equal(ruleNameExcepted.Id, list[0].Id);
            Assert.Equal(ruleNameExcepted.Name, list[0].Name);
            Assert.Equal(ruleNameExcepted.Description, list[0].Description);
            Assert.Equal(ruleNameExcepted.Json, list[0].Json);
            Assert.Equal(ruleNameExcepted.Template, list[0].Template);
            Assert.Equal(ruleNameExcepted.SqlStr, list[0].SqlStr);
            Assert.Equal(ruleNameExcepted.SqlPart, list[0].SqlPart);
            _ruleNameRepositoryMock.Verify(m => m.List(), Times.Once);
        }
        /// <summary>RuleName test unit for List method.
        /// Check if List method send back RuleName with no items 
        /// if there are no BidList items.</summary> 
        /// <remarks></remarks>
        [Fact]
        public void ListRuleNameEmpty_ShouldHaveEmptyListReturned()
        {
            // Arrange
            _ruleNameRepositoryMock.Setup(m => m.List()).Returns(new List<RuleName>());

            // Act
            var outputModel = _ruleNameService.List();

            // Assert
            Assert.NotNull(outputModel);
            Assert.Empty(outputModel);
            _ruleNameRepositoryMock.Verify(m => m.List(), Times.Once);
        }
        /// <summary>RuleName test unit for Update method.
        /// Check if Update method for a not existing item 
        /// send back null result.</summary> 
        /// <remarks></remarks> 
        [Fact]
        public void UpdateRuleNameThatDoesntExist_ShouldReturnNull()
        {
            // Arrange
            _ruleNameRepositoryMock.Setup(m => m.Update(It.IsAny<RuleName>()));

            // Act
            var outputModel = _ruleNameService.Update(1, new RuleNameInputModel
            {
                Name = "RuleName",
                Description = "RuleDescription",
                Json = "Json",
                Template = "Template",
                SqlStr = "SqlStr",
                SqlPart = "SqlPart"
            });

            // Assert
            Assert.Null(outputModel);
            _ruleNameRepositoryMock.Verify(m => m.Update(It.IsAny<RuleName>()), Times.Once);
        }
        /// <summary>RuleName test unit for Update method.
        /// Check if Update method send back
        /// correct RuleName item properties updated as expected.</summary> 
        /// <remarks></remarks>
        [Fact]
        public void UpdateRuleName_ShouldHaveUpdateRuleNameReturned()
        {
            // Arrange
            var ruleNameExcepted = new RuleName()
            {
                Id = 1,
                Name = "RuleName",
                Description = "RuleDescription",
                Json = "Json",
                Template = "Template",
                SqlStr = "SqlStr",
                SqlPart = "SqlPart"
            };
            var inputModel = new RuleNameInputModel()
            {
                Name = "RuleName",
                Description = "RuleDescription",
                Json = "Json",
                Template = "Template",
                SqlStr = "SqlStr",
                SqlPart = "SqlPart"
            };
            _ruleNameRepositoryMock.Setup(m => m.Update(It.IsAny<RuleName>())).Returns(ruleNameExcepted);

            // Act
            var outputModel = _ruleNameService.Update(1, inputModel);

            // Assert
            Assert.NotNull(outputModel);
            Assert.Equal(1, outputModel.Id);
            Assert.Equal(inputModel.Name, outputModel.Name);
            Assert.Equal(inputModel.Description, outputModel.Description);
            Assert.Equal(inputModel.Json, outputModel.Json);
            Assert.Equal(inputModel.Template, outputModel.Template);
            Assert.Equal(inputModel.SqlStr, outputModel.SqlStr);
            Assert.Equal(inputModel.SqlPart, outputModel.SqlPart);
            _ruleNameRepositoryMock.Verify(m => m.Update(It.IsAny<RuleName>()), Times.Once);
        }
    }
}
