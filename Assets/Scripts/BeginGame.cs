using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BeginGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Gameplay");
    }

    public void ToggleControls()
    {
        SceneManager.LoadScene("Controls");
    }

    public void ToggleMenu()
    {
        SceneManager.LoadScene("Title");
    }

}
