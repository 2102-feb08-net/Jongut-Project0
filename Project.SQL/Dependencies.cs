using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Project.SQL;

namespace Project.Library
{
    public class Dependencies : IDisposable
    {
        private bool _disposedValue;

        private readonly List<IDisposable> _disposables = new List<IDisposable>();

        public ProjectSQLContext CreateDbContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ProjectSQLContext>();
            var connectionString = File.ReadAllText("C:/revature/Jongut-Project0/project-connection-string.txt");
            optionsBuilder.UseSqlServer(connectionString);

            return new ProjectSQLContext(optionsBuilder.Options);
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
