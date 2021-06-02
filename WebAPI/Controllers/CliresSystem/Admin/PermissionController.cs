﻿using Infrastructure.Entities.CliresSystem;
using Infrastructure.Repositories.CiresSystem;
using Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Filters;
using Infrastructure.Models.Admin;
using Infrastructure.Constant;

namespace WebAPI.Controllers.CliresSystem
{
    [ApiVersion("1.0")]
    [ApiController]
    [Route("api/cliressystem/[controller]")]
    [JwtAuthorize]
    public class PermissionController : ControllerBase
    {
        private readonly IPermissionRepository permissionRepository;
        private readonly CliresSystemDBContext dbContext;
        public PermissionController(IPermissionRepository permissionRepository, CliresSystemDBContext db)
        {
            this.permissionRepository = permissionRepository;
            this.dbContext = db;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {

            return Ok(await permissionRepository.GetPermissionList());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            TblPermission item = await dbContext.TblPermissions.Where(x => x.PermId == id).FirstOrDefaultAsync();
            if (item == null)
                return NotFound();
            return Ok(item);
        }

        //[HttpPost]
        //public async Task<IActionResult> Post([FromBody] Permission permission)
        //{
        //    int permId = await permissionRepository.CreatePermission(permission);
        //    permission.PermissionID = permId;

        //    return CreatedAtAction(nameof(GetById),
        //            new { id = permId },
        //            permission
        //        );
        //}


        [HttpPut("{permId}")]
        public async Task<IActionResult> Put(int permId, Permission permission)
        {
            if (permId != permission.PermissionID) return BadRequest();
            int result= await permissionRepository.UpdatePermission(permId, permission);
            if (result != 0)
                return NotFound();
            return Ok(permission);
        }
    }
}