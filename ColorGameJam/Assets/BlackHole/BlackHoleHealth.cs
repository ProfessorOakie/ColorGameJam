using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BlackHole))]
public class BlackHoleHealth : Health {

    public override void TakeDamage(float baseDamage, Player.ColorColor col, float colorCorrectDamage)
    {
        if (col != GetComponent<BlackHole>().GetCoreColor())
            TakeDamage(colorCorrectDamage);
        TakeDamage(baseDamage);
    }

}
