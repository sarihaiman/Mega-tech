using Dal.Interfaces;
using Dal.Service;
using Dal.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel;
using Dal.Service;

namespace Dal
{
    public class DalManager
    {
       
        public ISettlement settlements { get; set; }
    


        public DalManager()
        {
            ServiceCollection collections = new ServiceCollection();
            collections.AddSingleton<MyDBContext>();
        
            collections.AddSingleton<ISettlement, SettlementService>();
            var serviceprovider = collections.BuildServiceProvider();
            settlements = serviceprovider.GetRequiredService<ISettlement>();
  
        }
    }
}
