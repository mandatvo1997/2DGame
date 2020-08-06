using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerSpider : MonoBehaviour
{
    [SerializeField]
    private GameObject plane;
    // Use this for initialization
    void Start()
    {
        StartCoroutine(CreatePlane());
    }
    IEnumerator CreatePlane()
    {
        yield return new WaitForSeconds(2);
        Vector2 temp = transform.position;
        temp.y += Random.Range(-2, 2);
        Instantiate(plane, temp, this.transform.rotation);
        StartCoroutine(CreatePlane());
    }
}
