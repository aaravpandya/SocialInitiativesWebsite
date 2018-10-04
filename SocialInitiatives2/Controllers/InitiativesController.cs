using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialInitiatives2.Models;
using SocialInitiatives2.Models.ViewModels;
using System.Drawing;

namespace SocialInitiatives2.Controllers
{
    public class InitiativesController : Controller
    {
        public InitiativeDbContext InitiativeDbContext;
        public InitiativesController(InitiativeDbContext dbContext)
        {
            InitiativeDbContext = dbContext;
        }

        [Route("Initiatives")]
        [Route("[controller]/[action]")]
        public IActionResult Index()
        {
            ViewBag.SelectedNav = "Initiatives";
            return View();
        }

        public IActionResult GetInitiativeForm(InitiativeModel initiativeModel)
        {
            Initiative initiative = new Initiative();
            initiative.Name = initiativeModel.Name;
            initiative.InitiativeAddress = initiativeModel.InitiativeAddress;
            initiative.Field = initiative.Field;
            initiative.OwnerName = initiativeModel.OwnerName;
            initiative.work = initiativeModel.work;
            IFormFile uploadedImage = initiativeModel.imageUpload;
            if (uploadedImage == null || uploadedImage.ContentType.ToLower().StartsWith("Image/"))
            {
                MemoryStream ms = new MemoryStream();
                uploadedImage.OpenReadStream().CopyTo(ms);
                System.Drawing.Image image = System.Drawing.Image.FromStream(ms);
                Infrastructure.Image imageEntity = new Infrastructure.Image();
                imageEntity.Name = uploadedImage.Name;
                imageEntity.Data = ms.ToArray();
                imageEntity.Width = image.Width;
                imageEntity.Height = image.Height;
                imageEntity.ContentType = uploadedImage.ContentType;

            }
            InitiativeDbContext.Add(initiative);
            InitiativeDbContext.SaveChanges();
            return Redirect(initiativeModel?.returnUrl ?? "/Index/Home");
        }
    }
}