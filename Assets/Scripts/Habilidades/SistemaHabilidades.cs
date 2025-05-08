using UnityEngine;

public class SistemaHabilidades : MonoBehaviour
{
    [Header("Lista de Habilidades")]
    [SerializeField] private Habilidad[] habilidades;

    public void EjecutarHabilidad(int index, Agente agente)
    {
        if (index >= 0 && index < habilidades.Length)
        {
            Habilidad habilidad = habilidades[index];
            habilidad.Efecto(agente);

            // 🔥 Disparar el evento
            Debug.Log($"[Evento] Lanzando evento de habilidad. Costo: {habilidad.Costo}, Portador: {agente.name}");
            HabilidadEvents.OnHabilidadUsada?.Invoke(agente, habilidad.Costo);

            Debug.Log($"Habilidad ejecutada: {habilidad.Descripcion}");
        }
        else
        {
            Debug.LogWarning("Índice de habilidad inválido.");
        }
    }
}
