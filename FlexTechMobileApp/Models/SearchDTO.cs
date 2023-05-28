using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexTechMobileApp.Models
{
    public class SearchDTO
    {
        public SearchDTO(string search) { 
            barcode = search;
        }

        public string barcode { get; set; }
    }
}
