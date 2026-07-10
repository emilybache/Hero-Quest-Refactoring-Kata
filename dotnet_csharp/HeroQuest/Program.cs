using CodingDojo;
using System.Text;

HeroQuest.Output = new StringBuilder();

QuestData questData = new()
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

Console.Out.WriteLine(HeroQuest.PlayerToString(questData.PlayerName, questData.PlayerHealth, questData.PlayerStrength,
    questData.PlayerMagic, questData.PlayerCraftingSkill));