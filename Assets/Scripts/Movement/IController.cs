using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IController 
{
    Body body { get; set; }

    void DetermineBody();

    void SayToBody(Vector2 destination);
}
