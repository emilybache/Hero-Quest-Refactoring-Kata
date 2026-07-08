using CodingDojo;

QuestData questData = new ()
{
 PlayerName = "Conan",
 PlayerHealth = 100,
 PlayerStrength = 7,
 PlayerMagic = 15,
 PlayerCraftingSkill = 12,
 ItemName = "Healing Potion",
 ItemKind = "Health",
 ItemPower = 20,
 EnemyName = "Goblin Warlord",
 EnemyPower = 12
};

Console.WriteLine("=== QUEST BEGINNING ===\n");
string result = HeroQuest.PlayerToString(questData.PlayerName, questData.PlayerHealth, questData.PlayerStrength, questData.PlayerMagic, questData.PlayerCraftingSkill);
Console.WriteLine(result);

result = HeroQuest.ItemToString(questData.ItemName, questData.ItemKind, questData.ItemPower);
Console.WriteLine(result);

Console.WriteLine("--- Exploring the dungeon... ---\n");
HeroQuest.PlayerFallsDown(questData);
result = HeroQuest.PlayerToString(questData.PlayerName, questData.PlayerHealth, questData.PlayerStrength, questData.PlayerMagic, questData.PlayerCraftingSkill);
Console.WriteLine(result);

Console.WriteLine("--- Using the healing item ---\n");
HeroQuest.ItemApplyEffectToPlayer(questData);
result = HeroQuest.PlayerToString(questData.PlayerName, questData.PlayerHealth, questData.PlayerStrength, questData.PlayerMagic, questData.PlayerCraftingSkill);
Console.WriteLine(result);

result = HeroQuest.ItemToString(questData.ItemName, questData.ItemKind, questData.ItemPower);
Console.WriteLine(result);

Console.WriteLine("--- Item degradation from repeated use ---\n");
HeroQuest.ItemReduceByUsage(questData);
result = HeroQuest.ItemToString(questData.ItemName, questData.ItemKind, questData.ItemPower);
Console.WriteLine(result);

HeroQuest.ItemReduceByUsage(questData);
result = HeroQuest.ItemToString(questData.ItemName, questData.ItemKind, questData.ItemPower);
Console.WriteLine(result);

Console.WriteLine("--- Repairing the damaged item ---\n");
HeroQuest.ItemRepair(questData);
result = HeroQuest.ItemToString(questData.ItemName, questData.ItemKind, questData.ItemPower);
Console.WriteLine(result);

Console.WriteLine("=== ENEMY ENCOUNTER ===\n");
result = HeroQuest.EnemyToString(questData.EnemyName, questData.EnemyPower);
Console.WriteLine(result);

HeroQuest.EnemyAttackPlayer(questData);
result = HeroQuest.PlayerToString(questData.PlayerName, questData.PlayerHealth, questData.PlayerStrength, questData.PlayerMagic, questData.PlayerCraftingSkill);
Console.WriteLine(result);

Console.WriteLine("--- Player retaliates ---\n");
HeroQuest.PlayerChallengeEnemy(questData);
result = HeroQuest.EnemyToString(questData.EnemyName, questData.EnemyPower);
Console.WriteLine(result);
