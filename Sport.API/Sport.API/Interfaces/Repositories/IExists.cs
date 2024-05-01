namespace Sport.API.Repositories.Interfaces;

/// <summary>
/// Інтерфейс для перевірки існування сутності.
/// </summary>
public interface IExists
{
    /// <summary>
    /// Чи інсує сутність.
    /// </summary>
    /// <param name="data">Сутність.</param>
    bool IsExists(string data);
}