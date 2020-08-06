using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCone : MonoBehaviour
{
    public TurretAI turret;
    public bool isLeft = false; // nếu player bên phải thì isLeft = false
    // Start is called before the first frame update
    private void Awake()
    {
        turret = gameObject.GetComponentInParent<TurretAI>();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            //tấn công tay trái
            if (isLeft)
                turret.Attack(false);
            //tấn công tay phải
            else
                turret.Attack(true);
        }
    }
}
