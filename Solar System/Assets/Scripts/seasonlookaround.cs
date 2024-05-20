using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class seasonlookaround : MonoBehaviour
{
    public float sensitivity;
    float xRotation;
    float yRotation;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        xRotation -= Input.GetAxis("Mouse Y") * Time.deltaTime * sensitivity;
        yRotation += Input.GetAxis("Mouse X") * Time.deltaTime * sensitivity;
       // Debug.Log(Input.GetAxis("Mouse X") * Time.deltaTime * sensitivity);
        //yRotation = Mathf.Clamp(yRotation, -90f, 90f);       
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);             // to stop the player from looking above/below 90
      // to stop the player from looking above/below 90

        transform.localEulerAngles = new Vector3(xRotation,yRotation, 0f);    
        if (Input.GetKeyDown(KeyCode.E)) SceneManager.LoadScene("Solar System");
    }
}
