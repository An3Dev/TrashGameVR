using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCanMover : MonoBehaviour
{
    [SerializeField] Spawner spawner;

    [SerializeField] int moveTrashCansAfterThisManySpawns = 5;
    float minSpeed = 0, maxSpeed = 1.5f;
    [SerializeField] float minChangeDirTime = 1, maxChangeDirTime = 10;

    float lastChangeDirTime = 0;
    float changeDirTime = 0;


    [SerializeField] Transform maxAnchor, minAnchor;
    [SerializeField] Rigidbody[] trashCanRigidbodies;

    IEnumerator moveCoroutine;


    //public Transform trashCans;

    bool isMoving = false;

    private void Update()
    {
        if (!isMoving && spawner.GetTotalSpawns() > moveTrashCansAfterThisManySpawns)
        {
            isMoving = true;
        }

        if (isMoving)
        {
            MoveTrashCans();
 
        }
    }

    void MoveTrashCans()
    {
        // signs are inverted because going away from player makes the num more negative
        if (trashCanRigidbodies[0].position.x <= maxAnchor.position.x)
        {
            if (trashCanRigidbodies[0].velocity.x < 0)
            {
                Debug.Log("< max");

                foreach (Rigidbody rb in trashCanRigidbodies)
                {

                    rb.velocity = Vector3.zero;
                }
            }
            
        }
        else if (trashCanRigidbodies[0].position.x >= minAnchor.position.x)
        {
            if (trashCanRigidbodies[0].velocity.x > 0)
            {
                Debug.Log("> min");
                foreach (Rigidbody rb in trashCanRigidbodies)
                {
                    rb.velocity = Vector3.zero;
                }
            }
        }
        
        if (Time.time - lastChangeDirTime > changeDirTime)
        {
            Debug.Log("change dir " + Time.time + " - " + lastChangeDirTime + " > " + changeDirTime);
            // change dir
            float randomVel = Random.Range(minSpeed, maxSpeed);
            if (trashCanRigidbodies[0].position.x <= maxAnchor.position.x)
            {
                randomVel = randomVel * 1;
            }
            else if (trashCanRigidbodies[0].position.x >= minAnchor.position.x)
            {
                randomVel = randomVel * -1;
            }

            changeDirTime = Random.Range(minChangeDirTime, maxChangeDirTime);
            //if (moveCoroutine != null) StopCoroutine(moveCoroutine);
            moveCoroutine = Move(changeDirTime, randomVel);
            StartCoroutine(moveCoroutine);

            lastChangeDirTime = Time.time;
        }
    }

    WaitForEndOfFrame waitEndOfFrame = new WaitForEndOfFrame();
    IEnumerator Move(float time, float speed)
    {
        float currTime = 0;

        float newSpeed = 0;
        while(currTime < time)
        {
            //Debug.Log(time);
            yield return new WaitForSeconds(Time.deltaTime);
            //Debug.Log("After: " + currTime);
            currTime += Time.deltaTime;

            if (currTime < time/ 3f)
            {
                newSpeed = Mathf.Lerp(0, speed, currTime / (time / 3f));
            }
            else if (currTime > time * 2 / 3f)
            {
                newSpeed = Mathf.Lerp(speed, 0, (time * 2 / 3f) / time);
                Debug.Log("Slow down");
            }

            foreach (Rigidbody rb in trashCanRigidbodies)
            {
                rb.velocity = new Vector3(newSpeed, 0, 0);
            }
        }
        
    }

}
