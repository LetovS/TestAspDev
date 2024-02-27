using AutoMapper;
using Store.Entities;
using Web.Api.Contracts;
using Web.Api.Services.DTOModels;

namespace Web.Api.Infrastructure.Automapper;

internal class ApiProfile : Profile
{
    public ApiProfile()
    {
        CreateMap<AnswerRequest, CreateAnswerModel>();

        CreateMap<QuestionRecord, QuestionResponse>()
            .ForMember(x => x.Id, opt => opt.MapFrom(d => d.Id))
            .ForMember(x => x.Question, opt => opt.MapFrom(d => d.Question))
            .ForMember(x => x.AnswerOptions, opt => opt.MapFrom(d => d.Answers));

        CreateMap<AnswerRecord, AnswerOption>()
            .ForMember(x => x.Answer, opt => opt.MapFrom(y => y.Answer));
    }
}
