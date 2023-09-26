using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCScript : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] float speed;

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(new Vector3(Random.Range(-10f, 10f), 0, Random.Range(-10f, 10f)) * speed);
    }
}
