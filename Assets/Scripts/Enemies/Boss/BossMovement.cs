using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour
{
    [SerializeField]
    private float _speed = 5;
    private Vector3 randomPositionBarricade;
    private bool inPosition = false;
    private bool movingLeft = false;
    // Start is called before the first frame update
    void Start()
    {
        randomPositionBarricade = new Vector3(Random.Range(-7, 7), Random.Range(3, 4), 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position != randomPositionBarricade && inPosition == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, randomPositionBarricade, _speed * Time.deltaTime);
            if (transform.position == randomPositionBarricade)
            {
                inPosition = true;
                movingLeft = true;
            }
        }
        if (inPosition == true)
        {
            if (movingLeft == true)
            {
                transform.Translate(Vector3.down * _speed * Time.deltaTime);

            }
            if (movingLeft == false)
            {
                transform.Translate(Vector3.up * _speed * Time.deltaTime);

            }
            if (transform.position.x <= -5)
            {
                movingLeft = false;
            }
            if (transform.position.x >= 5)
            {
                movingLeft = true;
            }
        }
    }
}

