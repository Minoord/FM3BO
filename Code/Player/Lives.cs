using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lives : MonoBehaviour
{
    public float LivesPlayer;
    public Text LivesText;

    // Start is called before the first frame update
    void Start()
    {
        LivesText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        LivesPlayer = Player.curHealth;
        LivesText.text = "Lives: " + LivesPlayer;
    }
}
