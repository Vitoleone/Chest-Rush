using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwerweInput : MonoBehaviour
{
    private float lastFingerPositionX;
    private float moveFactorX;
    public float MoveFactorX => moveFactorX;

    private void Update()
    {
        if(GameManager.instance.hasGameStarted)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("Girdi");
                lastFingerPositionX = Input.mousePosition.x;
            }
            else if (Input.GetMouseButton(0))
            {
                moveFactorX = Input.mousePosition.x - lastFingerPositionX;
                lastFingerPositionX = Input.mousePosition.x;
            }
            else if (Input.GetMouseButtonUp(0))
            {
                moveFactorX = 0;
            }
        }
       


    }
}
