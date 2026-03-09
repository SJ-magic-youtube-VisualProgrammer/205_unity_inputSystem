/************************************************************
************************************************************/
using UnityEngine;
using UnityEngine.InputSystem; // <- need this

/************************************************************
************************************************************/
public class Originnal_PlayerInput_Event : MonoBehaviour
{
	/****************************************
	****************************************/
	PlayerInput player_input_;
	
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
		player_input_ = GetComponent<PlayerInput>();
		
		action_move_	= player_input_.actions.FindActionMap("MyMap").FindAction("MyMove");
		action_jump_	= player_input_.actions.FindActionMap("MyMap").FindAction("MyJump");
		action_check_	= player_input_.actions.FindActionMap("MyMap").FindAction("MyCheck");
	}
	
	/******************************
	******************************/
    void OnEnable()
    {
		action_move_.started	+= OnMoveStarted;
		action_move_.performed	+= OnMove;
		action_move_.canceled	+= OnMoveCanceled;
		
		action_jump_.performed	+= OnJump;
		
		action_check_.performed	+= OnCheck;
	}
	
	/******************************
	******************************/
    void OnDisable()
    {
		action_move_.started	-= OnMoveStarted;
		action_move_.performed	-= OnMove;
		action_move_.canceled	-= OnMoveCanceled;
		
		action_jump_.performed	-= OnJump;
		
		action_check_.performed	-= OnCheck;
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
        
    }
	
	/******************************
	******************************/
    void OnMoveStarted(InputAction.CallbackContext ctx){
		Debug.Log("OnMoveStarted : " + Time.time);
	}
	
	/******************************
	******************************/
    void OnMove(InputAction.CallbackContext ctx){
		Vector2 val = ctx.ReadValue<Vector2>() * move_speed_;
		
		// transform.Translate(zx * Time.deltaTime * move_speed_);
		rb_.linearVelocity = new Vector3(val.x, 0, val.y);
	}
	
	/******************************
	******************************/
    void OnMoveCanceled(InputAction.CallbackContext ctx){
		Debug.Log("OnMoveCanceled : " + Time.time);
		
		rb_.linearVelocity = new Vector3(0, 0, 0);
	}
	
	/******************************
	******************************/
    void OnJump(InputAction.CallbackContext ctx){
		Debug.Log("OnJump : " + Time.time);
	}
	
	/******************************
	******************************/
    void OnCheck(InputAction.CallbackContext ctx){
		Debug.Log("OnCheck : " + Time.time);
	}
}
