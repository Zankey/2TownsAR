using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

    public Slider slider;
    public Text progressText;
    public int totalObjects = 5;
    private int objectsFound = 0;
    private bool CrossFound = false;
    private bool DiamondFound = false;
    private bool MountainFound = false;
    private bool CityFound = false;

    private void Start() {
        slider.value = 0;
    }

    // Update is called once per frame
    void Update () {
        objectsFound = calculateObjectsFound();
        slider.value = Mathf.Lerp(slider.value, (float)objectsFound/(float)totalObjects, 0.1f);
        progressText.text = objectsFound + "/" + totalObjects;
	}

    public void HamburgerMenu() {
        objectsFound++;
    }

    private int calculateObjectsFound() {
        int total = 0;
        if (CrossFound) { total += 1; }
        if (DiamondFound) { total += 1; }
        if (MountainFound) { total += 1; }
        if (CityFound) { total += 1; }
        return total;
    }

    public void FoundObject(AnimationType animationType) {
        switch (animationType) {
            case AnimationType.TwentyNine:
                CrossFound = true;
                break;
            case AnimationType.Five:
                DiamondFound = true;
                break;
            case AnimationType.Mountain:
                MountainFound = true;
                break;
            case AnimationType.City:
                CityFound = true;
                break;


        }
    }
}
