using System;
using GASF.ApplicationLogic.Data;
using GASF.ApplicationLogic.Services;
using GASF.Models.Groups;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GASF.Controllers
{
    [Authorize(Policy = "Secretary")]
    public class GroupController: Controller
    {
        private readonly GroupService groupService;

        public GroupController(GroupService groupService)
        {
            this.groupService = groupService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var indexViewModel = new GroupIndexViewModel {
                groups = groupService.GetAll()
            };
            return View(indexViewModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new Group());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([FromForm]Group group)
        {
            groupService.Add(group);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(string groupId)
        {
            try
            {
                var groupToEdit = groupService.GetById(Guid.Parse(groupId));
                return View(groupToEdit);
            }
            catch (InvalidOperationException)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([FromForm]Group group)
        {
            groupService.Update(group);
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(string groupId)
        {
            try
            {
                var groupToDelete = groupService.GetById(Guid.Parse(groupId));

                groupService.Delete(groupToDelete);

                return RedirectToAction("Index");
            }
            catch (InvalidOperationException)
            {
                return BadRequest();
            }   
        }
    }
}