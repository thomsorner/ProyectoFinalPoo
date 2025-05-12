using UnityEngine;

[CreateAssetMenu(menuName = "Habilidades/Zona de Daño")]
public class HabilidadZonaDeDaño : Habilidad
{
    [SerializeField] private GameObject zonaPrefab;
    [SerializeField] private float distanciaFrontal = 3f;
    [SerializeField] private float duracion = 5f;
    [SerializeField] private int dañoTotal = 30;

    public override void Efecto(Portador portador)
    {
        if (zonaPrefab == null)
        {
            Debug.LogWarning("Prefab de zona de daño no asignado.");
            return;
        }

        // Calcula la posición frente al agente, a la misma altura
        Vector3 spawnPos = portador.transform.position + portador.transform.forward * distanciaFrontal;
        spawnPos.y = portador.transform.position.y;

        GameObject zona = GameObject.Instantiate(zonaPrefab, spawnPos, Quaternion.identity);

        // Pasa los parámetros de daño y duración al script del prefab
        ZonaDeDañoHabilidad script = zona.GetComponent<ZonaDeDañoHabilidad>();
        if (script != null)
        {
            script.Configurar(dañoTotal, duracion);
        }

        // Destruir la zona después de la duración
        GameObject.Destroy(zona, duracion);
    }
}
