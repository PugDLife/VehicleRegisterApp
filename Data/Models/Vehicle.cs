using System.ComponentModel.DataAnnotations;

namespace VehicleRegisterApp.Data.Models
{
    public class Vehicle
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        public string Type {  get; set; }
        public string RegNumber {  get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        public double Weight { get; set; }  
        public Guid ContractorId { get; set; }
    }
}
