using UnityEngine;

public class Fire : MonoBehaviour
{
    [SerializeField]
    private GameObject _laserPrefab;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            FireLaser();
        }
    }

    public void FireLaser()
    {
        Instantiate(_laserPrefab, transform.position, transform.rotation);
    }

}
