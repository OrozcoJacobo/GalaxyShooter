using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    private Level01Controller _playerScore;


    private void Start()
    {
        _playerScore = GameObject.Find("Level01Controller").GetComponent<Level01Controller>();
        if(_playerScore == null)
        {
            Debug.LogError("Level01Controler is Null @ EnemyDeath.cs");
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Laser" || other.tag == "Player")
        {
            _playerScore.AddPlayerScore(10);
            Destroy(gameObject);
        }
    }
}
