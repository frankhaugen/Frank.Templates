namespace WpfWithoutXaml.Core;

public interface ITemperatureConverterService
{
    decimal FahrenheitToCelsius(decimal temperature);
    decimal CelsiusToFahrenheit(decimal temperature);
    decimal CelsiusToKelvin(decimal temperature);
    decimal KelvinToCelsius(decimal temperature);
    decimal FahrenheitToKelvin(decimal temperature);
    decimal KelvinToFahrenheit(decimal temperature);
}