using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Project.SQL
{
    public class Dependencies : IDisposable
    {
        private bool _disposedValue;

        private readonly List<IDisposable> _disposables = new List<IDisposable>();

        public Project0SQLContext CreateDbContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<Project0SQLContext>();
            var connectionString = File.ReadAllText("C:/revature/Jongut-Project0/project-connection-string.txt");
            optionsBuilder.UseSqlServer(connectionString);

            return new Project0SQLContext(optionsBuilder.Options);
        }

        public IProject0Repository CreateRepository(){
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
