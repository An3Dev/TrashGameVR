using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCan : MonoBehaviour
{
    [SerializeField] TrashType trashType;
    [SerializeField] Transform detectionHeightMarker;
    [SerializeField] float detectionRadius = 1;
    [SerializeField] LayerMask collisionMask;

    private void Update()
    {
        RaycastHit[] hitArray = Physics.SphereCastAll(detectionHeightMarker.position, detectionRadius, Vector3.up, collisionMask);        
        
        foreach(RaycastHit hit in hitArray)
        {
            IItem item = hit.collider.GetComponent<IItem>();
            if (item != null)
            {
                if (item.GetTrashType().Equals(trashType))
                {
                    print("trash can detected correct throw");
                    item.OnCorrectlyThrown();
                }
                else
                {
                    item.OnIncorrectlyThrown();
                }
            }
        }

    }
}
