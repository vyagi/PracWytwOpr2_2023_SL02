using Newtonsoft.Json.Linq;

namespace AdapterPattern;

public class Detector
{
    private readonly IThermometer _thermometer;

    public Detector(IThermometer thermometer) => 
        _thermometer = thermometer;

    public Decision Detect() =>
        _thermometer.GetTemperature() switch
        {
            < -5 => Decision.TooCold,
            > 25 => Decision.TooHot,
            _ => Decision.JustRight
        };
}

//3rd party library - zewnętrzna biblioteka
// to coś działą w sumie tak samo (daje temperaturę) ale zupełnie inaczej: nie metoda a propercja, nie double a string, nie Celsjusz an Kelwin, Inna nazwa
// a do tego - nie implementuje interfejsu IThermometer - POTRZEBUJEMY ADAPTERA !
public class InternetThermometer
{
    private static readonly HttpClient Client = new();

    public InternetThermometer() => Client.BaseAddress = new Uri("http://api.openweathermap.org/");

    public string Themperature =>
        ((dynamic)JObject.Parse(Client.GetAsync("data/2.5/weather?q=Rzeszow&appid=85bc214e20f8d9aed40b40cbf3467e93")
            .Result.Content.ReadAsStringAsync()
            .Result))["main"]["temp"];
}

public class InternetThermometerAdapter : IThermometer
{
    private readonly InternetThermometer _internetThermometer;

    public InternetThermometerAdapter(InternetThermometer internetThermometer) => 
        _internetThermometer = internetThermometer;

    //tutaj dzieje się cała "magia" - czyli "adaptacja"
    public double GetTemperature() =>  
         double.Parse(_internetThermometer.Themperature.Replace(".",",")) - 273.15;
}

public class MercuryThermometer : IThermometer
{
    private static readonly Random Generator = new();

    public double GetTemperature() => 
        Generator.NextDouble() * 100 - 50;
}

public enum Decision
{
    TooCold,
    JustRight,
    TooHot
}

public interface IThermometer
{
    double GetTemperature();
}