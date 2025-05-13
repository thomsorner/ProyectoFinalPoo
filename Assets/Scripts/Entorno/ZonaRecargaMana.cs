using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class ZonaRecargaMana : MonoBehaviour
{
    [SerializeField] private TipoRecargaMana tipo = TipoRecargaMana.Instantanea;
    [SerializeField] private int cantidadRecarga = 100; // si es instantánea
    [SerializeField] private float duracion = 5f;       // si es progresiva
    [SerializeField] private int cantidadPorSegundo = 2;

    private Dictionary<Portador, Coroutine> corutinas = new();

    private void OnTriggerEnter(Collider other)
    {
        Portador portador = other.GetComponent<Portador>();
        SistemaMana sistema = portador?.GetComponent<SistemaMana>();
        if (sistema == null) return;

        if (tipo == TipoRecargaMana.Instantanea)
        {
            sistema.Recuperar(cantidadRecarga);
        }
        else if (tipo == TipoRecargaMana.Progresiva && !corutinas.ContainsKey(portador))
        {
            Coroutine c = StartCoroutine(RecargaProgresiva(sistema, portador));
            corutinas.Add(portador, c);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Portador portador = other.GetComponent<Portador>();
        if (portador != null && corutinas.ContainsKey(portador))
        {
            StopCoroutine(corutinas[portador]);
            corutinas.Remove(portador);
        }
    }

    private IEnumerator RecargaProgresiva(SistemaMana sistema, Portador portador)
    {
        float tiempoTranscurrido = 0f;

        while (tiempoTranscurrido < duracion)
        {
            sistema.Recuperar(cantidadPorSegundo);
            yield return new WaitForSeconds(1f);
            tiempoTranscurrido += 1f;
        }

        corutinas.Remove(portador);
    }
}
