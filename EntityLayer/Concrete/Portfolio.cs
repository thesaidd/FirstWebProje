using EntityLayer.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Portfolio : BaseEntity
    {
        [Key]
        public int PortfolioID { get; set; }
        public string Name { get; set; }
        public string ImageuUrl { get; set; }
        public string ProjectUrl { get; set; }
        public string ImageuUrl2 { get; set; }
        


    }
}
