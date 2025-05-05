using UnityEngine;

public class Proyectil : MonoBehaviour
{
    private int da�o;
    private Vector3 direccion;
    private float velocidad;
    private Vector3 posicionInicial;
    [SerializeField] private float distanciaMaxima = 20f;

    public void Inicializar(float velocidad, int da�o, Portador portador)
    {
        this.velocidad = velocidad;
        this.da�o = da�o;
        this.direccion = portador.transform.forward; // o .right si es 2D
        this.posicionInicial = transform.position;
    }

    void Update()
    {
        transform.position += direccion * velocidad * Time.deltaTime;

        if (Vector3.Distance(posicionInicial, transform.position) >= distanciaMaxima)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Portador objetivo = other.GetComponent<Portador>();
        if (objetivo != null)
        {
            objetivo.GetComponent<SistemaVida>()?.Da�ar(da�o);
            Destroy(gameObject);
        }
    }
}
