using UnityEngine;

public class SistemaMana : Estadistica
{
    private AgenteMana _agenteMana;

    private void OnEnable()
    {
        _agenteMana = GetComponent<AgenteMana>();
        if (_agenteMana != null)
            HabilidadEvents.OnHabilidadUsada += ManejarHabilidadUsada;
    }

    private void OnDisable()
    {
        if (_agenteMana != null)
            HabilidadEvents.OnHabilidadUsada -= ManejarHabilidadUsada;
    }

    private void ManejarHabilidadUsada(Portador portador, int costo)
    {
        if (portador.gameObject == gameObject)
            Gastar(costo);
    }

    public void Recuperar(int cantidad)
    {
        int nuevo = Mathf.Min(getValorActual() + cantidad, getValorMaximo());
        setValorActual(nuevo);
        Debug.Log($"[Man�] Recuperado {cantidad}. Man� actual: {getValorActual()}");
    }

    public void Gastar(int cantidad)
    {
        int nuevo = Mathf.Max(getValorActual() - cantidad, getValorMinimo());
        setValorActual(nuevo);
        Debug.Log($"[Man�] Gastado {cantidad}. Man� actual: {getValorActual()}");
    }
}
