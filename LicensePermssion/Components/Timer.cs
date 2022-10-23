using Microsoft.AspNetCore.Components;

namespace LicensePermssion.Components;



public class Timer:ComponentBase
{
    public TimeSpan TimeLeft = new TimeSpan(0,1,30);
    public string DisplayText { get; set; } = "";
    protected override async Task OnInitializedAsync()
    {
        await TimerAsync();
        await base.OnInitializedAsync();
    }

    private async Task TimerAsync()
    {
        while (TimeLeft > new TimeSpan())
        {
            await Task.Delay(1000);
            TimeLeft = TimeLeft.Subtract(new TimeSpan(0,0,1));
            StateHasChanged();
        }
        await AfterTimeAsync();
        StateHasChanged();
    }
    private async Task AfterTimeAsync()
    {
        DisplayText = "ask for a new code";
    }
}