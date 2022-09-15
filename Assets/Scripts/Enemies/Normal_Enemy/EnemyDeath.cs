using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    private Level01Controller _playerScore;
    [SerializeField] private Sprite[] _liveSprites;
    [SerializeField] private GameObject _livesImage;

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
        if(other.tag == "Laser")
        {
            _playerScore.AddPlayerScore(10);
            Destroy(gameObject);
        }
    }
}
