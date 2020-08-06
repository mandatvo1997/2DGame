using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (DoorScript.Instance != null)
            DoorScript.Instance.CollectablesCount++;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            if(DoorScript.Instance != null)
            DoorScript.Instance.DeCreamentCollectables();
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
