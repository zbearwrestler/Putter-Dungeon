using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class Selectable : MonoBehaviour {
    Button button;
    Slider slider;
    Vector3 lastPointerPositon;

    // Use this for initialization
    void Start () {
        button = GetComponent<Button>();
        slider = GetComponent<Slider>();

        Debug.Log("Button: " + button + " Slider: " + slider);
        if (slider != null)
        {
            slider.onValueChanged.AddListener(delegate { OnSliderValueChange(); });
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (MenuScripts.instance.currentMouseOverGameObject == gameObject && Input.mousePosition != lastPointerPositon)
        {
            Debug.Log("Click");
            EventSystem.current.SetSelectedGameObject(gameObject);
        }
        lastPointerPositon = Input.mousePosition;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("OnPointerEnter Called");
        MenuScripts.instance.currentMouseOverGameObject = gameObject;
        EventSystem.current.SetSelectedGameObject(gameObject);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("OnPointerExit Called");
        MenuScripts.instance.currentMouseOverGameObject = null;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("OnPointerUp Called");
        // We only need this for buttons.
        if (button == null)
        {
            return;
        }

        // Set the selected game object in the event system to this button so
        // it works properly if we switch to the keyboard.
        MenuScripts.instance.currentButton = button;
        MenuScripts.instance.PlayClickSound();
    }

    /**
     * Play the 'tick' sound when we move a slider.
     */
    public void OnSliderValueChange()
    {
        Debug.Log("OnSliderValueChange Called");
        MenuScripts.instance.PlaySliderSound();
    }
}
