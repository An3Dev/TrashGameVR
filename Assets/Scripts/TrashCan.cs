using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCan : MonoBehaviour
{
    [SerializeField] TrashType trashType;
    [SerializeField] Transform detectionHeightMarker;
    [SerializeField] float detectionRadius = 1;
    [SerializeField] LayerMask collisionMask;

    public ScoreManager scoreManager;

    private void Update()
    {
        RaycastHit[] hitArray = Physics.SphereCastAll(detectionHeightMarker.position, detectionRadius, Vector3.up, collisionMask);        
        
        foreach(RaycastHit hit in hitArray)
        {
            IItem item = hit.collider.transform.root.GetComponent<IItem>();
            if (item != null && !item.IsInTrashCan())
            {
                if (item.GetTrashType().Equals(trashType))
                {
                    //print("trash can detected correct throw");
                    item.OnCorrectlyThrown();
                    scoreManager.OnScore(item.GetTrashType());
                }
                else
                {
                    //print("trash can incorrect");
                    item.OnIncorrectlyThrown();
                    scoreManager.OnIncorrect(item.GetTrashType(), this.trashType);
                }
            }
        }

    }
}
