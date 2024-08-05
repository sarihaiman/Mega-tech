using Dal.Interfaces;
using Dal.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Service
{
    public class SettlementService : ISettlement
    {
        private MyDBContext db;
        public SettlementService(MyDBContext db)
        {
            this.db = db;
        }

        public async Task<Settlement> CreateAsync(Settlement item)
        {
            try
            {
                db.Settlements.Add(item);
                await db.SaveChangesAsync();
                await db.SaveChangesAsync();
                return item;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public async Task<bool> DeleteAsync(int item)

        {
            try
            {
                Settlement l = await db.Settlements.FirstOrDefaultAsync(c => c.SettlementId == item);
                if (l == null)
                    throw new Exception("Settlement does not exist in DB");
                db.Settlements.Remove(l);
                db.SaveChanges();
                return true;
            }
            catch(Exception ex) 
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Settlement>> ReadAllAsync() =>await db.Settlements.ToListAsync();

        public async Task<bool> UpdateAsync(Settlement item)
        {
            try
            {
                var existingSettlement = db.Settlements.FirstOrDefault(x => x.SettlementId == item.SettlementId);

                if (existingSettlement == null)
                    throw new Exception("Settlement does not exist in DB"); 
                existingSettlement.SettlementName = item.SettlementName;
                await db.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }

}
