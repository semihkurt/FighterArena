using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FighterBase : MonoBehaviour
{
        [SerializeField]
        public Fighter fighter = null;

        FighterBase(Fighter fighter)
        {
                this.fighter = fighter;
        }

        public void copy(Fighter pFighter)
        {
                if(fighter == null)
                {
                        fighter = ScriptableObject.CreateInstance<Fighter>(); //new Fighter();
                        fighter.FighterName = pFighter.FighterName;
                        fighter.FighterPrice = pFighter.FighterPrice;
                        fighter.FighterSprite = pFighter.FighterSprite;
                        fighter.Item1 = pFighter.Item1;
                        fighter.Item2 = pFighter.Item2;
                        fighter.Item3 = pFighter.Item3;
                        fighter.Strength = pFighter.Strength;
                        fighter.Agility = pFighter.Agility;
                        fighter.Intelligence = pFighter.Intelligence;
                        fighter.FighterLevel = pFighter.FighterLevel;
                        fighter.FighterID = pFighter.FighterID;
                        fighter.Armor = pFighter.Armor;
                        fighter.AttackPower = pFighter.AttackPower;
                        fighter.FighterExperience = pFighter.FighterExperience;
                }else
                {
                        Debug.Log("Cant copy because it already exists");
                }
        }
}