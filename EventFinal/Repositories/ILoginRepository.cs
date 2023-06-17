using EventFinal.Models;
namespace EventFinal.Repositories
{
    public interface ILoginRepository
    {
        Registration Login(string Username, string Password);
    }
}
