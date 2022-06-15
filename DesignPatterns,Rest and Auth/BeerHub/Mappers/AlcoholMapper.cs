using BeerHub.Interfaces;
using BeerHub.Models;

namespace BeerHub.Mappers
{
    public class AlcoholMapper
    {
        public AlcoholMapper()
        {

        }

        public Alcohols AlcoholDTOToAlcohol(Alcohol alcoholDTO)
        {
            Alcohols a = new Alcohols();
            a.ID = alcoholDTO.AlcoholId;
            a.Name = alcoholDTO.Name;
            a.Type = alcoholDTO.Type;
            a.Percentage = alcoholDTO.Percentage;
            a.Calories = alcoholDTO.Calories;
            a.SpecificType = alcoholDTO.SpecificType;
            a.Upvote = alcoholDTO.Upvote;
            a.Downvote = alcoholDTO.Downvote;
            return a;
        }

        public Alcohol AlcoholToAlcoholDTO(Alcohols alcohol)
        {
            Alcohol a = new Alcohol();
            a.AlcoholId = alcohol.ID;
            a.Name = alcohol.Name;
            a.Type = alcohol.Type;
            a.SpecificType = alcohol.SpecificType;
            a.Calories = alcohol.Calories;
            a.Percentage = (float) alcohol.Percentage;
            a.Upvote = alcohol.Upvote;
            a.Downvote = alcohol.Downvote;
            return a;
        }
    }
}
