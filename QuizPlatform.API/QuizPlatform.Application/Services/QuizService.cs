using AutoMapper;
using QuizPlatform.Application.Dto.Quiz;
using QuizPlatform.Application.Exceptions;
using QuizPlatform.Application.Interfaces;
using QuizPlatform.Core.Entities;
using QuizPlatform.Core.Enums;
using QuizPlatform.Core.Repositories;

namespace QuizPlatform.Application.Services
{
    public class QuizService : IQuizService
    {
        private readonly IUserRepository _userRepository;
        private readonly IQuizRepository _quizRepository;
        private readonly IMapper _mapper;
        public QuizService(IUserRepository userRepository, IQuizRepository quizRepository, IMapper mapper)
        {
            _quizRepository = quizRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<QuizResponseDto> CreateQuizAsync(CreateQuizRequestDto createQuizRequestDto, Guid userId, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByIdAsync(userId, cancellationToken);

            if (user == null)
            {
                throw new NotFoundException("User with this Id not found");
            }

            var quiz = new Quiz
            {
                Id = Guid.NewGuid(),
                Description = createQuizRequestDto.Description,
                Title = createQuizRequestDto.Title,
                CreatedAt = DateTime.UtcNow,
                Status = QuizStatus.Draft,
                UserId = userId,
                UpdatedAt = null,
                PublishedAt = null,
                Questions = new List<Question>()
            };

            await _quizRepository.AddAsync(quiz, cancellationToken);
            await _quizRepository.SaveChangesAsync(cancellationToken);

            return _mapper.Map<QuizResponseDto>(quiz);
        }

        public async Task DeleteQuizAsync(Guid quizId, Guid userId, CancellationToken cancellationToken)
        {
            var quiz = await _quizRepository.GetByIdAsync(quizId, cancellationToken);

            if (quiz == null)
            {
                throw new NotFoundException("Quiz with this Id is not found");
            }

            if(quiz.UserId != userId)
            {
                throw new ForbiddenException("You don't have permission to delete this quiz");
            }

            await _quizRepository.DeleteAsync(quizId);
            await _quizRepository.SaveChangesAsync(cancellationToken);
        }

        public async Task<QuizResponseDto> GetQuizByIdAsync(Guid quizId, CancellationToken cancellationToken)
        {
            var quiz = await _quizRepository.GetQuizWithQuestionsAndAnswersAsync(quizId, cancellationToken);

            if (quiz == null)
            {
                throw new NotFoundException("Quiz with this Id is not found");
            }

            return _mapper.Map<QuizResponseDto>(quiz);
        }

        public async Task<List<QuizSummaryDto>> GetQuizzesByAuthorIdAsync(Guid authorId, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByIdAsync(authorId, cancellationToken);

            if(user  == null)
            {
                throw new NotFoundException("User with this Id is not found");
            } 

            var quizzes = await _quizRepository.GetByAuthorIdAsync(authorId, cancellationToken);
            
            return _mapper.Map<List<QuizSummaryDto>>(quizzes);
        }

        public async Task PublishQuizAsync(Guid quizId,Guid userId, CancellationToken cancellationToken)
        {
            var quiz = await _quizRepository.GetQuizWithQuestionsAndAnswersAsync(quizId,cancellationToken);

            if(quiz == null)
            {
                throw new NotFoundException("Quiz with this Id is not found");
            }

            if (quiz.UserId != userId)
            {
                throw new ForbiddenException("You don't have permission to publish this quiz");
            }

            if (quiz.Status != QuizStatus.Draft)
            {
                throw new BadRequestException($"Cannot publish quiz with status {quiz.Status}");
            }

            if(quiz.Questions == null || quiz.Questions.Count == 0)
            {
                throw new BadRequestException("Quiz must have at least 1 question");
            }



            quiz.Status = QuizStatus.Published;
            quiz.PublishedAt = DateTime.UtcNow;
            quiz.UpdatedAt = DateTime.UtcNow;

            await _quizRepository.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateQuizAsync(Guid quizId, UpdateQuizRequestDto updateQuizRequestDto, Guid userId, CancellationToken cancellationToken)
        {
            var quiz = await _quizRepository.GetByIdAsync(quizId, cancellationToken);

            if(quiz == null)
            {
                throw new NotFoundException("Quiz with this Id is not found");
            }

            if (quiz.UserId != userId)
            {
                throw new ForbiddenException("You don't have permission to update this quiz");
            }

            if (quiz.Status != QuizStatus.Draft)
            {
                throw new BadRequestException($"Cannot update quiz with status {quiz.Status}");
            }

            quiz.Title = updateQuizRequestDto.Title;
            quiz.Description = updateQuizRequestDto.Description;
            quiz.UpdatedAt = DateTime.UtcNow;

            await _quizRepository.SaveChangesAsync(cancellationToken);
        }
    }
}
