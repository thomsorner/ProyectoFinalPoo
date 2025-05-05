using UnityEngine;

public class SistemaVida : Estadistica
{
    /// <summary>
    /// Aumenta la vida actual sin pasar del valor m�ximo.
    /// </summary>
    public void Curar(int cantidad)
    {
        int nuevo = Mathf.Min(getValorActual() + cantidad, getValorMaximo());
        setValorActual(nuevo);
        Debug.Log($"[Vida] Curado {cantidad}. Vida actual: {getValorActual()}");
    }

    /// <summary>
    /// Disminuye la vida actual sin bajar del valor m�nimo.
    /// </summary>
    public void Da�ar(int cantidad)
    {
        int nuevo = Mathf.Max(getValorActual() - cantidad, 0); // permite llegar a 0
        setValorActual(nuevo);
        Debug.Log($"[Vida] Da�ado {cantidad}. Vida actual: {getValorActual()}");
    }

    void Update()
    {
        base.Update(); // mantiene regeneraci�n de Estadistica

        if (getValorActual() <= 0)
        {
            Debug.Log($"[Vida] {gameObject.name} ha muerto.");
            Destroy(gameObject);
        }
    }
}
