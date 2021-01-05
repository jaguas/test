using System.Collections.Generic;

namespace Application.Common.Interfaces
{
    public interface ICsvFileBuilder<T>
    {
        byte[] BuildFile(IEnumerable<T> records);
    }
}
