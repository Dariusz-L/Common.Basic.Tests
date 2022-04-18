using Common.Basic.Blocks;
using Common.Basic.Repository;
using Common.Basic.Threading;
using NSubstitute;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Common.Basic.Tests
{
    internal class RepositoryExtensionsTests
    {
        private const string ID = "ID";
        private static readonly object Object = new object();

        [Test]
        public void GivenAnyRepository_WhenGetIsFailure_ThenNothingSaved()
        {
            // Arrange
            var repository = Substitute.For<IRepository<object>>();
            repository.GetBy(ID).Returns(Result.FailureTask());
            repository.Save(Object).Returns(Result.SuccessTask());

            // Act
            repository.GetIfExistsOrCreateAndSave(ID, () => Object).GetAwaiterResult();

            // Assert
            repository.DidNotReceive().Save(Arg.Any<object>());
        }

        [Test]
        public void GivenAnyRepository_WhenGetIsSuccessAndObjectFound_ThenNothingSaved()
        {
            // Arrange
            var repository = Substitute.For<IRepository<object>>();
            repository.GetBy(ID).Returns(Result.SuccessTask(Object));
            repository.Save(Object).Returns(Result.SuccessTask());

            // Act
            repository.GetIfExistsOrCreateAndSave(ID, () => Object).GetAwaiterResult();

            // Assert
            repository.DidNotReceive().Save(Object);
        }

        [Test]
        public async Task GivenAnyRepository_WhenGetIsSuccessAndObjectNotFound_ThenNewSaved()
        {
            // Arrange
            var repository = Substitute.For<IRepository<object>>();
            repository.GetBy(ID).Returns(Result.SuccessTask());
            repository.Save(Object).Returns(Result.SuccessTask());

            // Act
            await repository.GetIfExistsOrCreateAndSave(ID, () => Object);

            // Assert
            await repository.Received().Save(Object);
        }
    }
}
