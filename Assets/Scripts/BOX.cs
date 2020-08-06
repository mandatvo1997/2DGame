using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOX : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip BoxSound;
    public int Health = 100;
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Health <= 0)
        {
            audioSource.PlayOneShot(BoxSound);
            Destroy(gameObject);            
        }
    }
    void Damage(int damage)
    {
        Health -= damage;   
    }
}
