using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayAgain : MonoBehaviour
{

    public Button ClickMeToPlay;

    // Start is called before the first frame update
    void Start()
    {
        ClickMeToPlay.onClick.AddListener(IfClicked);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void IfClicked()
    {
        SceneManager.LoadScene("Level1");

    }
}
