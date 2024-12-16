using Microsoft.EntityFrameworkCore;
using WebConsulting.Models;

namespace WebConsulting.Other
{
    public class ServicesService
    {
        private readonly ConsultingDBContext _context;

        public ServicesService(ConsultingDBContext context)
        {
            _context = context;
        }

        public async Task<List<Service>> GetAllServicesAsync()
        {
            return await _context.Services.ToListAsync();
        }

        public async Task DeleteServiceAsync(int serviceId)
        {
            var service = await _context.Services.FindAsync(serviceId);
            if (service != null)
            {
                _context.Services.Remove(service);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Service> GetServiceByIdAsync(int serviceId)
        {
            return await _context.Services.FindAsync(serviceId);
        }

        public async Task AddServiceAsync(Service newService)
        {
            _context.Services.Add(newService);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateServiceAsync(Service updatedService)
        {
            _context.Services.Update(updatedService);
            await _context.SaveChangesAsync();
        }
    }
}
