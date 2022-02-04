using Nubimetrics.Infrastructure.Helpers;
using System;
using System.Threading.Tasks;

namespace Nubimetrics.Infrastructure.Contracts
{
    public interface IFileWriter
    {
        Task WriteAsync(Action<FileWireterOptions> options, string source);
    }
}
