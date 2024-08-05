using MediatR;
using RedeTestCase.API.Application.Mediator.Base;

namespace RedeTestCase.API.Application.Features.Commands.Person
{
    public class InsertPersonRequest : IRequest<HandleResponse>
    {
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
