using Aurora.WebApp.Application.Contracts;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace Aurora.WebApp.Shared;

public partial class LoginComponent
{
    [Inject]
    public IAuthAppService AuthAppService { get; set; }
    
    private Model model = new Model();

    private async void OnFinish(EditContext editContext)
    {
        // Console.WriteLine($"Success:{JsonSerializer.Serialize(model)}");

        await AuthAppService.Login(model.Username, model.Password);
    }

    private void OnFinishFailed(EditContext editContext)
    {
        Console.WriteLine($"Failed:{JsonSerializer.Serialize(model)}");
    }
}

public class Model
{
    [Required, DisplayName("User Name")]
    public string Username { get; set; }
    [Required]
    public string Password { get; set; }
    public bool RememberMe { get; set; } = true;
}