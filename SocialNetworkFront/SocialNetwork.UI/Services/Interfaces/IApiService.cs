namespace SocialNetwork.UI.Services.Interfaces
{
    public interface IApiService
    {
        public Task<T> GetAsync<T>(string endpoint);
        public Task<T> CreateAsync<T>(string endpoint, T data);
    }
}
