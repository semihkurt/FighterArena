using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public struct FighterInstance
{
        Fighter fighter;

        FighterInstance(Fighter fighter)
        {
                this.fighter = fighter;
        }
}