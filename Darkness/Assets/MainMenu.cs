using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MainMenu : MonoBehaviour
{
    public Slider VolumeSound;
    public Slider VolumeEffect;
    private void Start()
    {
        VolumeSound.value = SoundController.instance.SoundVolume;
        VolumeEffect.value = SoundController.instance.EffectVolume;
    }
    public void LoadScene(int scene)
    {
        SceneManager.LoadSceneAsync(scene);
    }

    public void ChangeSoundVolume(Slider s)
    {
        SoundController.instance.ChangeSoundVolume(s.value);
    }

    public void ChangeEffectVolume(Slider s)
    {
        SoundController.instance.ChangeEffectVolume(s.value);

    }
}
