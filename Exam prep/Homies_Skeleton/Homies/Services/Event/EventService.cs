using Homies.Data;
using Homies.Data.Entities;
using Homies.Models;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;
using Event = Homies.Data.Entities.Event;

namespace Homies.Services.Event
{
    public class EventService : IEventService
    {
        private readonly HomiesDbContext _dbContext;

        public EventService(HomiesDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task AddEventAsync(string userId, AddEventViewModel viewModel)
        {
            Data.Entities.Event ev = new Data.Entities.Event()
            {
                Name = viewModel.Name,
                Description = viewModel.Description,
                HasStart = DateTime.ParseExact(viewModel.Start, "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
                HasEnd = DateTime.ParseExact(viewModel.End, "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
                TypeId = viewModel.TypeId,
                OrganiserId = userId,
                CreatedOn = DateTime.UtcNow
            };

            await _dbContext.Events.AddAsync(ev);
            await _dbContext.SaveChangesAsync();
        }

        public async Task AddEventToUserAsync(string userId, JoinedEventViewModel viewModel)
        {
            bool alreadyAdded = await _dbContext.EventsParticipants
                .AnyAsync(e => e.HelperId == userId && e.EventId == viewModel.Id);

            if (alreadyAdded == false)
            {
                var userEvent = new EventParticipant()
                {
                    HelperId = userId,
                    EventId = viewModel.Id,
                };

                await _dbContext.EventsParticipants.AddAsync(userEvent);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<AddEventViewModel> AddTypesToEventAsync()
        {
            var types = await _dbContext.Types
                .Select(e => new TypeEventViewModel
                {
                    Id = e.Id,
                    Name = e.Name
                }).ToListAsync();

            var evvent = new AddEventViewModel()
            {
                Types = types
            };

            return evvent;
        }

        public async Task<ICollection<JoinedEventViewModel>> AllJoinedEventsAsync(string id)
        {
            return await _dbContext.EventsParticipants
                .Where(p => p.HelperId == id)
                .Select(e => new JoinedEventViewModel
                {
                    Id = e.EventId,
                    Name = e.Event.Name,
                    Start = e.Event.HasStart,
                    Type = e.Event.Type.Name,
                    Organiser = e.Helper.UserName
                }).ToListAsync();
        }

        public async Task<JoinedEventViewModel> GetEventByIdAsync(int id)
        {
            var ev = await _dbContext.Events
                .Include(e => e.Type)
                .Include(e => e.Organiser)
                .FirstOrDefaultAsync(e => e.Id == id);

            if (ev == null)
            {
                return null;
            }

            var model = new JoinedEventViewModel()
            {
                Id = ev.Id,
                Name = ev.Name,
                Start = ev.HasStart,
                Type = ev.Type.Name,
                Organiser = ev.Organiser.UserName
            };

            return model;
        }

        public async Task RemoveEventAsync(string userId, JoinedEventViewModel ev)
        {
            var @event = await _dbContext.EventsParticipants
                .FirstOrDefaultAsync(e => e.HelperId == userId && e.EventId == ev.Id);

            if (@event != null)
            {
                _dbContext.EventsParticipants.Remove(@event);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<ICollection<AllEventViewModel>> ShowAllEventsAsync()
        {
            return await _dbContext.Events
                .Select(e => new AllEventViewModel
                {
                    Id = e.Id,
                    Name = e.Name,
                    Type = e.Type.Name,
                    Start = e.HasStart.ToString("yyyy-MM-dd H:mm"),
                    Organiser = e.Organiser.UserName
                }).ToListAsync();
        }

        public async Task<EditEventViewModel> GetEditEventByIdAsync(int id)
        {
            var ev = await _dbContext.Events
                .Include(e => e.Type)
                .Include(e => e.Organiser)
                .FirstOrDefaultAsync(e => e.Id == id);

            if (ev == null)
            {
                return null;
            }

            var types = await _dbContext.Types
                .Select(e => new TypeEventViewModel
                {
                    Id = e.Id,
                    Name = e.Name
                }).ToListAsync();

            var model = new EditEventViewModel()
            {
                Id = ev.Id,
                Description = ev.Description,
                Name = ev.Name,
                Start = ev.HasStart.ToString(),
                End = ev.HasEnd.ToString(),
                TypeId = ev.Type.Id,
                Types = types
            };

            return model;
        }

        public async Task EditEventAsync(int id, EditEventViewModel model)
        {
            var ev = await _dbContext.Events.FindAsync(id);

            if (ev != null)
            {
                ev.Name = model.Name;
                ev.Description = model.Description;
                ev.HasStart = DateTime.Parse(model.Start);
                ev.HasEnd = DateTime.Parse(model.End);
                ev.TypeId = model.TypeId;

                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<DetailsEventViewModel> DetailsForEventAsync(int id)
        {
            var ev = await _dbContext.Events
                .Include(e => e.Type)
                .Include(e => e.Organiser)
                .FirstOrDefaultAsync(e => e.Id == id);

            if (ev == null)
            {
                return null;
            }

            var model = new DetailsEventViewModel()
            {
                Id = ev.Id,
                Name = ev.Name,
                Description = ev.Description,
                Start = ev.HasStart.ToString(),
                End = ev.HasEnd.ToString(),
                Organiser = ev.Organiser.Email,
                Type = ev.Type.Name,
                CreatedOn = ev.CreatedOn.ToString()
            };

            return model;
        }
    }
}
