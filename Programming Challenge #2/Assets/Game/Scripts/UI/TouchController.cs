using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchController : MonoBehaviour
{

    public NinjaController ninja;

    public void MoveUp()
    {
        ninja.inputDirection.y = 1;
    }

    public void MoveLeft()
    {
        ninja.inputDirection.x = -1;
    }

    public void MoveRight()
    {
        ninja.inputDirection.x = 1;
    }

    public void MoveDown()
    {
        ninja.inputDirection.y = -1;
    }

    public void ResetInput()
    {
        ninja.inputDirection.x = 0;
        ninja.inputDirection.y = 0;
    }
}
