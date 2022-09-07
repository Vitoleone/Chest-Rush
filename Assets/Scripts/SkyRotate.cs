using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyRotate : MonoBehaviour
{
    [SerializeField] float rotateSpeed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.instance.hasGameStarted)
        {
            transform.Rotate(
                           Vector3.right * rotateSpeed * Time.deltaTime

                       ); ;
        }
       
        
    }
}
