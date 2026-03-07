using System;
namespace Blazor.Pages;public partial class Calculadora 
{
    public string Opcion { get; set; } = "Cubo";
    public double Val1 { get; set; } 
    public double Val2 { get; set; } 
    public double Val3 { get; set; } 
    public string UnidadDist { get; set; } = "m";
    public string UnidadTiempo { get; set; } = "s";
    public double Resultado { get; set; }
    public string MensajeError { get; set; } = "";
    public void EjecutarCalculo() 
    {
        try 
        {
            MensajeError = "";
            double resultadoBruto = Opcion switch {
                "Derivada" => (Val2 != 0) ? Val1 / Val2 : LanzarError("El tiempo no puede ser 0"),
                "D. Parcial" => Val1 * Math.Cos(Val2 * Math.PI / 180.0),
                "Cubo" => Val1 * Val2 * Val3, 
                "Cilindro" => Math.PI * Math.Pow(Val1, 2) * Val2,
                "Piramide" => 1.0/3.0 * Math.Pow(Val1, 2) * Val2,
                "Paralelepipedo" => Val1 * Val2 * Val3,
                "Cuadrado" => Val1 * Val2, 
                "Rectangulo" => Val1 * Val2,
                "Triangulo" => (Val1 * Val2) / 2.0,
                _ => 0
            };
            Resultado = Math.Round(resultadoBruto, 4);
        }
        catch {
            MensajeError = "Error en los datos.";
            Resultado = 0;
        }
    }
    private double LanzarError(string msj) {
        MensajeError = msj;
        return 0;
    }
    public void Limpiar() {
        Val1 = Val2 = Val3 = Resultado = 0;
        MensajeError = "";
    }
}