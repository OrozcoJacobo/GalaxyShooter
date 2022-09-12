using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField]
    private float _speed;
    private Vector3 _direction;

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        _direction = new Vector3(horizontalInput, verticalInput, 0);
        transform.Translate (_direction * _speed * Time.deltaTime);
    }
}
