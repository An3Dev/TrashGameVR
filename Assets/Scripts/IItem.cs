using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IItem
{
    TrashType GetTrashType();

    void OnCorrectlyThrown();

    void OnIncorrectlyThrown();

    bool IsInTrashCan();
}
