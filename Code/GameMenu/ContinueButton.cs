using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ContinueButton : MonoBehaviour
{
    private int NextSceneToLoad;

    public Button ClickMeToContinue;

    // Start is called before the first frame update
    void Start()
    {
        ClickMeToContinue.onClick.AddListener(IfClicked);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private int ContinueScene;
    void IfClicked()
    {
        ContinueScene = PlayerPrefs.GetInt("SavedScene");
        SceneManager.LoadScene(ContinueScene);

    }
}
