using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal.Models;

namespace Dal.Interfaces
{
    public interface IDalCrud<T>
    {
        Task<T> CreateAsync(T item);
        Task<bool> DeleteAsync(int item);
        Task<List<T>> ReadAllAsync();
        Task<bool> UpdateAsync(T item);

    }
}
