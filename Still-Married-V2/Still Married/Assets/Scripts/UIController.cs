using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;
using System.Collections;

public class Controller : MonoBehaviour
{
    // ----------- Variables ------------
    [SerializeField]public string SHstatus = "neutral";
    [SerializeField]public string FIstatus = "neutral";
    [SerializeField] private float SHealth = 100; // 
    [SerializeField]private float FHealth = 100;
    private float hitDamage = 10;
    
    [SerializeField]private int SStamina = 0; // max 4
    [SerializeField]private int FStamina = 0;
    private int staminaMax = 2;

    public bool gamePaused = false;

    // ----------- Objects -------------
    public GameObject shrek;
    public GameObject fiona;
    public GameObject shrekHbar;
    public GameObject fionaHbar;
    public GameObject shrekSbar;
    public GameObject fionaSbar;
    public GameObject finalCanvas;

    // SFX
    public AudioSource audioSourceLVL;
    public AudioClip chaise;
    public AudioClip merde;
    public AudioClip plier;
    public AudioClip soundtrack;
    public AudioClip emotional;
    public AudioClip tabarnac;
    public AudioClip married;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       //Play Soundtrack
        audioSourceLVL.PlayOneShot(soundtrack, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if(SStamina >= staminaMax){
            //speacial attack
            audioSourceLVL.PlayOneShot(chaise, 1.0f);
            DamageFiona(2f);
            SStamina = 0;
        }
        if(FStamina >= staminaMax){
            audioSourceLVL.PlayOneShot(emotional, 1.0f);
            // special attack
            DamageShrek(2f);
            FStamina = 0;
        }
    }

    public void OnAttack(InputAction.CallbackContext context){
        // User input control
        if(context.performed){
            if(gamePaused){
                // GAME ON
                if(context.interaction is TapInteraction){
                } 
            }
        }
    }

    public void AttackCheck()
    {
        // Get variables from other scripts
        string shrekState = shrek.GetComponent<PlayerControls>().getState();
        string shrekDefense = shrek.GetComponent<PlayerControls>().getDefense();
        string fionaState = fiona.GetComponent<FionaController>().getState();

        // Check who is attacking/being damaged
        if(shrekState == "attack" && fionaState == "neutral"){
            DamageFiona(1f);
        } else if (shrekState == "neutral" && fionaState == "attack"){
            // successful attack = stamina
            IncreaseStamina('f');
            DamageShrek(1f);
        } else if(shrekState == "defense" && fionaState == "attack"){
            if(shrekDefense == "good"){
                // successful defense = stamina
                IncreaseStamina('s');
            } if(shrekDefense == "weak"){
                DamageShrek(0.5f);
            } else if(shrekDefense == "bad"){
                DamageShrek(1f);
            }
        }
    }

    private void DamageShrek(float multiplier){
        audioSourceLVL.PlayOneShot(merde, 1.0f);
        SHealth -= (hitDamage * multiplier);
        if(SHealth <= 0){
            EndGame('f');
        } else {
            shrekHbar.transform.localScale += new Vector3(-0.5f, 0f, 0f);
            shrekHbar.transform.Translate(0.25f, 0f, 0f);
        }
    }

    private void DamageFiona(float multiplier){
        audioSourceLVL.PlayOneShot(tabarnac, 1.0f);
        FHealth -= (hitDamage * multiplier);
        if(FHealth <= 0){
            EndGame('s');
        } else {
            fionaHbar.transform.localScale += new Vector3(-0.5f, 0f, 0f);
            fionaHbar.transform.Translate(-0.25f, 0f, 0f);
        }
    }

    private void IncreaseStamina(char name){
        switch(name){
            case 's':
                SStamina++;
                shrekSbar.transform.localScale += new Vector3(-0.5f, 0f, 0f);
                shrekSbar.transform.Translate(0.5f, 0f, 0f);
                break;
            case 'f':
                FStamina++;
                fionaSbar.transform.localScale += new Vector3(-0.5f, 0f, 0f);
                fionaSbar.transform.Translate(-0.5f, 0f, 0f);
                break;
        }
    }

    public bool GameStatus(){
        return gamePaused;
    }

    private void EndGame(char winner){
        audioSourceLVL.PlayOneShot(married, 1.0f);
        if(winner == 's'){
            shrek.GetComponent<PlayerControls>().FinalPose('w');
            fiona.GetComponent<FionaController>().FinalPose('l');
        } else if(winner == 'f'){
            shrek.GetComponent<PlayerControls>().FinalPose('l');
            fiona.GetComponent<FionaController>().FinalPose('w');
        }
    }
}
