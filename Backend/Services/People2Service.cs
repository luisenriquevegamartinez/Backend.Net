using Backend.Controllers;

namespace Backend.Services
{
    public class People2Service : IPeopleService
    {
        public bool IsInvalid(People people) {
            if(people.Name == null) return true;
            if(people.Name.Length < 3) return true;
            return false;
        }

    }
}
