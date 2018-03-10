using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CnControls;

public class MovimientoTactil : MonoBehaviour {


	public float MovementSpeed;
	public float VectorMagnitude;

	private CharacterController _characterController;

	private Transform _mainCameraTransform;
	private Transform _transform;

	public Vector3 inputVector;
	Vector3 movement;

	public Animator anim;

	public bool StartWalking;
	public bool StartRunning;
	public bool WalkToRun;
	public bool Stop;

	int FloorMask;


	// Use this for initialization
	void Start () {

		FloorMask = LayerMask.GetMask ("Floor");
		_mainCameraTransform = Camera.main.GetComponent<Transform>();
		_characterController = GetComponent<CharacterController>();
		_transform = GetComponent<Transform>();
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {

		//Vector2 movememt = CnInputManager.GetAxisRaw("J1");

		inputVector = new Vector3(CnInputManager.GetAxis("Horizontal"), CnInputManager.GetAxis("Vertical"));
		Vector3 movementVector = Vector3.zero;

		VectorMagnitude = inputVector.sqrMagnitude;

		Andar ();
		Correr ();
		WalkOrRun ();
		Stop1 ();

		if (VectorMagnitude > 0.001f) {
			
			movementVector = _mainCameraTransform.TransformDirection (inputVector);
			movementVector.y = 0f;
			movementVector.Normalize ();
			_transform.forward = movementVector;

		}
			
		_characterController.Move(movementVector * Time.deltaTime * MovementSpeed);

	}

	void FixedUpdate() {

		animating (inputVector);

	}

	void Andar(){
		
		if (VectorMagnitude > 0.001f) {
			
			MovementSpeed = 1f;

			StartWalking = true;
		} 

		else {
			
			StartWalking = false;
		}
	}

	void Correr (){
		
		if (VectorMagnitude > 0.3f) {
			
			MovementSpeed = 5f;

			StartWalking = false;
			StartRunning = true;
				
		} 

		else 
			
		{

			StartRunning = false;

		}
	}

	void WalkOrRun(){
			
		if (StartRunning) {

			WalkToRun = true;
			StartWalking = false;
		} 

		else {

			WalkToRun = false;
		}

	}

	void Stop1(){
	
		if (VectorMagnitude < 0.001f) {

			StartWalking = false;
			StartRunning = false;
			WalkToRun = false;
			Stop = true;
		} 
		else {

			Stop = false;
		}
	
	}

	void animating ( Vector3 inputVector) {

		anim.SetBool ("IsWalking", StartWalking);
		anim.SetBool ("IsRuning", StartRunning);
		anim.SetBool ("WalkToRun", WalkToRun);
		anim.SetBool ("Stop", Stop);

	}
}
