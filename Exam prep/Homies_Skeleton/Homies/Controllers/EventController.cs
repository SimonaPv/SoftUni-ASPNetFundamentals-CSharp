using Homies.Models;
using Homies.Services.Event;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Homies.Controllers
{
    public class EventController : BaseController
    {
        private IEventService _eventService;

        public EventController(IEventService eventService)
        {
            this._eventService = eventService;
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            EditEventViewModel? book = await _eventService.GetEditEventByIdAsync(id);

            if (book == null)
            {
                return RedirectToAction(nameof(All));
            }

            return View(book);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, EditEventViewModel model)
        {
            if (ModelState.IsValid == false)
            {
                return View(model);
            }

            await _eventService.EditEventAsync(id, model);

            return RedirectToAction("All", "Event");
        }

        public async Task<IActionResult> All()
        {
            var model = await _eventService.ShowAllEventsAsync();

            return View(model);
        }

        public async Task<IActionResult> Leave(int id)
        {
            var ev = await _eventService.GetEventByIdAsync(id);

            if (ev == null)
            {
                return RedirectToAction("All", "Event");
            }

            string userId = GetUserId();
            await _eventService.RemoveEventAsync(userId, ev);

            return RedirectToAction("All", "Event");
        }

        public async Task<IActionResult> Join(int id)
        {
            var ev = await _eventService.GetEventByIdAsync(id);

            if (ev == null)
            {
                return RedirectToAction("All", "Event");
            }
             
            string userId = GetUserId();
            await _eventService.AddEventToUserAsync(userId, ev);

            return RedirectToAction("Joined", "Event");
        }

        public async Task<IActionResult> Joined()
        {
            string id = GetUserId();
            var models = await _eventService.AllJoinedEventsAsync(id);

            return View(models);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = await _eventService.AddTypesToEventAsync();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddEventViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            string id = GetUserId();

            await _eventService.AddEventAsync(id, model);
            return RedirectToAction("All", "Event");
        }

        public async Task<IActionResult> Details(int id)
        {
            var model = await _eventService.DetailsForEventAsync(id);

            if (model == null)
            {
                return RedirectToAction("All", "Event");
            }

            return View(model);
        }
    }
}
