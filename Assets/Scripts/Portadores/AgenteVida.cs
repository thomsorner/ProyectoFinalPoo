using UnityEngine;

public class AgenteVida : Agente
{
    [SerializeField] private SistemaVida sistemaVida;

    void Awake()
    {
        // Si no lo arrastras en el Inspector, lo busca autom�ticamente
        if (sistemaVida == null)
            sistemaVida = GetComponent<SistemaVida>();
    }

    /// <summary>
    /// Resta el costo de la habilidad al sistema de vida.
    /// </summary>
    public override void CobrarHabilidad(int costo)
    {
        sistemaVida.Da�ar(costo);
        Debug.Log($"[AgenteVida] Cobr� {costo} de vida. Vida restante: {sistemaVida.getValorActual()}");
    }
}
