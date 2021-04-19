using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuitButton : MonoBehaviour
{

    public Button ClickMeToQuit;

    // Start is called before the first frame update
    void Start()
    {
        ClickMeToQuit.onClick.AddListener(IfClicked);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void IfClicked()
    {
        Application.Quit();

    }

}
