using ECommerceSampleClassLibrary.Models;

namespace ECommerceSampleClassLibrary.Interfaces
{
    public interface ILoginService
    {
        string GenerateToken(ViewCustomer user);
        ViewCustomer Authenticate(UserLogin userLogin);
    }
}
