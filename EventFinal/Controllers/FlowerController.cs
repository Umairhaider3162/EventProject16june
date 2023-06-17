using EventFinal.Repositories;
using EventFinal.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace EventFinal.Controllers
{
   

    public class FlowerController : Controller
    {
        private readonly IFlowerRepository _flowerRepository;
        private readonly IWebHostEnvironment env;

        public FlowerController(IFlowerRepository flowerRepository,IWebHostEnvironment env)
        {
            _flowerRepository=flowerRepository;
            this.env=env;
        }
        public IActionResult Create()
        {
            return View();
        }
        public async Task<IActionResult> Create( FlowerViewModel model)
        {
            if (ModelState.IsValid)
            {
               string uniqueName = null;
                if (model.Photo != null)
                {
                    string UploadedFolder = Path.Combine(env.WebRootPath, "UploadeFlower");
                    uniqueName = Guid.NewGuid().ToString()+"_" + model.Photo.FileName;
                    string filepath = Path.Combine(uploadedFolder, uniqueName);
                }

            }
        }
    }
}
