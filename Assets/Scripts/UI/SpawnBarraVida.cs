using UnityEngine;

public class SpawnBarraVida : MonoBehaviour
{
    [SerializeField] private GameObject prefabBarraVida;

    private void Start()
    {
        SistemaVida sistema = GetComponent<SistemaVida>();
        if (sistema != null && prefabBarraVida != null)
        {
            GameObject barra = Instantiate(prefabBarraVida);
            BarraVida script = barra.GetComponent<BarraVida>();
            script.Inicializar(sistema, transform);

            // 👇 Asignar la barra al sistema para eliminarla al morir
            sistema.AsignarBarraVida(barra);
        }
    }
}
