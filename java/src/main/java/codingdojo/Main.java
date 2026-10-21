package codingdojo;

public class Main {

    public static void run() {
        String playerName = "Conan";
        int playerHealth = 100;
        int playerStrength = 7;
        int playerMagic = 15;
        int playerCraftingSkill = 12;
        String itemName = "Healing Potion";
        String itemKind = "Health";
        int itemPower = 20;
        String enemyName = "Goblin Warlord";
        int enemyPower = 12;

        HeroQuest.output.append("=== QUEST BEGINNING ===\n\n");

        String result = HeroQuest.playerToString(playerName, playerHealth, playerStrength,
                playerMagic, playerCraftingSkill);
        HeroQuest.output.append(result).append("\n");

        result = HeroQuest.itemToString(itemName, itemKind, itemPower);
        HeroQuest.output.append(result).append("\n");

        HeroQuest.output.append("--- Exploring the dungeon... ---\n\n");

        playerHealth = HeroQuest.playerFallsDown(playerStrength, playerHealth);
        result = HeroQuest.playerToString(playerName, playerHealth, playerStrength,
                playerMagic, playerCraftingSkill);
        HeroQuest.output.append(result).append("\n");

        HeroQuest.output.append("--- Using the healing item ---\n\n");

        HeroQuest.ItemEffectResult effectResult = HeroQuest.itemApplyEffectToPlayer(
                itemName, itemKind, itemPower, playerHealth,
                playerStrength, playerMagic);
        playerHealth = effectResult.playerHealth;
        playerStrength = effectResult.playerStrength;
        playerMagic = effectResult.playerMagic;

        result = HeroQuest.playerToString(playerName, playerHealth, playerStrength,
                playerMagic, playerCraftingSkill);
        HeroQuest.output.append(result).append("\n");

        result = HeroQuest.itemToString(itemName, itemKind, itemPower);
        HeroQuest.output.append(result).append("\n");

        HeroQuest.output.append("--- Item degradation from repeated use ---\n\n");

        HeroQuest.ItemUsageResult usageResult = HeroQuest.itemReduceByUsage(itemKind, itemPower);
        itemKind = usageResult.itemKind;
        itemPower = usageResult.itemPower;
        result = HeroQuest.itemToString(itemName, itemKind, itemPower);
        HeroQuest.output.append(result).append("\n");

        usageResult = HeroQuest.itemReduceByUsage(itemKind, itemPower);
        itemKind = usageResult.itemKind;
        itemPower = usageResult.itemPower;
        result = HeroQuest.itemToString(itemName, itemKind, itemPower);
        HeroQuest.output.append(result).append("\n");

        HeroQuest.output.append("--- Repairing the damaged item ---\n\n");

        itemPower = HeroQuest.itemRepair(playerCraftingSkill, itemPower);
        result = HeroQuest.itemToString(itemName, itemKind, itemPower);
        HeroQuest.output.append(result).append("\n");

        HeroQuest.output.append("=== ENEMY ENCOUNTER ===\n\n");

        result = HeroQuest.enemyToString(enemyName, enemyPower);
        HeroQuest.output.append(result).append("\n");

        playerHealth = HeroQuest.enemyAttackPlayer(enemyName, enemyPower,
                playerStrength, playerHealth);
        result = HeroQuest.playerToString(playerName, playerHealth, playerStrength,
                playerMagic, playerCraftingSkill);
        HeroQuest.output.append(result).append("\n");

        HeroQuest.output.append("--- Player retaliates ---\n\n");

        enemyPower = HeroQuest.playerChallengeEnemy(enemyName, playerStrength,
                itemPower, enemyPower);
        result = HeroQuest.enemyToString(enemyName, enemyPower);
        HeroQuest.output.append(result).append("\n");
    }

    public static void main(String[] args) {
        HeroQuest.output = new StringBuilder();
        run();
        System.out.println(HeroQuest.output);
    }
}
