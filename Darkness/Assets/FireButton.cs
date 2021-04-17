using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FireButton : MonoBehaviour
{
    public delegate void Onshoot(bool b);
    public static Onshoot onshoot;

    public Image FilledSprite;
    bool startAmount;
    public float speedAmount;
    public Button fireButton;
    // Start is called before the first frame update

    private void OnEnable()
    {
        onshoot += shootevent;
    }
    private void OnDisable()
    {
        onshoot -= shootevent;
    }

    private void Update()
    {
        if (startAmount)
        {
            FilledSprite.fillAmount += Time.deltaTime * speedAmount;
        }
    }

    void shootevent(bool b)
    {
        if (b==true)
        {
            FilledSprite.fillAmount = 0;
            startAmount = true;
            fireButton.interactable = false;
        }
        else
        {
            FilledSprite.fillAmount = 1;
            startAmount = false;
            fireButton.interactable = true;
        }
        
    }
}
