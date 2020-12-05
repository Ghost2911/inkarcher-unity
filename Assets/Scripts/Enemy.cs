using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D r;
    private AudioSource audioSource;

    void Start()
    {
        r = GetComponent<Rigidbody2D>();
        audioSource =  GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag != "Jumper" && collision.relativeVelocity.magnitude > 6)
        {
            Destroy(gameObject, 0.25f);
            GetComponent<Animator>().SetTrigger("isDead");
            audioSource.Play();
        }
    }
}
