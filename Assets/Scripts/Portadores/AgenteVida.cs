using UnityEngine;

public class AgenteVida : Agente, IConsumidorDeRecurso
{
    [SerializeField] private SistemaVida sistemaVida;

    // ✅ Propiedad pública de solo lectura para acceder desde SistemaHabilidades
    public SistemaVida SistemaVida => sistemaVida;

    protected override void Awake()
    {
        base.Awake(); // Llama al Awake de Agente y Portador

        // Si no se asigna manualmente, lo busca en el GameObject
        if (sistemaVida == null)
            sistemaVida = GetComponent<SistemaVida>();
    }

    /// <summary>
    /// Resta el costo de la habilidad al sistema de vida.
    /// </summary>
    public override void CobrarHabilidad(int costo)
    {
        sistemaVida.Dañar(costo);
        Debug.Log($"[AgenteVida] Cobro {costo} de vida. Vida restante: {sistemaVida.getValorActual()}");
    }
    public bool TieneRecursoSuficiente(int costo)
    {
        return sistemaVida.getValorActual() >= costo;
    }
}
