using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EX_Bullet : MonoBehaviour
{
    [Header("Effects")]
    public GameObject ShootParticle, HitParticle, MissParticle;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 3f);
        GameObject shootParticle = Instantiate(ShootParticle, transform.position - transform.forward*1.8f, transform.rotation);
        Destroy(shootParticle, 2f);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Target")
        {
            GameObject Particle = Instantiate(HitParticle, transform.position, transform.rotation);
            Destroy(Particle, 2f);
            print("Hit");
            // Destroy Target
            Destroy(collision.gameObject);
        }
        else
        {
            GameObject Particle = Instantiate(MissParticle, transform.position, transform.rotation);
            Destroy(Particle, 2f);
            print("Miss");
        }
        Destroy(gameObject);
    }
}
