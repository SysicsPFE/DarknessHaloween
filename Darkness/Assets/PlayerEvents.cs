using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEvents : MonoBehaviour
{
    public Transform ShootPos;
    public GameObject ShootPrefab;
    public Animator anim;
    public bool canRotate;
    public List<GameObject> armes;
    public AudioSource walkaudio;
    void Start()
    {
        armes[PlayerPrefs.GetInt("use", 0)].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Onclick();

        }
    }

    public void Shoot()
    {
        GameObject obj = Instantiate(ShootPrefab, ShootPos.transform.position, Quaternion.identity);
        obj.GetComponent<Shootable>().GetDirection(transform.forward);
    }

    public void Onclick()
    {
        anim.SetTrigger("isAttack");
    }

    public void SwitchButtonTrue()
    {
        if (FireButton.onshoot!=null)
        {
            FireButton.onshoot(true);
        }
        canRotate = false;


    }

    public void SwitchButtonFalse()
    {
        if (FireButton.onshoot != null)
        {
            FireButton.onshoot(false);
        }
        canRotate = true;

    }

    public void Walk()
    {
        walkaudio.volume = SoundController.instance.EffectVolume;
        walkaudio.Play();
    }

}
