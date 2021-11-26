using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class mvcItemModel
    {

        public int ItemID { get; set; }

        [Required(ErrorMessage = "This Field is Required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "This Field is Required")]
        public int Price { get; set; }

        [Required(ErrorMessage = "This Field is Required")]
        public string Description { get; set; }
        [DisplayName("Upload Image")]
        public string Image { get; set; }
        public HttpPostedFileBase ImageFile { get; set; }
    }
}