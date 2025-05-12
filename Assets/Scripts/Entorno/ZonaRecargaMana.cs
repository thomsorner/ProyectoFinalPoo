using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider))]
public class ZonaRecargaMana : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        SistemaMana sistemaMana = other.GetComponent<SistemaMana>();
        if (sistemaMana != null)
        {
            StartCoroutine(RecargarProgresivamente(sistemaMana));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        StopAllCoroutines(); // Detiene si sale de la zona
    }

    private IEnumerator RecargarProgresivamente(SistemaMana sistemaMana)
    {
        while (true)
        {
            sistemaMana.Recuperar(5);
            yield return new WaitForSeconds(1f); // +2 por segundo
        }
    }
}
