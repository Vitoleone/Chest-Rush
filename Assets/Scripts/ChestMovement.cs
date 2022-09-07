using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestMovement : MonoBehaviour
{
    private SwerweInput swerveInput;
    [SerializeField] private GameObject LeftBound;
    [SerializeField] private GameObject RightBound;
    private float leftBound;
    private float rightBound;
    
    [SerializeField] private float swerveSpeed = 0.5f;
    [SerializeField] private float maxSwervveAmount = 1f;

    private void Awake()
    {
        leftBound = LeftBound.transform.position.x;
        rightBound = RightBound.transform.position.x;
        
        swerveInput = GetComponent<SwerweInput>();
    }
    private void Start()
    {
        
    }
    private void Update()
    {
        float swerveAmount = swerveInput.MoveFactorX * Time.deltaTime * swerveSpeed;
        swerveAmount = Mathf.Clamp(swerveAmount, -maxSwervveAmount, maxSwervveAmount);
        if(GameManager.instance.hasGameStarted)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            transform.Translate(new Vector3(swerveAmount, 0, Vector3.forward.z * 5 * Time.deltaTime));
            if (transform.position.x <= LeftBound.transform.position.x + 0.65f)
            {
                transform.position = new Vector3(leftBound + 0.65f, transform.position.y, transform.position.z);
            }
            else if (transform.position.x >= RightBound.transform.position.x - 0.65f)
            {
                transform.position = new Vector3(rightBound - 0.65f, transform.position.y, transform.position.z);
            }
        }
        



    }
}
