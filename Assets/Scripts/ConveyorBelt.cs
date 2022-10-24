using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBelt : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 5f;
    Rigidbody belt;
    void Start()
    {
        belt = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = belt.position;
        belt.position += -transform.forward * speed * Time.fixedDeltaTime;
        belt.MovePosition(position);

    }
}
