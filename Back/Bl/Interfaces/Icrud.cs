using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl.Interfaces
{
    public interface IBlcrud<T>
    {
        Task<T> CreateAsync(T item);
        Task<bool> DeleteAsync(int item);
        Task<List<T>> ReadAllAsync();
        Task<bool> UpdateAsync(T item);
    }
}
