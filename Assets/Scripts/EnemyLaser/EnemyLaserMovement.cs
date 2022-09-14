using UnityEngine;

public class EnemyLaserMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);

        if(transform.position.y < -8)
        {
            Destroy(this.gameObject);
        }
    }


}
