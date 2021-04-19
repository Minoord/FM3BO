using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerQuit : MonoBehaviour
{

    private int CurScene;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("escape"))
        {
            CurScene = SceneManager.GetActiveScene().buildIndex;
            PlayerPrefs.SetInt("SavedScene", CurScene);
            SceneManager.LoadScene("PauseScreen");
        }
    }
}
