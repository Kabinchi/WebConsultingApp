using Microsoft.EntityFrameworkCore;
using WebConsulting.Models;

namespace WebConsulting.Other
{
    public class ApplicationService
    {
        private readonly ConsultingDBContext _context;

        public ApplicationService(ConsultingDBContext context)
        {
            _context = context;
        }

        public async Task<List<Application>> GetAllApplications()
        {
            return await _context.Applications
                .Include(a => a.User)
                .Include(a => a.ApplicationServices)
                    .ThenInclude(appService => appService.Service) // Добавляем загрузку связанных услуг
                .ToListAsync();
        }
    }
}