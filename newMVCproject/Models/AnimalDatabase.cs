using System.Collections.Generic;
using Shelter.Shared;

namespace newMVCproject.Models
{
    public class AnimalDatabase
    {
        private static bool _isInitialized = false;
        private static Shelter.Shared.Shelter _shelter = null;
        
        private static void Initialize(){
            if (!_isInitialized){

                var shelter = new Shelter.Shared.Shelter()
                {
                    Cats = new List<Cat> {
                        new Cat {Id = 1, Name = "Felix", DateOfBirth = "19/01/2005", IsChecked = true, KidFriendly = true, DateOfArrival = "23/09/2019"},
                        new Cat {Id = 2, Name = "Bacardi", DateOfBirth = "22/07/2008", IsChecked = true, KidFriendly = false, DateOfArrival = "12/06/2018"},
                        new Cat {Id = 3, Name = "Misty", DateOfBirth = "01/01/2001", IsChecked = true, KidFriendly = true, DateOfArrival = "12/06/2009"}
                    }
                };

                _shelter = shelter;
                _isInitialized = true;
            }
        }

        public static Shelter.Shared.Shelter Shelter
        {
            get{
                Initialize();
                return _shelter;
            }
        }
    }
}