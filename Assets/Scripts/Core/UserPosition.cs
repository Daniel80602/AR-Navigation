using TMPro;
using UnityEngine;

public class DisplayUserPosition : MonoBehaviour
{
    public GameObject sphereObject; // Reference to the sphere GameObject representing the user's position
    private TMP_Text textField;

    private void Start()
    {
        // Get the TextMeshPro Text component
        textField = GetComponent<TMP_Text>();

        // Check if the sphere GameObject reference is assigned
        if (sphereObject == null)
        {
            Debug.LogWarning("Sphere GameObject reference not assigned!");
        }
    }

    private void Update()
    {
        // Check if the sphere GameObject reference is assigned
        if (sphereObject != null && textField != null)
        {
            // Get the position of the sphere GameObject
            Vector3 spherePosition = sphereObject.transform.position;
            Quaternion  spherePosition2 = sphereObject.transform.rotation;

            textField.text = "";

            // Update the TextMeshPro text to display the sphere GameObject's position
            textField.text = "position: " + spherePosition + "rotation: " + spherePosition2;
        }
    }
}
