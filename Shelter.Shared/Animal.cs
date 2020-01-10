using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Shelter.Shared
{
    public abstract class Animal : BaseDbClass
    {
        public string name { get; set; }
        public string DateOfBirth { get; set; }
        public bool IsChecked { get; set; }
        public bool KidFriendly { get; set; }
        public string DateOfArrival{ get; set; }
        
        [Required]
        public int ShelterId { get; set; }
    }
}