using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexTechMobileApp.Models
{
    public class PaginationWarehouseDTO
    {
        public int Current_page { get; set; }
        public List<WarehouseModel> Data { get; set; }
        public string First_page_url { get; set; }
        public int From { get; set; }
        public int Last_page { get; set; }
        public string Last_page_url { get; set; }
        public List<LinksModel> Links { get; set; }
        public string Next_page_url { get; set; }
        public string Path { get; set;}
        public int Per_page { get; set;}
        public string? Prev_page_url { get; set;}
        public int To { get; set;}
        public int Total { get; set;}

    }
}   
