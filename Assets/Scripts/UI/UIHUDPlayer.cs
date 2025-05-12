using UnityEngine;

public class UIHUDPlayer : MonoBehaviour
{
    [Header("Referencias a las barras de UI")]
    [SerializeField] private UIBarraEstadistica barraVida;
    [SerializeField] private UIBarraEstadistica barraMana;

    private void Start()
    {
        // Buscar al jugador usando la etiqueta "Player"
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            SistemaVida sistemaVida = player.GetComponent<SistemaVida>();
            SistemaMana sistemaMana = player.GetComponent<SistemaMana>();

            if (sistemaVida != null)
                barraVida.Inicializar(sistemaVida);
            else
                Debug.LogWarning("SistemaVida no encontrado en el jugador.");

            if (sistemaMana != null)
                barraMana.Inicializar(sistemaMana);
            else
                Debug.LogWarning("SistemaMana no encontrado en el jugador.");
        }
        else
        {
            Debug.LogError("Jugador no encontrado con la etiqueta 'Player'.");
        }
    }
}
