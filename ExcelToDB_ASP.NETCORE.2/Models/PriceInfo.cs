using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace JSONToDB_ASPNETCORE2.Models
{
    public class PriceInfo
    {
        [Key]
        [JsonProperty("Time")]
        [Display(Name = " Effective Time")]
        [DataType(DataType.Date)]
        public int Time { get; set; }

        [Display(Name = " Effective Price")]
        [JsonProperty("Price")]
        public double Price { get; set; }

        [Display(Name = " Effective Value")]
        [JsonProperty("Value")]
        public double Value { get; set; }
    }
}
