using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Project.Library;

namespace Project.Library
{
    public class Dependencies : IDesignTimeDbContextFactory<ProjectSQLContext>, IDisposable
    {
        private bool _disposedValue;

        private readonly List<IDisposable> _disposables = new List<IDisposable>();

        public ProjectSQLContext CreateDbContext(string[] args = null)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ProjectSQLContext>();
            var connectionString = File.ReadAllText("C:/revature/Jongut-Project0/project-connection-string.txt");
            optionsBuilder.UseSqlServer(connectionString);

            return new ProjectSQLContext(optionsBuilder.Options);
        }

        public IRepository CreateStoreRepository()
        {
            var dbContext = CreateDbContext();
            _disposables.Add(dbContext);
            return new Repository(dbContext);
        }
        
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    foreach (IDisposable disposable in _disposables)
                    {
                        disposable.Dispose();
                    }
                }

                _disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
