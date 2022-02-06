using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputBuffer : MonoBehaviour
{
    [SerializeField] List<GameInputs> buffer;
    [SerializeField] List<SO_Move> moveset;
    int currentInputPriority;

    private void Awake()
    {
        moveset.Sort(SortByPriority);
    }
    private void Update()
    {
    }
    public void AddInput(GameInputs input)
    {
        buffer.Add(input);

        if (hasMove(buffer))
            SendExecution(buffer);
    }
    public bool hasMove(List<GameInputs> inputedInputs)
    {
        for (int i = 0; i < moveset.Count; i++)
        {
            if (moveset[i].isMoveExecuted(inputedInputs))
                return true;
        }
        return false;
    }
    public void SendExecution(List<GameInputs> inputedInputs)
    {
        for (int i = 0; i < moveset.Count; i++)
        {
            if (moveset[i].isMoveExecuted(inputedInputs))
            {
                ExecuteMove(moveset[i].GetMove(), moveset[i].GetPriority());

                if (moveset[i].clearsBuffer)
                    buffer.Clear();
                break;
            }
        }
    }
    public int SortByPriority(SO_Move move1, SO_Move move2)
    {
        return Comparer<int>.Default.Compare(move2.GetPriority(), move1.GetPriority());
    }
    public void ExecuteMove(Moveset move, int movePriority)
    {
        if (move == Moveset.None)
            return;

        if (movePriority >= currentInputPriority)
        {
            currentInputPriority = movePriority;
        }
        else
            return;

        switch (move)
        {
            case Moveset.StandingLight:
                Debug.Log(move);
                break;
            case Moveset.CrouchingLight:
                Debug.Log(move);
                break;

            case Moveset.StandingMedium:
                Debug.Log(move);
                break;
            case Moveset.CrouchingMedium:
                Debug.Log(move);
                break;

            case Moveset.StandingHeavy:
                Debug.Log(move);
                break;
            case Moveset.CrouchingHeavy:
                Debug.Log(move);
                break;

            case Moveset.SpecialOne:
                Debug.Log(move);
                break;
            case Moveset.SpecialTwo:
                Debug.Log(move);
                break;
            case Moveset.SpecialThree:
                Debug.Log(move);
                break;

            case Moveset.Super:
                Debug.Log(move);
                break;
        }

        currentInputPriority = 0;
    }
}
