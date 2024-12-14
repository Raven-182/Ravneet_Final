using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class ClickManager : MonoBehaviour
{
    public Camera mainCamera; 
    public int totalClicks = 0; 
    public TMP_Text clickDisplayText; 

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                NPCClickTracker clickTracker = hit.collider.GetComponent<NPCClickTracker>();
                if (clickTracker != null)
                {
                    clickTracker.IncrementClickCount();

                    totalClicks++;
                    UpdateClickDisplay();
                }
            }
        }
    }

    void UpdateClickDisplay()
    {
        if (clickDisplayText != null)
        {
            clickDisplayText.text = " " + totalClicks;
        }
    }
}

