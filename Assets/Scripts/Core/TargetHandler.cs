using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI.Extensions;

public class TargetHandler : MonoBehaviour {

    [SerializeField]
    private NavigationController navigationController;
    [SerializeField]
    private TextAsset targetModelData;
    [SerializeField]
    private AutoCompleteComboBox targetDataDropdown; // Change the type to AutoCompleteComboBox

    [SerializeField]
    private GameObject targetObjectPrefab;
    [SerializeField]
    private Transform targetObjectsParentTransform; // Assuming a single floor

    private List<TargetFacade> currentTargetItems = new List<TargetFacade>();

    private void Start() {
        GenerateTargetItems();
        FillDropdownWithTargetItems();
    }

    private void GenerateTargetItems() {
        IEnumerable<Target> targets = GenerateTargetDataFromSource();
        foreach (Target target in targets) {
            currentTargetItems.Add(CreateTargetFacade(target));
        }
    }

    private IEnumerable<Target> GenerateTargetDataFromSource() {
        return JsonUtility.FromJson<TargetWrapper>(targetModelData.text).TargetList;
    }

    private TargetFacade CreateTargetFacade(Target target) {
        GameObject targetObject = Instantiate(targetObjectPrefab, targetObjectsParentTransform, false);
        targetObject.SetActive(true);
        targetObject.name = target.Name;
        targetObject.transform.localPosition = target.Position;
        targetObject.transform.localRotation = Quaternion.Euler(target.Rotation);

        TargetFacade targetData = targetObject.GetComponent<TargetFacade>();
        targetData.Name = target.Name;

        return targetData;
    }

    private void FillDropdownWithTargetItems() {
        List<string> targetNames = currentTargetItems.Select(x => x.Name).ToList();

        foreach (string option in targetNames) {
            targetDataDropdown.AddItem(option);
        }
    }

    public void SetSelectedTargetPositionWithDropdown(string selectedValue) {
        navigationController.TargetPosition = GetCurrentlySelectedTarget(selectedValue);
    }

    private Vector3 GetCurrentlySelectedTarget(string selectedValue) {
        TargetFacade selectedTarget = currentTargetItems.Find(x =>
            x.Name.ToLower().Equals(selectedValue.ToLower()));

        if (selectedTarget != null) {
            return selectedTarget.transform.position;
        }

        return Vector3.zero; // Default position if selectedValue is invalid
    }

    public void AddOption(string option)
    {
        targetDataDropdown.AddItem(option);
    }

    public void RemoveOption(string option)
    {
        targetDataDropdown.RemoveItem(option);
    }

 
    public TargetFacade GetCurrentTargetByTargetText(string targetText) {
        return currentTargetItems.Find(x =>
            x.Name.ToLower().Equals(targetText.ToLower()));
    }
}
