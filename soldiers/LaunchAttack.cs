// static void LaunchAttack(Team attackerTeam, Team targetTeam)
// {
//     Random random = new Random();
//     Soldier attacker = GetRandomAliveSoldier(attackerTeam, random);
//     Soldier target = GetRandomAliveSoldier(targetTeam, random);

//     if (attacker != null && target != null)
//     {
//         int calculatedDamages = (int)(attacker.AttackPower * random.NextDouble());
//         attacker.Attack(target);
//     }
// }

// static Soldier GetRandomAliveSoldier(Team team, Random random)
// {
//     List<Soldier> aliveSoldiers = team.Soldiers.Where(soldier => soldier.Hp > 0).ToList();
//     return aliveSoldiers.Count > 0 ? aliveSoldiers[random.Next(aliveSoldiers.Count)] : null;
// }