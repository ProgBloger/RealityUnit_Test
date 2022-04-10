using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseMain : MonoBehaviour
{
    void Start()
    {
        var composer = new ComposeResultScreen();
        composer.Compose(GameScene.Lose);
    }
}
