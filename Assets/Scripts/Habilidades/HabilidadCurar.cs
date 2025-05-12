using UnityEngine;

[CreateAssetMenu(menuName = "Habilidades/Curación")]
public class HabilidadCurar : Habilidad
{
    [SerializeField] private int cantidadCuracion = 30;
    [SerializeField] private float duracion = 5f;

    public override void Efecto(Portador portador)
    {
        // Verifica que tenga un sistema de vida
        SistemaVida sistemaVida = portador.GetComponent<SistemaVida>();

        if (sistemaVida != null)
        {
            // Inicia la curación progresiva a través de una Coroutine
            MonoBehaviour host = portador as MonoBehaviour;
            if (host != null)
            {
                host.StartCoroutine(CuracionProgresiva(sistemaVida));
            }
        }
        else
        {
            Debug.LogWarning("El portador no tiene un SistemaVida para curar.");
        }
    }

    private System.Collections.IEnumerator CuracionProgresiva(SistemaVida sistemaVida)
    {
        int ticks = 5;
        int cantidadPorTick = cantidadCuracion / ticks;
        float intervalo = duracion / ticks;

        for (int i = 0; i < ticks; i++)
        {
            sistemaVida.Curar(cantidadPorTick);
            yield return new WaitForSeconds(intervalo);
        }
    }
}
