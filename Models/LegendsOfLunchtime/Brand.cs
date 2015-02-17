using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Models.LegendsOfLunchtime
{
    public class Brand
    {
        [Key]
        public Guid Id {get; set;}

        public string Name {get; set;}

        public string LogoUrl {get; set;}
    }
}
