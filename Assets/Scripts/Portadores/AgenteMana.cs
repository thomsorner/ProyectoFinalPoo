using UnityEngine;

public class AgenteMana : Agente
{
    [SerializeField] private SistemaMana sistemaMana;

    protected override void Awake()
    {
        base.Awake();  // Esto es CLAVE para que el Awake de Agente (y a su vez Portador) se ejecute

        if (sistemaMana == null)
            sistemaMana = GetComponent<SistemaMana>();
    }

    public override void CobrarHabilidad(int costo)
    {
        sistemaMana.Gastar(costo);
        Debug.Log($"[AgenteMana] Cobró {costo} de maná. Maná restante: {sistemaMana.getValorActual()}");
    }
}
