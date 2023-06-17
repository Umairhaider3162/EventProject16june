using EventFinal.Models;
namespace EventFinal.Repositories
{
    public interface IRegistrationRepository
    {
        int CreateUser(Registration register);
       // string NEW_Customer(Registration Registration);
       // string NEW_Admin(Registration registration);
       // bool AddRegistration(Registration register);
    }
}
