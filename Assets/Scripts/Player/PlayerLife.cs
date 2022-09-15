using System.Collections;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    [SerializeField] private int _playerLife = 3;
    private bool _isShieldActive = false;
    [SerializeField] private GameObject _shieldPrefab;
    private Level01Controller _currentPlayerLife;

    private void Start()
    {
        _currentPlayerLife = GameObject.Find("Level01Controller").GetComponent<Level01Controller>();
        if(_currentPlayerLife == null)
        {
            Debug.LogError("Level01Controller is NULL @ PlayerLife.cs");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "EnemyLaser" || other.tag == "Enemy")
        {
            Destroy(other.gameObject);
            if (_isShieldActive)
            {
                DeactivateShields();
                
                return;
            }
            _playerLife--;
            _currentPlayerLife.UpdateLives(_playerLife);
            Debug.Log("Player hit, lives: " + _playerLife);
            if(_playerLife <= 0)
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
