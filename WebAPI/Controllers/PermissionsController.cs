﻿using Infrastructure.Entities.CliresSystem;
using Infrastructure.Repositories;
using Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Filters;

namespace WebAPI.Controllers
{
    [ApiVersion("1.0")]
    [ApiController]
    [Route("api/[controller]")]
    [CustomTokenAuthFilter]
    public class PermissionsController : ControllerBase
    {
        private readonly IPermissionRepository permissionRepository;
        public PermissionsController(IPermissionRepository permissionRepository)
        {
            this.permissionRepository = permissionRepository;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {

            return Ok(await permissionRepository.GetPermissionList());
        }

        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetById(int id)
        //{
        //    var project = await Db.Projects.FindAsync(id);
        //    if (project == null)
        //        return NotFound();
        //    return Ok(project);
        //}

        //[HttpGet]
        //[Route("/api/Projects/{pid}/Tickets")]
        //public async Task<IActionResult> GetProjectTickets(int pId)
        //{
        //    var tickets = await Db.Tickets.Where(t => t.ProjectId == pId).ToListAsync();
        //    if (tickets == null || tickets.Count <= 0)
        //        return NotFound();

        //    return Ok(tickets);

        //}

        //[HttpPost]
        //public async Task<IActionResult> Post([FromBody] Project project)
        //{
        //    Db.Projects.Add(project);
        //    await Db.SaveChangesAsync();

        //    return CreatedAtAction(nameof(GetById),
        //            new { id = project.ProjectId },
        //            project
        //        );
        //}


        //[HttpPut("{id}")]
        //public async Task<IActionResult> Put(int id, Project project)
        //{
        //    if (id != project.ProjectId) return BadRequest();

        //    Db.Entry(project).State = EntityState.Modified;

        //    try
        //    {
        //        await Db.SaveChangesAsync();
        //    }
        //    catch
        //    {
        //        if (await Db.Projects.FindAsync(id) == null)
        //            return NotFound();
        //        throw;
        //    }
        //    return NoContent();
        //}

        //[HttpDelete("{id}")]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    var project = await Db.Projects.FindAsync(id);
        //    if (project == null) return NotFound();

        //    Db.Projects.Remove(project);
        //    Db.SaveChanges();

        //    return Ok(project);
        //}
    }
}