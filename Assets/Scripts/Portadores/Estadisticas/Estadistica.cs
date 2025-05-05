using UnityEngine;

public abstract class Estadistica : MonoBehaviour
{
    // parámetros
    [SerializeField] private int _valorMaximo = 100;
    [SerializeField] private int _valorActual = 100;
    [SerializeField] private int _valorMinimo = 1;

    private float _tiempoAcumulado = 0f;
    private float _intervaloRegeneracion = 1f; // 1 segundo

    // métodos y funciones

    public int getValorMaximo() => _valorMaximo;
    public void setValorMaximo(int valor) => _valorMaximo = valor;

    public int getValorActual() => _valorActual;
    public void setValorActual(int valor) => _valorActual = valor;

    public int getValorMinimo() => _valorMinimo;
    public void setValorMinimo(int valor) => _valorMinimo = valor;

    public void regeneracion()
    {
        if (_valorActual < _valorMaximo)
        {
            _valorActual += 1;
        }
    }

    protected virtual void Update()
    {
        _tiempoAcumulado += Time.deltaTime;

        if (_tiempoAcumulado >= _intervaloRegeneracion)
        {
            regeneracion();
            _tiempoAcumulado = 0f;
        }
    }
}
