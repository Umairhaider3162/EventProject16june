using EventFinal.Models;
using EventFinal.Repositories;
using EventFinal.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace EventFinal.Controllers
{
    public class EquipmentController : Controller
    {
        private readonly IEquipmentRepository _equipmentRepository;
        private readonly IWebHostEnvironment env;
        public EquipmentController(IEquipmentRepository equipmentRepository, IWebHostEnvironment env)
        {
            _equipmentRepository = equipmentRepository;
            this.env = env;
        }
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(EquipmentViewModel model)
        {
            if (ModelState.IsValid)
            {
                string unique = null;
                if (model.Photo != null)
                {
                    string uploadfolder = Path.Combine(env.WebRootPath, "UploadEquipment");
                    unique =Guid.NewGuid().ToString()+ "_" + model.Photo.FileName;
                    string filepath = Path.Combine(uploadfolder, unique);
                    model.Photo.CopyTo(new FileStream(filepath, FileMode.Create));
                    model.EquipmentFilePath = unique;
                    model.EquipmentFilename = model.Photo.FileName;
                }
                Equipment NewEquipment = new Equipment
                {
                    EquipmentFilename = model.EquipmentFilename,
                    EquipmentFilePath = model.EquipmentFilePath,
                    EquipmentName = model.EquipmentName,
                    EquipmentCost = model.EquipmentCost,
                    Createdby = 1,
                    Createdate=DateTime.Now,
                };
                var createdEquipment = await _equipmentRepository.AddEquipmentAsync(NewEquipment);
                return RedirectToAction("Create", "Venue");

            }
            return View();
        }

        public IActionResult ShowEquipment()
        {
            IEnumerable<Equipment> equipment = _equipmentRepository.ShowEquipmment();
            return View(equipment);
        }

        public IActionResult EquipmentDetails(int id)
        {
            var equipment = _equipmentRepository.GetEquipmentById(id);
            return View(equipment);
        }
    }
}
