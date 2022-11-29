namespace Aurora.WebApp.Provider.OperatorProviders;

public interface IOperatorProvider
{
    public string Token { get; }

    public bool IsLogin => string.IsNullOrWhiteSpace(Token);
}