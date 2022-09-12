using UnityEngine;

public class Earth : MonoBehaviour
{
    [SerializeField]
    private float _rotateSpeed = 20.0f;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.down * _rotateSpeed * Time.deltaTime);
    }
}
