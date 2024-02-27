using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Web.Api.Contracts;
using Web.Api.Services.Abstract;
using Web.Api.Services.DTOModels;

namespace Web.Api.Controllers;

/// <summary>
/// Контроллер опросов
/// </summary>
[ApiController]
[Route("api/v1/question-cards")]
public class QuestionCardsController : ControllerBase
{
    private readonly IQuestionCardsService _questionCardsService;
    private readonly IMapper _mapper;

    /// <summary>
    /// ctor.
    /// </summary>
    public QuestionCardsController(
        IQuestionCardsService questionCardsService,
        IMapper mapper)
    {
        this._questionCardsService = questionCardsService;
        this._mapper = mapper;
    }

    /// <summary>
    /// Получить следующий вопрос по Id для опроса.
    /// </summary>
    [HttpGet("{surveyId}/{questionId}", Name = "get-next-questions-for-survey")]
    public async Task<IActionResult> GetNextQuestionForSurvey(
        [FromRoute] Guid surveyId,
        [FromRoute] Guid questionId)
    {
        var question = await _questionCardsService.GetQuestionById(surveyId, questionId, CancellationToken.None);

        if (question == null)
        {
            return NotFound();
        }

        // Маппинг в response
        var response = _mapper.Map<QuestionResponse>(question);

        return Ok(response);
    }

    /// <summary>
    /// Сохраняет ответ
    /// </summary>
    /// <returns>Возвращает ИД следующего вопроса</returns>
    [HttpPost("{surveyId}/{interviewId}", Name = "save-answer-and-get-next-question-id")]
    public async Task<Guid> SaveAnswerAndGetNextQuestionId(
        [FromRoute] Guid surveyId,
        [FromRoute] Guid interviewId,
        [FromBody] AnswerRequest answerRequest
        )
    {
        var model = _mapper.Map<CreateAnswerModel>(answerRequest);

        var response = await _questionCardsService.SaveAnswerResult(surveyId, interviewId, model, CancellationToken.None);
        
        return response;
    }
}
