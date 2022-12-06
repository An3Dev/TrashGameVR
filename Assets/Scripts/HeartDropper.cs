using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartDropper : MonoBehaviour
{
    public List<GameObject> hearts;
    int i = 0;
    [SerializeField] ParticleSystem heartEffect;

    public void Drop()
    {
        if (i == hearts.Count)
        {
            return;
        }
        GameObject heart = hearts[hearts.Count - 1 - i];
        i++;
        heart.SetActive(false);
        heartEffect.transform.position = heart.transform.position;
        heartEffect.Play();

        //Rigidbody rb = heart.GetComponent<Rigidbody>();
        //rb.isKinematic = false;
        //rb.AddTorque(Vector3.right * Random.Range(-50, 50));
        //rb.AddForce(Vector3.down * 350);
    }
}
