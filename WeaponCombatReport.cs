using System.Collections.Generic;
/// <summary>
/// Todo
/// </summary>
public class TalonCombatResultReport
{
    private List<WeaponCombatOrder> weaponCombatOrderList = new List<WeaponCombatOrder>();
    private bool destructableDestroyed = false;
    private bool setDestructableDestroyed = false;
    private int shotHit = int.MinValue;
    private int damageReceived = int.MinValue;
    private int damageMitigated = int.MinValue;
}