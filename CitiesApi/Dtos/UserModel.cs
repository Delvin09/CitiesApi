using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CitiesApi.Dtos
{
    public class UserModel
    {
        [Required(ErrorMessage = "Name not specified")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Value not specified")]
        public int? Value { get; set; }

        [Required(ErrorMessage = "CityId not specified")]
        public int? CityId { get; set; }
    }
}
