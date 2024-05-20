using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jupiterrotate : MonoBehaviour
{
    private float SpinAngle;
    public float Speed;
    public float TiltAngle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    SpinAngle += Time.deltaTime * Speed;
    Quaternion rotationAboutAxis = Quaternion.Euler( 0, SpinAngle, 0);
    Quaternion tiltOfAxis = Quaternion.Euler(0, 0, TiltAngle);
    transform.rotation = tiltOfAxis * rotationAboutAxis ;
        
    }
}
