using Application.Common.Interfaces;

namespace Service.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        public string UserId => "JohnDoe";
    }
}
