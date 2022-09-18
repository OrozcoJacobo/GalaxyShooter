using UnityEngine;

public class AsteroidMovement : MonoBehaviour
{
    [SerializeField] float _speed = 5f;
    [SerializeField] GameObject _asteroidExplosion;
    private bool _movingLeft = false;
    private bool _movingRight = false;

    private void Start()
    {
        if (transform.position.x < 0)
        {
            _movingRight = true;
        }
        else if(transform.position.x > 0)
        {
            _movingLeft = true;
        }
    }
    private void Update()
    {
        if(_movingRight)
        {
            MovingRight();
        }
        if(_movingLeft)
        {
            MovingLeft();
        }
        if(transform.position.x < -12 || transform.position.x > 12)
        {
            Destroy(this.gameObject);
        }
    }

    private void MovingRight()
    {
        transform.Translate(Vector3.right * _speed * Time.deltaTime);
    }
    private void MovingLeft()
    {
        transform.Translate(Vector3.left * _speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Laser")
        {
            _asteroidExplosion.GetComponent<AsteroidExplosion>().AsteroidExplode(other, transform.position);
            Destroy(this.gameObject);
        }
    }
}
