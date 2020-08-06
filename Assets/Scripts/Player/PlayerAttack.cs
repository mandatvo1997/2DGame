using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip AttackSound;
    public float attackdelay = 0.3f;
    public bool attacking = false;
    public Animator anim;
    public Collider2D trigger;
    private void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
        // tắt trigger Collider
        trigger.enabled = false;
        audioSource = GetComponent<AudioSource>();
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z) && !attacking)
        {
            attacking = true;
            //mở trigger
            trigger.enabled = true;
            attackdelay = 0.3f;
            audioSource.PlayOneShot(AttackSound);
        }
        //delay Tấn công 
        if (attacking)
        {
            if (attackdelay > 0)
            {
                attackdelay -= Time.deltaTime; // Time.deltaTime giúp game chạy theo thời gian thật không bị ảnh hưởng bởi frame
            }
            else
            {
                attacking = false;
                trigger.enabled = false;
            }
        }
        anim.SetBool("Attacking", attacking);
    }
}
