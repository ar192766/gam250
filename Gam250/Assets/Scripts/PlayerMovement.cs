using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour 
{
	// health for the player
	public float playerHealth = 50;
    public float bulletDamage = 7;

	// speed for the player
	public float speed;

	//Rigibody for player movement
	Rigidbody rigidbody;
	// float that will control gravity 
	public float yAxis;
	//Vector3 for player movement
	Vector3 playerMove = Vector3.zero;
	// Rigibody for player rotation
	Rigidbody playerRB;
	// Declaring camera
	Camera camera;
	//Dfloats that will control speed of player rotation
	public float sensitivity;
	float mr = 0;


	void Start () 
	{
		// assigning variables
		playerRB = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>();
		camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
		rigidbody = GetComponent<Rigidbody> ();
		// cursor will lock so mouse will not be visible when playing
		Screen.lockCursor = true;

	}

	void FixedUpdate ()
    { 
		// floats that are assigned to X,Y Axis
		float rotationY = Input.GetAxis ("Mouse Y") * sensitivity;
		float rotationX = Input.GetAxis ("Mouse X") * sensitivity;

		yAxis += Physics.gravity.y * Time.fixedDeltaTime;

		playerMove = new Vector3 (Input.GetAxis ("Horizontal") * speed, rigidbody.velocity.y , Input.GetAxis ("Vertical") * speed);
		playerMove = transform.TransformDirection (playerMove);
		rigidbody.velocity = playerMove;
		//Allows player to rotate on the Y axis
		playerRB.transform.Rotate(0, rotationX, 0);
		//Clamping the X axis so that player can only go up and down so far
		mr += rotationY;
		mr = Mathf.Clamp(mr, -30, 50);
		camera.transform.localEulerAngles = new Vector3(-mr, 0, 0);


	}

    void NoHealth()
    {
        if(playerHealth == 0)
        {
            Debug.Log("Player Dead");
        }
    }
}
