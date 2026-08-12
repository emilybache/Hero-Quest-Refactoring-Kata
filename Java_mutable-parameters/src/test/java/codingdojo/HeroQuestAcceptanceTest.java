package codingdojo;

import org.approvaltests.Approvals;
import org.junit.jupiter.api.Test;

public class HeroQuestAcceptanceTest {

    @Test
    public void fullScenario() {
        HeroQuest.output.setLength(0);

        String playerName = "Conan";
        int[] playerHealth = new int[]{100};
        int[] playerStrength = new int[]{7};
        int[] playerMagic = new int[]{15};
        int playerCraftingSkill = 12;
        String itemName = "Healing Potion";
        String[] itemKind = new String[]{"Health"};
        int[] itemPower = new int[]{20};
        String enemyName = "Goblin Warlord";
        int[] enemyPower = new int[]{12};

        HeroQuest.output.append("=== QUEST BEGINNING ===\n\n");
        String result = HeroQuest.playerToString(playerName, playerHealth[0], playerStrength[0],
                playerMagic[0], playerCraftingSkill);
        HeroQuest.output.append(result).append("\n");

        result = HeroQuest.itemToString(itemName, itemKind[0], itemPower[0]);
        HeroQuest.output.append(result).append("\n");

        HeroQuest.output.append("--- Exploring the dungeon... ---\n\n");

        HeroQuest.playerFallsDown(playerHealth, playerStrength);

        result = HeroQuest.playerToString(playerName, playerHealth[0], playerStrength[0],
                playerMagic[0], playerCraftingSkill);
        HeroQuest.output.append(result).append("\n");

        HeroQuest.output.append("--- Using the healing item ---\n\n");
        HeroQuest.itemApplyEffectToPlayer(
                itemName, itemKind, itemPower[0], playerHealth,
                playerStrength, playerMagic);

        result = HeroQuest.playerToString(playerName, playerHealth[0], playerStrength[0],
                playerMagic[0], playerCraftingSkill);
        HeroQuest.output.append(result).append("\n");

        result = HeroQuest.itemToString(itemName, itemKind[0], itemPower[0]);
        HeroQuest.output.append(result).append("\n");

        HeroQuest.output.append("--- Item degradation from repeated use ---\n\n");
        HeroQuest.itemReduceByUsage(itemKind, itemPower);
        result = HeroQuest.itemToString(itemName, itemKind[0], itemPower[0]);
        HeroQuest.output.append(result).append("\n");

        HeroQuest.itemReduceByUsage(itemKind, itemPower);
        result = HeroQuest.itemToString(itemName, itemKind[0], itemPower[0]);
        HeroQuest.output.append(result).append("\n");

        HeroQuest.output.append("--- Repairing the damaged item ---\n\n");
        HeroQuest.itemRepair(itemPower, playerCraftingSkill);
        result = HeroQuest.itemToString(itemName, itemKind[0], itemPower[0]);
        HeroQuest.output.append(result).append("\n");

        HeroQuest.output.append("=== ENEMY ENCOUNTER ===\n\n");
        result = HeroQuest.enemyToString(enemyName, enemyPower[0]);
        HeroQuest.output.append(result).append("\n");

        HeroQuest.enemyAttackPlayer(enemyName, enemyPower[0],
                playerStrength, playerHealth);

        result = HeroQuest.playerToString(playerName, playerHealth[0], playerStrength[0],
                playerMagic[0], playerCraftingSkill);
        HeroQuest.output.append(result).append("\n");

        HeroQuest.output.append("--- Player retaliates ---\n\n");
        HeroQuest.playerChallengeEnemy(enemyName, playerStrength,
                itemPower, enemyPower);

        result = HeroQuest.enemyToString(enemyName, enemyPower[0]);
        HeroQuest.output.append(result).append("\n");

        Approvals.verify(HeroQuest.output.toString());
    }
}
