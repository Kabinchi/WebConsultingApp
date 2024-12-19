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
        return _context.Users.FirstOrDefault(u => u.Id == userId);
    }

    public async Task<List<Application>> GetApplicationsByUserId(int userId)
    {
        using var context = new ConsultingDBContext();
        return await context.Applications
            .Include(a => a.Service)
            .Where(a => a.UserId == userId)
            .ToListAsync();
    }


    public async Task UpdateUser(User user)
    {
        var existingUser = _context.Users.FirstOrDefault(u => u.Id == user.Id);
        if (existingUser != null)
        {
            existingUser.FullName = user.FullName;
            existingUser.PhoneNumber = user.PhoneNumber;
            existingUser.Email = user.Email;

            _context.Users.Update(existingUser);
            await _context.SaveChangesAsync();
        }
    }
}
