using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossDeath : MonoBehaviour
{
    [SerializeField] private GameObject _bossDeath;
    private Level01Controller _controller;
    private float _bossLife = 20;
    private AudioSource _audioSource;
    [SerializeField] private AudioClip _bossExplosion;
    // Start is called before the first frame update
    private void Start()
    {
        _controller = GameObject.Find("Level01Controller").GetComponent<Level01Controller>();
        _audioSource = GetComponent<AudioSource>();
        if(_controller == null)
        {
            Debug.LogError("Level01Controller is Null @ BossDeath.cs");
        }
        if(_audioSource == null)
        {
            Debug.LogError("AudioSource is Null @ BossDeath.cs");
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Laser")
        {
            Destroy(other.gameObject);
            _bossLife--; 
            if(_bossLife <= 0)
            {
                //_audioSource.clip = _bossExplosion;
                Destroy(this.gameObject);
                GameObject explosion = Instantiate(_bossDeath, transform.position, Quaternion.identity);
                //_audioSource.Play();
                Destroy(explosion, 2.3f);
                _controller.BossDefeat();
                SceneManager.LoadScene(3);
            }
            
        }
    }
}
