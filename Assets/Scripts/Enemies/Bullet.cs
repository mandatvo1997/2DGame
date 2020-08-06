using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

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

        if (target.tag == "Ground")
        {
            Destroy(gameObject);
        }
    }
}
