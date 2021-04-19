using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 

public class PlayButton : MonoBehaviour
{
    
    private int NextSceneToLoad;

    public Button ClickMeToPlay;

    // Start is called before the first frame update
    void Start()
    {
        NextSceneToLoad = SceneManager.GetActiveScene().buildIndex + 1;

        ClickMeToPlay.onClick.AddListener(IfClicked);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void IfClicked()
    {
        SceneManager.LoadScene(NextSceneToLoad);

    }
}
