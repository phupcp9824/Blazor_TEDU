using Blazored.LocalStorage;
using Data;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;

namespace Blazor.Service
{
    public interface ITaskApiClient
    {
        Task<List<TaskDto>> Get(TaskListSearch taskListSearch);

        Task<List<AssigneeDto>> GetAssignee();

        Task<bool> DeleteTask(Guid id);

        Task<LoginResponse> Login(LoginRequest loginRequest);
        Task Logout();
    }

    public class TaskApiClient(HttpClient Http, ILocalStorageService _localStorage, AuthenticationStateProvider _authenticationStateProvider) : ITaskApiClient
    {
        public async Task<bool> DeleteTask(Guid id)
        {
            var result = await Http.DeleteAsync($"api/Blazor/{id}");
            return result.IsSuccessStatusCode;
        }

        public async Task<List<TaskDto>> Get(TaskListSearch taskListSearch)
        {
            string Url = $"api/Blazor?name={taskListSearch.name}&assigneeId={taskListSearch.AssigneeId}&priority={taskListSearch.Priority}";
            var result = await Http.GetFromJsonAsync<List<TaskDto>>(Url);
            return result;
        }

        public async Task<List<AssigneeDto>> GetAssignee()
        {
            var result = await Http.GetFromJsonAsync<List<AssigneeDto>>("api/User");
            return result;
        }

        public async Task<LoginResponse> Login(LoginRequest loginRequest)
        {
            var result = await Http.PostAsJsonAsync("api/Login", loginRequest);
            var content = await result.Content.ReadAsStringAsync();
            var loginresponse = JsonSerializer.Deserialize<LoginResponse>(content,
                new JsonSerializerOptions()
                {
                    PropertyNameCaseInsensitive = true
                });
            if (result.IsSuccessStatusCode)
            {
                await _localStorage.SetItemAsync("authToken", loginresponse.Token);
                ((ApiAuthenticationStateProvider)_authenticationStateProvider).MarkUserAsAuthenticated(loginRequest.UserName);
                Http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", loginresponse.Token);
                return loginresponse;
            }
            else 
            {
                return loginresponse;
            }
        }
        public async Task Logout()
        {
            await _localStorage.RemoveItemAsync("authToken");
            ((ApiAuthenticationStateProvider)_authenticationStateProvider).MarkUserAsLoggedOut();
            Http.DefaultRequestHeaders.Authorization = null;
        }
    }
}
