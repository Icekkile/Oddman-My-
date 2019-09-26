using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IController 
{
    void SetTargetPoint(Vector2 TargetPoint);

    bool CountCoolDown();
}
