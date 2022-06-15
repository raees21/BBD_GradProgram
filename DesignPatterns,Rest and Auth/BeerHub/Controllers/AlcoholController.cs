using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using BeerHub.Interfaces;
using BeerHub.Models;
using System.Collections.ObjectModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using BeerHub.Database;
using Microsoft.EntityFrameworkCore;

namespace BeerHub.Controllers
{

  [ApiController]
  [Route("api")]
  public class AlcoholController : ControllerBase
  {

    static Main main = new Main();

    #region Gets
    [Route("Alcohol/{name}")]
    [HttpGet]
    public ActionResult GetAlcohol(string name)
    {
      return StatusCode(200, main.GetAlcohol(name));
    }

    [Route("Alcohol/")]
    [HttpPost]
    public ActionResult AddAlcohol([FromBody] Alcohols alcohols)
    {
      return StatusCode(201, main.AddAlcohol(alcohols));
    }

    [Route("GetVotes/{name}")]
    [HttpGet]
    public ActionResult GetVotes(string name)
    {
      if (main.GetVotes(name) == null) return NotFound(); //404
      return StatusCode(200, main.GetVotes(name));
    }

    [Route("GetAllAlcohols/")]
    [HttpGet]
    public ActionResult<Alcohol> GetAllAlcohols()
    {
      if (main.GetAllAlcohols() == null) return NotFound(); //404

      return StatusCode(200, main.GetAllAlcohols());
    }
    #endregion

    #region Puts
    [Route("Upvote/{name}")]
    [HttpGet]
    public bool UpVote(string name)
    {
      return main.UpVote(name);
    }

    [Route("Downvote/{name}")]
    [HttpGet]
    public bool Downvote(string name)
    {
      return main.Downvote(name);
    }
    #endregion

    #region Delete
    [Route("Alcohol/{name}")]
    [HttpDelete]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public bool RemoveAlcohol(string name)
    {
      return main.RemoveAlcohol(name);
    }
    #endregion

    #region Post

    [Route("save/")]
    [HttpPost]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public void Save()
    {
      main.Save();
    }
    #endregion
    //[HttpGet]
    //public IEnumerable<Alcohol> GetAllAlcohols()
    //{
    //    return alcohols;
    //}

    //[Route("api/alcohol/{id}")]
    //[HttpGet]
    //public IActionResult GetAlcohol(int id)
    //{
    //    var alcohol = alcohols.FirstOrDefault((p) => p.ID == id);
    //    if(alcohol == null)
    //    {
    //        return NotFound();
    //    }
    //    return Ok(alcohol);
    //}

    //[Route("api/new-alchohol")]
    //[HttpPost]
    //public IActionResult NewAlcohol(Alcohol newAlcohol)
    //{
    //    if (!ModelState.IsValid)
    //    {
    //        return BadRequest("Invalid Data");
    //    }
    //    alcohols.Prepend(newAlcohol);
    //    return Ok(alcohols.Append(newAlcohol));
    //}

    //[Route("api/alcohol/new-ingredients")]
    //[HttpPost]
    //public IActionResult NewIngredients(int id, List<string> newIngredients)
    //{
    //    var alcohol = alcohols.FirstOrDefault((p) => p.ID == id);
    //    if (alcohol == null)
    //    {
    //        return NotFound();
    //    }
    //    alcohol.Ingredients = new List<string>(newIngredients);

    //    return Ok(alcohol);
    //}






    //[HttpGet]
    //public IEnumerable<Alcohol> GetAllAlcohols()
    //{
    //    return alcohols;
    //}

    //[Route("api/alcohol/{id}")]
    //[HttpGet]
    //public IActionResult GetAlcohol(int id)
    //{
    //    var alcohol = alcohols.FirstOrDefault((p) => p.ID == id);
    //    if(alcohol == null)
    //    {
    //        return NotFound();
    //    }
    //    return Ok(alcohol);
    //}

    //[Route("api/new-alchohol")]
    //[HttpPost]
    //public IActionResult NewAlcohol(Alcohol newAlcohol)
    //{
    //    if (!ModelState.IsValid)
    //    {
    //        return BadRequest("Invalid Data");
    //    }
    //    alcohols.Prepend(newAlcohol);
    //    return Ok(alcohols.Append(newAlcohol));
    //}

    //[Route("api/alcohol/new-ingredients")]
    //[HttpPost]
    //public IActionResult NewIngredients(int id, List<string> newIngredients)
    //{
    //    var alcohol = alcohols.FirstOrDefault((p) => p.ID == id);
    //    if (alcohol == null)
    //    {
    //        return NotFound();
    //    }
    //    alcohol.Ingredients = new List<string>(newIngredients);

    //    return Ok(alcohol);
    //}

  }
}
