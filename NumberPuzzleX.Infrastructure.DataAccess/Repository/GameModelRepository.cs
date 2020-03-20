using System;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using NumberPuzzleX.Core.Domain.Model;
using NumberPuzzleX.Core.Domain.Service;
using DbGameModel = NumberPuzzleX.Infrastructure.DataAccess.Model.GameModel;

namespace NumberPuzzleX.Infrastructure.DataAccess.Repository
{
    public class GameModelRepository : IGameModelRepository
    {
        private readonly string _connectionString;

        /*
         * Her har jeg gjort det på aller enkleste vis.
         * Hvis EntityFramework Core, gjør dette:
         *  https://docs.microsoft.com/en-us/ef/core/miscellaneous/connection-strings
         * Hvis Dapper, se andre svaret her:
         *  https://stackoverflow.com/questions/37597300/net-core-dapper-connection-string
         */

        public GameModelRepository()
        {
            _connectionString =
                @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=NumberPuzzleX;Integrated Security=True";
        }

        public async Task<int> Create(GameModel gameModel)
        {
            await using var conn = new SqlConnection(_connectionString);
            const string insert =
                "INSERT INTO Game (Id, Numbers, PlayCount) VALUES (@Id, @Numbers, @PlayCount)";
            var dbGameModel = MapToDb(gameModel);
            return await conn.ExecuteAsync(insert, dbGameModel);
        }

        public async Task<GameModel> Read(Guid id)
        {
            await using var conn = new SqlConnection(_connectionString);
            const string select =
                "SELECT Id, Numbers, PlayCount FROM Game WHERE Id = @Id";
            var result = await conn.QueryAsync<DbGameModel>(select, new {Id=id});
            var gameModel = result.SingleOrDefault();
            return MapToDomain(gameModel);
        }



        public async Task<int> Update(GameModel gameModel)
        {
            await using var conn = new SqlConnection(_connectionString);
            const string insert =
                "UPDATE Game SET Numbers=@Numbers, PlayCount= @PlayCount WHERE Id=@Id";
            var dbGameModel = MapToDb(gameModel);
            return await conn.ExecuteAsync(insert, dbGameModel);
        }

        private static GameModel MapToDomain(DbGameModel gameModel)
        {
            var numbers = gameModel.Numbers.ToCharArray().Select(c => c - '0').ToArray();
            return new GameModel(gameModel.Id, gameModel.PlayCount, numbers);
        }

        private static DbGameModel MapToDb(GameModel gameModel)
        {
            var numbers = new string(gameModel.Numbers).Replace(' ','0');
            return new DbGameModel(gameModel.Id, gameModel.PlayCount, numbers);
        }
    }
}
