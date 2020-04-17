using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Activities;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/{controller}")]
    [ApiController]
    public class ActivitiesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ActivitiesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<Activity>>> GetList()
        {
            return await _mediator.Send(new ActivityList.Query());
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<Activity>> GetDetail(Guid id)
        {
            return await _mediator.Send(new ActivityDetail.Query { Id = id });
        }
    }
}