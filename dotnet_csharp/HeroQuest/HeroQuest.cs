namespace CodingDojo;

using System.Text;

public static class HeroQuest
{
    public static StringBuilder Output { get; set; } = new();

    public static string PlayerToString(QuestData questData)
    {
        return
            $"{questData.PlayerName}'s Attributes:\nHealth: {questData.PlayerHealth}\nStrength: {questData.PlayerStrength}\nMagic: {questData.PlayerMagic}\nCrafting Skill: {questData.PlayerCraftingSkill}\n";
    }
    
    public static string EnemyToString(QuestData questData)
    {
        return $"Enemy: {questData.EnemyName}\nPower: {questData.EnemyPower}\n";
    }
    
    public static String ItemToString(QuestData questData)
    {
        return $"Item: {questData.ItemName}\nKind: {questData.ItemKind}\nPower: {questData.ItemPower}\n";
    }

    public static void PlayerFallsDown(QuestData questData)
    {
        Output.AppendLine("Player drops off a cliff.");
        if (questData.PlayerStrength < 5)
        {
            questData.PlayerHealth = questData.PlayerHealth - 10;
            Output.AppendLine("Player's strength is too small. Health decreases by 10.");
        }
    }

    public static void ItemReduceByUsage(QuestData questData)
    {
        Output.AppendLine($"Using the item with kind '{questData.ItemKind}' and power {questData.ItemPower}");
        questData.ItemPower = questData.ItemPower / 2;
        if (questData.ItemPower == 0)
        {
            questData.ItemKind = "Junk";
        }
    }
    
    public static void ItemApplyEffectToPlayer(QuestData data) {
        Output.AppendLine($"Applying the effect of {data.ItemName} ({data.ItemKind}):");

        if (data.ItemKind == "Health") {
            data.PlayerHealth = data.PlayerHealth + data.ItemPower;
        } else if (data.ItemKind == "Strength") {
            data.PlayerStrength = data.PlayerStrength + data.ItemPower;
        } else if (data.ItemKind == "Magic") {
            data.PlayerMagic = data.PlayerMagic + data.ItemPower;
        } else {
            // ignore unknown item kind
        }
    }
    
    public static void ItemRepair(QuestData questData) {
        Output.AppendLine("Using the repair skill to fix the item:");

        int repairAmount = -5 + ((questData.PlayerCraftingSkill) * 2) + 1;

        questData.ItemPower =  (questData.ItemPower + repairAmount);

        Output.AppendLine($"Repaired the item by {repairAmount} points. Item's Durability: {questData.ItemPower}");
    }
    

    
    public static void EnemyAttackPlayer(QuestData questData)
    {
        Output.AppendLine($"The enemy '{questData.EnemyName}' attacks!");
        int damage = questData.EnemyPower;
        
        if (questData.PlayerStrength > questData.EnemyPower)
        {
            damage = damage / 2;
            Output.AppendLine("Player's strength allows them to reduce the damage!");
        }
        
        questData.PlayerHealth = questData.PlayerHealth - damage;
        Output.AppendLine($"Player takes {damage} damage. Health is now: {questData.PlayerHealth}");
    }
    
    public static void PlayerChallengeEnemy(QuestData questData)
    {
        Output.AppendLine($"The player challenges {questData.EnemyName}!");
        int playerAttackPower = questData.PlayerStrength + (questData.ItemPower > 0 ? questData.ItemPower / 2 : 0);
        
        if (playerAttackPower > questData.EnemyPower)
        {
            questData.EnemyPower = questData.EnemyPower - (playerAttackPower / 2);
            Output.AppendLine($"The player defeats the enemy! Enemy power reduced to {questData.EnemyPower}");
        }
        else
        {
            Output.AppendLine("The enemy is too strong. The player retreats!");
        }
    }
}