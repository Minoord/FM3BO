using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{

    private int NextSceneToLoad;
    // Start is called before the first frame update
    void Start()
    {
        NextSceneToLoad = SceneManager.GetActiveScene().buildIndex + 1; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(NextSceneToLoad);
        }
    }
}
