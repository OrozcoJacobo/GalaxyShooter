using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFire : MonoBehaviour
{
    [SerializeField] private GameObject _laser;
    [SerializeField] private float _shootInterval;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        InvokeRepeating(nameof(FireLaser), _shootInterval, _shootInterval);
    }

    private void FireLaser()
    {
        float laserOffset = -1f;
        Vector3 laserStartPosition = (transform.position + new Vector3(0, laserOffset, 0));
        Instantiate(_laser, laserStartPosition, Quaternion.identity);
    }
}
