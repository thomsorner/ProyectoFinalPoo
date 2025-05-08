using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemigoPrefab;
    [SerializeField] private Transform[] puntosSpawn; // ← Ahora usamos GameObjects como posiciones
    [SerializeField] private float tiempoRespawn = 3f;

    private Dictionary<Transform, GameObject> enemigosVivos = new();

    void Start()
    {
        foreach (Transform punto in puntosSpawn)
        {
            SpawnEnemigo(punto);
        }
    }

    void Update()
    {
        List<Transform> posicionesMuertas = new();

        foreach (var par in enemigosVivos)
        {
            if (par.Value == null)
                posicionesMuertas.Add(par.Key);
        }

        foreach (var punto in posicionesMuertas)
        {
            enemigosVivos.Remove(punto);
            StartCoroutine(RespawnDespuesDeTiempo(punto));
        }
    }

    private void SpawnEnemigo(Transform punto)
    {
        GameObject enemigo = Instantiate(enemigoPrefab, punto.position, punto.rotation);
        enemigosVivos[punto] = enemigo;
    }

    private IEnumerator RespawnDespuesDeTiempo(Transform punto)
    {
        yield return new WaitForSeconds(tiempoRespawn);
        SpawnEnemigo(punto);
    }
}
