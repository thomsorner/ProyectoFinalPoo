using UnityEngine;

public abstract class Habilidad : ScriptableObject
{
    [SerializeField] private string _descripcion;
    [SerializeField] private int _cooldown;
    [SerializeField] private int _costo;

    public string Descripcion => _descripcion;
    public int Cooldown => _cooldown;
    public int Costo => _costo;

    public abstract void Efecto(Portador portador);
}
