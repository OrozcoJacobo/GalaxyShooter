using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Laser")
        {
            Destroy(gameObject);
        }
    }
}
