using UnityEngine;

public abstract class Agente : Portador
{
    [SerializeField] private SistemaHabilidades sistemaHabilidades;

    protected override void Awake()
    {
        base.Awake();  // Esto es CLAVE para que el Awake de Portador se ejecute

        if (sistemaHabilidades == null)
            sistemaHabilidades = GetComponent<SistemaHabilidades>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            sistemaHabilidades.EjecutarHabilidad(0, this);

        if (Input.GetKeyDown(KeyCode.Alpha2))
            sistemaHabilidades.EjecutarHabilidad(1, this);

        if (Input.GetKeyDown(KeyCode.Alpha3))
            sistemaHabilidades.EjecutarHabilidad(2, this);
    }

    public abstract void CobrarHabilidad(int costo);
}
