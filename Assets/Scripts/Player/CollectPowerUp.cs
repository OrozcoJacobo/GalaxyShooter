using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectPowerUp : MonoBehaviour
{
    private PlayerMovement speedBoost;
    private Fire tripleShot;
    private PlayerLife shield;
    private void Start()
    {
        speedBoost = GameObject.Find("Player").GetComponent<PlayerMovement>();
        tripleShot = GameObject.Find("Player").GetComponentInChildren<Fire>();
        shield = GameObject.Find("Player").GetComponent<PlayerLife>();
        if(speedBoost == null)
        {
            Debug.LogError("Speed Boost is NULL @ CollectPowerUp");
        }
        if(tripleShot == null)
        {
            Debug.LogError("Triple Shot is NULL @ CollectPowerUp");
        }
        if(shield == null)
        {
            Debug.LogError("Shield is NULL @ CollectPowerup");
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "TripleShot")
        {
            //Debug.Log("Triple Shot collected");
            tripleShot.TripleShotActive();
            Destroy(other.gameObject);
        }
        if(other.tag == "Speed")
        {
            //Debug.Log("Speed collected");
            speedBoost.SpeedBoostActive();
            Destroy(other.gameObject);
        }
        if(other.tag == "Shield")
        {
            //Debug.Log("Shield collected");
            shield.ShieldsActive();
            Destroy(other.gameObject);
        }
    }
}
