using Aurora.WebApp.Provider.LocalStoreProviders;

namespace Aurora.WebApp.Provider.OperatorProviders;

public class OperatorProvider: IOperatorProvider
{
    private readonly ILocalStorageProvider _localStorageProvider;
    public string Token { get; }

    public OperatorProvider(ILocalStorageProvider localStorageProvider)
    {
        _localStorageProvider = localStorageProvider;
        Token = Task.Run(async()=> await _localStorageProvider.GetItem<String>("token")).Result;
    }
}