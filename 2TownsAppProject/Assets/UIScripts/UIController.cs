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
    public AboutViewController aboutViewController;
    public ProgressViewController progressViewController;
    public GameObject sliderFillArea;

    private void Start() {
        slider.value = 0;
    }

    // Update is called once per frame
    void Update () {
        objectsFound = calculateObjectsFound();
        slider.value = Mathf.Lerp(slider.value, (float)objectsFound/(float)totalObjects, 0.1f);
        progressText.text = objectsFound + "/" + totalObjects;
	}

    private int calculateObjectsFound() {
        int total = 0;
        if (CrossFound) { total += 1; }
        if (DiamondFound) { total += 1; }
        if (MountainFound) { total += 1; }
        if (CityFound) { total += 1; }
        if (total > 0) {
            sliderFillArea.SetActive(true);
        } else {
            sliderFillArea.SetActive(false);
        }
        return total;
    }

    public void FoundObject(ARObjectType objectType, AboutViewState aboutViewState = AboutViewState.Peeking) {
        switch (objectType) {
            case ARObjectType.Cross:
                CrossFound = true;
                aboutViewController.SetTitleText("(Insert Cross Title Here)");
                aboutViewController.SetBodyText("(Replace this text with cross body text.)");
                break;
            case ARObjectType.Diamond:
                DiamondFound = true;
                aboutViewController.SetTitleText("(Insert Diamond Title Here)");
                aboutViewController.SetBodyText("(Replace this text with diamond body text.)");
                break;
            case ARObjectType.Mountain:
                MountainFound = true;
                aboutViewController.SetTitleText("(Insert Mountain Title Here)");
                aboutViewController.SetBodyText("(Replace this text with mountain body text.)");
                break;
            case ARObjectType.City:
                CityFound = true;
                aboutViewController.SetTitleText("(Insert City Title Here)");
                aboutViewController.SetBodyText("(Replace this text with city body text.)");
                break;
        }

        aboutViewController.SetState(aboutViewState);
        progressViewController.FoundObject(objectType);

    }

    private void TapBadge(ARObjectType objectType) {
        FoundObject(objectType, AboutViewState.Shown);
    }

    public void TapDiamond() {
        if (!DiamondFound) { return; }
        TapBadge(ARObjectType.Diamond);
    }

    public void TapCross() {
        if (!CrossFound) { return; }
        TapBadge(ARObjectType.Cross);
    }

    public void TapCity() {
        if (!CityFound) { return; }
        TapBadge(ARObjectType.City);
    }

    public void TapMountain() {
        if (!MountainFound) { return; }
        TapBadge(ARObjectType.Mountain);
    }

    public void NotTrackingObject(ARObjectType objectType) {
        if (aboutViewController.state == AboutViewState.Peeking) {
            aboutViewController.SetState(AboutViewState.Hidden);
        } else {
            aboutViewController.hideWhenPossible = true;
        }

    }
}
