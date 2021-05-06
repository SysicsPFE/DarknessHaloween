using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public float SoundVolume;
    public float EffectVolume;



    private void Start()
    {
       
    }
    #region SINGLETON PATTERN
    public static SoundController instance;
    
    #endregion

    private void Awake()
    {
        
            // if the singleton hasn't been initialized yet
            if (instance != null && instance != this)
            {
                Destroy(this.gameObject);
                return;//Avoid doing anything else
            }

            instance = this;
            DontDestroyOnLoad(this.gameObject);
        if (PlayerPrefs.HasKey("effect"))
        {
            EffectVolume = PlayerPrefs.GetFloat("effect");
            SoundVolume = PlayerPrefs.GetFloat("sound");
            MainGameSound.volume = SoundVolume;

        }
        else
        {
            PlayerPrefs.SetFloat("effect", 1);
            SoundVolume = 0.5f;
            MainGameSound.volume = SoundVolume;
            EffectVolume = 1;
            PlayerPrefs.SetFloat("sound", 0.5f);
        }

    }

    public AudioSource MainGameSound;

    public void ChangeEffectVolume(float f)
    {
        EffectVolume = f;
        PlayerPrefs.SetFloat("effect", EffectVolume);
    }

    public void ChangeSoundVolume(float f)
    {
        SoundVolume = f;
        MainGameSound.volume = f;
        PlayerPrefs.SetFloat("sound", SoundVolume);
    }
}
