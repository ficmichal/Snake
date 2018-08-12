using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Snake.Players.EF;

namespace Snake.Players.Repositories
{
    public abstract class BaseRepository : IDisposable
    {
        public SnakePlayers Context { get; } = new SnakePlayers();

        internal int SaveChanges()
        {
            try
            {
                return Context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                //Thrown when there is a concurrency errors
                //If Entries propery is null, no records were modified
                //entities in Entries threw error due to timestamp/conncurrency
                //for now, just rethrow the exception
                throw ex;
            }
            catch (DbUpdateException ex)
            {
                //Thrown when database update fails
                //Examine the inner execption(s) for additional 
                //details and affected objects
                //for now, just rethrow the exception
                throw ex;
            }
            catch (CommitFailedException ex)
            {
                //handle transaction failures here
                //for now, just rethrow the exception
                throw ex;
            }
            catch (Exception ex)
            {
                //some other exception happened and should be handled
                throw ex;
            }
        }
        internal async Task<int> SaveChangesAsync()
        {
            try
            {
                return await Context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                //Thrown when there is a concurrency errors
                //for now, just rethrow the exception
                throw;
            }
            catch (DbUpdateException ex)
            {
                //Thrown when database update fails
                //Examine the inner execption(s) for additional 
                //details and affected objects
                //for now, just rethrow the exception
                throw;
            }
            catch (CommitFailedException ex)
            {
                //handle transaction failures here
                //for now, just rethrow the exception
                throw;
            }
            catch (Exception ex)
            {
                //some other exception happened and should be handled
                throw ex;
            }
        }

        bool disposed = false;
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                Context.Dispose();
                // Free any managed objects here. 
                //
            }

            // Free any unmanaged objects here. 
            //
            disposed = true;
        }
    }
}
