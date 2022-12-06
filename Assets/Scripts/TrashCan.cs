using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCan : MonoBehaviour
{
    [SerializeField] TrashType trashType;
    [SerializeField] Transform detectionHeightMarker;
    [SerializeField] float detectionRadius = 1;
    [SerializeField] LayerMask collisionMask;
    [SerializeField] ParticleSystem particleSystem;

    public ScoreManager scoreManager;

    private void Update()
    {
        //RaycastHit[] hitArray = Physics.SphereCastAll(detectionHeightMarker.position, detectionRadius, Vector3.up, 0.01f, collisionMask);
        Collider[] colliderArray = Physics.OverlapSphere(detectionHeightMarker.position, detectionRadius, collisionMask);
        foreach(Collider hit in colliderArray)
        {
            IItem item = hit.GetComponent<Collider>().transform.root.GetComponent<IItem>();
            //if (item != null)
            //{

            //    print(hit.GetComponent<Collider>().name + " " +item.ToString());
            //}
            if (item != null && !item.IsInTrashCan())
            {
                if (item.GetTrashType().Equals(trashType))
                {
                    //print("trash can detected correct throw");
                    item.OnCorrectlyThrown();
                    scoreManager.OnScore(item.GetTrashType());
                    particleSystem.Play();
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

    void OnDrawGizmosSelected()
    {
        // Draw a semitransparent red cube at the transforms position
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawCube(detectionHeightMarker.position, new Vector3(detectionRadius, detectionRadius, detectionRadius));
    }
}
