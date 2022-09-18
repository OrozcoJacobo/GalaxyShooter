using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    private Level01Controller _playerScore;
    private Animator _animator;
    private EnemyMovement _enemyIsDead;

    private void Start()
    {
        _playerScore = GameObject.Find("Level01Controller").GetComponent<Level01Controller>();
        _animator = GetComponent<Animator>();
        _enemyIsDead = GetComponent<EnemyMovement>();
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
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Laser" || other.tag == "Player")
        {
            if(other.tag == "Laser")
                Destroy(other.gameObject);

            _animator.SetTrigger("EnemyIsDead");
            _enemyIsDead.IsDead();
            _playerScore.AddPlayerScore(10);
            Destroy(gameObject, 2.3f);
        }
    }
}
