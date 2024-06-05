using Backend.Controllers;

namespace Backend.Services
{
    public class PeopleService : IPeopleService
    {
        public bool IsInvalid(People people) => string.IsNullOrEmpty(people.Name);

    }
}
