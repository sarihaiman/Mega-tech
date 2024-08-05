using AutoMapper;
using Bl.Interfaces;
using Dal;
using Dal.Service;
using Dal.Models;
using Dto.models;
using DTO.Classes;

namespace Service
{
    public class SettlementService : ISettlement
    {
        private DalManager dalManager;
        readonly IMapper mapper;
        public SettlementService(DalManager dalManager)
        {
            this.dalManager = dalManager;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MyDBDProfile>();
            });
            mapper = config.CreateMapper();
        }
        public async Task<Settlements> CreateAsync(Settlements item)
        {
            return mapper.Map<Settlements>(await dalManager.settlements.CreateAsync(mapper.Map<Settlement>(item)));
        }
        public async Task<bool> DeleteAsync(int item)
        {
            return await dalManager.settlements.DeleteAsync(item);
        }
        public async Task<List<Settlements>> ReadAsync(Predicate<Settlements> filter)
        {
            try
            {
                List<Settlements> l = await ReadAllAsync();
                return l.FindAll(l => filter(l));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        public async Task<List<Settlements>> ReadAllAsync() => mapper.Map<List<Settlement>, List<Settlements>>(await dalManager.settlements.ReadAllAsync());
        public async Task<bool> UpdateAsync(Settlements item)
        {
            try
            {
                return await dalManager.settlements.UpdateAsync(mapper.Map<Settlements, Settlement>(item));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
