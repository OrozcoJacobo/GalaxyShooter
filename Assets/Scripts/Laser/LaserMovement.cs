using UnityEngine;

public class LaserMovement : MonoBehaviour
{
    [SerializeField]
    private float _speed = 10f;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        //transform.position += moveDirection * _speed * Time.deltaTime;
        rb.AddForce(transform.up * _speed, ForceMode2D.Impulse);
        LaserDelete();
    }

    private void LaserDelete()
    {
        if(transform.position.x > 10f)
        {
            Destroy(this.gameObject);
        }
        else if(transform.position.x < -10f)
        {
            Destroy(this.gameObject);
        }
        if(transform.position.y > 6)
        {
            Destroy(this.gameObject);
        }
        else if(transform.position.y < -6)
        {
            Destroy(this.gameObject);
        }
    }


}
