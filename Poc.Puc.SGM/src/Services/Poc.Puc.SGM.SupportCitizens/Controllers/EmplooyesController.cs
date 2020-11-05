﻿using Microsoft.AspNetCore.Mvc;
using Poc.Puc.SGM.SupportCitizens.Domain;
using Poc.Puc.SGM.SupportCitizens.Repositories;
using Poc.Puc.SGM.SupportCitizens.Services;
using System;
using System.Threading.Tasks;

namespace Poc.Puc.SGM.SupportCitizens.Controllers
{

    [Route("employees")]
    [ApiController]
    public class EmplooyesController : ControllerBase
    {
        private readonly EmplooyeRepository repository;

        public EmplooyesController()
        {
            var repository = new EmplooyeRepository();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Employee emp)
        {
            await repository.InsertAsync(emp);

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromRoute] Guid id,[FromBody] Employee emp)
        {
            await repository.UpdateAsync(emp, x => x.Id == id);

            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            var emp = await repository.GetByIdAsync(x => x.Id == id);

            return Ok(emp);
        }
    }
}