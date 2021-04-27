using UnityEngine;

public class Collision_of_streetcaar : MonoBehaviour
{
    public TranlationMover tranlationMover;

    void OnCollisionEnter (Collision collision)
    {
        if (collision.collider.tag == "People")
        {
            Debug.Log("Hit!");
        }
    }
}
