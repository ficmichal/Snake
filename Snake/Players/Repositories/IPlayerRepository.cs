using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake.Players.Repositories
{
    public interface IPlayerRepository
    {
        int Add(Player Player);

        Task<int> AddAsync(Player Player);

        int Save(Player Player);

        Task<int> SaveAsync(Player Player);

        int Delete(string nickname);

        Task<int> DeleteAsync(string nickname);

        int Delete(Player Player);

        Task<int> DeleteAsync(Player Player);

        Player GetOne(string nickname);

        Task<Player> GetOneAsync(string nickname);

        List<Player> GetAll();

        Task<List<Player>> GetAllAsync();


        List<Player> ExecuteQuery(string sql);

        Task<List<Player>> ExecuteQueryAsync(string sql);

        List<Player> ExecuteQuery(string sql, object[] sqlParametersObjects);

        Task<List<Player>> ExecuteQueryAsync(string sql, object[] sqlParametersObjects);
    }
}
