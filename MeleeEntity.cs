using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEntity : BaseEntity
{
    private void Update() {
        if(!HasEnemy)
        {
            FindTarget();
        }

        if(!HasEnemy)
            return;

        if(IsInRange && !moving)
        {
            //Attack!
            if(canAttack) //Double check
            {
                Attack();
            }
        }else{
            GetInRange();
        }
    }

    protected override void Attack()
    {
        base.Attack();
        currentTarget.TakeDamage(baseDamage);
    }
}
