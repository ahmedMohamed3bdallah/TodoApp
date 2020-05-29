using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Todo.Commands.Create.Dto;
using Application.Todo.Commands.Delete.Dto;
using Application.Todo.Commands.Update.Dto;
using Application.Todo.Commands.UpdateList;
using Application.Todo.Queries.Get;
using Application.Todo.Queries.Get.Dto;
using Application.Todo.Queries.GetAll;
using Application.Todo.Queries.GetAll.Dto;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class TodoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TodoController(IMediator mediator)
        {
            this._mediator = mediator;
        }


        [HttpGet("{UserID}")]
        public async Task<ActionResult<List<TodoGetAllQueryDto>>> GetAll(long UserID)
        {
            return Ok(await _mediator.Send(new GetAllQuery { UserID = UserID }));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TodoGetQueryDto>> Get(long ID)
        {

            return Ok(await _mediator.Send(new GetQuery { ID = ID }));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TodoCreateCommandDto commandDto)
        {
            await _mediator.Send(commandDto);
            return Ok(commandDto);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] TodoUpdateCommandDto commandDto)
        {
            return Ok(await _mediator.Send(commandDto));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateList([FromBody] UpdateListCommand commandDto)
        {
            return Ok(await _mediator.Send(commandDto));
        }


        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete(long id)
        {
            return Ok(await _mediator.Send(new TodoDeleteCommandDto { ID = id }));
        }

    }
}