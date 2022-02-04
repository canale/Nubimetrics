using Microsoft.Extensions.Logging;
using Nubimetrics.Infrastructure.Contracts;
using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;

namespace Nubimetrics.Infrastructure.Helpers
{
    public class FileWriter : IFileWriter
    {
        private readonly ILogger<FileWriter> logger;

        public FileWriter(ILogger<FileWriter> logger)
        {
            this.logger = logger;
        }


        public async Task WriteAsync(Action<FileWireterOptions> options, string source)
        {
            if (string.IsNullOrEmpty(source))
            {
                throw new ArgumentException($"'{nameof(source)}' cannot be null or empty.", nameof(source));
            }

            var fileWireterOptions = new FileWireterOptions();
            options(fileWireterOptions);

            TryCreateDirectory(fileWireterOptions);

            await File.WriteAllTextAsync(fileWireterOptions.GetFullPath(), source);
        }

        private void TryCreateDirectory(FileWireterOptions fileWireterOptions)
        { 
            if (!Directory.Exists(fileWireterOptions.Root))
            {
                Directory.CreateDirectory(fileWireterOptions.Root);
                logger.LogInformation($"Direcotry was created on {fileWireterOptions.Root}");
            }
            else
            {
                logger.LogInformation($"Direcotry {fileWireterOptions.Root} exists already.");
            }
        }
    }

    public class FileWireterOptions : IFileNameOption
    {
        private string path;
        private string fileName;

        public string Root => path;

        public IFileNameOption AddPath(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                throw new ArgumentException($"'{nameof(path)}' cannot be null or empty.", nameof(path));
            }
            this.path = path;
            return this;
        }

        public IFileNameOption UseAssemblyDirectory()
        {
            this.path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            return this;
        }

        public IFileNameOption UseAssemblyDirectory(string path)
        {
            this.path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), path);
            return this;
        }

        public void AddFileName(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                throw new ArgumentException($"'{nameof(fileName)}' cannot be null or empty.", nameof(fileName));
            }

            this.fileName = fileName;
        }

        public string GetFullPath() => Path.Combine(path, fileName);

    }


    public interface IFileNameOption
    {
        void AddFileName(string fileName);
    }
}
