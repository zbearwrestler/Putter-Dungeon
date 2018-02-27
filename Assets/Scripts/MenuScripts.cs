using UnityEngine;
using System.Collections;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MenuScripts : MonoBehaviour {

    public AudioMixer mixer;
    public static MenuScripts instance;
    public GameObject[] panels;
    public int currentid;
    
    public AudioClip sliderSound;
    public AudioClip clickSound;

    [HideInInspector]
    public GameObject currentMouseOverGameObject;

    [HideInInspector]
    public Button currentButton;

    // Use this for initialization
    void Start () {
	
	}

    void Awake()
    {
        instance = this;
    }

    public void PlayClickSound()
    {
        GetComponent<AudioSource>().clip = clickSound;
        GetComponent<AudioSource>().Play();
    }

    public void PlaySliderSound()
    {
        GetComponent<AudioSource>().clip = sliderSound;
        GetComponent<AudioSource>().Play();
    }

    public void SwitchMenu (int id)
    {
        panels[id].SetActive(true);
        panels[currentid].SetActive(false);
        currentid = id;
        Debug.Log("New id of " + id);
    }

    public void SetMusicVolume(float value)
    {
        mixer.SetFloat("MusicVolume", ConvertToDecibel(value));
    }
    public void SetSoundEffectsVolume(float value)
    {
        mixer.SetFloat("SoundEffectsVolume", ConvertToDecibel(value));
    }
    public void SetMasterVolume(float value)
    {
        mixer.SetFloat("MasterVolume", ConvertToDecibel(value));
    }

    public float ConvertToDecibel(float value)
    {
        // Log(0) is undefined so we just set it by default to -80 decibels
        // which is 0 volume in the audio mixer.
        float decibel = -80f;

        // I think the correct formula is Mathf.Log10(value / 100f) * 20f.
        // Using that yields -6dB at 50% on the slider which is I think is half
        // volume, but I don't feel like it sounds like half volume. :p And I also
        // felt this homemade formula sounds more natural/linear when you go towards 0.
        // Note: We use 0-100 for our volume sliders in the menu, hence the
        // divide by 100 in the equation. If you use 0-1 instead you would remove that.
        if (value > 0)
        {
            decibel = Mathf.Log(value / 100f) * 17f;
        }

        return decibel;
    }

    public void BeginGame()
    {
        Debug.Log("Begin Game Called");
        Application.LoadLevel(1);
    }
    public void Quit()
    {
#if UNITY_STANDALONE
        //Quit the application
        Application.Quit();
#endif

        //If we are running in the editor
#if UNITY_EDITOR
        //Stop playing the scene
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
