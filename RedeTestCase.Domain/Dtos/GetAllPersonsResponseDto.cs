﻿namespace RedeTestCase.Domain.Dtos
{
    public class GetAllPersonsResponseDto
    {
        public int PersonId { get; set; }
        public string JobCategoryDescription { get; set; }
        public int JobCategoryId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public string TelefoneNumber { get; set; }
        public string Country { get; set; }
        public bool IsFreelance { get; set; }
        public bool IsMarried { get; set; }
        public bool Active { get; set; }
    }
}
