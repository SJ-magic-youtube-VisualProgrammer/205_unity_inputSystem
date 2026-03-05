/************************************************************
************************************************************/
using UnityEngine;
using UnityEngine.InputSystem; // <- need this

/************************************************************
************************************************************/
public class ProjectWide_Polling : MonoBehaviour
{
	/****************************************
	****************************************/
	[SerializeField] float move_speed_ = 10.0f;
	
	Rigidbody rb_;
	
	InputAction action_move_;
	InputAction action_jump_;
	InputAction action_check_;
	
	
	/****************************************
	****************************************/
	
	/******************************
	******************************/
    void Awake()
    {
		action_move_	= InputSystem.actions.FindActionMap("MyMap").FindAction("MyMove");
		action_jump_	= InputSystem.actions.FindActionMap("MyMap").FindAction("MyJump");
		action_check_	= InputSystem.actions.FindActionMap("MyMap").FindAction("MyCheck");
	}
	
	/******************************
	******************************/
    void OnEnable()
    {
	}
	
	/******************************
	******************************/
    void OnDisable()
    {
	}
	
	/******************************
	******************************/
    void Start()
    {
		rb_ = GetComponent<Rigidbody>();
    }
	
	/******************************
	******************************/
    void Update()
    {
		/********************
		********************/
		Vector2 val = action_move_.ReadValue<Vector2>() * move_speed_;
		rb_.linearVelocity = new Vector3(val.x, 0, val.y);
		
		/********************
		********************/
		if( action_jump_.WasPressedThisFrame() ){
			Debug.Log("MyJump");
		}
		
		if( action_check_.WasPressedThisFrame() ){
			Debug.Log("MyCheck");
		}
        
    }
}
