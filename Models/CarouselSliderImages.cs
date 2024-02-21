using System.ComponentModel.DataAnnotations;

namespace TS.Models
{
    public class CarouselSliderImages
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Enter Carousel Main Heading")]
        [Display(Name = "Main Heading")]
        [StringLength(150)]
        public string Heading_Content { get; set; }

        [Display(Name = "Content Caption")]
        [Required(ErrorMessage = "Enter Carousel Content Caption")]
        [StringLength(250)]
        public string Content_Caption { get; set; }

        [Display(Name = "Carousel Button Title")]
        [Required(ErrorMessage = "Enter Carousel Button Title")]
        [StringLength(150)]
        public string Carousel_Button_Title { get; set; }

        [Display(Name = "Carousel Button URL")]
        [Required(ErrorMessage = "Enter Carousel Button URL")]
        [StringLength(150)]
        public string Carousel_Button_URL { get; set; }


        [Display(Name = "Carousel Image")]
        [Required(ErrorMessage = "Choose an Image")]
        public string CSImage { get; set; }
    }
}
