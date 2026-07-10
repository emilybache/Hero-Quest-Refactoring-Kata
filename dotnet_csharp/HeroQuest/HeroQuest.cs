namespace CodingDojo;

using System.Text;

public static class HeroQuest
{
    public static StringBuilder Output { get; set; } = new();

    public static string PlayerToString(string? playerName, int playerHealth, int playerStrength, int playerMagic,
        int playerCraftingSkill)
    {
        return
            $"{playerName}'s Attributes:\nHealth: {playerHealth}\nStrength: {playerStrength}\nMagic: {playerMagic}\nCrafting Skill: {playerCraftingSkill}\n";
    }

    public static string EnemyToString(string? enemyName, int enemyPower)
    {
        return $"Enemy: {enemyName}\nPower: {enemyPower}\n";
    }

    public static string ItemToString(string? itemName, string? itemKind, int itemPower)
    {
        return $"Item: {itemName}\nKind: {itemKind}\nPower: {itemPower}\n";
    }

    public static int PlayerFallsDown(int playerStrength, int playerHealth)
    {
        Output.AppendLine("Player drops off a cliff.");
        if (playerStrength < 5)
        {
            playerHealth = playerHealth - 10;
            Output.AppendLine("Player's strength is too small. Health decreases by 10.");
        }

        return playerHealth;
    }

    public static (string? ItemKind, int ItemPower) ItemReduceByUsage(string? itemKind, int itemPower)
    {
        Output.AppendLine($"Using the item with kind '{itemKind}' and power {itemPower}");
        itemPower = itemPower / 2;
        if (itemPower == 0)
        {
            itemKind = "Junk";
        }

        return (itemKind, itemPower);
    }

    public static (int PlayerHealth, int PlayerStrength, int PlayerMagic) ItemApplyEffectToPlayer(string? itemName,
        string? itemKind, int itemPower, int playerHealth, int playerStrength, int playerMagic)
    {
        Output.AppendLine($"Applying the effect of {itemName} ({itemKind}):");

        if (itemKind == "Health")
        {
            playerHealth = playerHealth + itemPower;
        }
        else if (itemKind == "Strength")
        {
            playerStrength = playerStrength + itemPower;
        }
        else if (itemKind == "Magic")
        {
            playerMagic = playerMagic + itemPower;
        }
        else
        {
            // ignore unknown item kind
        }

        return (playerHealth, playerStrength, playerMagic);
    }

    public static int ItemRepair(int playerCraftingSkill, int itemPower)
    {
        Output.AppendLine("Using the repair skill to fix the item:");

        int repairAmount = -5 + (playerCraftingSkill * 2) + 1;

        itemPower = itemPower + repairAmount;

        Output.AppendLine($"Repaired the item by {repairAmount} points. Item's Durability: {itemPower}");

        return itemPower;
    }


    public static int EnemyAttackPlayer(string? enemyName, int enemyPower, int playerStrength, int playerHealth)
    {
        Output.AppendLine($"The enemy '{enemyName}' attacks!");
        int damage = enemyPower;

        if (playerStrength > enemyPower)
        {
            damage = damage / 2;
            Output.AppendLine("Player's strength allows them to reduce the damage!");
        }

        playerHealth = playerHealth - damage;
        Output.AppendLine($"Player takes {damage} damage. Health is now: {playerHealth}");

        return playerHealth;
    }

    public static int PlayerChallengeEnemy(string? enemyName, int playerStrength, int itemPower, int enemyPower)
    {
        Output.AppendLine($"The player challenges {enemyName}!");
        int playerAttackPower = playerStrength + (itemPower > 0 ? itemPower / 2 : 0);

        if (playerAttackPower > enemyPower)
        {
            enemyPower = enemyPower - (playerAttackPower / 2);
            Output.AppendLine($"The player defeats the enemy! Enemy power reduced to {enemyPower}");
        }
        else
        {
            Output.AppendLine("The enemy is too strong. The player retreats!");
        }

        return enemyPower;
    }
}