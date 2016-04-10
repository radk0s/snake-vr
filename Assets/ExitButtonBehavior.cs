using UnityEngine;
using System.Collections;
using System;

public class ExitButtonBehavior : AbstractButtonBehavior
{
    public override void PerformAction()
    {
        Application.Quit();
    }
}
