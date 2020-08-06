using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretAI : MonoBehaviour
{
    public int turHealth = 100;
    public float distance;//giữa player - turret
    public float wakerange;
    public float shootinterval;//chu kì bắn
    public float bulletspeed = 5;
    public float bullettimer;
    public bool awake = false;
    public GameObject bullet;
    public Transform target;//lấy vị trí player
    public Animator anim;
    public Transform shootpointL, shootpointR;
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("Awake", awake);
        RangeCheck();
        if (turHealth < 0)
        {
            Destroy(gameObject);
        }
    }
    //kiểm tra range
    void RangeCheck()
    {
        distance = Vector2.Distance(transform.position, target.transform.position);
        if (distance < wakerange)
            awake = true;
        if (distance > wakerange)
            awake = false;
    }
    public void Attack(bool attackright)
    {
        bullettimer += Time.deltaTime;
        if(bullettimer >= shootinterval)//cho phép trụ bắn
        {
            Vector2 direction = target.transform.position - transform.position;//bắn khoảng ngắn từ trụ tới player
            direction.Normalize();
            if (attackright) //ShootPoint kiểm tra để bắn đạn
            {
                GameObject bulletclone;
                //khởi tạo bullet bắn player
                bulletclone = Instantiate(bullet, shootpointR.transform.position, shootpointR.transform.rotation) as GameObject;
                bulletclone.GetComponent<Rigidbody2D>().velocity = direction * bulletspeed;
                bullettimer = 0;
            }
            if (!attackright)
            {
                GameObject bulletclone;
                //khởi tạo bullet bắn player
                bulletclone = Instantiate(bullet, shootpointL.transform.position, shootpointL.transform.rotation) as GameObject;
                bulletclone.GetComponent<Rigidbody2D>().velocity = direction * bulletspeed;
                bullettimer = 0;
            }
        }
    }
    void Damage(int damage)
    {
        turHealth -= damage;
    }
}
