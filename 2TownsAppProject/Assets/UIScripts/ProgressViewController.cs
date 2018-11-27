using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressViewController : MonoBehaviour {

    private float targetYPosition = 345;
    private RectTransform rectTransform;
    public bool badgesAreHidden = true;
    public Image[] badgeImages;
    public Sprite[] badgeSprites;

    // Use this for initialization
    void Start() {
        this.rectTransform = GetComponent<RectTransform>();
        this.rectTransform.anchoredPosition3D = new Vector3(this.rectTransform.anchoredPosition3D.x, targetYPosition, this.rectTransform.anchoredPosition3D.z);
    }

    // Update is called once per frame
    void Update() {
        float newHeight = Mathf.Lerp(this.rectTransform.anchoredPosition3D.y, targetYPosition, 0.1f);
        this.rectTransform.anchoredPosition3D = new Vector3(this.rectTransform.anchoredPosition3D.x, newHeight, this.rectTransform.anchoredPosition3D.z);
    }

    private void SetBadgesHidden(bool isHidden) {
        this.badgesAreHidden = isHidden;
        if (badgesAreHidden) {
            targetYPosition = 345;
        } else {
            targetYPosition = 0;
        }
    }

    public void ToggleBadgesHidden() {
        SetBadgesHidden(!badgesAreHidden);
    }

    public void FoundObject(ARObjectType objectType) {
        switch (objectType) {
            case ARObjectType.Cross:
                badgeImages[0].sprite = badgeSprites[0];
                break;
            case ARObjectType.Mountain:
                badgeImages[1].sprite = badgeSprites[1];
                break;
            case ARObjectType.Diamond:
                badgeImages[2].sprite = badgeSprites[2];
                break;
            case ARObjectType.City:
                badgeImages[3].sprite = badgeSprites[3];
                break;
        }
    }
}
