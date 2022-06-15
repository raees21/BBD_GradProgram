using BeerHub.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace BeerHub.Models
{
  public class AlcoholMainCollection
  {
    private Collection<AlcoholTypeCollection> alcoholTypeCollection;

    public Collection<AlcoholTypeCollection> AlcoholTypeCollection
    {
      get { return alcoholTypeCollection; }
      set
      {
        if (alcoholTypeCollection != value)
        {
          alcoholTypeCollection = value;
        }
      }
    }

    public bool AddAlcohol(Alcohols alcohol)
    {
      
      foreach(var atc in AlcoholTypeCollection)
      {
        if(atc.Type == alcohol.Type)
        {
          return atc.AddAlcohol(alcohol);
        }
      }
      AlcoholTypeCollection.Add(new AlcoholTypeCollection(alcohol));
      return true;
    }

    public bool UpVote(string name)
    {
      foreach (var atc in AlcoholTypeCollection)
      {
        if (atc.FindName(name) == true)
        {
          return atc.UpVote(name);
        }
      }
      return false;
    }

    public bool DownVote(string name)
    {
      foreach (var atc in AlcoholTypeCollection)
      {
        if (atc.FindName(name) == true)
        {
          return atc.DownVote(name);
        }
      }
      return false;
    }

    public string GetVotes(string name)
    {
      foreach (var atc in AlcoholTypeCollection)
      {
        if (atc.FindName(name) == true)
        {
          return atc.GetVotes(name);
        }
      }
      return "";
    }

    public Alcohols GetAlcohol(string name)
    {
      foreach (var atc in AlcoholTypeCollection)
      {
        if (atc.FindName(name) == true)
        {
          return atc.GetAlcohol(name);
        }
      }
      return null;
    }

    public bool RemoveAlcohol(string name)
    {
      foreach (var atc in AlcoholTypeCollection)
      {
        if (atc.FindName(name) == true)
        {
          return atc.RemoveAlcohol(name);
        }
      }
      return false;
    }

    public List<Alcohols> GetAllAlcohols()
    {
      List<Alcohols> tmp = new List<Alcohols>();
      foreach(var atc in AlcoholTypeCollection)
      {
        tmp.AddRange(atc.GetAllAlcohols());
      }
      return tmp;
    }

    public AlcoholMainCollection()
    {
      AlcoholTypeCollection = new Collection<AlcoholTypeCollection>();
    }

  }
}
