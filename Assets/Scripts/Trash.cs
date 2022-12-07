using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : MonoBehaviour, IItem
{
    public TrashType trashType;
    [SerializeField] Collider trashCollider;
    [SerializeField] ParticleSystem correctEffect, incorrectEffect;
    [SerializeField] ParticleSystem recycleEffect, trashEffect, compostEffect;
    [SerializeField] int points;


    bool isInTrashCan = false;

    public TrashType GetTrashType()
    {
        return trashType;
    }

    public bool IsInTrashCan()
    {
        return isInTrashCan;
    }

    public void OnCorrectlyThrown()
    {
        //print("Trash item knows it was correctly thrown");
        OnEnteredTrashCan();
    }

    public void OnIncorrectlyThrown()
    {
        //print("Trash item knows it was incorrectly thrown");
        OnEnteredTrashCan();
    }

    public void OnEnteredTrashCan()
    {
        isInTrashCan = true;
        trashCollider.enabled = false;
    }

    public void OnMissed()
    {
        missed = true;
    }

    bool missed = false;
    private void Update()
    {
        if (missed)
        {
            transform.localScale = transform.localScale - (Vector3.one * Time.deltaTime);
            if (transform.localScale.x < 0)
            {
                transform.gameObject.SetActive(false);
            }
        }
    }

}
