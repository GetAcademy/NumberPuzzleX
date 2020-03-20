using System;
using System.Collections.Generic;
using System.Text;
using _40_NumberPuzzleX.Core.Application.Services;
using _40_NumberPuzzleX.Core.Domain.Model;
using _40_NumberPuzzleX.Core.Domain.Services;
using NUnit.Framework;

namespace _90_NumberPuzzleX.UnitTest
{
    class GameServiceTest
    {
        [Test]
        public void TestPlay()
        {
            // Lær og bruk Moq (NuGet)
            // Men dette eksemplet viser hva mocking er
            // https://github.com/GetAcademy/ArchitectureOnion/blob/master/ArchitectureOnion.UnitTest/PersonServiceTest.cs
            var gameId = new Guid("82ad76d0-d796-4bb5-bddc-1318dcd8cb68");
            var mock = new MyMockGameModelRepository();
            var service = new GameService(mock);
            service.Play(0, gameId);

            Assert.IsTrue(mock.HasRead);
            Assert.IsTrue(mock.HasUpdated);
        }
    }

    class MyMockGameModelRepository : IGameModelRepository
    {
        public bool HasRead { get; private set; }
        public bool HasUpdated { get; private set; }
        public void Create(GameModel gameModel)
        {
        }

        public GameModel Read(Guid id)
        {
            HasRead = true;
            return new GameModel(new []{1,2,3,4,5,6,7,8,0});
        }

        public void Update(GameModel gameModel)
        {
            HasUpdated = true;
        }
    }
}
