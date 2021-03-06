﻿using System;
using System.Threading.Tasks;
using NumberPuzzleX.Core.Application.Service;
using NumberPuzzleX.Core.Domain.Model;
using NumberPuzzleX.Core.Domain.Service;
using NUnit.Framework;

namespace _90_NumberPuzzleX.UnitTest
{
    class GameServiceTest
    {
        [Test]
        public async Task TestPlay()
        {
            // Lær og bruk Moq (NuGet)
            // Men dette eksemplet viser hva mocking er
            // https://github.com/GetAcademy/ArchitectureOnion/blob/master/ArchitectureOnion.UnitTest/PersonServiceTest.cs
            var gameId = new Guid("82ad76d0-d796-4bb5-bddc-1318dcd8cb68");
            var mock = new MyMockGameModelRepository();
            var service = new GameService(mock);
            await service.Play(0, gameId);

            Assert.IsTrue(mock.HasRead);
            Assert.IsTrue(mock.HasUpdated);
        }
    }

    class MyMockGameModelRepository : IGameModelRepository
    {
        public bool HasRead { get; private set; }
        public bool HasUpdated { get; private set; }
        public Task<int> Create(GameModel gameModel)
        {
            return Task.Run(() => 1);
        }

        public Task<GameModel> Read(Guid id)
        {
            HasRead = true;
            return Task.Run(() => new GameModel(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 0 }));
        }

        public Task<int> Update(GameModel gameModel)
        {
            return Task.Run(() =>
            {
                HasUpdated = true;
                return 1;
            });
        }
    }
}
