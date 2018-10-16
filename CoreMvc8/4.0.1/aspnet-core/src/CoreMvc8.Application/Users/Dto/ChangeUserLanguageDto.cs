using System.ComponentModel.DataAnnotations;

namespace CoreMvc8.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}