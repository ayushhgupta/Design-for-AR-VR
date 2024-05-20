using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LookAtTarget : MonoBehaviour {

    [Tooltip("This is the object that the script's game object will look at by default")]
    public GameObject defaultTarget; // the default target that the camera should look at
    public float smoothness;
    public float speed;
    public GameObject dup;
    [Tooltip("This is the object that the script's game object is currently look at based on the player clicking on a gameObject")]
    public GameObject newTarget;
    public GameObject currentTarget; // the target that the camera should look at
    private Vector3 cameraPosition;
    [SerializeField] float sensitivity;
    public GameObject text;
    float xRotation;
    float yRotation;
    private double radius;
    public float scale;
    private Image image;

    public float y_scale;
    private Vector3 gaze_shift;
    public void MoveCamera()
    {
        
        radius = scale*0.5*(float)currentTarget.transform.localScale.x;
        Debug.Log ("radius" + radius); 
        Vector3 newPos = new Vector3(currentTarget.transform.position.x, currentTarget.transform.position.y, currentTarget.transform.position.z - (float)radius);
        transform.position = newPos;
            
        xRotation -= Input.GetAxis("Mouse Y") * Time.deltaTime * sensitivity;
        yRotation += Input.GetAxis("Mouse X") * Time.deltaTime * sensitivity;
        Debug.Log(Input.GetAxis("Mouse X") * Time.deltaTime * sensitivity);
        //yRotation = Mathf.Clamp(yRotation, -90f, 90f);       
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);             // to stop the player from looking above/below 90
      // to stop the player from looking above/below 90

        transform.localEulerAngles = new Vector3(xRotation,yRotation, 0f);            
        
    }

    // Start happens once at the beginning of playing. This is a great place to setup the behavior for this gameObject
	void Start () {
		if (defaultTarget == null) 
		{
            defaultTarget = this.gameObject;
			Debug.Log ("defaultTarget target not specified. Defaulting to parent GameObject");
		}

        if (currentTarget == null)
        {
            currentTarget = this.gameObject;
            Debug.Log("currentTarget target not specified. Defaulting to parent GameObject");
        }
        MoveCamera();
    }
	
	// Update is called once per frame
    // For clarity, Update happens constantly as your game is running
    void Update()
    {
        MoveCamera();
        // if primary mouse button is pressed
        if (Input.GetKey("space"))
        {
            // determine the ray from the camera to the mousePosition
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            // cast a ray to see if it hits any gameObjects
            RaycastHit[] hits;
            hits = Physics.RaycastAll(ray);

            // if there are hits
            if (hits.Length>0)
            {
                // get the first object hit
                RaycastHit hit = hits[0];
                newTarget = hit.collider.gameObject;
                if(currentTarget==newTarget){
                    text = GameObject.Find("SunText");
                    if(currentTarget.name=="Mercury"){
                        image = text.transform.GetChild(0).GetComponent<Image>();
                    }
                    if(currentTarget.name=="Venus"){
                        image = text.transform.GetChild(1).GetComponent<Image>();
                    }
                    if(currentTarget.name=="Earth"){
                        image = text.transform.GetChild(2).GetComponent<Image>();
                    }
                    if(currentTarget.name=="Mars"){
                        image = text.transform.GetChild(3).GetComponent<Image>();
                    }
                    if(currentTarget.name=="Jupiter"){
                        image = text.transform.GetChild(4).GetComponent<Image>();
                    }
                    if(currentTarget.name=="Saturn"){
                        image = text.transform.GetChild(5).GetComponent<Image>();
                    }
                    if(currentTarget.name=="Uranus"){
                        image = text.transform.GetChild(6).GetComponent<Image>();
                    }
                    if(currentTarget.name=="Neptune"){
                        image = text.transform.GetChild(7).GetComponent<Image>();
                    }
                    if(currentTarget.name=="Moon"){
                        image = text.transform.GetChild(8).GetComponent<Image>();
                    }
                    if(currentTarget.name=="Phobos"){
                        image = text.transform.GetChild(9).GetComponent<Image>();
                    }
                    if(currentTarget.name=="Demos"){
                        image = text.transform.GetChild(10).GetComponent<Image>();
                    }
                    image.enabled = !image.enabled;
                    } 
                else {
                    if(image!=null){
                        image.enabled = false;
                    }
                    //image.enabled = false;

                }
                    
                //else 
                //{
                //    text = GameObject.Find("SunText");
                //    if(currentTarget.name=="Mercury"){
                //        image = text.transform.GetChild(1).GetComponent<Image>();
                //    }
                //    image.enabled = false;

                //}
                
                currentTarget = newTarget;


                Debug.Log("Target changed to "+currentTarget.name);
                transform.LookAt(currentTarget.transform);
            }
        } else if (Input.GetMouseButtonDown(0)) // if the second mouse button is pressed
        {
            currentTarget = defaultTarget;
            Debug.Log("Target changed to " + currentTarget.name);
            transform.LookAt(currentTarget.transform);
        } 
        //else if (currentTarget!=null)
        //{
            
            // transform here refers to the attached gameobject this script is on.
            // the LookAt function makes a transform point it's Z axis towards another point in space
            // In this case it is pointing towards the target.transform
            //transform.LookAt(currentTarget.transform);
        //} else // reset the look at back to the default
        if(currentTarget==null)
        {
            currentTarget = defaultTarget;
            Debug.Log("Target changed to " + currentTarget.name);
        }
        if (Input.GetKeyDown(KeyCode.E)) SceneManager.LoadScene("Seasons");
        if (Input.GetKeyDown(KeyCode.W)) {
            dup.GetComponent<Camera>().enabled = !dup.GetComponent<Camera>().enabled;
            //dup.enabled = !dup.enabled ;

        }
    }
}
