using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;

public class Crossbow : MonoBehaviour
{
    // define and/or initiate a lot of variables
    public bool lockAndLoaded = true;
    private bool isOut = true;
    private bool isAiming = false;
    
    public float arrowSpeed = 50f;

    public AudioSource crossbowReload;
    public AudioSource crossbowShot;
    
    public GameObject arrowPrefab;
    public GameObject crosshair;
    public List<GameObject> removeBow;
    
    public Animator animator;
    
    public Transform arrowSpawnPoint;
    public Transform scopedArrowSpawnPoint;

    void Update()
    {
        // if the player presses f, the crossbow will be tucked away, and it will no longer be able to shoot or reload
        if (Input.GetKeyDown(KeyCode.F) && isOut)
        {
            // Play the animation
            animator.SetTrigger("PullBack"); 
            isOut = false;

        } else if (Input.GetKeyDown(KeyCode.F) && !isOut)
        {
            // if f is pressed again, it will pull out the crossbow, since its already tucked away
            // Play the animation
            animator.SetTrigger("PullUp"); 
            isOut = true;
        }
        
        // Since i have to spawn points for the arrow, one is set to be in the middle of the screen
        // the other is set from the crossbow, so it acts like a hip shot.
        if (Input.GetKey(KeyCode.Mouse1) && isOut)
        {
            // calls the OnScopedShoot method
            OnScopedShoot();
        }
        else
        {
            // removes the UI for the crosshair, sets isAiming to false, and "spawns" the crossbow
            crosshair.SetActive(false);
            isAiming = false;
            for (int i = 0; i < removeBow.Count; i++)
            {
                removeBow[i].SetActive(true);
            }
        } 
        
        // there is a lot of conditions that needs to be fulfilled in order for this to run
        // the crossbow needs to be out, not aiming (rightclicked) and needs to be loaded
        if (Input.GetKey(KeyCode.Mouse0) && isOut && !isAiming && lockAndLoaded)
        {
            // calls the OnShoot method
            OnShoot();
        }

        if (Input.GetKeyDown(KeyCode.R) && !isAiming && !lockAndLoaded)
        {
            // calls the OnReload coroutine, which reloads the crossbow
            StartCoroutine(OnReload());
        }
    }
    
    public void OnShoot()
    {
        //Shoot without aiming
        
        // plays the crossbow animation
        animator.SetTrigger("Shoot");
        
        // fires an arrow
        GameObject arrow = Instantiate(arrowPrefab, arrowSpawnPoint.position, arrowSpawnPoint.rotation);
        
        // gets the arrows rigidbody
        Rigidbody arrowRigidbody = arrow.GetComponent<Rigidbody>();
        
        // and gives it an impulse boost to be shot
        // the reason i dont use raycast, is i want the arch on the arrow (dont know if its possible)
        arrowRigidbody.AddForce(arrowSpawnPoint.up * arrowSpeed, ForceMode.Impulse);

        lockAndLoaded = false;
        
        StartCoroutine(OnShotSound());

    }

    public void OnScopedShoot()
    {
        // sets the UI to true
        crosshair.SetActive(true);
        isAiming = true;
            
        // "despawns" the crossbow
        for (int i = 0; i < removeBow.Count; i++)
        {
            removeBow[i].SetActive(false);
        }
        
        // The same as line 79 through 98
        if (Input.GetKey(KeyCode.Mouse0) && isAiming && lockAndLoaded)
        {
            // plays the crossbow animation
            animator.SetTrigger("Shoot");
            
            // fires an arrow
            GameObject arrow = Instantiate(arrowPrefab, scopedArrowSpawnPoint.position, scopedArrowSpawnPoint.rotation);

            // gets the arrows rigidbody
            Rigidbody arrowRigidbody = arrow.GetComponent<Rigidbody>();
            
            // and gives it an impulse boost to be shot
            // the reason i dont use raycast, is i want the arch on the arrow (dont know if its possible)
            arrowRigidbody.AddForce(scopedArrowSpawnPoint.up * arrowSpeed, ForceMode.Impulse);

            lockAndLoaded = false;
            
            StartCoroutine(OnShotSound());
        }
    }
    
    IEnumerator OnReload()
    {
        // Play only 1.5 seconds of sound, because it's scoffed
        crossbowReload.Play();
        yield return new WaitForSeconds(1.5f);
        crossbowReload.Stop();
        
        // then set this to true, so the player can shoot again
        lockAndLoaded = true;
    }

    IEnumerator OnShotSound()
    {
        // this gets called everytime the player shoots, and makes the crossbow play a sound.
        // The time is set to 4.8f so it skips the first part, then stop the sounds again after 0.8 seconds
        // again beccause the sound files are scoffed, and i didnt want to waste time editing them
        crossbowShot.time = 4.8f;
        crossbowShot.Play();
        yield return new WaitForSeconds(0.8f);
        crossbowShot.Stop();
    }
}
