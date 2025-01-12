using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [Header("Enemy stats")]
    public int Hp = 100;

    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();    
    }

    public void Damage(int damageAmount)
    {
        Hp -= damageAmount;

        if(Hp <= 0)
        {
            anim.SetTrigger("die");
            StartCoroutine(DestroyEnemy());
        }
        else
        {
            anim.SetTrigger("damage");
        }
    }

    IEnumerator DestroyEnemy()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }

   
}
