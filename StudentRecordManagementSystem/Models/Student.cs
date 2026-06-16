using System.ComponentModel.DataAnnotations;

namespace StudentRecordManagementSystem.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Display(Name = "Roll Number")]
        public int RollNumber { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(30, ErrorMessage = "Name cannot exceed 30 characters.")]
        [RegularExpression(@"^[A-Za-z ]+$",
            ErrorMessage = "Name should contain only alphabets and spaces.")]
        [Display(Name = "Student Name")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Maths marks are required.")]
        [Range(1, 100, ErrorMessage = "Marks must be between 1 and 100.")]
        [Display(Name = "Maths Marks")]
        public int Maths { get; set; }

        [Required(ErrorMessage = "Physics marks are required.")]
        [Range(1, 100, ErrorMessage = "Marks must be between 1 and 100.")]
        [Display(Name = "Physics Marks")]
        public int Physics { get; set; }

        [Required(ErrorMessage = "Chemistry marks are required.")]
        [Range(1, 100, ErrorMessage = "Marks must be between 1 and 100.")]
        [Display(Name = "Chemistry Marks")]
        public int Chemistry { get; set; }

        [Required(ErrorMessage = "English marks are required.")]
        [Range(1, 100, ErrorMessage = "Marks must be between 1 and 100.")]
        [Display(Name = "English Marks")]
        public int English { get; set; }

        [Required(ErrorMessage = "Programming marks are required.")]
        [Range(1, 100, ErrorMessage = "Marks must be between 1 and 100.")]
        [Display(Name = "Programming Marks")]
        public int Programming { get; set; }

        public bool IsActive { get; set; } = true;

        // Computed Properties

        public int Total =>
            Maths + Physics + Chemistry + English + Programming;

        public double Average =>
            Total / 5.0;

        public string Grade
        {
            get
            {
                return Average switch
                {
                    >= 90 => "A+",
                    >= 80 => "A",
                    >= 70 => "B",
                    >= 60 => "C",
                    >= 50 => "D",
                    _ => "F"
                };
            }
        }
    }
}