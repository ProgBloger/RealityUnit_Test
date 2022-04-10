using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinMain : MonoBehaviour
{
    void Start()
    {
        var composer = new ComposeResultScreen();
        composer.Compose(GameScene.Win);
    }
}
