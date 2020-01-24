using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISaver<T>
{
    T param { get; set; }
    void SaveParam();
    void LoadParam();
}
