using CodingDojo;
using System.Text;

namespace CodingDojo;

public static class Program
{
    public static void Run()
    {
        var questData = new QuestData
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

        HeroQuest.Output.AppendLine("=== QUEST BEGINNING ===\n");

        string result = HeroQuest.PlayerToString(questData.PlayerName, questData.PlayerHealth, questData.PlayerStrength,
                questData.PlayerMagic, questData.PlayerCraftingSkill);
        HeroQuest.Output.AppendLine(result);

        result = HeroQuest.ItemToString(questData.ItemName, questData.ItemKind, questData.ItemPower);
        HeroQuest.Output.AppendLine(result);

        HeroQuest.Output.AppendLine("--- Exploring the dungeon... ---\n");

        HeroQuest.PlayerFallsDown(questData);
        result = HeroQuest.PlayerToString(questData.PlayerName, questData.PlayerHealth, questData.PlayerStrength,
                questData.PlayerMagic, questData.PlayerCraftingSkill);
        HeroQuest.Output.AppendLine(result);

        HeroQuest.Output.AppendLine("--- Using the healing item ---\n");

        HeroQuest.ItemApplyEffectToPlayer(questData);
        result = HeroQuest.PlayerToString(questData.PlayerName, questData.PlayerHealth, questData.PlayerStrength,
                questData.PlayerMagic, questData.PlayerCraftingSkill);
        HeroQuest.Output.AppendLine(result);

        result = HeroQuest.ItemToString(questData.ItemName, questData.ItemKind, questData.ItemPower);
        HeroQuest.Output.AppendLine(result);

        HeroQuest.Output.AppendLine("--- Item degradation from repeated use ---\n");

        HeroQuest.ItemReduceByUsage(questData);
        result = HeroQuest.ItemToString(questData.ItemName, questData.ItemKind, questData.ItemPower);
        HeroQuest.Output.AppendLine(result);

        HeroQuest.ItemReduceByUsage(questData);
        result = HeroQuest.ItemToString(questData.ItemName, questData.ItemKind, questData.ItemPower);
        HeroQuest.Output.AppendLine(result);

        HeroQuest.Output.AppendLine("--- Repairing the damaged item ---\n");

        HeroQuest.ItemRepair(questData);
        result = HeroQuest.ItemToString(questData.ItemName, questData.ItemKind, questData.ItemPower);
        HeroQuest.Output.AppendLine(result);

        HeroQuest.Output.AppendLine("=== ENEMY ENCOUNTER ===\n");

        result = HeroQuest.EnemyToString(questData.EnemyName, questData.EnemyPower);
        HeroQuest.Output.AppendLine(result);

        HeroQuest.EnemyAttackPlayer(questData);
        result = HeroQuest.PlayerToString(questData.PlayerName, questData.PlayerHealth, questData.PlayerStrength,
                questData.PlayerMagic, questData.PlayerCraftingSkill);
        HeroQuest.Output.AppendLine(result);

        HeroQuest.Output.AppendLine("--- Player retaliates ---\n");

        HeroQuest.PlayerChallengeEnemy(questData);
        result = HeroQuest.EnemyToString(questData.EnemyName, questData.EnemyPower);
        HeroQuest.Output.AppendLine(result);
    }

    public static void Main()
    {
        HeroQuest.Output = new StringBuilder();
        Run();
        Console.WriteLine(HeroQuest.Output);
    }
}
