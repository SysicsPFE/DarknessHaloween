using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Wave")]
public class Wave : ScriptableObject
{
    public List <GameObject> Ennemie;
    public float speed;
    public float health;
    public int Nbennemie;

    [HideInInspector]
    public int increment;

    public void ResatWave()
    {
        increment = 0;
    }

}
 