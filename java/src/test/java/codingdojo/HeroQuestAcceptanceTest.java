package codingdojo;

import org.approvaltests.Approvals;
import org.junit.jupiter.api.Test;

public class HeroQuestAcceptanceTest {

    @Test
    public void fullScenario() {
        HeroQuest.output.setLength(0);

        QuestData questData = new QuestData();
        questData.playerName = "Conan";
        questData.playerHealth = 100;
        questData.playerStrength = 7;
        questData.playerMagic = 15;
        questData.playerCraftingSkill = 12;
        questData.itemName = "Healing Potion";
        questData.itemKind = "Health";
        questData.itemPower = 20;
        questData.enemyName = "Goblin Warlord";
        questData.enemyPower = 12;

        HeroQuest.output.append("=== QUEST BEGINNING ===\n\n");
        String result = HeroQuest.playerToString(questData.playerName, questData.playerHealth, questData.playerStrength,
                questData.playerMagic, questData.playerCraftingSkill);
        HeroQuest.output.append(result).append("\n");

        result = HeroQuest.itemToString(questData.itemName, questData.itemKind, questData.itemPower);
        HeroQuest.output.append(result).append("\n");

        HeroQuest.output.append("--- Exploring the dungeon... ---\n\n");
        questData.playerHealth = HeroQuest.playerFallsDown(questData.playerStrength, questData.playerHealth);
        result = HeroQuest.playerToString(questData.playerName, questData.playerHealth, questData.playerStrength,
                questData.playerMagic, questData.playerCraftingSkill);
        HeroQuest.output.append(result).append("\n");

        HeroQuest.output.append("--- Using the healing item ---\n\n");
        HeroQuest.ItemEffectResult effectResult = HeroQuest.itemApplyEffectToPlayer(
                questData.itemName, questData.itemKind, questData.itemPower, questData.playerHealth,
                questData.playerStrength, questData.playerMagic);
        questData.playerHealth = effectResult.playerHealth;
        questData.playerStrength = effectResult.playerStrength;
        questData.playerMagic = effectResult.playerMagic;

        result = HeroQuest.playerToString(questData.playerName, questData.playerHealth, questData.playerStrength,
                questData.playerMagic, questData.playerCraftingSkill);
        HeroQuest.output.append(result).append("\n");

        result = HeroQuest.itemToString(questData.itemName, questData.itemKind, questData.itemPower);
        HeroQuest.output.append(result).append("\n");

        HeroQuest.output.append("--- Item degradation from repeated use ---\n\n");
        HeroQuest.ItemUsageResult usageResult = HeroQuest.itemReduceByUsage(questData.itemKind, questData.itemPower);
        questData.itemKind = usageResult.itemKind;
        questData.itemPower = usageResult.itemPower;
        result = HeroQuest.itemToString(questData.itemName, questData.itemKind, questData.itemPower);
        HeroQuest.output.append(result).append("\n");

        usageResult = HeroQuest.itemReduceByUsage(questData.itemKind, questData.itemPower);
        questData.itemKind = usageResult.itemKind;
        questData.itemPower = usageResult.itemPower;
        result = HeroQuest.itemToString(questData.itemName, questData.itemKind, questData.itemPower);
        HeroQuest.output.append(result).append("\n");

        HeroQuest.output.append("--- Repairing the damaged item ---\n\n");
        questData.itemPower = HeroQuest.itemRepair(questData.playerCraftingSkill, questData.itemPower);
        result = HeroQuest.itemToString(questData.itemName, questData.itemKind, questData.itemPower);
        HeroQuest.output.append(result).append("\n");

        HeroQuest.output.append("=== ENEMY ENCOUNTER ===\n\n");
        result = HeroQuest.enemyToString(questData.enemyName, questData.enemyPower);
        HeroQuest.output.append(result).append("\n");

        questData.playerHealth = HeroQuest.enemyAttackPlayer(questData.enemyName, questData.enemyPower,
                questData.playerStrength, questData.playerHealth);
        result = HeroQuest.playerToString(questData.playerName, questData.playerHealth, questData.playerStrength,
                questData.playerMagic, questData.playerCraftingSkill);
        HeroQuest.output.append(result).append("\n");

        HeroQuest.output.append("--- Player retaliates ---\n\n");
        questData.enemyPower = HeroQuest.playerChallengeEnemy(questData.enemyName, questData.playerStrength,
                questData.itemPower, questData.enemyPower);
        result = HeroQuest.enemyToString(questData.enemyName, questData.enemyPower);
        HeroQuest.output.append(result).append("\n");

        Approvals.verify(HeroQuest.output.toString());
    }
}
