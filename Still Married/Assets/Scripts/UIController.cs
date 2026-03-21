using UnityEngine;

public class Controller : MonoBehaviour
{
    // ----------- Variables ------------
    public string SHstatus = "neutral";
    public string FIstatus = "neutral";
    private int SHealth = 100; // 
    private int FHealth = 100;
    private int hitDammage = 10;
    
    private int SStamina = 0; // max 4
    private int FStamina = 0;
    private int staminaMax = 4;

    // ----------- Sprites -------------
    public GameObject shrek;
    public GameObject fiona;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AttackCheck()
    {
        // 
        string shrekState = shrek.GetComponent<PlayerControls>().getState();
        string fionaState = shrek.GetComponent<PlayerControls>().getState();

        Debug.Log(shrekState + " , " + fionaState);
        /*
        if(shrekState == "attack" && fionaState == "neutral"){
            FHealth -= hitDammage;
        } else if (shrekState == "neutral" && fionaState == "attack"){
            SHealth -= hitDammage;
        } else if(shrekState == "defense" && fionaState == "attack"){

        }
        */
    }
}
