using UnityEngine;

public class SistemaMana : Estadistica
{
    /// <summary>
    /// Aumenta el man� actual sin pasar del valor m�ximo.
    /// </summary>
    public void Recuperar(int cantidad)
    {
        int nuevo = Mathf.Min(getValorActual() + cantidad, getValorMaximo());
        setValorActual(nuevo);
        Debug.Log($"[Man�] Recuperado {cantidad}. Man� actual: {getValorActual()}");
    }

    /// <summary>
    /// Disminuye el man� actual sin bajar del valor m�nimo.
    /// </summary>
    public void Gastar(int cantidad)
    {
        int nuevo = Mathf.Max(getValorActual() - cantidad, getValorMinimo());
        setValorActual(nuevo);
        Debug.Log($"[Man�] Gastado {cantidad}. Man� actual: {getValorActual()}");
    }

    // Heredamos Start() y Update() de Estadistica, que ya implementa regeneraci�n
}
