using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CodeFirstLab.Models.Places
{
    public class Province
    {
        [Key]
        [Display(Name = "Province Code")]
        public string ProvinceCode { get; set; }
        [Display(Name = "Province")]
        public string ProvinceName { get; set; }
        public List<City> Cities { get; set; }
    }
}