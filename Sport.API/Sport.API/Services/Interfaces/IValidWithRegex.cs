namespace Sport.API.Services.Interfaces;

/// <summary>
/// Інтерфейс для перевірки валідності за допомогою регулярних виразиів.
/// </summary>
public interface IValidWithRegex
{
    /// <summary>
    /// Чи валідна сутність.
    /// </summary>
    /// <param name="data">Строка для перевірки.</param>
    bool IsValidCorrectString(string data);
}