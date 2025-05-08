using UnityEngine;

public class SistemaVida : Estadistica
{
    private AgenteVida _agenteVida;

    private void OnEnable()
    {
        _agenteVida = GetComponent<AgenteVida>();
        if (_agenteVida != null)
            HabilidadEvents.OnHabilidadUsada += ManejarHabilidadUsada;
    }

    private void OnDisable()
    {
        if (_agenteVida != null)
            HabilidadEvents.OnHabilidadUsada -= ManejarHabilidadUsada;
    }

    private void ManejarHabilidadUsada(Portador portador, int costo)
    {
        if (portador.gameObject == gameObject)
            Da�ar(costo);
    }

    public void Curar(int cantidad)
    {
        int nuevo = Mathf.Min(getValorActual() + cantidad, getValorMaximo());
        setValorActual(nuevo);
        Debug.Log($"[Vida] Curado {cantidad}. Vida actual: {getValorActual()}");
    }

    public void Da�ar(int cantidad)
    {
        int nuevo = Mathf.Max(getValorActual() - cantidad, getValorMinimo());
        setValorActual(nuevo);
        Debug.Log($"[Vida] Da�ado {cantidad}. Vida actual: {getValorActual()}");

        if (getValorActual() <= getValorMinimo())
        {
            Debug.Log($"{gameObject.name} ha muerto.");
            Destroy(gameObject);
        }
    }
}
