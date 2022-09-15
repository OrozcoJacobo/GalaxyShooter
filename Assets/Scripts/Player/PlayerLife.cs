using System.Collections;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    [SerializeField] private int _playerLife = 3;
    private bool _isShieldActive = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "EnemyLaser")
        {
            Destroy(other.gameObject);
            if (_isShieldActive)
            {
                DeactivateShields();
                
                return;
            }
            _playerLife--;
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
        StartCoroutine(DeactivateShields());
    }

    IEnumerator DeactivateShields()
    {
        yield return new WaitForSeconds(5f);
        _isShieldActive = false;
    }
}
