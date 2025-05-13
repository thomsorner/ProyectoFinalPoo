using UnityEngine;

public class SistemaVida : Estadistica
{
    private AgenteVida _agenteVida;
    private GameObject barraVidaGO;

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

    /// <summary>
    /// Permite asignar una barra de vida visual al sistema.
    /// </summary>
    public void AsignarBarraVida(GameObject barra)
    {
        barraVidaGO = barra;
    }

    private void ManejarHabilidadUsada(Portador portador, int costo)
    {
        if (portador.gameObject == gameObject && _agenteVida != null && _agenteVida.enabled)
        {
            Dañar(costo); // solo cobra si el agente de vida está activo
        }
    }


    public void Curar(int cantidad)
    {
        int nuevo = Mathf.Min(getValorActual() + cantidad, getValorMaximo());
        setValorActual(nuevo);
        Debug.Log($"[Vida] Curado {cantidad}. Vida actual: {getValorActual()}");
    }

    public void Dañar(int cantidad)
    {
        int nuevo = Mathf.Max(getValorActual() - cantidad, getValorMinimo());
        setValorActual(nuevo);
        Debug.Log($"[Vida] Dañado {cantidad}. Vida actual: {getValorActual()}");

        if (getValorActual() <= getValorMinimo())
        {
            Debug.Log($"{gameObject.name} ha muerto.");

            // ✅ Eliminar la barra si fue asignada
            if (barraVidaGO != null)
                Destroy(barraVidaGO);

            Destroy(gameObject);
        }
    }
}
