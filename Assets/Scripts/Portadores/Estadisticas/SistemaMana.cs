using UnityEngine;

public class SistemaMana : Estadistica
{
    private AgenteMana _agenteMana;

    [SerializeField] private TipoRecargaMana tipoRecarga = TipoRecargaMana.Progresiva;

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
        if (portador.gameObject == gameObject && _agenteMana != null && _agenteMana.enabled)
        {
            Gastar(costo); // solo si el agente mana está activo
        }
    }


    public void Recuperar(int cantidad)
    {
        int nuevo = Mathf.Min(getValorActual() + cantidad, getValorMaximo());
        setValorActual(nuevo);
        Debug.Log($"[Maná] Recuperado {cantidad}. Maná actual: {getValorActual()}");
    }

    public void Gastar(int cantidad)
    {
        int nuevo = Mathf.Max(getValorActual() - cantidad, getValorMinimo());
        setValorActual(nuevo);
        Debug.Log($"[Maná] Gastado {cantidad}. Maná actual: {getValorActual()}");
    }

    public override void Update()
    {
        if (tipoRecarga == TipoRecargaMana.Progresiva && getValorActual() < getValorMaximo())
        {
            _tiempoAcumulado += Time.deltaTime;

            if (_tiempoAcumulado >= _intervaloRegeneracion)
            {
                Recuperar(1);
                _tiempoAcumulado = 0f;
            }
        }
    }
}
