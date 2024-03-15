using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileScript : MonoBehaviour
{
    public Vector3 targetPostition;
    private Vector3 correctPosition;
    public int number;
    public bool inRightPlace;
    void Awake()
    {
        targetPostition = transform.position;
        correctPosition = transform.position;
    }

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, targetPostition, 0.05f);

        if(targetPostition == correctPosition)
        {
            inRightPlace = true;   
        }
        else
        {
            inRightPlace = false;
        }
    }
}
