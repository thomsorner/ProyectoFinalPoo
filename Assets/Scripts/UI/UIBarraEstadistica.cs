using UnityEngine;
using UnityEngine.UI;

public class UIBarraEstadistica : MonoBehaviour
{
    [SerializeField] private Image barra;
    private Estadistica sistema;

    public void Inicializar(Estadistica estadistica)
    {
        sistema = estadistica;
    }

    void Update()
    {
        if (sistema == null) return;

        float porcentaje = (float)sistema.getValorActual() / sistema.getValorMaximo();
        barra.fillAmount = porcentaje;
    }
}
