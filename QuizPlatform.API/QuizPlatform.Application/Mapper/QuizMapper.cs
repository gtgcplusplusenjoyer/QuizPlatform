using AutoMapper;
using QuizPlatform.Application.Dto.Quiz;
using QuizPlatform.Core.Entities;

namespace QuizPlatform.Application.Mapper
{
    public class QuizMapper : Profile
    {
        public QuizMapper()
        {
            CreateMap<Quiz, QuizResponseDto>()
                .ForMember(dest => dest.AuthorName,
                    opt => opt.MapFrom(src => src.Author != null ? src.Author.UserName : "Unknown"))
                .ForMember(dest => dest.Status,
                    opt => opt.MapFrom(src => (int)src.Status))
                .ForMember(dest => dest.QuestionCount,
                    opt => opt.MapFrom(src => src.Questions != null ? src.Questions.Count : 0));

            CreateMap<Quiz, QuizSummaryDto>()
                .ForMember(dest => dest.Status,
                    opt => opt.MapFrom(src => (int)src.Status))
                .ForMember(dest => dest.QuestionCount,
                    opt => opt.MapFrom(src => src.Questions != null ? src.Questions.Count : 0))
                .ForMember(dest => dest.AttemptsCount,
                    opt => opt.MapFrom(src => (int?)null))
                .ForMember(dest => dest.AverageScore,
                    opt => opt.MapFrom(src => (int?)null));

            CreateMap<CreateQuizRequestDto, Quiz>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.UserId, opt => opt.Ignore())
                .ForMember(dest => dest.Author, opt => opt.Ignore())
                .ForMember(dest => dest.Status, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.PublishedAt, opt => opt.Ignore())
                .ForMember(dest => dest.Questions, opt => opt.Ignore());

            CreateMap<UpdateQuizRequestDto, Quiz>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.UserId, opt => opt.Ignore())
                .ForMember(dest => dest.Author, opt => opt.Ignore())
                .ForMember(dest => dest.Status, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.PublishedAt, opt => opt.Ignore())
                .ForMember(dest => dest.Questions, opt => opt.Ignore())
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
             
             
        }
    }
}
