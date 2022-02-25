using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameInput
{
    [SerializeField] GameBinds _input;
    [SerializeField] int _window = 0;

    public GameBinds Input { get { return _input; } }
    public int Window { get { return _window; } set { _window = value; } }

    public GameInput(GameBinds input)
    {
        _input = input;
    }
}
