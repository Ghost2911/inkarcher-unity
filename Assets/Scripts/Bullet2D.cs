using UnityEngine;
using System.Collections;

public class Bullet2D : MonoBehaviour
{

    private Vector2 currPoint;
    private Vector2 prevPoint;
    private Vector2 currDir;

    private Rigidbody2D r;
    private AudioSource audioSource;

    public AudioClip audioIce;
    public AudioClip audioEnemy;
    public AudioClip audioBomb;
    public AudioClip audioHit;

    bool isMove = true;

    void Start()
    {
        r = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        Destroy(gameObject, 20);
        prevPoint = transform.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Возможно разнести по отдельным классам -> увеличение сложности редактирования
        if (isMove)
        {
            if (collision.gameObject.tag == "Enemy")
            {
                Destroy(collision.gameObject, 0.25f);
                collision.gameObject.GetComponent<Animator>().SetTrigger("isDead");
                audioSource.PlayOneShot(audioEnemy);
            }
            else if (collision.gameObject.tag == "Ground")
            {
                isMove = false;
                GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
                audioSource.PlayOneShot(audioHit);
            }
            else if (collision.gameObject.tag == "Default")
            {
                isMove = false;
                transform.SetParent(collision.gameObject.transform);
                Destroy(r);
                audioSource.PlayOneShot(audioHit);
            }
            else if (collision.gameObject.tag == "Ice")
            {
                Destroy(collision.gameObject, 0.25f);
                collision.gameObject.GetComponent<Animator>().SetTrigger("isDead");
                audioSource.PlayOneShot(audioIce);
            }
            else if (collision.gameObject.tag == "Bomb")
            {
                Destroy(collision.gameObject, 0.25f);
                collision.gameObject.GetComponent<Animator>().SetTrigger("isDead");
                collision.gameObject.GetComponent<ExplosionForce2D>().Explosion2D();
                audioSource.PlayOneShot(audioBomb);
            }
        }
    }

    void RotationChangeWhileFlying()
    {
        currPoint = transform.position;
        currDir = prevPoint - currPoint;
        currDir.Normalize();

        float rotationZ = Mathf.Atan2(currDir.y, currDir.x) * Mathf.Rad2Deg;
        Vector3 Vzero = Vector3.zero;

        transform.rotation = Quaternion.Euler(0, 0, rotationZ);

        prevPoint = currPoint;
    }

    private void Update()
    {
        if (isMove && Time.timeScale!=0)
            RotationChangeWhileFlying();
    }

}
