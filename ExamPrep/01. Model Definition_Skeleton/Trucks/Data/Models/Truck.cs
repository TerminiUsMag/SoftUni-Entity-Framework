﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trucks.Common;
using Trucks.Data.Models.Enums;

namespace Trucks.Data.Models
{
    public class Truck
    {
        public Truck()
        {
            this.ClientsTrucks = new HashSet<ClientTruck>();
        }
        [Key]
        public int Id { get; set; }
        [MaxLength(ValidationConstants.TruckRegistrationNumberLength)]
        public string? RegistrationNumber { get; set; }
        [Required]
        [MaxLength(ValidationConstants.TruckVinNumberLength)]
        public string VinNumber { get; set; } = null!;
        public int TankCapacity { get; set; }
        public int CargoCapacity { get; set; }
        [Required]
        public CategoryType CategoryType { get; set; }
        [Required]
        public MakeType MakeType { get; set; }
        [ForeignKey(nameof(Despatcher))]
        [Required]
        public int DespatcherId { get; set; }
        public Despatcher Despatcher { get; set; } = null!;
        public ICollection<ClientTruck> ClientsTrucks { get; set; }



    }
}
