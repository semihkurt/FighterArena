using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FighterBase : MonoBehaviour 
{
        [SerializeField] public Fighter fighter;

        FighterBase(Fighter fighter)
        {
                this.fighter = fighter;
        }
}