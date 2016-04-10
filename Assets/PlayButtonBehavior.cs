using UnityEngine;
using System.Collections;
using System;

public class PlayButtonBehavior : AbstractButtonBehavior {
    public override void PerformAction()
    {
        Application.LoadLevel("MainScene");
    }
}
