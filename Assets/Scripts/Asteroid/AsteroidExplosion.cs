using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidExplosion : MonoBehaviour
{
    [SerializeField] private GameObject _asteroidExplosion;
    [SerializeField] private AudioSource _asteroidExplosionAudioSource;
    [SerializeField] private AudioClip _asteroidExplosionClip;
    public void AsteroidExplode(Collider2D other, Vector3 position)
    {
        if(other.tag == "Laser")
        {
            _asteroidExplosionAudioSource.clip = _asteroidExplosionClip;
            GameObject explosion = Instantiate(_asteroidExplosion, position, Quaternion.identity);
            Destroy(other.gameObject);
            Destroy(explosion, 2.3f);
            _asteroidExplosionAudioSource.Play();
        }
    }
}
