using UnityEngine;

[CreateAssetMenu(menuName = "Habilidades/Proyectil")]
public class HabilidadProyectil : Habilidad
{
    [SerializeField] private GameObject prefabProyectil;
    [SerializeField] private float velocidad = 10f;
    [SerializeField] private int daño = 30;

    public override void Efecto(Portador portador)
    {
        if (prefabProyectil == null)
        {
            Debug.LogWarning("Prefab de proyectil no asignado.");
            return;
        }

        Vector3 spawnPos = portador.transform.position + portador.transform.forward + Vector3.up * 1f; 
        GameObject proyectil = GameObject.Instantiate(prefabProyectil, spawnPos, portador.transform.rotation);

        Proyectil script = proyectil.GetComponent<Proyectil>();
        if (script != null)
        {
            script.Inicializar(velocidad, daño, portador);
        }
    }
}
