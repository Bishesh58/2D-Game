using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunMovingScript : MonoBehaviour
{

    private Vector3 sunPositionA;

    private Vector3 sunPositionB;

    private Vector3 nexPos;


    [SerializeField]
    private float sunSpeed;



    [SerializeField]
    private Transform childTransform;

    [SerializeField]
    private Transform transformB;

    // Start is called before the first frame update
    void Start()
    {

        sunPositionA = childTransform.localPosition;
        sunPositionB = transformB.localPosition;
        nexPos = sunPositionB;
            
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        childTransform.localPosition = Vector3.MoveTowards(childTransform.localPosition, nexPos, sunSpeed * Time.deltaTime);

        if (Vector3.Distance(childTransform.localPosition, nexPos) <= 0.1)
        {

            ChangeDestination();
        }
    }

    private void ChangeDestination()
    {

        nexPos = nexPos != sunPositionA ? sunPositionA : sunPositionB;
    }
}
