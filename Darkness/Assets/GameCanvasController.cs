using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameCanvasController : MonoBehaviour
{
    public GameObject GameWinPanel;
    public GameObject GameOverPanel;

    public GameObject PausePanel;
    public GameObject BG;

   public void gameWin()
    {
        Time.timeScale = 0;
        BG.SetActive(true);
        GameWinPanel.SetActive(true);
    }

    public void gameOver()
    {
        Time.timeScale = 0;
        BG.SetActive(true);
        GameOverPanel.SetActive(true);
    }

    public void Pause()
    {
        Time.timeScale = 0;
        BG.SetActive(true);
        PausePanel.SetActive(true);
    }

    public void Return()
    {
        Time.timeScale = 1;
        BG.SetActive(false);
        PausePanel.SetActive(false);
    }
}
