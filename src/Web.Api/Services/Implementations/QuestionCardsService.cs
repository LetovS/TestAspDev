using Microsoft.EntityFrameworkCore;
using Store;
using Store.Abstract;
using Store.Entities;
using Web.Api.Contracts;
using Web.Api.Services.Abstract;
using Web.Api.Services.DTOModels;

namespace Web.Api.Services.Implementations;

/// <summary>
/// Сервис вопросов
/// </summary>
public class QuestionCardsService : IQuestionCardsService
{
    private readonly ResourcesContext _resourcesContext;

    /// <summary>
    /// ctor.
    /// </summary>
    public QuestionCardsService(ResourcesContext resourcesContext)
    {
        this._resourcesContext = resourcesContext;
    }

    /// <inheritdoc/>
    public async Task<QuestionRecord?> GetQuestionById(
        Guid surveyId,
        Guid questionId,
        CancellationToken ct)
    {
        var survey = await _resourcesContext
                                    .Surveys
                                    .Where(x => x.Id == surveyId)
                                    .Include(x => x.Questions)
                                    .ThenInclude(x => x.Answers)
                                    .SingleOrDefaultAsync(ct)
                                                        ?? throw new InvalidOperationException("С таким ИД больше одного опроса");

        var question = survey.Questions.Where(x => x.Id == questionId).SingleOrDefault();

        return question;
    }

    /// <inheritdoc/>    
    public async Task<Guid> SaveAnswerResult(
        Guid surveyId,
        Guid interviewId,
        CreateAnswerModel createAnswerModel,
        CancellationToken ct)
    {
        var survey = await _resourcesContext
                                    .Surveys
                                    .Where(x => x.Id == surveyId)
                                    .Include(x => x.Interviews)
                                    .ThenInclude(x => x.Results)
                                    .Include(x => x.Questions)
                                    .ThenInclude(x => x.Answers)
                                    .SingleOrDefaultAsync(ct)
                                                        ?? throw new InvalidOperationException("С таким ИД больше одного опроса");

        // Сохранить ответ
        var interview = survey.Interviews.Where(x => x.Id == interviewId).SingleOrDefault();
        var result = new ResultRecord(Guid.NewGuid()) { Answer = string.Join(",", createAnswerModel.Answers) };

        if (interview is null)
        {
            var newInterviw = new InterviewRecord(interviewId) { InterviewDate = DateTime.UtcNow};            
            newInterviw.Results.Add(result);
            survey.Interviews.Add(newInterviw);
        }
        else
        {
            interview.Results.Add(result);
        }
        _resourcesContext.SaveChanges();

        // Получаем ИД следующего вопроса
        var questions = survey.Questions.Order().ToList();

        var current = questions.Where(x => x.Question.Equals(createAnswerModel.Question)).SingleOrDefault() ?? throw new InvalidOperationException();

        int indexCurentQuestion = questions.IndexOf(current);

        // Если индекс текущего вопроса уже последний, то возвращаем default Guid иначе следующий ИД.
        //TODO Подумать как сортировать вопросы, т.к. могут возвращаться не отсортированные.
        return indexCurentQuestion == questions.Count -1 ? default : questions[++indexCurentQuestion].Id;

    }
}
