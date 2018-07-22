using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake.Players.Repositories
{
    class PlayerRepository : BaseRepository, IPlayerRepository
    {
        public int Add(Player Player)
        {
            Context._Players.Add(Player);
            return SaveChanges();
        }

        public Task<int> AddAsync(Player Player)
        {
            Context._Players.Add(Player);
            return SaveChangesAsync();
        }

        public int Save(Player Player)
        {
            Context.Entry(Player).State = EntityState.Modified;
            return SaveChanges();
        }

        public Task<int> SaveAsync(Player Player)
        {
            Context.Entry(Player).State = EntityState.Modified;
            return SaveChangesAsync();
        }

        public int Delete(string nickname)
        {
            Context.Entry(new Player()
            {
                Nickname = nickname
            }).State = EntityState.Deleted;
            return SaveChanges();
        }

        public Task<int> DeleteAsync(string nickname)
        {
            Context.Entry(new Player()
            {
                Nickname = nickname
            }).State = EntityState.Deleted;
            return SaveChangesAsync();
        }

        public int Delete(Player Player)
        {
            Context.Entry(Player).State = EntityState.Deleted;
            return SaveChanges();
        }

        public Task<int> DeleteAsync(Player Player)
        {
            Context.Entry(Player).State = EntityState.Deleted;
            return SaveChangesAsync();
        }

        public Player GetOne(string nickname)
            => Context._Players.Find(nickname);

        public Task<Player> GetOneAsync(string nickname)
            => Context._Players.FindAsync(nickname);


        public List<Player> GetAll()
            => Context._Players.ToList();

        public Task<List<Player>> GetAllAsync()
            => Context._Players.ToListAsync();

        public List<Player> ExecuteQuery(string sql)
            => Context._Players.SqlQuery(sql).ToList();

        public Task<List<Player>> ExecuteQueryAsync(string sql)
            => Context._Players.SqlQuery(sql).ToListAsync();

        public List<Player> ExecuteQuery(string sql, object[] sqlParametersObjects)
            => Context._Players.SqlQuery(sql, sqlParametersObjects).ToList();

        public Task<List<Player>> ExecuteQueryAsync(string sql, object[] sqlParametersObjects)
            => Context._Players.SqlQuery(sql, sqlParametersObjects).ToListAsync();
    }

}
