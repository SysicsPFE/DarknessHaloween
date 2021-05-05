using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
   
   
    
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.GetInt("use", 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void use(int i)
    {
        PlayerPrefs.GetInt("use", i);
        
    }
}
