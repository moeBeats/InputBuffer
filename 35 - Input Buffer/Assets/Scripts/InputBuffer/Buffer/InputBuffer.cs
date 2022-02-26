using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputBuffer : MonoBehaviour
{
    [SerializeField] List<GameInput> _buffer;
    //[SerializeField] GameInput[] _testBuffer;
    [SerializeField] float _bufferSize;
    [SerializeField] List<SO_Move> _moveset;
    private void Awake()
    {
        _moveset.Sort(SortByPriority);
        //_buffer = new GameInput[_bufferSize];
    }
    private void FixedUpdate()
    {
        if (0 < _buffer.Count)
         _buffer[_buffer.Count - 1].Window += 1;

    }
    public void AddInput(GameInput input)
    {
        _buffer.Add(input);
        StartCoroutine(CO_RemoveInput(input));
        if (hasMove(_buffer))
            SendExecution(_buffer);
    }
    IEnumerator CO_RemoveInput(GameInput input)
    {
        yield return new WaitForSeconds(_bufferSize);
        _buffer.Remove(input);
    }
    bool hasMove(List<GameInput> inputedInputs)
    {
        for (int i = 0; i < _moveset.Count; i++)
        {
            if (_moveset[i].isMoveExecuted(inputedInputs))
                return true;
        }

        return false;
    }
    void SendExecution(List<GameInput> inputedInputs)
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
    void ExecuteMove(MoveSlots moveSlot, int movePriority)
    {
        if (moveSlot == MoveSlots.None)
            return;

        int currentInputPriority = 0;
        if (movePriority >= currentInputPriority)
            currentInputPriority = movePriority;
        else
            return;

        switch (moveSlot)
        {
            case MoveSlots.StandingLight:
                Debug.Log(moveSlot);
                break;
            case MoveSlots.CrouchingLight:
                Debug.Log(moveSlot);
                break;

            case MoveSlots.StandingMedium:
                Debug.Log(moveSlot);
                break;
            case MoveSlots.CrouchingMedium:
                Debug.Log(moveSlot);
                break;

            case MoveSlots.StandingHeavy:
                Debug.Log(moveSlot);
                break;
            case MoveSlots.CrouchingHeavy:
                Debug.Log(moveSlot);
                break;

            case MoveSlots.SpecialOne:
                Debug.Log(moveSlot);
                break;
            case MoveSlots.SpecialTwo:
                Debug.Log(moveSlot);
                break;
            case MoveSlots.SpecialThree:
                Debug.Log(moveSlot);
                break;

            case MoveSlots.Super:
                Debug.Log(moveSlot);
                break;
        }

        currentInputPriority = 0;
    }
    int SortByPriority(SO_Move move1, SO_Move move2)
    {
        return Comparer<int>.Default.Compare(move2.Priority, move1.Priority);
    }
}
