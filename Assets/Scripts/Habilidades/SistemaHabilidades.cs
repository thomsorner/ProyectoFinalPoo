using System.Collections.Generic;
using UnityEngine;

public class SistemaHabilidades : MonoBehaviour
{
    [Header("Lista de Habilidades")]
    [SerializeField] private Habilidad[] habilidades;

    // Guarda el último momento en que cada habilidad fue usada
    private Dictionary<int, float> tiemposUltimoUso = new();

    public void EjecutarHabilidad(int index, Agente agente)
    {
        // Validación del índice y existencia de la habilidad
        if (index < 0 || index >= habilidades.Length || habilidades[index] == null)
        {
            Debug.LogWarning("Índice de habilidad inválido o habilidad no asignada.");
            return;
        }

        Habilidad habilidad = habilidades[index];
        int costo = habilidad.Costo;

        // ⏳ Verificar si la habilidad está en cooldown
        if (tiemposUltimoUso.TryGetValue(index, out float ultimoUso))
        {
            float tiempoRestante = habilidad.Cooldown - (Time.time - ultimoUso);
            if (tiempoRestante > 0)
            {
                Debug.LogWarning($"Habilidad en cooldown. Tiempo restante: {tiempoRestante:F1} s");
                return;
            }
        }

        // ⚡ Verificar si el agente tiene suficiente recurso
        if (agente is IConsumidorDeRecurso consumidor && consumidor.TieneRecursoSuficiente(costo))
        {
            // Ejecutar la habilidad
            habilidad.Efecto(agente);

            // Emitir el evento para que los sistemas descuenten el recurso
            HabilidadEvents.OnHabilidadUsada?.Invoke(agente, costo);

            // Registrar el tiempo de uso para controlar cooldown
            tiemposUltimoUso[index] = Time.time;

            Debug.Log($"Habilidad ejecutada: {habilidad.Descripcion}");
        }
        else
        {
            Debug.LogWarning("No hay suficiente recurso para usar esta habilidad.");
        }
    }
}
