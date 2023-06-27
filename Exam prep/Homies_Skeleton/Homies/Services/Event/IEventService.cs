using Homies.Models;

namespace Homies.Services.Event
{
    public interface IEventService
    {
        Task<ICollection<AllEventViewModel>> ShowAllEventsAsync();

        Task<AddEventViewModel> AddTypesToEventAsync();

        Task AddEventAsync(string userId, AddEventViewModel viewModel);

        Task<ICollection<JoinedEventViewModel>> AllJoinedEventsAsync(string id);

        Task<JoinedEventViewModel> GetEventByIdAsync(int id);

        Task<EditEventViewModel> GetEditEventByIdAsync(int id);

        Task AddEventToUserAsync(string userId, JoinedEventViewModel viewModel);

        Task RemoveEventAsync(string userId, JoinedEventViewModel ev);

        Task EditEventAsync(int id, EditEventViewModel model);

        Task<DetailsEventViewModel> DetailsForEventAsync(int id);
    }
}
