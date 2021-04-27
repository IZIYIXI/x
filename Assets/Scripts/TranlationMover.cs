using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;
using PathCreation;

public class TranlationMover : MonoBehaviour
{
    public PathCreator pathCreator;

    public GameObject turnPoint;
    public GameObject straightEndPoint;
    public GameObject curveEndPoint;

    Transform[] Points = new Transform[2];

    private int targetPointID = 0;
    public float speed = 5f;
    public float distanceTravelled = 0f;
    private float targetDistance;
    //public bool railsTurn = false;
    public RaillsRotation raillsRotation; //в самом Unity перетащил скрипт к которому (смотри в свойствах этого скрипта у направляющих рельсов)
    private bool shouldMove = true;
    private bool hasTurned = false;

    // Start is called before the first frame update
    void Start()
    {
        Points[0] = turnPoint.transform;
        Points[1] = straightEndPoint.transform;
    }

    void Update()
    {
        //if (targetPointID < 1)
        //{
        //    if (hasPassedTurnPoint != raillsRotation.railsTurn)
        //    {
        //        hasPassedTurnPoint = raillsRotation.railsTurn;
        //    }
        //}

        if (shouldMove)
        {
            if (!hasTurned)
            {
                Points[1] = straightEndPoint.transform;
                targetDistance = Vector3.Distance(transform.position, Points[targetPointID].position);
                transform.Translate(Vector3.Normalize(Points[targetPointID].position - transform.position) * Time.deltaTime * speed);
                if (targetDistance < 0.5f)
                {
                    if ((targetPointID == 0) && (raillsRotation.railsTurn))
                    {
                        hasTurned = true;
                    }
                    if (targetPointID < Points.Length - 1)
                    {
                        targetPointID++;
                    }
                    else
                    {
                        shouldMove = false;
                    }
                }
            }
            else
            {
                Points[1] = curveEndPoint.transform;
                distanceTravelled += speed * Time.deltaTime;  //движение по кривой Безье
                transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled);
                transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled);
                targetDistance = Vector3.Distance(transform.position, Points[targetPointID].position);
                if (targetDistance < 0.5f)
                {
                    shouldMove = false;
                }
            }
        }



        //if (kostyl == false)
        //{
        //    float distance = Vector3.Distance(target_Pos, transform.position);
        //    target_Pos = Points[pointID].transform.position;
        //    transform.Translate(Vector3.Normalize(target_Pos - transform.position) * Time.deltaTime * speed);

        //    if (distance < 0.5f)
        //    {
        //        if (pointID < Points.Length - 1)
        //        {
        //            pointID++;
        //        }
        //        else
        //        {
        //            Destroy(gameObject);
        //        }
        //    }
        //}

        //if ((shouldTurn == true)&&(pointID==1))
        //{
        //    kostyl = true;
        //    distanceTravelled += speed * Time.deltaTime;  //движение по кривой Безье
        //    transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled);
        //    transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled);
        //}
        //else
        //{
        //    target_Pos = Points[pointID].transform.position;
        //    transform.Translate(Vector3.Normalize(target_Pos - transform.position) * Time.deltaTime * speed);
        //}
    }
    // Update is called once per frame
    /*void FixedUpdate() //поворот
    {
        Quaternion rotationY = Quaternion.AngleAxis(1, Vector3.up);
        transform.rotation *= rotationY;
    }*/
}
