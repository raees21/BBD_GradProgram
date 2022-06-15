using BeerHub.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace BeerHub.Models
{
  public class AlcoholType
  {

    #region Privates
    Collection<Alcohols> alcohols;
    private string type;
    #endregion

    #region Properties
    public string Type
    {
      get { return type; }
      set
      {
        if (type != value)
        {
          type = value;
        }
      }
    }

    public Collection<Alcohols> Alcohols
    {
      get { return alcohols; }
      set
      {
        if (alcohols != value)
        {
          alcohols = value;
        }
      }
    }
    #endregion

    #region Methods
    public bool AddAlcohol(Alcohols alcohol)
    {
      if (alcohol.SpecificType == Type)
      {
        Alcohols.Add(alcohol);
        return true;
      }
      return false;
    }

    public bool FindName(string name)
    {
      foreach( var alc in Alcohols)
      {
        if (alc.Name == name)
        {
          return true;
        }
      }
      return false;
    }

    public string GetVotes(string name)
    {
      foreach (var alc in Alcohols)
      {
        if (alc.Name == name)
        {
          
          return "Upvote: " + alc.Upvote + ", Downvote: " + alc.Downvote;
        }
      }
      return "Successful";
    }

    public bool UpVote(string name)
    {
      foreach (var alc in Alcohols)
      {
        if (alc.Name == name)
        {
          alc.UpVote();
          return true;
        }
      }
      return false;
    }

    public bool DownVote(string name)
    {
      foreach (var alc in Alcohols)
      {
        if (alc.Name == name)
        {
          alc.DownVote();
          return true;
        }
      }
      return false;
    }

    public Alcohols GetAlcohol(string name)
    {
      foreach (var alc in Alcohols)
      {
        if (alc.Name == name)
        {
          return alc;
        }
      }
      return null;
    }

    public bool RemoveAlcohol(string name)
    {
      foreach (var alc in Alcohols)
      {
        if (alc.Name == name)
        {
          Alcohols.Remove(alc);
          return true;
        }
      }
      return false;
    }

    public List<Alcohols> GetAllAlcohols()
    {
      return Alcohols.ToList();
    }
    #endregion

    #region CTOR
    public AlcoholType(Alcohols alcohol)
    {
      Type = alcohol.SpecificType;
      alcohols = new Collection<Alcohols>();
      alcohols.Add(alcohol);
    }
    #endregion

  }
}
