using UnityEngine;

public class SistemaHabilidades : MonoBehaviour
{
    [Header("Lista de Habilidades")]
    [SerializeField] private Habilidad[] habilidades;  // Lista de habilidades asignadas desde el Inspector

    // Método para ejecutar una habilidad
    public void EjecutarHabilidad(int index, Agente agente)
    {
        // Verificamos si el índice de habilidad es válido
        if (index >= 0 && index < habilidades.Length)
        {
            // Ejecutamos el efecto de la habilidad
            habilidades[index].Efecto(agente);

            // Luego de ejecutar el efecto, cobramos el costo de la habilidad
            agente.CobrarHabilidad(habilidades[index].Costo);

            Debug.Log($"Habilidad ejecutada: {habilidades[index].Descripcion}");
        }
        else
        {
            Debug.LogWarning("Índice de habilidad inválido.");
        }
    }
}
