using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    public ScoreManager scoreManager;

    List<GameObject> objects = new List<GameObject>();

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.transform.root.GetComponent<IItem>() != null)
        {
            // make sure that there are not double triggers for the same object hitting the floor more than once.
            foreach(GameObject go in objects)
            {
                if (GameObject.ReferenceEquals(collision.collider.gameObject, go))
                {
                    return;
                }
            }
            objects.Add(collision.collider.gameObject);
            scoreManager.OnMissOccurs();
            collision.collider.transform.root.GetComponent<IItem>().OnMissed();
        }
    }
}
