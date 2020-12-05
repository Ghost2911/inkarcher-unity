using UnityEngine;
using System.Collections;

public class FireScript2D : MonoBehaviour
{ 
    public float speed = 10; 
    public Transform gunPoint; 
    public float fireRate = 1; 
    public bool facingRight = true;

    public Sprite defaultBow; //спрайт обычного состояния лука
    public Sprite chargedBow; //спрайт заряженного лука

    public Transform zRotate;
    public Rigidbody2D arrow;

    public int shootCount = 0;

    public AudioClip chargeSound;
    public AudioClip shotSound;

    private AudioSource audioSource;

    private float curTimeout, angle; //таймаут выстрела, поворот спрайта лука
    private int invert;
    private Vector3 mouse;

    private bool isPressed = false;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            if (!UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
            {
                Fire(arrow);
                shootCount++;
                GetComponent<SpriteRenderer>().sprite = defaultBow;
                audioSource.PlayOneShot(shotSound);
            }
        }

        else
        {
            curTimeout = 1000;
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (!UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
            {
                isPressed = true;
                GetComponent<SpriteRenderer>().sprite = chargedBow;
                audioSource.PlayOneShot(chargeSound);
            }
        }

        if (isPressed)
        {
            if (!UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
            {
                Vector2 target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector2 lookDir = target - (Vector2)transform.position;

                angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;

                transform.rotation = Quaternion.Euler(0, 0, angle);
            }
        }
    }

    void Fire(Rigidbody2D bullet)
    {
        curTimeout += Time.deltaTime;
        if (curTimeout > fireRate)
        {
            curTimeout = 0;
            Vector2 direction = gunPoint.position - transform.position;
            Rigidbody2D clone = Instantiate(bullet, gunPoint.position, Quaternion.identity) as Rigidbody2D;
            clone.transform.rotation = Quaternion.Euler(0, 0, angle);

            clone.AddForce(clone.transform.right*-10, ForceMode2D.Impulse);
        }
    }

    public int ShootCount()
    {
        return shootCount;
    }
}
