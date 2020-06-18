using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundScript : MonoBehaviour
{
    [Header("Ground Properties And Behaviour")]
    [SerializeField] float destroyEveryThingWhichCollideGroundAfterCertainSeconds = 5f;





    void OnCollisionEnter2D(Collision2D colInfo)
    {
        if (!colInfo.gameObject.CompareTag("bullet")) 
        {
            Destroy(colInfo.gameObject, destroyEveryThingWhichCollideGroundAfterCertainSeconds);
        }
       
        Debug.Log("GroundScript : "+ colInfo.gameObject.name + ": hits the ground.");
    }


}
