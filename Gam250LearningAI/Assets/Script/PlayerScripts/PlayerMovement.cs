using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour 
{
	// health for the player
	public static float playerHealth = 50;

	public float healthDrainSpeed = 0.2f;
	public float rageHealthDrainSpeed = 0.4f;
	// speed for the player
	public float speed;
	// jump force for player
	public float jumpForce;
	// gravity for the player
	public float gravity;

	// bool for jump checking
	public bool grounded = false;
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
		// assigning the yAxis to jumpForce
		yAxis = jumpForce;
		// cursor will lock so mouse will not be visible when playing
		Screen.lockCursor = true;

	}

	void FixedUpdate ()
	{
		//If player health = 0 then Game Over scene will activate
		if(playerHealth < 0)
		{
			SceneManager.LoadScene("GameOver");
		}


		// floats that are assigned to X,Y Axis
		float rotationY = Input.GetAxis ("Mouse Y") * sensitivity;
		float rotationX = Input.GetAxis ("Mouse X") * sensitivity;
		//Checks to see if both things are true so that the player is allowed to jump
		if (Input.GetKeyDown (KeyCode.Space) && grounded == true) 
		{
			// Adds force so that the player can jump up and down
			rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse );
		} 
		else
		{
			// else yAxis = 0 meaning the player will fall back to the floor
			yAxis = 0f;
		}

		yAxis += Physics.gravity.y * Time.fixedDeltaTime;

		//
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

}
