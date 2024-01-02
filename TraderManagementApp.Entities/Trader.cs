using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System;

namespace TraderManagementApp.Entities
{
    public class Trader
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TraderId { get; set; }
        public string Name { get; set; }
        public string MobileNumber { get; set; }
        public int Age { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
