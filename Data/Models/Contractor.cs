using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace VehicleRegisterApp.Data.Models
{
    public class Contractor
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        public string Name { get; set; }
        [EmailAddress, Required]
        public string Email { get; set; }
        [Phone, Required]
        public string PhoneNumber {  get; set; }
        public Collection<Vehicle> Vehicles { get; set; }
    }
}
