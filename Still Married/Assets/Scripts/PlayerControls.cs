using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;
using System.Collections;

// --------------- SHREK CONTROLS ---------------------
// - Controls his attack/defense/neutral state based on User input
// - Changes the Shrek sprite based on state (currently color)
// - 

public class PlayerControls : MonoBehaviour
{
    public SpriteRenderer shrek;
    [SerializeField] private string shrekState = "neutral";
    private string defenseState = "good";

    private float timer = 0;
    private int timer2 = 0;
    private bool countdown = false;

    public GameObject controllerScript;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        shrek = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // Change sprite
        if(shrekState == "neutral"){
            shrek.color = Color.grey;
            //reset defense
            defenseState = "good";
        } else if(shrekState == "defend" && !countdown){
            // Timer to reduce defense efficiency
            if(defenseState == "good"){
                shrek.color = Color.blue;
                countdown = true;
                timer = 180f;
            } else if(defenseState == "weak"){
                shrek.color = Color.violet;
                countdown = true;
                timer = 180f;
            } else {
                shrek.color = Color.red;
            }
        } else if(shrekState == "attack" && !countdown){
            shrek.color = Color.green;
            countdown = true;
            timer = 60f;
        }

        // countdown for attack reset + defense degrade
        if(countdown && timer > 0){
            timer = timer - 1f;
        } else if(countdown && timer <= 0 && shrekState == "attack"){
            countdown = false;
            shrekState = "neutral";
        }  else if(countdown && timer <= 0 && shrekState == "defend" && defenseState == "good"){
            //Debug.Log("Yep");
            countdown = false;
            defenseState = "weak";
        } else if(countdown && timer <= 0 && shrekState == "defend" && defenseState == "weak"){
            //Debug.Log("Yep");
            countdown = false;
            defenseState = "bad";
        }
    }

    public void OnAttack(InputAction.CallbackContext context){
        // User input control
        if(context.performed){
            if(context.interaction is HoldInteraction){
                shrekState = "defend";
            }
            if(context.interaction is TapInteraction){
                shrekState = "attack";
                controllerScript.GetComponent<Controller>().AttackCheck();
            } 
        }
         if(context.canceled){
                shrekState = "neutral";
        }
        /*
        switch (context.phase) {
            case InputActionPhase.Performed:
                if(context.interaction is HoldInteraction){
                    shrek.color = Color.red;
                    Debug.Log("Defend");
                } else {
                    shrek.color = Color.grey;
                    Debug.Log("Neutral");
                }
                break;
            case InputActionPhase.Started:
                if(context.interaction is HoldInteraction){
                    shrek.color = Color.white;
                    Debug.Log("Hold Release");
                } else if(context.interaction is TapInteraction) {
                    shrek.color = Color.green;
                    Debug.Log("Tap");
                }
                break;
            case InputActionPhase.Canceled:
                shrek.color = Color.grey;
                Debug.Log ("Neutral");
                break;
        } */
    }

    public string getState(){
        return shrekState;
    }
}
