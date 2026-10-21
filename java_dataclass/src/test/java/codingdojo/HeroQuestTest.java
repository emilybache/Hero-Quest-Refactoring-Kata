package codingdojo;

import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;

import static org.junit.jupiter.api.Assertions.assertEquals;

public class HeroQuestTest {

    private QuestData questData;

    @BeforeEach
    void SetUp() {
        HeroQuest.output.setLength(0);
        questData = new QuestData();
        questData.setPlayerName("Conan");
        questData.setPlayerHealth(100);
        questData.setPlayerStrength(20);
        questData.setPlayerMagic(10);
        questData.setPlayerCraftingSkill(10);
        questData.setItemName("Amulet of Strength");
        questData.setItemKind("Strength");
        questData.setItemPower(10);
        questData.setEnemyName("Goblin");
        questData.setEnemyPower(5);
    }

    @Test
    void playerToString() {
        var result = HeroQuest.playerToString(questData.getPlayerName(),
                questData.getPlayerHealth(), questData.getPlayerStrength(), questData.getPlayerMagic(), questData.getPlayerCraftingSkill());

        var expected = "Conan's Attributes:\nHealth: 100\nStrength: 20\nMagic: " +
                "10\nCrafting " +
                "Skill: 10\n";

        assertEquals(expected, result);
    }

    @Test
    void playerFallsDown() {
        questData.setPlayerStrength(3);
        HeroQuest.playerFallsDown(questData);
        assertEquals(90, questData.getPlayerHealth());
    }

    @Test
    void playerFallsDownNoDamage() {
        HeroQuest.playerFallsDown(questData);
        assertEquals(100, questData.getPlayerHealth());
    }

    @Test
    void itemToString() {
        var result = HeroQuest.itemToString(questData.getItemName(), questData.getItemKind(), questData.getItemPower());
        var expected = "Item: Amulet of Strength\nKind: Strength\nPower: 10\n";
        assertEquals(expected, result);
    }

    @Test
    void itemReduceByUsage() {
        HeroQuest.itemReduceByUsage(questData);
        assertEquals(5, questData.getItemPower());
    }

    @Test
    void itemReduceByUsageToJunk() {
        questData.setItemPower(1);
        HeroQuest.itemReduceByUsage(questData);
        assertEquals(0, questData.getItemPower());
        assertEquals("Junk", questData.getItemKind());
    }

    @Test
    void itemApplyEffectToPlayer() {
        HeroQuest.itemApplyEffectToPlayer(questData);
        assertEquals(30, questData.getPlayerStrength());
    }

    @Test
    void itemApplyEffectToPlayerJunk() {
        questData.setItemKind("Junk");
        HeroQuest.itemApplyEffectToPlayer(questData);
        assertEquals(20, questData.getPlayerStrength());
    }

    @Test
    void itemRepair() {
        HeroQuest.itemRepair(questData);
        assertEquals(26, questData.getItemPower());
    }

    @Test
    void enemyToString() {
        var result = HeroQuest.enemyToString(questData.getEnemyName(), questData.getEnemyPower());
        var expected = "Enemy: Goblin\nPower: 5\n";
        assertEquals(expected, result);
    }

    @Test
    void enemyAttackPlayer() {
        HeroQuest.enemyAttackPlayer(questData);
        assertEquals(98, questData.getPlayerHealth());
    }

    @Test
    void playerChallengeEnemy() {
        HeroQuest.playerChallengeEnemy(questData);
        assertEquals(-7, questData.getEnemyPower());
    }
}
