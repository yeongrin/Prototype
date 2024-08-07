using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisibilityController : MonoBehaviour
{
    private void Update()
    {
        // Get the current layer of the object
            int layer = gameObject.layer;

            // Check if the current layer is "scene1"
            if (layer == LayerMask.NameToLayer("Scene1"))
            {
                // If in the correct layer, set the object to be visible
                SetVisible(true);
            }
            else
            {
                // If not in the correct layer, set the object to be invisible
                SetVisible(false);
            }
        }
    

    private void SetVisible(bool isVisible)
    {
        // Enable or disable the GameObject based on visibility
        gameObject.SetActive(isVisible);
    }
}
