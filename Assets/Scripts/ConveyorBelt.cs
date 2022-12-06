using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBelt : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 5f;
    Rigidbody junk;
    void Start()
    {
        junk = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = junk.position;
        junk.position += -transform.forward * speed * Time.fixedDeltaTime;
        junk.MovePosition(position);

    }
}
