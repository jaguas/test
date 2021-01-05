using System.Threading.Tasks;

namespace Application.Common.Behaviours
{
    public interface IIdentityService
    {
        Task<string> GetUserNameAsync(string userId);
    }
}