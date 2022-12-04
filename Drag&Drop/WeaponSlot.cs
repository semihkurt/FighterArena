using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSlot : InventorySlot
{
	protected override void Awake()
	{
		base.Awake();
		dropArea.DropConditions.Add(new IsWeaponCondition());
	}
}
