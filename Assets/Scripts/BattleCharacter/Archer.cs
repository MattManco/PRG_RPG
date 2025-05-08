using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer : BattleCharacter
{
    public override bool LevelUp()
    {
        //Dostuff()

        base.LevelUp(); //<- Is what the Base (BattleCharacter) class does

        //DoMoreStuff();

        return false;
    }
}
