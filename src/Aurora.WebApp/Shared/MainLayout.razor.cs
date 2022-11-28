using Microsoft.AspNetCore.Components.Forms;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace Aurora.WebApp.Shared;

public partial class MainLayout
{
    public bool IsLogin { get; set; } = true;
    
    private Model model = new Model();

    private void OnFinish(EditContext editContext)
    {
        // Console.WriteLine($"Success:{JsonSerializer.Serialize(model)}");

        if (model.Username == "admin" && model.Password == "123")
        {
            IsLogin = true;
            StateHasChanged();
        }
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