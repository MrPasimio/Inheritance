using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Rigidbody2D rb;
    public SpriteRenderer sr;
    public BoxCollider2D boxCollider;

    public bool canAttack = true;
    public float attackDuration;
    public float attackRate;
    public float damage;


    // Start is called before the first frame update
    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
        
        sr = GetComponentInChildren<SpriteRenderer>();
        
        boxCollider = GetComponent<BoxCollider2D>();
        

        boxCollider.enabled = false;
        sr.enabled = false;
    }

    public virtual void Attack()
    {
        if (canAttack)
        {
            canAttack = false;
            sr.enabled = true;
            boxCollider.enabled = true;
            Invoke("DisableWeapon", attackDuration);
            Invoke("AttackReset", 60f / attackRate);
        }
    }

    public void DisableWeapon()
    {
        sr.enabled = false;
        boxCollider.enabled = false;
    }

    public void AttackReset()
    {
        canAttack = true;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Trigger!");
        if(collision.CompareTag("Enemy"))
        {
            Debug.Log("Enemy Hit!");
            collision.GetComponent<Enemy>().TakeDamage(damage);
        }
    }

}
