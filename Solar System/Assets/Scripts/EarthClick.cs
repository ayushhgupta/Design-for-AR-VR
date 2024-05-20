using UnityEngine;
using UnityEngine.UI;
 
public class EarthClick : MonoBehaviour {
 
    public Image image;
 
    void Start() {
        // Turns the image off.
        image.enabled = false;
    }
 
    void KeyDownEvent() {
        // Turns the image on if it is off, and off if it is on.
        image.enabled = !image.enabled;
    }
}