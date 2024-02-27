using Store.Entities;
using Web.Api.Services.DTOModels;

namespace Web.Api.Services.Abstract;

/// <summary>
/// Интерфейс для управления карточками вопросов.
/// </summary>
public interface IQuestionCardsService
{
    /// <summary>
    /// Получить вопрос по идентификатору из определенного опроса.
    /// </summary>
    /// <param name="surveyId">Идентификатор опроса.</param>
    /// <param name="questionId">Идентификатор вопроса.</param>
    /// <param name="ct">Токен отмены для асинхронной операции.</param>
    /// <returns>Запись вопроса или null, если не найдена.</returns>
    /// <exception cref="InvalidOperationException">Выбрасывается, если опрос не найден.</exception>
    Task<QuestionRecord?> GetQuestionById(Guid surveyId, Guid questionId, CancellationToken ct = default);

    /// <summary>
    /// Сохранить результат ответа.
    /// </summary>
    Task<Guid> SaveAnswerResult(Guid surveyId, Guid interviewId, CreateAnswerModel createAnswerRecordModel, CancellationToken ct = default);
}
