using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider))]
public class ZonaDeDañoHabilidad : MonoBehaviour
{
    private int dañoTotal;
    private float duracion;

    public void Configurar(int daño, float tiempo)
    {
        dañoTotal = daño;
        duracion = tiempo;
    }

    private void OnTriggerEnter(Collider other)
    {
        Portador portador = other.GetComponent<Portador>();
        if (portador != null && portador != GetComponentInParent<Portador>())
        {
            StartCoroutine(DañarDuranteTiempo(portador));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        StopAllCoroutines(); // Detiene el daño si sale de la zona
    }

    private IEnumerator DañarDuranteTiempo(Portador portador)
    {
        SistemaVida sistema = portador.GetComponent<SistemaVida>();
        if (sistema == null) yield break;

        int ticks = Mathf.FloorToInt(duracion);
        int dañoPorTick = dañoTotal / ticks;
        float intervalo = duracion / ticks;

        for (int i = 0; i < ticks; i++)
        {
            sistema.Dañar(dañoPorTick);
            yield return new WaitForSeconds(intervalo);
        }
    }
}
