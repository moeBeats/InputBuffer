using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Move" ,menuName = "Character Move")]
public class SO_Move : ScriptableObject
{
    [SerializeField] Moveset moveSlot;
    [SerializeField] List<GameInputs> input;
    [SerializeField] int priority = 0;
    [SerializeField] int bufferWindow = 15;
    [SerializeField] public bool clearsBuffer;

    public bool isMoveExecuted(List<GameInputs> inputedInputs)
    {
        int inputIndex = 0;
        for (int i = 0; i < inputedInputs.Count; i++)
        {
            if (inputedInputs[i] == input[inputIndex])
            {
                inputIndex++;
                if (inputIndex == input.Count)
                {
                    return true;
                }
            }
        }
        return false;
    }
    public int GetPriority()
    {
        return priority;
    }
    public Moveset GetMove()
    {
        return moveSlot;
    }

}
