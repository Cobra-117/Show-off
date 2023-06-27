using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class Walk : MonoBehaviour
{
	public float[] speedCurve;
	public float speed = 10.0f;
	public float airVelocity = 8f;
	public float gravity = 10.0f;
	public float maxVelocityChange = 10.0f;
	public float jumpHeight = 2.0f;
	public float maxFallSpeed = 20.0f;
	public float rotateSpeed = 25f; //Speed the player rotate
	private Vector3 moveDir;
	//public GameObject cam;
	private Rigidbody rb;

	private float distToGround;

	private bool canMove = true; //If player is not hitted
	private bool isStuned = false;
	private bool wasStuned = false; //If player was stunned before get stunned another time
	private float pushForce;
	private Vector3 pushDir;

	public Vector3 checkPoint;
	private bool slide = false;
	int currentChunk = 0;
	bool isFirstChunk = true;

	//Gamepad values
    public Vector2 analogValue;
    public Vector3 rotateDirection;

	Animator animator;
	public GameObject cineMachineCam;

    //method that returns the analog stick X,Y values from -1 to 1 
    //void OnMove(InputValue value)
    //{
    //    analogValue = value.Get<Vector2>();
    //}

	public void OnButtonPress()
	{

	}

    void GetDirection()
    {
		analogValue = GetComponentInParent<PlayerInputScript>().analogValue;
		
		float horizontal = analogValue.x;
        float vertical = analogValue.y;

		//direction vector of the camera
		//Vector3 camForward = Camera.main.transform.forward;
		//Vector3 camRight = Camera.main.transform.right;
		//Vector3 camForward = cineMachineCam.transform.forward;
		//Vector3 camRight = cineMachineCam.transform.right;

		//set these to 0 since we don't want vertical values
		//camForward.y = 0;
		//camRight.y = 0;

		//horizontal and vertical forces to be applied relative to the camera
		//Vector3 forwardRelative = vertical * camForward;
		//Vector3 rightRelative = horizontal * camRight;

		//rotateDirection = forwardRelative + rightRelative;
		rotateDirection = new Vector3(vertical, 0, -horizontal);
		
    }

    void RotateObject()
    {
        transform.rotation = Quaternion.LookRotation(rotateDirection);
    }

    void  Start (){
		// get the distance to ground
		distToGround = GetComponent<Collider>().bounds.extents.y;
		animator = GetComponent<Animator>();
		cineMachineCam = GameObject.FindGameObjectWithTag("cmCam");
		speed = speedCurve[0];
	}
	
	bool IsGrounded (){
		return true;
		return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f);
	}
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "flying")
            transform.parent.gameObject.GetComponent<SwitchMovement>().SwitchToFlying();

        if (other.tag == "swimming")
            transform.parent.gameObject.GetComponent<SwitchMovement>().SwitchToSwimming();

        if (other.tag == "jumping")
            transform.parent.gameObject.GetComponent<SwitchMovement>().SwitchToJumping();
    }

    void Awake () {
		rb = GetComponent<Rigidbody>();
		rb.freezeRotation = true;
		rb.useGravity = false;

		checkPoint = transform.position;
		Cursor.visible = false;
	}
	
	void FixedUpdate () {
		if (PauseMenu.isGamePaused)
			return;
		if (canMove)
		{
			//if (moveDir.x != 0 || moveDir.z != 0)
			//{
			//	Vector3 targetDir = moveDir; //Direction of the character

			//	targetDir.y = 0;
			//	if (targetDir == Vector3.zero)
			//		targetDir = transform.forward;
			//	Quaternion tr = Quaternion.LookRotation(targetDir); //Rotation of the character to where it moves
			//	Quaternion targetRotation = Quaternion.Slerp(transform.rotation, tr, Time.deltaTime * rotateSpeed); //Rotate the character little by little
			//	transform.rotation = targetRotation;
			//}

			if (IsGrounded())
			{
			 // Calculate how fast we should be moving
				Vector3 targetVelocity = rotateDirection;
				targetVelocity *= speed;
				animator.Play("Take 001");
				//Debug.Log("Fix animation");
				//if (animator.)

				// Apply a force that attempts to reach our target velocity
				Vector3 velocity = rb.velocity;
				if (targetVelocity.magnitude < velocity.magnitude) //If I'm slowing down the character
				{
					targetVelocity = velocity;
					rb.velocity /= 1.1f;
				}
				Vector3 velocityChange = (targetVelocity - velocity);
				velocityChange.x = Mathf.Clamp(velocityChange.x, -maxVelocityChange, maxVelocityChange);
				velocityChange.z = Mathf.Clamp(velocityChange.z, -maxVelocityChange, maxVelocityChange);
				velocityChange.y = 0;
				if (!slide)
				{
					if (Mathf.Abs(rb.velocity.magnitude) < speed * 1.0f)
						rb.AddForce(velocityChange, ForceMode.VelocityChange);
				}
				else if (Mathf.Abs(rb.velocity.magnitude) < speed * 1.0f)
				{
					rb.AddForce(moveDir * 0.15f, ForceMode.VelocityChange);
					//Debug.Log(rb.velocity.magnitude);
				}
				//rb.velocity = new Vector3(rotateDirection.x, rb.velocity.y, rotateDirection.z);

                // Jump
    //            if (IsGrounded() && Input.GetButton("Jump"))
				//{
				//	rb.velocity = new Vector3(velocity.x, CalculateJumpVerticalSpeed(), velocity.z);
				//}
			}
			else
			{
				if (!slide)
				{
					Vector3 targetVelocity = new Vector3(moveDir.x * airVelocity, rb.velocity.y, moveDir.z * airVelocity);
					Vector3 velocity = rb.velocity;
					Vector3 velocityChange = (targetVelocity - velocity);
					velocityChange.x = Mathf.Clamp(velocityChange.x, -maxVelocityChange, maxVelocityChange);
					velocityChange.z = Mathf.Clamp(velocityChange.z, -maxVelocityChange, maxVelocityChange);
					rb.AddForce(velocityChange, ForceMode.VelocityChange);
					if (velocity.y < -maxFallSpeed)
						rb.velocity = new Vector3(velocity.x, -maxFallSpeed, velocity.z);
				}
				else if (Mathf.Abs(rb.velocity.magnitude) < speed * 1.0f)
				{
					rb.AddForce(moveDir * 0.15f, ForceMode.VelocityChange);
				}
			}
		}
		else
		{
			rb.velocity = pushDir * pushForce;
		}
		// We apply gravity manually for more tuning control
		rb.AddForce(new Vector3(0, -gravity * GetComponent<Rigidbody>().mass, 0));
	}

	private void Update()
	{
        GetDirection();
        RotateObject();
        float h = Input.GetAxis("Horizontal");
		float v = Input.GetAxis("Vertical");

		/*Vector3 v2 = v * cam.transform.forward; //Vertical axis to which I want to move with respect to the camera
		Vector3 h2 = h * cam.transform.right; //Horizontal axis to which I want to move with respect to the camera
		moveDir = (v2 + h2).normalized; //Global position to which I want to move in magnitude 1
        */
        //moveDir = new Vector3(1, 0, 0);
		RaycastHit hit;
		if (Physics.Raycast(transform.position, -Vector3.up, out hit, distToGround + 0.1f))
		{
			if (hit.transform.tag == "Slide")
			{
				slide = true;
			}
			else
			{
				slide = false;
			}
		}
        //ManageInputs();
	}

    void ManageInputs()
    {
        moveDir = new Vector3(0, 0, 0);

        if (Input.GetKey(KeyCode.Z)) {
            moveDir = new Vector3(0, 0, 1);
        }
    }

	float CalculateJumpVerticalSpeed () {
		// From the jump height and gravity we deduce the upwards speed 
		// for the character to reach at the apex.
		return Mathf.Sqrt(2 * jumpHeight * gravity);
	}

	public void HitPlayer(Vector3 velocityF, float time)
	{
		rb.velocity = velocityF;

		pushForce = velocityF.magnitude;
		pushDir = Vector3.Normalize(velocityF);
		StartCoroutine(Decrease(velocityF.magnitude, time));
	}

	public void LoadCheckPoint()
	{
		transform.position = checkPoint;
	}

	private IEnumerator Decrease(float value, float duration)
	{
		if (isStuned)
			wasStuned = true;
		isStuned = true;
		canMove = false;

		float delta = 0;
		delta = value / duration;

		for (float t = 0; t < duration; t += Time.deltaTime)
		{
			yield return null;
			if (!slide) //Reduce the force if the ground isnt slide
			{
				pushForce = pushForce - Time.deltaTime * delta;
				pushForce = pushForce < 0 ? 0 : pushForce;
				//Debug.Log(pushForce);
			}
			rb.AddForce(new Vector3(0, -gravity * GetComponent<Rigidbody>().mass, 0)); //Add gravity
		}

		if (wasStuned)
		{
			wasStuned = false;
		}
		else
		{
			isStuned = false;
			canMove = true;
		}
	}

	public void UpdateChunk()
    {
        if (isFirstChunk) {
            isFirstChunk = false;
            return;
        }
        currentChunk += 1;
        if (currentChunk < speedCurve.Length) {
            speed = speedCurve[currentChunk];
        }
    }
}
