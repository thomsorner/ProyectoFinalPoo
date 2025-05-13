using UnityEngine;

public class TextoFlotante : MonoBehaviour
{
    void Update()
    {
        if (Camera.main != null)
        {
            transform.forward = Camera.main.transform.forward;
        }
    }
}
