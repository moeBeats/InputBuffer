using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputBuffer : MonoBehaviour
{
    [SerializeField] List<GameInputs> _buffer;
    [SerializeField] List<SO_Move> _moveset;

    private void Awake()
    {
        _moveset.Sort(SortByPriority);
    }
    public void AddInput(GameInputs input)
    {
        _buffer.Add(input);

        if (hasMove(_buffer))
            SendExecution(_buffer);
    }
    public bool hasMove(List<GameInputs> inputedInputs)
    {
        for (int i = 0; i < _moveset.Count; i++)
        {
            if (_moveset[i].isMoveExecuted(inputedInputs))
                return true;
        }

        return false;
    }
    public void SendExecution(List<GameInputs> inputedInputs)
    {
        for (int i = 0; i < _moveset.Count; i++)
        {
            if (_moveset[i].isMoveExecuted(inputedInputs))
            {
                ExecuteMove(_moveset[i].MoveSlot, _moveset[i].Priority);

                if (_moveset[i].ClearsBuffer)
                    _buffer.Clear();

                break;
            }
        }
    }
    public void ExecuteMove(Moveset move, int movePriority)
    {
        if (move == Moveset.None)
            return;

        int currentInputPriority = 0;
        if (movePriority >= currentInputPriority)
            currentInputPriority = movePriority;
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
    public int SortByPriority(SO_Move move1, SO_Move move2)
    {
        return Comparer<int>.Default.Compare(move2.Priority, move1.Priority);
    }
}
