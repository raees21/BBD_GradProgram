using BeerHub.Interfaces;

using System;

using System.Collections.Generic;

using System.Collections.ObjectModel;

using System.ComponentModel.DataAnnotations;

using System.Linq;

using System.Threading.Tasks;




namespace BeerHub.Models

{

  public class Cocktails

  {

    [Key]

    public int CocktailsId { get; set; }

    public string CocktailName { get; set; }

    public string CocktailIngredients { get; set; }

    public double Percentage { get; set; }

  }

}