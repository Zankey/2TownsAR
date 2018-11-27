using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public enum AboutViewState {
    Hidden,
    Peeking,
    Shown
}

public class AboutViewController : MonoBehaviour {

    private float targetYPosition = -300;
    private RectTransform rectTransform;
    public Text aboutBodyTextBox;
    public Text aboutTitleTextBox;
    public AboutViewState state = AboutViewState.Hidden;
    public bool hideWhenPossible = true;

	// Use this for initialization
	void Start () {
        this.rectTransform = GetComponent<RectTransform>();
        this.rectTransform.anchoredPosition3D = new Vector3(this.rectTransform.anchoredPosition3D.x, targetYPosition, this.rectTransform.anchoredPosition3D.z);
	}
	
	// Update is called once per frame
	void Update () {
        float newHeight = Mathf.Lerp(this.rectTransform.anchoredPosition3D.y, targetYPosition, 0.1f);
        this.rectTransform.anchoredPosition3D = new Vector3(this.rectTransform.anchoredPosition3D.x, newHeight, this.rectTransform.anchoredPosition3D.z);
    }

    public void SetBodyText(string body) {
        aboutBodyTextBox.text = body;
    }

    public void SetTitleText(string title) {
        aboutTitleTextBox.text = title;
    }

    public void SetState(AboutViewState state) {
        this.state = state;
        switch (state) {
            case AboutViewState.Hidden:
                this.targetYPosition = -300;
                break;
            case AboutViewState.Peeking:
                this.targetYPosition = -220;
                hideWhenPossible = false;
                break;
            case AboutViewState.Shown:
                this.targetYPosition = 0;
                break;
        }
    }

    public void ToggleAboutView() {
        if (state == AboutViewState.Shown) {
            if (hideWhenPossible) {
                SetState(AboutViewState.Hidden);
            } else {
                SetState(AboutViewState.Peeking);
            }
        } else if (state == AboutViewState.Peeking) {
            SetState(AboutViewState.Shown);
        }
    }
}
