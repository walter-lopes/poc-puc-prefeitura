﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Poc.Puc.SGM.GeneralIntegration.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Poc.Puc.SGM.GeneralIntegration.Controllers
{
    [Route("project")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IHttpClientFactory _clientFactory;

        public ProjectController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateProjectModel project)
        {
            var projectJson = new StringContent(
                                JsonConvert.SerializeObject(project),
                                Encoding.UTF8,
                                "application/json");

            var client = _clientFactory.CreateClient();
            var response = await client.PostAsync($"https://localhost:44363/project", projectJson);

            if (response.IsSuccessStatusCode)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromRoute] Guid id, ChangeStatusRequest request)
        {
            var json = new StringContent(
                                JsonConvert.SerializeObject(request),
                                Encoding.UTF8,
                                "application/json");

            var client = _clientFactory.CreateClient();
            var response = await client.PutAsync($"https://localhost:44363/project/{id}", json);

            if (response.IsSuccessStatusCode)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var client = _clientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:44363/project");

            if (response.IsSuccessStatusCode)
            {
                return Ok(response.Content);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            var client = _clientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:44363/project/{id}");

            if (response.IsSuccessStatusCode)
            {
                return Ok(response.Content);
            }
            else
            {
                return BadRequest();
            }
        }
    }


    public class ChangeStatusRequest
    {
        public string EmployeeEmail { get; set; }

        public string Status { get; set; }
    }
}