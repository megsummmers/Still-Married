using UnityEngine;

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
    private int staminaMax = 4;

    // ----------- Objects -------------
    public GameObject shrek;
    public GameObject fiona;
    public GameObject shrekHbar;
    public GameObject fionaHbar;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       

    }

    // Update is called once per frame
    void Update()
    {
        if(SStamina == 5){
            //speacial attack
            DamageFiona(2f);
        }

        if(FStamina == 5){
            DamageShrek(2f);
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
            DamageShrek(1f);
        } else if(shrekState == "defense" && fionaState == "attack"){
            if(shrekDefense == "good"){
                SStamina++;
            } if(shrekDefense == "weak"){
                DamageShrek(0.5f);
            } else if(shrekDefense == "bad"){
                DamageShrek(1f);
            }
        }
    }

    private void DamageShrek(float multiplier){
        SHealth -= (hitDamage * multiplier);
        shrekHbar.transform.localScale += new Vector3(-0.5f, 0f, 0f);
        shrekHbar.transform.Translate(-0.25f, 0f, 0f);
    }

    private void DamageFiona(float multiplier){
        FHealth -= (hitDamage * multiplier);
        fionaHbar.transform.localScale += new Vector3(-0.5f, 0f, 0f);
        fionaHbar.transform.Translate(-0.25f, 0f, 0f);
    }
}
