using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider))]
public class ZonaDeDaño : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        SistemaVida sistemaVida = other.GetComponent<SistemaVida>();
        if (sistemaVida != null)
        {
            StartCoroutine(DañarProgresivamente(sistemaVida));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        StopAllCoroutines(); // Detiene la curación si sale de la zona
    }

    private IEnumerator DañarProgresivamente(SistemaVida sistemaVida)
    {
        while (true)
        {
            sistemaVida.Dañar(5);
            yield return new WaitForSeconds(1f); // 2 por segundo
        }
    }
}
