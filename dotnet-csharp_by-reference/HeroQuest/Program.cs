using CodingDojo;
using System.Text;

namespace CodingDojo;

public static class Program
{
    public static void Run()
    {
        string playerName = "Conan";
        int playerHealth = 100;
        int playerStrength = 7;
        int playerMagic = 15;
        int playerCraftingSkill = 12;
        string itemName = "Healing Potion";
        string itemKind = "Health";
        int itemPower = 20;
        string enemyName = "Goblin Warlord";
        int enemyPower = 12;

        HeroQuest.Output.AppendLine("=== QUEST BEGINNING ===\n");

        string result = HeroQuest.PlayerToString(playerName, playerHealth, playerStrength,
                playerMagic, playerCraftingSkill);
        HeroQuest.Output.AppendLine(result);

        result = HeroQuest.ItemToString(itemName, itemKind, itemPower);
        HeroQuest.Output.AppendLine(result);

        HeroQuest.Output.AppendLine("--- Exploring the dungeon... ---\n");

        HeroQuest.PlayerFallsDown(playerStrength, ref playerHealth);
        result = HeroQuest.PlayerToString(playerName, playerHealth, playerStrength,
                playerMagic, playerCraftingSkill);
        HeroQuest.Output.AppendLine(result);

        HeroQuest.Output.AppendLine("--- Using the healing item ---\n");

        HeroQuest.ItemApplyEffectToPlayer(
            itemName, itemKind, itemPower, ref playerHealth,
            ref playerStrength, ref playerMagic);

        result = HeroQuest.PlayerToString(playerName, playerHealth, playerStrength,
                playerMagic, playerCraftingSkill);
        HeroQuest.Output.AppendLine(result);

        result = HeroQuest.ItemToString(itemName, itemKind, itemPower);
        HeroQuest.Output.AppendLine(result);

        HeroQuest.Output.AppendLine("--- Item degradation from repeated use ---\n");

        HeroQuest.ItemReduceByUsage(ref itemKind, ref itemPower);
        result = HeroQuest.ItemToString(itemName, itemKind, itemPower);
        HeroQuest.Output.AppendLine(result);

        HeroQuest.ItemReduceByUsage(ref itemKind, ref itemPower);
        result = HeroQuest.ItemToString(itemName, itemKind, itemPower);
        HeroQuest.Output.AppendLine(result);

        HeroQuest.Output.AppendLine("--- Repairing the damaged item ---\n");

        HeroQuest.ItemRepair(playerCraftingSkill, ref itemPower);
        result = HeroQuest.ItemToString(itemName, itemKind, itemPower);
        HeroQuest.Output.AppendLine(result);

        HeroQuest.Output.AppendLine("=== ENEMY ENCOUNTER ===\n");

        result = HeroQuest.EnemyToString(enemyName, enemyPower);
        HeroQuest.Output.AppendLine(result);

        HeroQuest.EnemyAttackPlayer(enemyName, enemyPower,
            playerStrength, ref playerHealth);
        result = HeroQuest.PlayerToString(playerName, playerHealth, playerStrength,
                playerMagic, playerCraftingSkill);
        HeroQuest.Output.AppendLine(result);

        HeroQuest.Output.AppendLine("--- Player retaliates ---\n");

        HeroQuest.PlayerChallengeEnemy(enemyName, playerStrength,
            itemPower, ref enemyPower);
        result = HeroQuest.EnemyToString(enemyName, enemyPower);
        HeroQuest.Output.AppendLine(result);
    }

    public static void Main()
    {
        HeroQuest.Output = new StringBuilder();
        Run();
        Console.WriteLine(HeroQuest.Output);
    }
}
