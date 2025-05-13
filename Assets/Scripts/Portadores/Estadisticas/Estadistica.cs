using UnityEngine;

public abstract class Estadistica : MonoBehaviour
{
    [SerializeField] private int _valorMaximo = 100;
    [SerializeField] private int _valorActual = 100;
    [SerializeField] private int _valorMinimo = 1;

    [SerializeField] protected float _intervaloRegeneracion = 1f;
    protected float _tiempoAcumulado = 0f;

    public int getValorMaximo() => _valorMaximo;
    public int getValorActual() => _valorActual;
    public int getValorMinimo() => _valorMinimo;

    public void setValorActual(int valor) => _valorActual = valor;

    public virtual void Update()
    {
        // Vacío por defecto. Las clases hijas definen la lógica.
    }

    public void regeneracion()
    {
        setValorActual(Mathf.Min(getValorActual() + 1, getValorMaximo()));
    }
}
