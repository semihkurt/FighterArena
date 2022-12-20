using UnityEngine;

[CreateAssetMenu(fileName= "New Fighter", menuName = "FighterShop/Fighter")]
public class Fighter : ScriptableObject
{
    [SerializeField] private string fighterID;
    [SerializeField] private string fighterName;
    [SerializeField] private int fighterLevel = 1;
    [SerializeField] private float fighterExperience = 0.0f;
    [SerializeField] private int fighterPrice = 300;
    [SerializeField] enum Type { Warrior, Archer, Mage}
    [SerializeField] private Type type = Type.Warrior;
    [SerializeField] private Sprite fighterSprite;

    [SerializeField] private int attackPower = 40;
    [SerializeField] private int armor = 15;
    [SerializeField] private int strength = 10;
    [SerializeField] private int agility = 10;
    [SerializeField] private int intelligence = 10;
    [SerializeField] private Item item1;
    [SerializeField] private Item item2;
    [SerializeField] private Item item3;

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

    public Item Item1 { get => item1; set => item1 = value;}
    public Item Item2 { get => item2; set => item2 = value;}
    public Item Item3 { get => item3; set => item3 = value;}

    public void ResetData()
    {

        item1 = null;
        item2 = null;
        item3 = null;
    }
}
