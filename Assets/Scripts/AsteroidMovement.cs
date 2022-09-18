using UnityEngine;

public class AsteroidMovement : MonoBehaviour
{
    [SerializeField] float _speed = 5f;
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
    }

    private void MovingRight()
    {
        transform.Translate(Vector3.right * _speed * Time.deltaTime);
    }
    private void MovingLeft()
    {
        transform.Translate(Vector3.left * _speed * Time.deltaTime);
    }
}
