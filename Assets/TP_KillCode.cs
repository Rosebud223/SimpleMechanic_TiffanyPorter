using UnityEngine;

public class ChangeColorOnClick : MonoBehaviour
{
    public Transform player;  // Assign player in Inspector
    public float activationDistance = 3f; // Distance threshold
    public string excludeObjectName = "Eye";

    void OnMouseDown()
    {
        if (player != null)
        {
            float distance = Vector3.Distance(player.position, transform.position);
            
            if (distance <= activationDistance)
            {
                ChangeColorRecursively(transform, Color.red); // Change color of all parts
            }
            else
            {
                Debug.Log("Too far away to interact!");
            }
        }
    }

    void ChangeColorRecursively(Transform obj, Color newColor)
    {
        // Change color of the object's Renderer, if it has one
        Renderer renderer = obj.GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.material.color = newColor;
        }

        // Loop through all children and apply the color change
        foreach (Transform child in obj)
        {
            if (child.name != excludeObjectName)
            {
            ChangeColorRecursively(child, newColor);
            }
        }
    }
}
