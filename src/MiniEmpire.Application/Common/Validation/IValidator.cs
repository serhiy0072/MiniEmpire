namespace MiniEmpire.Application.Common.Validation;

/// <summary>Повертає тексти помилок; порожньо — запит валідний.</summary>
public interface IValidator<T>
{
    IEnumerable<string> Validate(T request);
}
