using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Move" ,menuName = "Character Move")]
public class SO_Move : ScriptableObject
{
    [SerializeField] MoveSlots _moveSlot;
    [SerializeField] List<GameInputs> _input;
    [SerializeField] int _priority = 0;
    [SerializeField] bool _clearsBuffer = true;

    public MoveSlots MoveSlot { get { return _moveSlot; } }
    public int Priority { get { return _priority; } }
    public bool ClearsBuffer { get { return _clearsBuffer; } }

    public bool isMoveExecuted(List<GameInputs> inputedInputs)
    {
        int inputIndex = 0;
        for (int i = 0; i < inputedInputs.Count; i++)
        {
            if (inputedInputs[i] == _input[inputIndex])
            {
                inputIndex++;

                if (inputIndex == _input.Count)
                {
                    return true;
                }
            }
        }
        return false;
    }
}
