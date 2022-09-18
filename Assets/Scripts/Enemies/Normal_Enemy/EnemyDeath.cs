using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    private Level01Controller _playerScore;
    private Animator _animator;
    private EnemyMovement _enemyIsDead;
    private AudioSource _audioSource;
    private BoxCollider2D _boxCollider;
    [SerializeField] private AudioClip _enemyExplosionSound;

    private void Start()
    {
        _playerScore = GameObject.Find("Level01Controller").GetComponent<Level01Controller>();
        _animator = GetComponent<Animator>();
        _enemyIsDead = GetComponent<EnemyMovement>();
        _audioSource = GetComponent<AudioSource>();
        _boxCollider = GetComponent<BoxCollider2D>();
        if(_playerScore == null)
        {
            Debug.LogError("Level01Controler is Null @ EnemyDeath.cs");
        }
        if(_animator == null)
        {
            Debug.LogError("Animator is Null @ EnemyDeath.cs");
        }
        if(_enemyIsDead == null)
        {
            Debug.LogError("EnemyMovement is Null @ EnemyDeath.cs");
        }
        if(_audioSource == null)
        {
            Debug.LogError("AudioSource is Null @ EnemyDeath.cs");
        }
        if(_boxCollider == null)
        {
            Debug.LogError("BoxCollider2D is Null @ EnemyDeath.cs");
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Laser" || other.tag == "Player")
        {
            if(other.tag == "Laser")
                Destroy(other.gameObject);

            _audioSource.clip = _enemyExplosionSound;
            _animator.SetTrigger("EnemyIsDead");
            _enemyIsDead.IsDead();
            _playerScore.AddPlayerScore(10);
            _audioSource.Play();
            _boxCollider.enabled = false;
            Destroy(gameObject, 2.3f);
        }
    }
}
