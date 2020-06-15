using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuitTimer : MonoBehaviour
{
    Text message;
    float timer;
    void Start()
    {
        message = GetComponent<Text>();

        timer = 5f;
    }

    void Update()
    {
        message.text = $"O jogo vai sair em {(int)timer}";

        if (timer <= 0) Application.Quit();

        else timer -= Time.deltaTime;
    }
}
