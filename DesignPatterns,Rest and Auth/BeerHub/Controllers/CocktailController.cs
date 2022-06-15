using BeerHub.Database;
using BeerHub.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeerHub.Controllers
{

    [ApiController]
    [Route("api")]
    public class CocktailController : ControllerBase
    {
        private readonly DBManager _db;

        public CocktailController(DBManager db)
        {
            _db = db;
        }

        [Route("GetAllCocktails")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cocktails>>> GetAllCocktails()
        {
            return await _db.cocktails.ToListAsync();
        }

        [Route("GetCocktailsByAlcohol/{alcohol}")]
        [HttpGet]
        public List<Cocktails> GetCocktailsbyAlcohol(string alcohol)
        {
            var cocktailList = new List<Cocktails>();
            for (int j = 1; j <= _db.cocktails.Count(); j++)
            {
                string cocktailByAlc = _db.cocktails.Find(j).CocktailIngredients;
                string[] words = cocktailByAlc.Split(",", StringSplitOptions.TrimEntries);
                for (int i = 0; i < words.Length; i++)
                {
                    if (alcohol.ToLower() == words[i].ToLower())
                    {
                        Cocktails cocktails = new Cocktails
                        {
                            CocktailName = _db.cocktails.Find(j).CocktailName,
                            CocktailIngredients = _db.cocktails.Find(j).CocktailIngredients,
                            Percentage = _db.cocktails.Find(j).Percentage
                        };
                        cocktailList.Add(cocktails);
                    }
                }
            }
            return cocktailList;
        }

        [Route("UpdateCocktail/{id}")]
        [HttpPatch]
        public async Task<ActionResult<IEnumerable<Cocktails>>> UpdateCocktail(int id, Cocktails newCocktail)
        {
            Cocktails cocktail = await _db.cocktails.FirstOrDefaultAsync(p => p.CocktailsId == id);

            if (cocktail == null)
            {
                return NotFound();
            }
            cocktail.CocktailIngredients = newCocktail.CocktailIngredients ?? newCocktail.CocktailIngredients;
            cocktail.CocktailName = newCocktail.CocktailName ?? newCocktail.CocktailName;
            cocktail.Percentage = newCocktail.Percentage;
            await _db.SaveChangesAsync();
            return Ok();
        }

        [Route("NewCocktail")]
        [HttpPost]
        public async Task<ActionResult<Cocktails>> NewCocktail(Cocktails newCocktail)
        {

            _db.cocktails.Add(newCocktail);
            await _db.SaveChangesAsync();
            return Ok();
        }

        [Route("DeleteCocktail/{cocktailId}")]
        [HttpDelete]
        public async Task<ActionResult> DeleteProduct(int cocktailId)
        {
            Cocktails cocktail = await _db.cocktails.FirstOrDefaultAsync(p => p.CocktailsId == cocktailId);

            if (cocktail == null)
            {
                return NotFound();
            }

            _db.cocktails.Remove(cocktail);

            await _db.SaveChangesAsync();

            return StatusCode(201);
        }
    }
}