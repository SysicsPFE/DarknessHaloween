using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shootable : MonoBehaviour
{
    public Rigidbody rb;
    public float speed;
    Vector3 direction;
    public GameObject particuleEffect;

    // Start is called before the first frame update
    private void FixedUpdate()
    {
        rb.velocity = direction * Time.deltaTime * speed;
    }
    private void OnEnable()
    {
        Destroy(gameObject, 2);
    }

    public void GetDirection(Vector3 dir)
    {
        direction = dir;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Ennemie")
        {
            EnnemieMovement e = other.GetComponent<EnnemieMovement>();
            e.GetDammage(5);
            GameObject obj = Instantiate(particuleEffect, transform.position, transform.rotation);
            Destroy(this.gameObject);
            Destroy(obj, 0.5f);
        }
    }
}
