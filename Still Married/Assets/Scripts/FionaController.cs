using UnityEngine;

public class FionaController : MonoBehaviour
{
    public SpriteRenderer fiona;
    [SerializeField] private string fionaState = "neutral"; 
    private float timer = 0;
    private bool countdown = false;
    private int atkChance;

    private int[,] attackPatterns = {{0, 1, 1, 0, 1}, {1, 0, 0, 1, 0}, {1, 0, 1, 0, 1}, {0, 0, 1, 1, 0}, {0, 1, 0, 1, 0}};
    private int patternLength = 5;
    private int patternX = 0;
    private int patternY = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        fiona = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(fionaState == "neutral" && !countdown){
            fiona.color = Color.grey;
            countdown = true;
            timer = 180f;
        } else if(fionaState == "attack" && !countdown){
            fiona.color = Color.green;
            countdown = true;
            timer = 60f;
        }

        if(countdown && timer > 0){
            timer = timer - 0.1f;
        } else if(countdown && timer <= 0){
            countdown = false;
            if(patternY == 4){
                patternY = 0;
                patternX = 0;
            } else if(patternX < 4){
                patternX++;
            } else if(patternX == 4){
                patternX = 0;
                patternY++;
            }

            if(attackPatterns[patternX, patternY] == 1){
                fionaState = "attack";
            } else {
                fionaState = "neutral";
            }

        }
    }

    public string getState(){
        return fionaState;
    }
}
