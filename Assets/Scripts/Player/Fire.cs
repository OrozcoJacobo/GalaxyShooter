using System.Collections;
using UnityEngine;

public class Fire : MonoBehaviour
{
    [SerializeField]
    private GameObject _laserPrefab;
    [SerializeField]
    private GameObject _tripleShotPrefab;
    private bool _isTripleShotActive = false;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            FireLaser();
        }
    }

    public void FireLaser()
    {
        if(_isTripleShotActive)
        {
            Instantiate(_tripleShotPrefab, transform.position + new Vector3 (0, 4f, 0), transform.rotation);
        }
        else
        {
            Instantiate(_laserPrefab, transform.position + new Vector3(0, 1f, 0), transform.rotation);
        }
    }

    public void TripleShotActive()
    {
        _isTripleShotActive=true;
        StartCoroutine(DeactivateTripleShot());
    }

    IEnumerator DeactivateTripleShot()
    {
        yield return new WaitForSeconds(5f);
        _isTripleShotActive = false;    
    }

}
