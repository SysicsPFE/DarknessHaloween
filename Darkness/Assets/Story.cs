using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Story : MonoBehaviour
{
    public Text storyText;
    public string story;
    public float time;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WriteText());
    }

    IEnumerator WriteText()
    {
       
        for (int i = 0; i < story.Length; i++)
        {
            storyText.text += story[i];
            yield return new WaitForSeconds(time);
        }
    }

}
