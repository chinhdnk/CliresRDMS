using ApplicationCore.Repositories.CliresSystem;
using Infrastructure.Constant;
using Infrastructure.Entities.CliresSystem;
using Infrastructure.Models.CliresSystem;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using WebApi.Filters;

namespace WebAPI.Controllers.CliresSystem.Admin
{
    [ApiVersion("1.0")]
    [ApiController]
    [Route("api/cliressystem/[controller]")]
    [JwtAuthorize]
    public class GroupController : ControllerBase
    {
        private readonly IGroupRepository groupRepository;
        private readonly CliresSystemDBContext dbContext;
        public GroupController(IGroupRepository groupRepository, CliresSystemDBContext db)
        {
            this.groupRepository = groupRepository;
            this.dbContext = db;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await groupRepository.GetGroupList());
        }

        [HttpGet("{groupId}")]
        public async Task<IActionResult> GetById(int groupId)
        {
            Group group = await groupRepository.GetGrouByID(groupId);
            if (group == null)
                return NotFound();
            return Ok(group);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Group group)
        {
            group.CreatedBy = HttpContext.Items[UserIdentityConstant.USERNAME].ToString();
            group.CreatedDate = DateTime.Now;
            bool isGroupExist= await groupRepository.CheckGroupExist(0, group.GroupName);

            if (isGroupExist)
                return StatusCode((int)HttpStatusCode.Conflict, "group_exist");

            int groupID = await groupRepository.CreateGroup(group);
            if (groupID == 0)
                return NotFound();
            return Ok(group);
        }

        [HttpPut("{groupId}")]
        public async Task<IActionResult> Put(int groupId, Group group)
        {
            if (groupId != group.GroupID) return BadRequest();
            group.ModifiedBy = HttpContext.Items[UserIdentityConstant.USERNAME].ToString();
            group.ModifiedDate = DateTime.Now;
            bool isGroupExist = await groupRepository.CheckGroupExist(groupId, group.GroupName);
            if (isGroupExist)
                return StatusCode((int)HttpStatusCode.Conflict, "group_exist");

            int result = await groupRepository.UpdateGroup(groupId, group);
            if (result != 1)
                return NotFound();
            return Ok(group);
        }

        [HttpDelete("{groupId}")]
        public async Task<IActionResult> Delete(int groupId)
        {
            bool result = await groupRepository.DeleteGroup(groupId);
            if (result)
                return Ok();
            else
                return NotFound();
        }
    }
}
