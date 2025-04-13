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

        public async Task<Service> GetServiceByIdAsync(int id)
        {
            return await _context.Services
                .AsNoTracking()
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task AddServiceAsync(Service newService)
        {
            _context.Services.Add(newService);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateServiceAsync(Service updatedService)
        {
            var existingService = await _context.Services.FindAsync(updatedService.Id);

            if (existingService == null)
            {
                throw new ArgumentException("Услуга не найдена");
            }

            _context.Entry(existingService).CurrentValues.SetValues(updatedService);

            await _context.SaveChangesAsync();
        }
    }
}
