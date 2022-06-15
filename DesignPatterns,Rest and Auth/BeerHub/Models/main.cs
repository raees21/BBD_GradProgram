using BeerHub.Controllers;
using BeerHub.Database;
using BeerHub.Interfaces;
using BeerHub.Mappers;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace BeerHub.Models
{
  public class Main
  {
    private AlcoholMapper map;
    private AlcoholMainCollection amc;

    public Main()
    {
      map = new AlcoholMapper();
      amc = new AlcoholMainCollection();
      loadAlcohol();
      AutoSaveAsync();
    }

    private async Task AutoSaveAsync()
    {
      while (true)
      {
        await Task.Delay(TimeSpan.FromMinutes(10));
        Save();
      }
    }

    #region Gets
    public Alcohols GetAlcohol(string name)
    {
      return amc.GetAlcohol(name.ToLower());
    }

    public bool UpVote(string name)
    {
      return amc.UpVote(name.ToLower());
    }

    public List<Alcohols> GetAllAlcohols()
    {
      return amc.GetAllAlcohols();
    }
    #endregion

    #region Post

    public bool RemoveAlcohol(string name)
    {
      bool temp = amc.RemoveAlcohol(name.ToLower());
      if (temp)
      {
        RemoveAlcohols(name.ToLower());
      }
      return temp;
    }

    public bool AddAlcohol(Alcohols alcohol)
    {
      return amc.AddAlcohol(alcohol);
    }

    public void Save()
    {
      foreach (var l in GetAllAlcohols())
      {
        Save(l);
      }
    }
    #endregion

    #region Puts
    public bool Downvote(string name)
    {
      return amc.DownVote(name.ToLower());
    }

    public string GetVotes(string name)
    {
      return amc.GetVotes(name.ToLower());
    }
    #endregion

    public void loadAlcohol()
    {
      string queryString = "SELECT * from Alcohol";
      string connectionString = "Data Source=beerhub.cefferesjfkl.us-east-1.rds.amazonaws.com;Initial Catalog=BeerHub;Persist Security Info=True;User ID=admin;Password=Raees123.";

      using (SqlConnection connection = new SqlConnection(connectionString))
      {
        SqlCommand command = new SqlCommand(queryString, connection);
        command.Parameters.AddWithValue("@tPatSName", "Your-Parm-Value");
        connection.Open();
        SqlDataReader reader = command.ExecuteReader();
        try
        {
          while (reader.Read())
          {
            amc.AddAlcohol(new Alcohols((string)reader["Name"], (string)reader["Type"], (string)reader["SpecificType"], (double)reader["Percentage"], (int)reader["AlcoholId"], (int)reader["Calories"], (int)reader["Downvote"], (int)reader["Upvote"]));
          }
        }
        finally
        {
          // Always call Close when done reading.
          reader.Close();
        }
      }
    }

    public void Save(Alcohols alc)
    {
      string query = "MERGE INTO Alcohol a USING( " +
        " VALUES (" + alc.ID + ",'" + alc.Name + "', '" + alc.Type + "','" + alc.SpecificType + "', " + alc.Percentage + ", " + alc.Calories + ", " + alc.Downvote + " , " + alc.Upvote + ") )" +
        " AS m(AlcoholId, Name, Type, SpecificType, Percentage, Calories, Downvote, Upvote )" +
        " ON a.AlcoholId = m.AlcoholId" +
        " WHEN MATCHED THEN" +
        " UPDATE SET a.Name = m.Name, a.SpecificType=m.SpecificType, a.Percentage=m.Percentage, a.Calories=m.Calories, a.Downvote=m.Downvote, a.Upvote=m.Upvote" +
        " " +
        " WHEN NOT MATCHED THEN" +
        " INSERT( Name, Type, SpecificType, Percentage, Calories, Downvote, Upvote )" +
        " VALUES(m.Name, m.Type, m.SpecificType, m.Percentage, m.Calories,  m.Downvote, m.Upvote); ";
      string connectionString = "Data Source=beerhub.cefferesjfkl.us-east-1.rds.amazonaws.com;Initial Catalog=BeerHub;Persist Security Info=True;User ID=admin;Password=Raees123.";
      using (SqlConnection connection = new SqlConnection(connectionString))
      {
        SqlCommand command = new SqlCommand(query, connection);
        connection.Open();
        SqlDataReader reader = command.ExecuteReader();
        try
        {
        }
        finally
        {
          // Always call Close when done reading.
          reader.Close();
        }
      }
    }


    public void RemoveAlcohols(string name)
    {
      string queryString = "DELETE FROM Alcohol where Name = @tPatSName";
      string connectionString = "Data Source=beerhub.cefferesjfkl.us-east-1.rds.amazonaws.com;Initial Catalog=BeerHub;Persist Security Info=True;User ID=admin;Password=Raees123.";

      using (SqlConnection connection = new SqlConnection(connectionString))
      {
        SqlCommand command = new SqlCommand(queryString, connection);
        command.Parameters.AddWithValue("@tPatSName", name.ToLower());
        connection.Open();
        SqlDataReader reader = command.ExecuteReader();
        try
        {
        }
        finally
        {
          // Always call Close when done reading.
          reader.Close();
        }
      }
    }
  }
}
