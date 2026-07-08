namespace CodingDojo;

public static class HeroQuest
{
    public static string PlayerToString(string playerName, int playerHealth, int playerStrength, int playerMagic,
        int playerCraftingSkill)
    {
        return
            $"{playerName}'s Attributes:\nHealth: {playerHealth}\nStrength: {playerStrength}\nMagic: {playerMagic}\nCrafting Skill: {playerCraftingSkill}\n";
    }

    public static void PlayerFallsDown(QuestData questData)
    {
        Console.WriteLine("Player drops off a cliff.");
        if (questData.PlayerStrength < 5)
        {
            questData.PlayerHealth = questData.PlayerHealth - 10;
            Console.WriteLine("Player's strength is too small. Health decreases by 10.");
        }
    }

    public static String ItemToString(String itemName, String itemKind, int itemPower)
    {
        return $"Item: {itemName}\nKind: {itemKind}\nPower: {itemPower}\n";
    }

    public static void ItemReduceByUsage(QuestData questData)
    {
        Console.WriteLine($"Using the item with kind '{questData.ItemKind}' and power {questData.ItemPower}");
        questData.ItemPower = questData.ItemPower / 2;
        if (questData.ItemPower == 0)
        {
            questData.ItemKind = "Junk";
        }
    }
    
    public static void ItemApplyEffectToPlayer(QuestData data) {
       Console.WriteLine($"Applying the effect of {data.ItemName} ({data.ItemKind}):");

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
       Console.WriteLine("Using the repair skill to fix the item:");

        int repairAmount = -5 + ((questData.PlayerCraftingSkill) * 2) + 1;

        questData.ItemPower =  (questData.ItemPower + repairAmount);

        Console.WriteLine($"Repaired the item by {repairAmount} points. Item's Durability: {questData.ItemPower}");
    }
    
    public static string EnemyToString(string enemyName, int enemyPower)
    {
        return $"Enemy: {enemyName}\nPower: {enemyPower}\n";
    }
    
    public static void EnemyAttackPlayer(QuestData questData)
    {
        Console.WriteLine($"The enemy '{questData.EnemyName}' attacks!");
        int damage = questData.EnemyPower;
        
        if (questData.PlayerStrength > questData.EnemyPower)
        {
            damage = damage / 2;
            Console.WriteLine("Player's strength allows them to reduce the damage!");
        }
        
        questData.PlayerHealth = questData.PlayerHealth - damage;
        Console.WriteLine($"Player takes {damage} damage. Health is now: {questData.PlayerHealth}");
    }
    
    public static void PlayerChallengeEnemy(QuestData questData)
    {
        Console.WriteLine($"The player challenges {questData.EnemyName}!");
        int playerAttackPower = questData.PlayerStrength + (questData.ItemPower > 0 ? questData.ItemPower / 2 : 0);
        
        if (playerAttackPower > questData.EnemyPower)
        {
            questData.EnemyPower = questData.EnemyPower - (playerAttackPower / 2);
            Console.WriteLine($"The player defeats the enemy! Enemy power reduced to {questData.EnemyPower}");
        }
        else
        {
            Console.WriteLine("The enemy is too strong. The player retreats!");
        }
    }
}