using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossDeath : MonoBehaviour
{
    private float _bossLife = 5;
    // Start is called before the first frame update

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Laser")
        {
            Destroy(other.gameObject);
            _bossLife--; 
            if(_bossLife <= 0)
            {
                Destroy(this.gameObject);
                SceneManager.LoadScene(0);
            }
            
        }
    }
}
