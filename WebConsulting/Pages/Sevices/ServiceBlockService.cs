// Services/ServiceBlockService.cs
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebConsulting.Models;

namespace WebConsulting.Services
{
    public class ServiceBlockService : IServiceBlockService
    {
        private readonly ConsultingDBContext _db;

        public ServiceBlockService(ConsultingDBContext db)
            => _db = db;

        public async Task<IEnumerable<ServiceBlock>> GetAllBlocksAsync()
        {
            return await _db.ServiceBlocks
                .Include(b => b.BlockServices)
                .ToListAsync();
        }

        public async Task<ServiceBlock> GetBlockByIdAsync(int blockId)
        {
            return await _db.ServiceBlocks
                .Include(b => b.BlockServices)
                .FirstOrDefaultAsync(b => b.Id == blockId);
        }

        public async Task<ServiceBlock> CreateBlockAsync(ServiceBlock block)
        {
            _db.ServiceBlocks.Add(block);
            await _db.SaveChangesAsync();
            return block;
        }

        public async Task<ServiceBlock> UpdateBlockAsync(ServiceBlock block)
        {
            _db.ServiceBlocks.Update(block);
            await _db.SaveChangesAsync();
            return block;
        }

        public async Task DeleteBlockAsync(int blockId)
        {
            var block = await _db.ServiceBlocks.FindAsync(blockId);
            if (block == null) return;

            _db.ServiceBlocks.Remove(block);
            await _db.SaveChangesAsync();
        }

        public async Task<BlockService> GetBlockServiceAsync(int serviceId)
        {
            return await _db.BlockServices
                .FirstOrDefaultAsync(s => s.Id == serviceId);
        }

        public async Task<BlockService> CreateBlockServiceAsync(BlockService svc)
        {
            _db.BlockServices.Add(svc);
            await _db.SaveChangesAsync();
            return svc;
        }

        public async Task<BlockService> UpdateBlockServiceAsync(BlockService svc)
        {
            _db.BlockServices.Update(svc);
            await _db.SaveChangesAsync();
            return svc;
        }

        public async Task DeleteBlockServiceAsync(int serviceId)
        {
            var svc = await _db.BlockServices.FindAsync(serviceId);
            if (svc == null) return;

            _db.BlockServices.Remove(svc);
            await _db.SaveChangesAsync();
        }
    }
}
