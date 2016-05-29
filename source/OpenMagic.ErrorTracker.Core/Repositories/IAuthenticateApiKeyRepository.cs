using System.Threading.Tasks;

namespace OpenMagic.ErrorTracker.Core.Repositories
{
    public interface IAuthenticateApiKeyRepository
    {
        Task<bool> AuthenticateAsync(string apiKey);
    }
}