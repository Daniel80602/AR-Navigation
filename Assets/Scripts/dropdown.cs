using UnityEngine;
using UnityEngine.UI;

public class Dropdown: MonoBehaviour
{
    public GameObject dropdownUI;
    public GameObject panel1;
    public GameObject panel2;
    public GameObject panel3;
    public GameObject panel4;

    private CanvasGroup dropdownCanvasGroup;

    void Start()
    {
        dropdownCanvasGroup = dropdownUI.GetComponent<CanvasGroup>();
        ShowDropdownUI(false); // Initially hide the dropdown UI
    }

    void Update()
    {
        // Check which panel is active
        bool onPanel1 = panel1.activeSelf;
        bool onPanel2 = panel2.activeSelf;
        bool onPanel3 = panel3.activeSelf;
        bool onPanel4 = panel4.activeSelf;

        // Show or hide the dropdown UI accordingly
        if (onPanel2)
        {
            ShowDropdownUI(true);
        }
        else
        {
            ShowDropdownUI(false);
        }
    }

    void ShowDropdownUI(bool show)
    {
        if (show)
        {
            dropdownCanvasGroup.alpha = 1; // Make the dropdown visible
            dropdownCanvasGroup.interactable = true; // Enable interaction with the dropdown
            dropdownCanvasGroup.blocksRaycasts = true; // Enable raycasts on the dropdown
        }
        else
        {
            dropdownCanvasGroup.alpha = 0; // Hide the dropdown
            dropdownCanvasGroup.interactable = false; // Disable interaction with the dropdown
            dropdownCanvasGroup.blocksRaycasts = false; // Disable raycasts on the dropdown
        }
    }
}
