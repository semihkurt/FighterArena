using UnityEngine;

[CreateAssetMenu(fileName= "New Fighter", menuName = "FighterShop/Fighter")]
public class Fighter : ScriptableObject
{
    [SerializeField] private string fighterID;
    [SerializeField] private string fighterName;
    [SerializeField] private int fighterLevel;
    [SerializeField] private float fighterExperience;
    [SerializeField] private int fighterPrice;
    [SerializeField] enum Type { Warrior, Archer, Mage}
    [SerializeField] private Type type = Type.Warrior;
    [SerializeField] private Sprite fighterSprite;

    [SerializeField] private int attackPower;
    [SerializeField] private int armor;
    [SerializeField] private int strength;
    [SerializeField] private int agility;
    [SerializeField] private int intelligence;


    //#region Getters and Setters
    public string FighterID { get; set; }
    public string FighterName { get; set; }
    public int FighterPrice { get ; set; }
    public int FighterLevel { get ; set; }
    public float FighterExperience {get; set;}
   // public Type FighterType {get; set;}
    public Sprite FighterSprite { get; set; }

    public int AttackPower {get; set;}
    public int Armor{get; set;}
    public int Strength {get; set;}
    public int Agility{get; set;}
    public int Intelligence{get;set;}
}
