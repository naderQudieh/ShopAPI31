using System.Threading.Tasks;

namespace Core.Auth
{
    public interface IJwtFactory
    {
        Task<AccessToken> GenerateEncodedToken(string id, string userName);
    }
}