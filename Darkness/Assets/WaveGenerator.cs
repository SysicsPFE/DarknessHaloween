using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveGenerator : MonoBehaviour
{
    public Text WaveText;
    public List<Transform> StartPos;
    public List<Endposition> EndPos;

    public List<Wave> waves;

    Wave switchWave;
    int Nbennemie;

    [HideInInspector]
    public int WaveIndex;

    public List<EnnemieMovement> ennemieMovements;

    public GameObject Alert;

    public Text TextNbennemie;
    public Text Textcounter;
    private void Awake()
    {
        WaveIndex = 0;
    }

    void Start()
    {
        StartWave();
    }

    // Update is called once per frame
  

    void StartWave()
    {
        StartCoroutine(InstatnitateWave());
    }

    IEnumerator InstatnitateWave()
    {
        WaveText.text = "WAVE "+(WaveIndex+1);
        WaveText.gameObject.SetActive(true);

        yield return new WaitForSeconds(2);
        WaveText.gameObject.SetActive(false);
        Nbennemie = waves[WaveIndex].Nbennemie;
        TextNbennemie.text = Nbennemie.ToString();
        Textcounter.text = "0";
        for (int i = 0; i < waves[WaveIndex].Nbennemie; i++)
        {
            int S = Random.Range(0, StartPos.Count - 1);
            int E = Random.Range(0, EndPos.Count - 1);

            Transform Spos = StartPos[S];
            Transform Epos = EndPos[E].transform;


            GameObject obj = Instantiate(waves[WaveIndex].Ennemie[i], Spos.position, Quaternion.identity);
            EnnemieMovement ennemie = obj.GetComponent<EnnemieMovement>();
            ennemie.InitAgent(waves[WaveIndex].health, waves[WaveIndex].speed, Epos,this);
            ennemieMovements.Add(ennemie);
            yield return new WaitForSeconds(2);
        }
    }

    public void RemovePos(Endposition e)
    {
        Alert.SetActive(true);

        EndPos.Remove(e);
        Nbennemie--;
        VerifNbennemie();

    }

    public void EnnemieDown()
    {
        Nbennemie--;
        Textcounter.text = (int.Parse(Textcounter.text) + 1).ToString();
        VerifNbennemie();
    }
    void VerifNbennemie()
    {
        if (Nbennemie==0)
        {
            if (WaveIndex== waves.Count-1)
            {
                print("GameWin");
            }
            else
            {
                WaveIndex++;
                StartWave();
            }
            
            
        }
    }

    public void SetNewPos(EnnemieMovement e)
    {
        if (EndPos.Count==0)
        {
            print("GameOver");
            return;
        }
        int E = Random.Range(0, EndPos.Count - 1);

        
        Transform Epos = EndPos[E].transform;
        e.GetNewPos(Epos);
    }
}
