using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    [Header("Bullet Properties")]
    [SerializeField] float releaseTime = 0.15f;
    [SerializeField] Rigidbody2D rigidbody2D;
    [SerializeField] PolygonCollider2D polyCollider2D;
    [SerializeField] Rigidbody2D hook;
    [SerializeField] float maximumDistance = 2f;
    [SerializeField] float averageTimeInSecondBetweenBulletReleaseAndItsDestruction = 2f;


    
    public bool isBulletReleased = false;
    private bool isPressed = false;


    void Update()
    {
        MakingRadiousForBullet();
    }





    void OnMouseDown()
    {
        isPressed = true;
        rigidbody2D.isKinematic = true;
        polyCollider2D.enabled = false;
    }



    void OnMouseUp()
    { 
        isPressed = false;
        rigidbody2D.isKinematic = false;
        StartCoroutine(Release());
    }


    IEnumerator Release()
    {
        yield return new WaitForSeconds(releaseTime);
        GetComponent<SpringJoint2D>().enabled = false;
        polyCollider2D.enabled = true;
        this.enabled = false;
        StartCoroutine(IsBulletReleasedEnabledAfterCertainSecondsCoroutine());
    }


    IEnumerator IsBulletReleasedEnabledAfterCertainSecondsCoroutine() 
    {
        yield return new WaitForSeconds(averageTimeInSecondBetweenBulletReleaseAndItsDestruction);
        isBulletReleased = true;
    }



    private void MakingRadiousForBullet()
    {
        if (isPressed)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (Vector3.Distance(mousePos, hook.position) > maximumDistance)
            {
                if (rigidbody2D)
                {
                    // linear line formula
                    rigidbody2D.position = hook.position + (mousePos - hook.position).normalized * maximumDistance;
                }
            }
            else
            {
                if (rigidbody2D)
                {
                    rigidbody2D.position = mousePos;
                }
            }
        }
    }













}
