﻿using MediatR;
using RedeTestCase.API.Mediator.Base;

namespace RedeTestCase.API.Features.Commands.Person
{
    public class UpdatePersonRequest : IRequest<HandleResponse>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public string TelefoneNumber { get; set; }
        public string Country { get; set; }
        public bool IsFreelance { get; set; }
        public bool IsMarried { get; set; }
        public int JobCategoryId { get; set; }
    }
}
