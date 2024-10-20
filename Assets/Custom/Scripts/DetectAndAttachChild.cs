using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectAndAttachChild : MonoBehaviour
{

    public string tagToDetect = "";

    void Start()
    {
        DetectAndAttachChildren();
    }

    void DetectAndAttachChildren()
    {
        // Find all game objects with the specified script attached
        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag(tagToDetect);

        // Attach each found object as a child of this object
        foreach (GameObject obj in objectsWithTag)
        {
            // Ensure the object isn't already a child
            if (obj.transform.parent != transform)
            {
                obj.transform.parent = transform;
            }
        }
    }
}
