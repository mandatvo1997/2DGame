using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsManager : MonoBehaviour
{
    public AudioClip bananas,chests, swords, destroy;

    public AudioSource adisrc;
    // Use this for initialization
    void Start()
    {
        bananas = Resources.Load<AudioClip>("Banana");
        chests = Resources.Load<AudioClip>("Chest");
        swords = Resources.Load<AudioClip>("Sword");
        destroy = Resources.Load<AudioClip>("Rock Crash");
        adisrc = GetComponent<AudioSource>();

    }

    public void Playsound(string clip)
    {
        switch (clip)
        {
            case "bananas":
                adisrc.clip = bananas;
                adisrc.PlayOneShot(bananas, 0.6f);
                break;
            case "chests":
                adisrc.clip = chests;
                adisrc.PlayOneShot(chests, 0.6f);
                break;

            case "destroy":
                adisrc.clip = destroy;
                adisrc.PlayOneShot(destroy, 1f);
                break;

            case "sword":
                adisrc.clip = swords;
                adisrc.PlayOneShot(swords, 1f);
                break;

        }
    }
}
