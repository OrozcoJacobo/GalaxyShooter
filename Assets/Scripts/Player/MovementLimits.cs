using UnityEngine;

public class MovementLimits : MonoBehaviour
{
    void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -8.32f, 8.32f), Mathf.Clamp(transform.position.y, -4.1f, 4.1f));
    }
        
}
