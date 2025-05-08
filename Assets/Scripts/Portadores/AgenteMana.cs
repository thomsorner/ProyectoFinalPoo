using UnityEngine;

public class AgenteMana : Agente, IConsumidorDeRecurso
{
    [SerializeField] private SistemaMana sistemaMana;

    // Propiedad p�blica de solo lectura
    public SistemaMana SistemaMana => sistemaMana;

    protected override void Awake()
    {
        base.Awake();

        if (sistemaMana == null)
            sistemaMana = GetComponent<SistemaMana>();
    }

    public override void CobrarHabilidad(int costo)
    {
        sistemaMana.Gastar(costo);
        Debug.Log($"[AgenteMana] Cobr� {costo} de man�. Man� restante: {sistemaMana.getValorActual()}");
    }
    public bool TieneRecursoSuficiente(int costo)
    {
        return sistemaMana.getValorActual() >= costo;
    }
}
