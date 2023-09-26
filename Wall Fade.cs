using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallFade : MonoBehaviour
{
    [SerializeField] Transform cammera;
    [SerializeField] MeshRenderer wall;
    [SerializeField] float clipRange;

    void Update()
    {
        //finds the distance between the cammera and this instance of the wall
        float distance =
        Mathf.Sqrt(Mathf.Pow(cammera.position.x - transform.position.x, 2)
        + Mathf.Pow(cammera.position.z - transform.position.z, 2));

        //checks distance with clip range and disables it if necissary
        if (distance < clipRange)
        {
            wall.enabled = false;
        }
        else
        {
            wall.enabled = true;
        }
    }
}
