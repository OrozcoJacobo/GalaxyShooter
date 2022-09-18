using System.Collections;
using UnityEngine;

public class Fire : MonoBehaviour
{
    [SerializeField]
    private GameObject _laserPrefab;
    [SerializeField]
    private GameObject _tripleShotPrefab;
    private bool _isTripleShotActive = false;
    [SerializeField] private AudioClip _laserSoundClip;
    private AudioSource _audioSource;
    private float _fireRate = 0.5f;
    private float _canFire = -1f;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        if(_audioSource == null)
        {
            Debug.LogError("Audio Souce is Null @ Fire");
        }
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            FireLaser();
        }
    }

    public void FireLaser()
    {
        _audioSource.clip = _laserSoundClip;
        if (_isTripleShotActive && Time.time > _canFire)
        {
            _canFire = Time.time + _fireRate;
            Instantiate(_tripleShotPrefab, transform.position + new Vector3 (0, 4f, 0), transform.rotation);
            _audioSource.Play();
        }
        else if(Time.time > _canFire)
        {
            _canFire = Time.time + _fireRate;
            Instantiate(_laserPrefab, transform.position + new Vector3(0, 1f, 0), transform.rotation);
            //_audioSource.Play();
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
