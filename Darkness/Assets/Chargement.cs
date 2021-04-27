using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Chargement : MonoBehaviour
{
    private void OnEnable()
    {
        StartCoroutine(Load());
    }
    public void loadScene(int scene)
    {
        SceneManager.LoadSceneAsync(scene);

    }

    IEnumerator Load()
    {
        yield return new WaitForSeconds(7);
        loadScene(1);
    }
}
