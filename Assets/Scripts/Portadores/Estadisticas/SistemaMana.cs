using UnityEngine;

public class SistemaMana : Estadistica
{
    /// <summary>
    /// Aumenta el maná actual sin pasar del valor máximo.
    /// </summary>
    public void Recuperar(int cantidad)
    {
        int nuevo = Mathf.Min(getValorActual() + cantidad, getValorMaximo());
        setValorActual(nuevo);
        Debug.Log($"[Maná] Recuperado {cantidad}. Maná actual: {getValorActual()}");
    }

    /// <summary>
    /// Disminuye el maná actual sin bajar del valor mínimo.
    /// </summary>
    public void Gastar(int cantidad)
    {
        int nuevo = Mathf.Max(getValorActual() - cantidad, getValorMinimo());
        setValorActual(nuevo);
        Debug.Log($"[Maná] Gastado {cantidad}. Maná actual: {getValorActual()}");
    }

    // Heredamos Start() y Update() de Estadistica, que ya implementa regeneración
}
