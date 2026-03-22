using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public float timer = 5.0f;
    public float timerReset = 5.0f;
    public string sceneName = "";

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        // Start Timer
        timer -= Time.deltaTime;
        if(timer <= 0){
            // Change Scene
            SceneManager.LoadScene(sceneName);
            timer = timerReset;
        }
    }
}
