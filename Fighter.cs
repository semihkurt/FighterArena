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
    public string FighterID { get => fighterID; set => fighterID = value; }
    public string FighterName { get => fighterName; set => fighterName = value; }
    public int FighterPrice { get => fighterPrice; set => fighterPrice = value; }
    public int FighterLevel{ get => fighterLevel; set => fighterLevel = value; }
    public float FighterExperience { get => fighterExperience; set => fighterExperience = value; }
   // public Type FighterType {get; set;}
    public Sprite FighterSprite { get => fighterSprite; set => fighterSprite = value; }

    public int AttackPower { get => attackPower; set => attackPower = value; }
    public int Armor { get => armor; set => armor = value; }
    public int Strength { get => strength; set => strength = value; }
    public int Agility { get => agility; set => agility = value; }
    public int Intelligence { get => intelligence; set => intelligence = value; }
}
