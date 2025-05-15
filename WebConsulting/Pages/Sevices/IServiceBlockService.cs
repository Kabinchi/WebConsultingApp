// Services/IServiceBlockService.cs
using System.Collections.Generic;
using System.Threading.Tasks;
using WebConsulting.Models;

namespace WebConsulting.Services
{
    public interface IServiceBlockService
    {
        Task<IEnumerable<ServiceBlock>> GetAllBlocksAsync();
        Task<ServiceBlock> GetBlockByIdAsync(int blockId);
        Task<ServiceBlock> CreateBlockAsync(ServiceBlock block);
        Task<ServiceBlock> UpdateBlockAsync(ServiceBlock block);
        Task DeleteBlockAsync(int blockId);

        Task<BlockService> GetBlockServiceAsync(int serviceId);
        Task<BlockService> CreateBlockServiceAsync(BlockService svc);
        Task<BlockService> UpdateBlockServiceAsync(BlockService svc);
        Task DeleteBlockServiceAsync(int serviceId);
    }
}
