using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaillsRotation : MonoBehaviour
{
    public int frame = 0;
    public bool railsTurn = false; // false -- прямо, true -- налево
    private bool turnLeft = false;
    //private bool action = false;
    public TranlationMover tranlationMover; //в самом Unity перетащил скрипт к которому (смотри в свойствах этого скрипта у направляющих рельсов)
    private bool currentShouldTurn;
    // Start is called before the first frame update
    
    
    void Start()
    {
        //RaillsRotation x = streetcar.Find("TranlationMover").GetComponent(typeof(RaillsRotation)).shouldTurn;
        currentShouldTurn = railsTurn;
    }

    // Update is called once per frame
    void FixedUpdate() //поворот
    {
        if(railsTurn != turnLeft/*currentShouldTurn*/)
        {
            /*if((canTurn==true)) // не знаю, надо ли париться с тем, нужно ли делать проверки на тот промежуток времени, когда идет переброс направляющих на другую сторону, если вдруг изменится в это время shouldTurn
            {

            }*/
            if (frame < 6)
            {
                if (turnLeft)
                {
                    Quaternion rotationY = Quaternion.AngleAxis(0.1f, Vector3.up);
                    transform.rotation *= rotationY;
                    frame++;
                    if (frame == 6)
                    {
                        turnLeft = false;
                        frame = 0;
                    }
                }
                else
                {
                    Quaternion rotationY = Quaternion.AngleAxis(0.1f, Vector3.down);
                    transform.rotation *= rotationY;
                    frame++;
                    if (frame == 6)
                    {
                        turnLeft = true;
                        frame = 0;
                    }
                }

                //switch (left)
                //{
                //    case false:
                //        {
                //            Quaternion rotationY = Quaternion.AngleAxis(0.1f, Vector3.down);
                //            transform.rotation *= rotationY;
                //            frame++;
                //            if (frame == 6)
                //            {
                //                left = true;
                //                frame = 0;
                //            }
                //            break;
                //        }
                //    case true:
                //        {
                //            Quaternion rotationY = Quaternion.AngleAxis(0.1f, Vector3.up);
                //            transform.rotation *= rotationY;
                //            frame++;
                //            if (frame == 6)
                //            {
                //                left = false;
                //                frame = 0;
                //            }
                //            break;
                //        }
                //    default:
                //        {

                //            break;
                //        }
                //}
            }
        }
        
        
        /*else
        {
            if (left == false)
            {
                left = true;
                frame = 0;
            }
            else
            {
                left = true;
                frame = 0;
            }
        }*/
    }
}
