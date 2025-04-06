using Microsoft.EntityFrameworkCore;
using WebConsulting.Models;

public class UserService
{
    private readonly ConsultingDBContext _context;

    public UserService(ConsultingDBContext context)
    {
        _context = context;
    }

    public User GetUserById(int userId)
    {
        return _context.Users
            .Include(u => u.Applications)
                .ThenInclude(a => a.ApplicationServices)
                    .ThenInclude(appService => appService.Service)
            .FirstOrDefault(u => u.Id == userId);
    }

    public async Task<List<Application>> GetActiveApplicationsByUserId(int userId)
    {
        return await _context.Applications
            .Where(a => a.UserId == userId && !a.IsDeleted)
            .Include(a => a.ApplicationServices)
                .ThenInclude(appService => appService.Service)
            .OrderByDescending(a => a.CreatedAt)
            .ToListAsync();
    }

    public async Task<List<Application>> GetAllApplicationsByUserId(int userId)
    {
        return await _context.Applications
            .Where(a => a.UserId == userId)
            .Include(a => a.ApplicationServices)
                .ThenInclude(appService => appService.Service)
            .OrderByDescending(a => a.CreatedAt)
            .ToListAsync();
    }

    public async Task UpdateUser(User user)
    {
        var existingUser = await _context.Users.FindAsync(user.Id);
        if (existingUser != null)
        {
            existingUser.FullName = user.FullName;
            existingUser.PhoneNumber = user.PhoneNumber;
            existingUser.Email = user.Email;

            await _context.SaveChangesAsync();
        }
    }

    public async Task<bool> CancelApplication(int applicationId, string reason, string canceledBy, int canceledById)
    {
        var application = await _context.Applications
            .Include(a => a.ApplicationServices)
            .FirstOrDefaultAsync(a => a.Id == applicationId);

        if (application == null) return false;

        application.IsDeleted = true;
        application.DeletedAt = DateTime.Now;
        application.DeleteReason = reason;
        application.DeletedBy = canceledBy;
        application.DeletedByUserId = canceledById.ToString();
        application.Status = "Отменено";

        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> RestoreApplication(int applicationId)
    {
        var application = await _context.Applications
            .IgnoreQueryFilters()
            .Include(a => a.ApplicationServices)
            .FirstOrDefaultAsync(a => a.Id == applicationId);

        if (application == null || !application.IsDeleted) return false;

        application.IsDeleted = false;
        application.DeletedAt = null;
        application.DeleteReason = null;
        application.DeletedBy = null;
        application.DeletedByUserId = null;
        application.Status = "В ожидании";

        await _context.SaveChangesAsync();
        return true;
    }
}