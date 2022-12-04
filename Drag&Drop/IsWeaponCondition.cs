public class IsWeaponCondition : DropCondition
{
	public override bool Check(DragDrop draggable)
	{
		return draggable.GetComponent<Weapon>() != null;
	}
}
