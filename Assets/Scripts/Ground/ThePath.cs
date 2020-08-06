using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThePath : MonoBehaviour {
    private int startAt = 0;
    private int directionMove = 1;
    public Transform[] listPoint;
    // Use this for initialization
    public void OnDrawGizmos()
    {
        if (listPoint == null || listPoint.Length < 2)
            return;
        for (int i = 1; i < listPoint.Length; i++)
        {
            Gizmos.DrawLine(listPoint[i - 1].position, listPoint[i].position);
        }
    }
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public Transform getPointAt(int p)
    {
        return listPoint[p];
    }
    public Transform getNextPoint()
    {
        if (startAt == 0)
            directionMove = 1;
        else if (startAt == listPoint.Length - 1)
            directionMove = -1;
        startAt += directionMove;
        return listPoint[startAt];
    }
}
