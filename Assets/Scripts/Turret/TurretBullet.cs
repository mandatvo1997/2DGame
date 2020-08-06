using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBullet : MonoBehaviour
{
    public float lifetime = 2;//đạn tồn tại 2s
    // Start is called before the first frame update
    void Start()
    {
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.isTrigger == false) //kiểm tra không va chạm collider khác
        {
            if(collision.CompareTag("Player"))
            {
                collision.SendMessageUpwards("Damage", 1);
            }
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        lifetime -= Time.deltaTime;
        if (lifetime <= 0)
            Destroy(gameObject);
    }
}
