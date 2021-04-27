using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Endposition : MonoBehaviour
{
    public GameObject EnnemieObj;

    public Transform thisTransform;
    public bool HasEnnemie;

    public GameObject sprite;

    public WaveGenerator waveGenerator;
    // Start is called before the first frame update
    
    public void ChangeBehavior()
    {
        HasEnnemie = true;
        waveGenerator.RemovePos(this);
        EnnemieObj.SetActive(true);
        sprite.SetActive(false);
    }
}
