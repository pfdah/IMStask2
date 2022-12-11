using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;

namespace Ims_task.Model
{
    public class TariffDetails
    {
        public int startUnit { get; set; }
        public int endUnit { get; set; }
        public decimal energyRate { get; set; }
        public decimal serviceCharge { get; set; }
        [Key]
        public int tariffId { get; set; }
        public TariffMaster master { get; set; }
    }
    public class TariffMaster
    {
        [Key]
        public int tariffId { get; set; }
        [Required]
        public int rebateDays { get; set; }
        [Required]
        public decimal rebateRate { get; set; }
        [Required]
        public int penaltyDays { get; set; }
        [Required]
        public decimal penaltyRate { get; set; }
        public TariffDetails details { get; set; }
    }
}
