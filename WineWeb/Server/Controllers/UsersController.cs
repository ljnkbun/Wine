using Microsoft.AspNetCore.Mvc;
using WineWeb.Server.Parameters;
using WineWeb.Server.Queries;

namespace WineWeb.Server.Controllers
{
    public class UsersController : BaseApiController
    {
        // GET: api/v1/<controller>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] UsersParameter filter)
        {
            return Ok(await Mediator.Send(new GetUserssQuery()
            {
                PageSize = filter.PageSize,
                PageNumber = filter.PageNumber,
                CreatedDate = filter.CreatedDate,
                ModifiedDate = filter.ModifiedDate,
                CreatedUserId = filter.CreatedUserId,
                ModifiedUserId = filter.ModifiedUserId,
                Username = filter.Username,
                Password = filter.Password,
                IsActive = filter.IsActive,
            }));
        }

        //// GET api/v1/<controller>/5
        //[HttpGet("{id}")]
        //public async Task<IActionResult> Get(int id)
        //{
        //    return Ok(await Mediator.Send(new GetUsersQuery { Id = id }));
        //}

        //// POST api/v1/<controller>
        //[HttpPost]
        //public async Task<IActionResult> Post(CreateUsersCommand command)
        //{
        //    return Ok(await Mediator.Send(command));
        //}

        //// PUT api/v1/<controller>/5
        //[HttpPut("{id}")]
        //public async Task<IActionResult> Put(int id, UpdateUsersCommand command)
        //{
        //    if (id != command.Id) return BadRequest();
        //    return Ok(await Mediator.Send(command));
        //}

        //// DELETE api/v1/<controller>/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    return Ok(await Mediator.Send(new DeleteUsersCommand { Id = id }));
        //}

    }
}