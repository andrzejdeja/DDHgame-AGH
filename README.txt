MONSTERS:

SQdragon class implements Silverquick Dragon that has:
2 attacks (magical and physical)
30% for magic attack
10% for critical hit

Critical hit doubles damage

When dragon's hp is lower than 20%, it deals more damage and takes less damage:
45% for magic attack
20% for critical hit
Player's damage is reduced by 50%

Property HealthMax is used to control percentage of hp.

QSDragonFactory class is basic factory for SQDragon.


DemonFactory class is factory that returns 3 diffrent Demons: Demon, AngryDemon and CruelDemon; in this order. 

Demon class implements Demon that has only one attack and no logic.

AngryDemon class implements Angry Demon. It has higher stats than basic Demon, but behaves the same way.

CruelDemon class implements Cruel Demon. 
It has higher stats that Angry Demon and deals additional 20% more damage, when it's hp drops under 20%.

WEAPONS (swords):

VampiricFalchion class implements Vampiric Falchion. It absorbs damage equal to 15% of dealt damage.

TraitorsBlade class implements Traitor's Blade. It increases dealt damage by 30% and received damage by 20%.

LuckySword class implements Lucky Sword. It has 15% for critical hit.

UncommonWeaponFactory returns those 3 swords.

SKILLS:

SwordCleave class implements Sword Cleave: 
0.56*Strength + 0.18*Precision (incised damage)
Stamina: 40
Minlevel: 12

SwordLunge class implements Sword Lunge:
0.12*Strength + 0.28*Precision (stab damage)
0.12*Strength + 0.22*Precision (incised damage)
Stamina: 25
Minlevel: 7

SwordWhirlwind class implements Sword Whirlwind:
0.24*Strength + 0.64*Precision (incised damage)
Stamina: 35
Minlevel: 17

The above skills have coresponding decorators.

AdvancedWeaponMoveFactory returns those skilla and can combine two skills into combo, similarly to BasicSpellFactory.

Other notes:
Displayed damage is wrong, as far as I checked it doesn't consider modifications made by ModifyOffensive and ModifyDeffensive.
Once character died after dealing fatal hit. Couldn't replicate.
