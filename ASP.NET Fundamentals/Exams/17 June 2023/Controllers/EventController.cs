using Homies.Constants;
using Homies.Data;
using Homies.Data.Models;
using Homies.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Homies.Controllers;

[Authorize]
public class EventController:Controller
{
    private readonly HomiesDbContext dbContext;

    public EventController(HomiesDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<IActionResult> All()
    {
        PreviewEventViewModel[] events = await dbContext.Events
            .Select(e => new PreviewEventViewModel()
            {
                Id = e.Id,
                Name = e.Name,
                Start = e.Start.ToString(EventConstants.DateTimeFormat),
                Type = e.Type.Name,
                Organiser = e.Organiser.UserName
            })
            .AsNoTracking()
            .ToArrayAsync();

        return View(events);
    }
    public async Task<IActionResult> Add()
    {
        FullEventViewModel viewModel = await GetEmptyEventViewModelWithTypesAsync();

        return View(viewModel);
    }

    [HttpPost]
    public async Task<IActionResult> Add(FullEventViewModel model)
    {
        if(ModelState.IsValid == false)
        {
            return View(model);
        }

        Event newEvent = new Event()
        {
            Name = model.Name,
            Description = model.Description,
            OrganiserId = User.FindFirstValue(ClaimTypes.NameIdentifier),
            CreatedOn = DateTime.Now,
            Start = model.Start,
            End = model.End,
            TypeId = model.TypeId
        };

        dbContext.Events.Add(newEvent);
        await dbContext.SaveChangesAsync();

        return RedirectToAction(nameof(All));
    }
    public async Task<IActionResult> Edit(int id)
    {
        Event? e = await dbContext.Events.FirstOrDefaultAsync(e => e.Id == id);

        if(e == null)
        {
            return RedirectToAction(nameof(All));
        }

        string currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        if(currentUserId != e.OrganiserId)
        {
            return RedirectToAction(nameof(All));
        }

        FullEventViewModel viewModel = await GetEmptyEventViewModelWithTypesAsync();

        viewModel.Name = e.Name;
        viewModel.Description = e.Description;
        viewModel.Start = e.Start;
        viewModel.End = e.End;
        viewModel.TypeId = e.TypeId;

        return View(viewModel);
    }
    [HttpPost]
    public async Task<IActionResult> Edit(int id,FullEventViewModel model)
    {
        Event? e = await dbContext.Events.FirstOrDefaultAsync(e => e.Id == id);

        if(e == null)
        {
            return RedirectToAction(nameof(All));
        }

        string currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        if(currentUserId != e.OrganiserId)
        {
            return RedirectToAction(nameof(All));
        }

        e.Name = model.Name;
        e.Description = model.Description;
        e.Start = model.Start;
        e.End = model.End;
        e.TypeId = model.TypeId;

        await dbContext.SaveChangesAsync();

        return RedirectToAction(nameof(All));
    }
    public async Task<IActionResult> Join(int id)
    {
        string? organiserId = await dbContext.Events
            .Where(e => e.Id == id)
            .Select(e => e.OrganiserId)
            .FirstOrDefaultAsync();

        if(organiserId == null)
        {
            return RedirectToAction(nameof(All));
        }

        string currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        if(currentUserId == organiserId)
        {
            return RedirectToAction(nameof(All));
        }

        bool isAlreadyJoined = dbContext.EventsParticipants.Any(ep => ep.HelperId == currentUserId && ep.EventId == id);

        if(isAlreadyJoined)
        {
            return RedirectToAction(nameof(All));
        }

        EventParticipant eventParticipant = new EventParticipant()
        {
            EventId = id,
            HelperId = currentUserId
        };

        dbContext.EventsParticipants.Add(eventParticipant);

        await dbContext.SaveChangesAsync();

        return RedirectToAction(nameof(Joined));
    }
    public async Task<IActionResult> Joined()
    {
        string currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        PreviewEventViewModel[] selectedEvents = await dbContext.Events
            .Where(e => e.EventsParticipants.Any(ep => ep.HelperId == currentUserId) || e.OrganiserId == currentUserId)
            .Select(e => new PreviewEventViewModel()
            {
                Id = e.Id,
                Name = e.Name,
                Start = e.Start.ToString(EventConstants.DateTimeFormat),
                Type = e.Type.Name,
                Organiser = e.Organiser.UserName
            })
            .AsNoTracking()
            .ToArrayAsync();

        return View(selectedEvents);
    }
    public async Task<IActionResult> Leave(int id)
    {
        string currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        EventParticipant? eventParticipant = dbContext.EventsParticipants
            .FirstOrDefault(ep => ep.HelperId == currentUserId && ep.EventId == id);

        if(eventParticipant == null)
        {
            return RedirectToAction(nameof(All));
        }

        dbContext.EventsParticipants.Remove(eventParticipant);

        await dbContext.SaveChangesAsync();

        return RedirectToAction(nameof(All));
    }
    //public async Task<IActionResult> Details(int id)
    //{
    //    Event? e = await dbContext.Events.FirstOrDefaultAsync(e => e.Id == id);

    //    if(e == null)
    //    {
    //        return RedirectToAction(nameof(All));
    //    }




    //}
    private async Task<FullEventViewModel> GetEmptyEventViewModelWithTypesAsync()
    {
        TypeViewModel[] types = await dbContext.Types
            .Select(t => new TypeViewModel()
            {
                Id = t.Id,
                Name = t.Name
            })
            .AsNoTracking()
            .ToArrayAsync();

        FullEventViewModel viewModel = new FullEventViewModel();

        viewModel.Types = types;

        return viewModel;
    }
}
