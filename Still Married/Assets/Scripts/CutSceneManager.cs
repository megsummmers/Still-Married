using UnityEngine;
using TMPro;

public class CutSceneManager : MonoBehaviour
{
    private float timer1 = 0.2f;
    private float timer2 = 4.0f;
    private float timer3 = 4.0f;
    private float timer4 = 4.0f;
    private float timer5 = 4.0f;
    public TextMeshProUGUI dialogueLine; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       dialogueLine.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        // Start Timer
        timer1 -= Time.deltaTime;
        if(timer1 <= 0){
            // Change Scene
            dialogueLine.text = "S: Who cut the onions?";
            timer2 -= Time.deltaTime;
        }

        if(timer2 <= 0){
            // Change Scene
            dialogueLine.text = "F: I did.";
            timer3 -= Time.deltaTime;
        }

         if(timer3 <= 0){
            // Change Scene
            dialogueLine.text = "S: Why would you do it? Onions are MY thing.";
            timer4 -= Time.deltaTime;
        }

        if(timer4 <= 0){
            // Change Scene
            dialogueLine.text = "F: It's just onions.";
            timer5 -= Time.deltaTime;
        }

         if(timer5 <= 0){
            // Change Scene
            dialogueLine.text = "S: ...";
        }
}
}
