using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField]
    private float _speed;
    private Vector3 _direction;
    private bool _speedPowerUp;
    private float _speedMultiplier = 2f;

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        _direction = new Vector3(horizontalInput, verticalInput, 0);
        transform.Translate (_direction * _speed * Time.deltaTime);
    }

    public void SpeedBoostActive()
    {
        _speed *= _speedMultiplier;
        StartCoroutine(DeactivateSpeedBoost());
    }

    IEnumerator DeactivateSpeedBoost()
    {
        yield return new WaitForSeconds(5.0f);
        _speed /= _speedMultiplier;
    }
}
