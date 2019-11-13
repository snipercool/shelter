using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace Shelter.Shared
{
    public interface IDatabaseInitializer
    {
        void Initialize();
    }

    public class DatabaseInitializer : IDatabaseInitializer
    {
        private ShelterContext _context;
        private ILogger<DatabaseInitializer> _logger;
        public DatabaseInitializer(ShelterContext context, ILogger<DatabaseInitializer> logger)
        {
        _context = context;
        _logger = logger;
        }
        public void Initialize()
        {
            try
        {
        if (_context.Database.EnsureCreated())
        {
            AddData();
        }
        }
        catch (Exception ex)
        {
            _logger.LogCritical(ex, "Error occurred while creating database");

        }
    }

    private void AddData()
    {
      /* var tripel = new BeerType { Name = "Tripel" };
      var pils = new BeerType { Name = "Pils" };
      var brewery = new Brewery()
      {
        Name = "InBev Belgium",
        Owner = new Owner()
        {
          Name = "InBev"
        },
        Beers = new List<Beer> {
          new Beer { Name = "Jupiler", BeerType = pils },
          new Beer { Name = "Tripel Karmeliet ", BeerType = tripel},
          new Beer { Name = "Stella", BeerType = pils }
        }
      };
      _context.Breweries.Add(brewery);

      _context.SaveChanges(); */
        Var shelter = new Shelter(){
            Cats = new List<Cat> {
                new Cat {Id = 1, Name = "Felix", DateOfBirth = "19/01/2005", IsChecked = true, KidFriendly = true, DateOfArrival = "23/09/2019"},
                new Cat {Id = 2, Name = "Bacardi", DateOfBirth = "22/07/2008", IsChecked = true, KidFriendly = false, DateOfArrival = "12/06/2018"},
                new Cat {Id = 3, Name = "Misty", DateOfBirth = "01/01/2001", IsChecked = true, KidFriendly = true, DateOfArrival = "12/06/2009"}
            }
        }
        _context.Shelters.Add(shelter);
        _context.SaveChanges();
    }
}