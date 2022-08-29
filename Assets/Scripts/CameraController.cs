using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] GameObject Chest;
    void Start()
    {
        
    }

    private void Update()
    {
        transform.position = new Vector3(Chest.transform.position.x, transform.position.y, Chest.transform.position.z-9f);
    }
    // Update is called once per frame
    
}
