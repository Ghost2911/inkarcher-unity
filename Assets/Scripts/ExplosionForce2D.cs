using System.Collections;
using UnityEngine;

public class ExplosionForce2D : MonoBehaviour
{

    private enum Mode { simple, adaptive }
    [SerializeField] private Mode mode;
    [SerializeField] private float radius;
    [SerializeField] private float power;
    [SerializeField] private LayerMask layerMask;

    public void Explosion2D()
    {
        Vector3 position = transform.position;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(position, radius, layerMask);

        foreach (Collider2D hit in colliders)
        {
            if (hit.attachedRigidbody != null)
            {
                Vector3 direction = hit.transform.position - position;
                direction.z = 0;

                if (CanUse(position, hit.attachedRigidbody))
                {
                    if (hit.tag == "Ice")
                    {
                        Destroy(hit.gameObject, 0.25f);
                        hit.GetComponent<Animator>().SetTrigger("isDead");
                    }

                    hit.attachedRigidbody.AddForce(direction.normalized * power);
                }
            }
        }
    }

    bool CanUse(Vector3 position, Rigidbody2D body)
    {
        if (mode == Mode.simple) return true;

        RaycastHit2D hit = Physics2D.Linecast(position, body.position);

        if (hit.rigidbody != null && hit.rigidbody == body)
        {
            return true;
        }

        return false;
    }
}