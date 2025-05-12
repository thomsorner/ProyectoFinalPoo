using UnityEngine;
using UnityEngine.UI;

public class BarraVida : MonoBehaviour
{
    [SerializeField] private Image imagenBarra;
    private Transform objetivo;
    private SistemaVida sistemaVida;

    public void Inicializar(SistemaVida sistema, Transform aSeguir)
    {
        sistemaVida = sistema;
        objetivo = aSeguir;
    }

    private void Update()
    {
        if (sistemaVida == null || objetivo == null) return;

        // Actualiza la barra
        float porcentaje = (float)sistemaVida.getValorActual() / sistemaVida.getValorMaximo();
        imagenBarra.fillAmount = porcentaje;

        // Siempre mirar hacia la cámara
        transform.position = objetivo.position + Vector3.up * 2f;
        transform.forward = Camera.main.transform.forward;
    }
}
