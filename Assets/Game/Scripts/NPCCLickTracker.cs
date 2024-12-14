using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class NPCClickTracker : MonoBehaviour
{
    public int clickCount = 0; 
    public int maxClicks = 5; 
    public GameObject particleEffect; 

    public void IncrementClickCount()
    {
        clickCount++;

        if (clickCount >= maxClicks)
        {
            
            if (particleEffect != null)
            {
                Instantiate(particleEffect, transform.position, Quaternion.identity);
            }

            Destroy(gameObject);
        }
    }
}
