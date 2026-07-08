using CodingDojo;

QuestData questData = new ()
{
 PlayerName = "Conan",
 PlayerHealth = 100,
 PlayerStrength = 20,
 PlayerMagic = 10,
 PlayerCraftingSkill = 10,
 ItemName = "Amulet of Strength",
 ItemKind = "Strength",
 ItemPower = 10,
 EnemyName = "Shadow Dragon",
 EnemyPower = 15
};

Console.WriteLine("\n--- Game Start: Inventory  ---");
string result = HeroQuest.PlayerToString(questData.PlayerName, questData.PlayerHealth, questData.PlayerStrength, questData.PlayerMagic, questData.PlayerCraftingSkill);
Console.WriteLine(result);

result = HeroQuest.ItemToString(questData.ItemName, questData.ItemKind, questData.ItemPower);
Console.WriteLine(result);

result = HeroQuest.EnemyToString(questData.EnemyName, questData.EnemyPower);
Console.WriteLine(result);

Console.WriteLine("\n--- Player using item  ---");
HeroQuest.ItemApplyEffectToPlayer(questData);
HeroQuest.ItemReduceByUsage(questData);

result = HeroQuest.PlayerToString(questData.PlayerName, questData.PlayerHealth, questData.PlayerStrength, questData.PlayerMagic, questData.PlayerCraftingSkill);
Console.WriteLine(result);

result = HeroQuest.ItemToString(questData.ItemName, questData.ItemKind, questData.ItemPower);
Console.WriteLine(result);

HeroQuest.ItemRepair(questData);

result = HeroQuest.ItemToString(questData.ItemName, questData.ItemKind, questData.ItemPower);
Console.WriteLine(result);

Console.WriteLine("\n--- Enemy Encounter ---");

HeroQuest.EnemyAttackPlayer(questData);

result = HeroQuest.PlayerToString(questData.PlayerName, questData.PlayerHealth, questData.PlayerStrength, questData.PlayerMagic, questData.PlayerCraftingSkill);
Console.WriteLine(result);

HeroQuest.PlayerChallengeEnemy(questData);

result = HeroQuest.EnemyToString(questData.EnemyName, questData.EnemyPower);
Console.WriteLine(result);
