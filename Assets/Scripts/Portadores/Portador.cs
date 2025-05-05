using UnityEngine;

public class Portador : MonoBehaviour
{
    [Header("Sistemas")]
    [SerializeField] protected SistemaVida sistemaVida;

    protected virtual void Awake()
    {
        if (sistemaVida == null)
            sistemaVida = GetComponent<SistemaVida>();
    }
}
