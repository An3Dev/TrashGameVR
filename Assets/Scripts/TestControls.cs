using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TestControls : MonoBehaviour
{

    public Spawner spawner;

    public Transform trash, rec, comp;

    float cooldown = 0.5f;
    float cooldownTimer = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        cooldownTimer += Time.deltaTime;
    }

    public void Trash(InputAction.CallbackContext action)
    {
        if (action.ReadValueAsButton() && cooldownTimer >= cooldown)
        {
            PutOverBin(spawner.GetLastObject(), trash);
            cooldownTimer = 0;
        }
    }

    public void Rec(InputAction.CallbackContext action)
    {
        if (action.ReadValueAsButton() && cooldownTimer >= cooldown)
        {
            PutOverBin(spawner.GetLastObject(), rec);
            cooldownTimer = 0;
        }
    }

    public void Comp(InputAction.CallbackContext action)
    {
        if (action.ReadValueAsButton() && cooldownTimer >= cooldown)
        {
            PutOverBin(spawner.GetLastObject(), comp);
            cooldownTimer = 0;
        }
    }

    void PutOverBin(GameObject obj, Transform bin)
    {
        obj.GetComponent<Rigidbody>().velocity = Vector3.zero;
        obj.transform.position = bin.transform.position;
        obj.transform.position += Vector3.up * 3;
    }
}
