using System;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using _40_NumberPuzzleX.Core.Domain.Model;
using _40_NumberPuzzleX.Core.Domain.Service;
using Dapper;
using DbGameModel = _14_NumberPuzzleX.Infrastructure.DataAccess.Model.GameModel;

namespace NumberPuzzleX.Infrastructure.DataAccess
{
    public class GameModelRepository : IGameModelRepository
    {
        private string _connectionString;

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

        public Task Create(GameModel gameModel)
        {
            throw new NotImplementedException();
        }

        public async Task<GameModel> Read(Guid id)
        {
            await using var conn = new SqlConnection(_connectionString);
            const string select =
                "SELECT Id, Numbers, PlayCount FROM Game WHERE Id = @Id";
            var result = await conn.QueryAsync<DbGameModel>(select);
            var gameModel = result.SingleOrDefault();
            var numbers = gameModel.Numbers.ToCharArray().Select(c=>c - '0').ToArray();
            return new GameModel(gameModel.Id, gameModel.PlayCount, numbers);
        }

        public Task Update(GameModel gameModel)
        {
            throw new NotImplementedException();
        }
    }
}
