﻿using MediaVisualizer.Services;
using MediaVisualizer.Shared.Dtos;
using MediaVisualizer.Shared.Requests;
using Microsoft.AspNetCore.Mvc;

namespace MediaVisualizer.Api.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class ManwhaController : ControllerBase
{
    private readonly IManwhaService _manwhaService;

    public ManwhaController(IManwhaService manwhaService)
    {
        _manwhaService = manwhaService;
    }

    [HttpGet]
    [Route("~/api/[controller]/{id:int}")]
    public async Task<IActionResult> Get(int id)
    {
        return Ok(await _manwhaService.Get(id));
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] FiltersRequest filters)
    {
        return Ok(await _manwhaService.GetList(filters));
    }

    [HttpGet]
    public async Task<ActionResult<ManwhaDto>> GetRandom()
    {
        return Ok(await _manwhaService.GetRandom());
    }

    [HttpGet]
    public async Task<IActionResult> GetTitles()
    {
        return Ok(await _manwhaService.GetTitles());
    }
}