using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
            Debug.Log("hit enemy");

            collision.gameObject.GetComponent<EnemyHealth>().Damage(100);

            Destroy(gameObject);
        }

        if (collision.gameObject)
        {
            Debug.Log(collision.collider.gameObject.name);
            Destroy(gameObject);
        }
    }
}
