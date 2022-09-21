using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PycApi.Dto.Dto
{
    public class ProductDto
    {
        [Required(ErrorMessage = "Ürün adı girmek zorunludur.")]
        [MaxLength(100, ErrorMessage = "En Fazla 100 karaker girin")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "Ürün adı girmek zorunludur.")]
        [MaxLength(500)]
        public string Descripton { get; set; }


        [Required(ErrorMessage = "Kategori girmek zorunludur.")]
        public int CategoryId { get; set; }


        [Required(ErrorMessage = "Renk girmek zorunludur.")]
        public string Color { get; set; }


        [Required(ErrorMessage = "Marka girmek zorunludur.")]
        public string Brand { get; set; }


        [Required(ErrorMessage = "Fiyat girmek zorunludur.")]
        [Range(0, double.MaxValue, ErrorMessage = "Geçerli bir değer giriniz.")]
        public double Price { get; set; }


    }
}
