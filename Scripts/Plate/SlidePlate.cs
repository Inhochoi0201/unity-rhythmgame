using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidePlate : MonoBehaviour
{


    [SerializeField] Transform startPos;
    [SerializeField] Transform endPos;
    
    [SerializeField] float plateSpeed = 3;

    int chk = 0;
    bool isDone = false;


    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if(chk==0) transform.position = startPos.position;
            if (other.transform.position.x == this.transform.position.x && other.transform.position.z == this.transform.position.z)
            {
                if (chk == 0)
                {
                    other.transform.SetParent(transform);
                    chk++;
                    StartCoroutine(SlidePlateCo());
                }
                if (isDone)
                {
                    other.transform.SetParent(null);
                }
            }
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (transform.position == endPos.position)
            {
                transform.position = startPos.position;
                chk = 0;
                isDone = false;
            }
        }
    }


    IEnumerator SlidePlateCo()
    {
        while (Vector3.SqrMagnitude(transform.position - endPos.position) >= 0.001f)
        {
            transform.position = Vector3.Lerp(transform.position, endPos.position, Time.deltaTime * plateSpeed);
            yield return null;
        }

        transform.position = endPos.position;
        isDone = true;
    }

}
