using System;
using System.Collections.Generic;
using System.Text;

namespace TraderManagementApp.BusinessLayer.ViewModels
{
    public class TraderViewModel
    {
        public int TraderId { get; set; }
        public string Name { get; set; }
        public string MobileNumber { get; set; }
        public int Age { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
