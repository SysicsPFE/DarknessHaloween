using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
public class EnnemieMovement : MonoBehaviour
{
    public NavMeshAgent agent;
     Transform target;

     float Health;
     float speed;
    Endposition endpos;
    WaveGenerator waveGenerator;

    public Image healthBar;

    float MaxHealth;

    public GameObject HealthDead;
    // Start is called before the first frame update

    public void InitAgent(float h,float s,Transform t,WaveGenerator _waveGenerator)
    {
        Health = h;
        MaxHealth = h;
        speed = s;
        agent.speed = s;
        endpos = t.GetComponent<Endposition>();
        target = endpos.thisTransform;
      
        agent.SetDestination(target.position);
        waveGenerator = _waveGenerator;
        StartCoroutine(VerifTarget());
    }

    public void GetNewPos(Transform t)
    {
        endpos = t.GetComponent<Endposition>();
        target = endpos.thisTransform;
        agent.SetDestination(target.position);


    }

    // Update is called once per frame
 
    IEnumerator VerifTarget()
    {
        yield return new WaitForSeconds(0.05f);
        if (endpos.HasEnnemie)
        {
            waveGenerator.SetNewPos(this);
            StartCoroutine(VerifTarget());
        }
        else
        {
            if (Vector3.Distance(target.position, transform.position) < 3f)
            {
                endpos.ChangeBehavior();
                gameObject.SetActive(false);

            }
            else
            {
                StartCoroutine(VerifTarget());
            }
        }
        
    }

    public void GetDammage(float dammage)
    {
        Health -= dammage;
        healthBar.fillAmount = Health / MaxHealth;
        if (Health==0)
        {
            HealthDead.SetActive(true);
            waveGenerator.EnnemieDown();
            Destroy(gameObject,0.1f);
            transform.tag = "Untagged";
        }
    }
}
