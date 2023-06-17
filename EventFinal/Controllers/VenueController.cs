using EventFinal.Repositories;
using EventFinal.ViewModel;
using EventFinal.Models;
using Dapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventFinal.Controllers
{
    public class VenueController : Controller
    {
        private readonly IVenueRepository _venueRepository;
        private readonly IWebHostEnvironment hostingEnvironment;
        public VenueController(IWebHostEnvironment hostingEnvironment, IVenueRepository venueRepository)
        {
            _venueRepository = venueRepository;
            this.hostingEnvironment = hostingEnvironment;
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(VenueViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = null;
                if (model.Photo != null)
                {
                    string uploadFolder = Path.Combine(hostingEnvironment.WebRootPath, "UploadedFiles");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                    string filepath = Path.Combine(uploadFolder, uniqueFileName);
                    model.Photo.CopyTo(new FileStream(filepath, FileMode.Create));
                    model.VenueFilePath = uniqueFileName;
                    model.VenueFilename = model.Photo.FileName;
                }
                Venue newVenue = new Venue
                {
                    VenueFilename = model.VenueFilename,
                    VenueFilePath=model.VenueFilePath,
                    VenueName = model.VenueName,
                    VenueCost = model.VenueCost,
                    Createdby = model.Createdby,
                };
                var createdvenue = await _venueRepository.SaveVenueAsync(newVenue);
                return RedirectToAction("Registration", "Registration");
            }
            return View();
        }

        public IActionResult GetVenues ()
        {
            IEnumerable<Venue> venues= _venueRepository.GetVenues();
            return View(venues);
        }

        public IActionResult VenueDetails(int id)
        {
            Venue venue = _venueRepository.GetVenueById(id);
            return View(venue);
            
        }
        public IActionResult DeleteVenue (int id)
        {

        }
    }
}
