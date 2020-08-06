using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonShoot : MonoBehaviour {
    [SerializeField]
    private GameObject bullet;
    // Use this for initialization
    void Start () {
        StartCoroutine(Attack());
    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator Attack()
    {
        yield return new WaitForSeconds(Random.Range(2, 5));
        Instantiate(bullet, transform.position, Quaternion.identity);
        StartCoroutine(Attack());
    }
    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.isTrigger == false) //kiểm tra không va chạm collider khác
        {
            if (target.CompareTag("Player"))
            {
                target.SendMessageUpwards("Damage", 5);
            }
            Destroy(gameObject);
        }
    }
}
