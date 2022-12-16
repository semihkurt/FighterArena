using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSlot : ItemSlot
{
	protected override void Awake()
	{
		base.Awake();
		dropArea.DropConditions.Add(new IsWeaponCondition());
	}
}
