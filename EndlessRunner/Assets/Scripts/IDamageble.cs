using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageble
{
    public int healthPoints { get; }
    public bool isAlive { get; }
    public void ModifyHealth(int _value);
}
