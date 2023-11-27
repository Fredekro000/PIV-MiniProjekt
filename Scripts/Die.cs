using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Die : MonoBehaviour
{
    public AudioSource deathSound;
    public GameObject enemy;
    
    private void OnCollisionEnter(Collision collision)
    {
        // Checks if the arrow hits a gameobject with the enemy tag
        if (collision.gameObject.CompareTag("Enemy"))
        {
            StartCoroutine(Death());
            
            // saves the hit gameobject as enemy to kill later
            enemy = collision.gameObject;
        }
    }

    IEnumerator Death()
    {
        // Plays the deathsound for the furry, and skips the first play of the audioclip since its irrelevant
        deathSound.Play();
        deathSound.time = 2f;
        
        // Play the sound for 7.8 seconds then stop it and kill the enemy
        yield return new WaitForSeconds(7.8f);
        deathSound.Stop();
        
        Destroy(enemy);
    }
}
