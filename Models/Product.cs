using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DotNetLabExam.Models
{
    public class Product
    {
        [Key]
        [Display(Name ="Product Id")]
        public int ProductId { set; get; }

        [Display(Name ="Product Name")]
        [Required(ErrorMessage ="You Have Not entered a Product Name")]
        [DataType(DataType.Text)]
        [StringLength(50,ErrorMessage ="the {0} value Can not be greater than {1} values")]
        public string ProductName { set; get; }


        [Required(ErrorMessage = "You Have Not Entered a Rate of Product")]
        [DataType(DataType.Currency)]
        [Display(Name = "Rate Of Product")]
        public decimal Rate { set; get; }


        [DataType(DataType.Text)]
        [Required(ErrorMessage = "You Have Not Description of a Product Name")]
        [StringLength(200,ErrorMessage ="The Length of {0} can not be greater than {1} chars")]

        public string Description { set; get; }



        [DataType(DataType.Text)]
        [Required(ErrorMessage = "You Have Not Entered  a Category Name")]
        [StringLength(50,ErrorMessage ="the length of {0} can not be greater than {1} chars")]
        public string CategoryName { set; get; }


    }
}