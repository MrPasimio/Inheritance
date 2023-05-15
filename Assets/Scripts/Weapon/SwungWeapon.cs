using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwungWeapon : Weapon
{
    public float arcRange;
    public float speed;


    public override void Attack()
    {
        if (canAttack)
        {
            canAttack = false;
            sr.enabled = true;
            boxCollider.enabled = true;
            transform.localEulerAngles = new Vector3(0, 0, -arcRange);
            StartCoroutine(Swing());
            Invoke("AttackReset", 60 / attackRate);
        }
    }

    public IEnumerator Swing()
    {
        Debug.Log("Starting Swing. Starting angle: " + transform.localEulerAngles.z);
        float degreesSwung = 0;
        while(degreesSwung < arcRange*2)
        {
            transform.Rotate(Vector3.forward, speed * Time.deltaTime);
            degreesSwung += speed * Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        DisableWeapon();
    }
}
