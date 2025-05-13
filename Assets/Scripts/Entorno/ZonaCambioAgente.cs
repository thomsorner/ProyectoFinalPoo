using UnityEngine;

public class ZonaCambioAgente : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        AgenteVida agenteVida = other.GetComponent<AgenteVida>();
        AgenteMana agenteMana = other.GetComponent<AgenteMana>();

        if (agenteVida != null && agenteMana != null)
        {
            if (agenteVida.enabled)
            {
                agenteVida.enabled = false;
                agenteMana.enabled = true;
                Debug.Log("Cambio a AgenteMana.");
            }
            else if (agenteMana.enabled)
            {
                agenteMana.enabled = false;
                agenteVida.enabled = true;
                Debug.Log("Cambio a AgenteVida.");
            }
        }
    }
}
