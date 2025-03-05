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
 ItemPower = 10
};

string result = HeroQuest.PlayerToString(questData.PlayerName, questData.PlayerHealth, questData.PlayerStrength, questData.PlayerMagic, questData.PlayerCraftingSkill);
Console.WriteLine(result);

result = HeroQuest.ItemToString(questData.ItemName, questData.ItemKind, questData.ItemPower);
Console.WriteLine(result);

HeroQuest.ItemApplyEffectToPlayer(questData);
HeroQuest.ItemReduceByUsage(questData);

result = HeroQuest.PlayerToString(questData.PlayerName, questData.PlayerHealth, questData.PlayerStrength, questData.PlayerMagic, questData.PlayerCraftingSkill);
Console.WriteLine(result);

result = HeroQuest.ItemToString(questData.ItemName, questData.ItemKind, questData.ItemPower);
Console.WriteLine(result);

Console.WriteLine("Player tries to repair item...");
HeroQuest.ItemRepair(questData);

result = HeroQuest.ItemToString(questData.ItemName, questData.ItemKind, questData.ItemPower);
Console.WriteLine(result);

