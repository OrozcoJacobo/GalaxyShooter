using System.Collections;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    [SerializeField] private int _playerLife = 3;
    private bool _isShieldActive = false;
    [SerializeField] private GameObject _shieldPrefab;
    private Level01Controller _currentPlayerLife;
    [SerializeField] private GameObject _enemy;
    [SerializeField] private GameObject _asteroid;
    [SerializeField] private GameObject _asteroidExplosion;
    [SerializeField] private GameObject _rightEngine;
    [SerializeField] private GameObject _leftEngine;
    [SerializeField] private AudioClip _asteroidExplosionSound;
    private AudioSource _playerAudioSource;

    private void Start()
    {
        _currentPlayerLife = GameObject.Find("Level01Controller").GetComponent<Level01Controller>();
        _playerAudioSource = GetComponent<AudioSource>();
        if(_currentPlayerLife == null)
        {
            Debug.LogError("Level01Controller is NULL @ PlayerLife.cs");
        }
        if( _playerAudioSource == null)
        {
            Debug.LogError("Audio Source is NULL @ PlayerLife.cs");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "EnemyLaser" || other.tag == "Enemy" || other.tag == "Asteroid")
        {
            
            if (_isShieldActive)
            {
                if (other.tag == "Enemy")
                {
                    _enemy.GetComponent<Animator>().SetTrigger("EnemyIsDead");
                    Destroy(other.gameObject, 2.3f);
                }
                if(other.tag == "Asteroid")
                {
                    _playerAudioSource.clip = _asteroidExplosionSound;
                    GameObject explosion = Instantiate(_asteroidExplosion, other.transform.position, Quaternion.identity);
                    Destroy(other.gameObject);
                    Destroy(explosion, 2.3f);
                    _playerAudioSource.Play();

                }
                DeactivateShields();
                
                return;
            }
            _playerLife--;
            _currentPlayerLife.UpdateLives(_playerLife);
            //Debug.Log("Player hit, lives: " + _playerLife);
            if (other.tag == "Enemy")
            {
                _enemy.GetComponent<Animator>().SetTrigger("EnemyIsDead");
                Destroy(other.gameObject, 2.3f);
            }
            else if (other.tag == "Asteroid")
            {
                _playerAudioSource.clip = _asteroidExplosionSound;
                GameObject explosion = Instantiate(_asteroidExplosion, other.transform.position, Quaternion.identity);
                Destroy(other.gameObject);
                Destroy(explosion, 2.3f);
                _playerAudioSource.Play();
                //AsteroidExplosionHere
            }
            else
            {
                Destroy(other.gameObject);
            }
            if(_playerLife == 2)
            {
                _leftEngine.SetActive(true);
            }
            if(_playerLife == 1)
            {
                _rightEngine.SetActive(true);
            }
            if (_playerLife <= 0)
            {
                Destroy(this.gameObject);

            }



        }
    }

    public void ShieldsActive()
    {
        _isShieldActive = true;
        _shieldPrefab.SetActive(true);
    }

    private void DeactivateShields()
    {
        _isShieldActive = false;
        _shieldPrefab.SetActive(false);
    }
}
