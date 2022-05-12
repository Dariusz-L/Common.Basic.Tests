using Common.Basic.Blocks;
using Common.Basic.DDD;
using Common.Basic.Files;
using Common.Basic.Json;
using Common.Basic.Repository;
using NSubstitute;
using NUnit.Framework;
using System;
using System.IO;

namespace Common.Basic.Tests
{
    internal class LocalStorageRepositoryTests
    {
        private static readonly IJsonConverter JsonConverter = new NewtonsoftJsonConverter();
        private static readonly string DataPath = "C:/TestPath/";

        private static readonly TestEntity[] Entites = new TestEntity[]
        {
            new TestEntity("1", "1"),
            new TestEntity("2", "3"),
            new TestEntity("2", "3"),
        };

        //[Test]
        //public void GivenRepository_WhenExistsOfName_Then()
        //{
        //    // Arrange
        //    var dirOps = Substitute.For<IDirectoryOperations>();
        //    dirOps.Exists(Arg.Any<string>()).Returns(true);
        //    dirOps.GetFiles(Arg.Any<string>()).Returns(Array.Empty<string>());

        //    var fileOps = Substitute.For<IFileOperations>();
        //    var jsonConverter = Substitute.For<IJsonConverter>();
        //    IRepository<TestEntity> repository = new LocalStorageRepository<TestEntity>(DataPath, dirOps, fileOps, jsonConverter);
        //    //repository.GetAll().Returns(Result<TestEntity[]>.SuccessTask(Entites));
        //    // Act
        //    repository.ExistsOfName("Name", entity => "Name");

        //    // Assert
        //    //repository.DidNotReceive().Save(Arg.Any<object>());
        //}

        class TestEntity : Entity
        {
            public string Name { get; }

            public TestEntity(string id, string name) : base(id)
            {
                Name = name;
            }
        }
    }
}
