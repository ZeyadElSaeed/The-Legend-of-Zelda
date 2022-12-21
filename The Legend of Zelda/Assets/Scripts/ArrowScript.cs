using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ArrowScript : MonoBehaviour
{

    public GameObject hitParticle;

    public ParticleSystem trailParticle;
    public float radius = 2f;

    private void OnCollisionEnter(Collision collision)
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        foreach (Collider arrowed in colliders)
        {
            if (collision.gameObject.CompareTag("Bokoblin"))
            {
                collision.gameObject.GetComponent<Enemy>().TakeDamage(5);
                break;

            }
            else if (collision.gameObject.CompareTag("Moblin"))
            {
                collision.gameObject.GetComponent<Enemy>().TakeDamage(5);
                break;
            }
            else if (collision.gameObject.CompareTag("MawJLaygo"))
            {
                collision.gameObject.GetComponent<Fire>().TakeDamage(5);
                break;
            }
        }
        Instantiate(hitParticle, transform.position, Quaternion.identity);
        trailParticle.transform.parent = transform.parent;
        trailParticle.Stop();

        Camera.main.transform.DOComplete();
        Camera.main.transform.DOShakePosition(.4f, .5f, 20, 90, false, true);

        Destroy(gameObject);
    }
}
