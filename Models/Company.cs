﻿using System.ComponentModel;

namespace Project_1_KYH.Models
{
    public class Company
    {
        [DisplayName("Company ID")]
        public int ID { get; set; }
        [DisplayName("Company Name")]
        public string Name { get; set; }
    }
}
