using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UICooldownManager : MonoBehaviour
{
    [System.Serializable]
    public class HabilidadUI
    {
        public Image relleno; // Image tipo Filled
    }

    [SerializeField] private HabilidadUI[] habilidades;

    private void OnEnable()
    {
        CooldownEvents.OnCooldownIniciado += IniciarCooldown;
    }

    private void OnDisable()
    {
        CooldownEvents.OnCooldownIniciado -= IniciarCooldown;
    }

    private void IniciarCooldown(int index, float duracion)
    {
        if (index >= 0 && index < habilidades.Length)
        {
            StartCoroutine(AnimarCooldown(habilidades[index].relleno, duracion));
        }
    }

    private IEnumerator AnimarCooldown(Image imagen, float tiempo)
    {
        float tiempoActual = 0f;
        imagen.fillAmount = 0f; // Comienza vacía (invisible)

        while (tiempoActual < tiempo)
        {
            tiempoActual += Time.deltaTime;
            imagen.fillAmount = tiempoActual / tiempo; // Se llena
            yield return null;
        }

        imagen.fillAmount = 1f; // Totalmente visible al final
    }
}
