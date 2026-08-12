package codingdojo;

import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;

import static org.junit.jupiter.api.Assertions.assertEquals;

public class HeroQuestTest {

    private String playerName;
    private int[] playerHealth;
    private int[] playerStrength;
    private int[] playerMagic;
    private int playerCraftingSkill;
    private String itemName;
    private String[] itemKind;
    private int[] itemPower;

    private String enemyName;
    private int[] enemyPower;

    @BeforeEach
    void SetUp() {
        playerName = "Conan";
        playerHealth = new int[] { 100 };
        playerStrength = new int[] { 20 };
        playerMagic = new int[] { 10 };
        playerCraftingSkill = 10;
        itemName = "Amulet of Strength";
        itemKind = new String[] { "Strength" };
        itemPower = new int[] { 10 };
        enemyName = "Goblin Warlord";
        enemyPower = new int[] { 12 };
    }

    @Test
    void enemyToString() {
        var result = HeroQuest.enemyToString(enemyName, enemyPower[0]);
        var expected = "Enemy: Goblin Warlord\nPower: 12\n";
        assertEquals(expected, result);
    }

    @Test
    void enemyAttackPlayer() {
        HeroQuest.enemyAttackPlayer(enemyName, enemyPower[0], playerStrength, playerHealth);
        assertEquals(94, playerHealth[0]);
    }

    @Test
    void playerChallengeEnemy() {
        HeroQuest.playerChallengeEnemy(enemyName, playerStrength, itemPower, enemyPower);
        assertEquals(0, enemyPower[0]);
    }

    @Test
    void playerToString() {
        var result = HeroQuest.playerToString(playerName,
                playerHealth[0], playerStrength[0], playerMagic[0], playerCraftingSkill);

        var expected = "Conan's Attributes:\nHealth: 100\nStrength: 20\nMagic: " +
                "10\nCrafting " +
                "Skill: 10\n";

        assertEquals(expected, result);
    }

    @Test
    void playerFallsDown() {
        playerStrength[0] = 3;
        HeroQuest.playerFallsDown(playerHealth, playerStrength);
        assertEquals(90, playerHealth[0]);
    }

    @Test
    void playerFallsDownNoDamage() {
        HeroQuest.playerFallsDown(playerHealth, playerStrength);
        assertEquals(100, playerHealth[0]);
    }

    @Test
    void itemToString() {
        var result = HeroQuest.itemToString(itemName, itemKind[0], itemPower[0]);
        var expected = "Item: Amulet of Strength\nKind: Strength\nPower: 10\n";
        assertEquals(expected, result);
    }

    @Test
    void itemReduceByUsage() {
        HeroQuest.itemReduceByUsage(itemKind, itemPower);
        assertEquals(5, itemPower[0]);
    }

    @Test
    void itemReduceByUsageToJunk() {
        itemPower[0] = 1;
        HeroQuest.itemReduceByUsage(itemKind, itemPower);
        assertEquals(0, itemPower[0]);
        assertEquals("Junk", itemKind[0]);
    }

    @Test
    void itemApplyEffectToPlayer() {
        HeroQuest.itemApplyEffectToPlayer(itemName,itemKind, itemPower[0], playerHealth, playerStrength, playerMagic);
        assertEquals(30, playerStrength[0]);
    }

    @Test
    void itemApplyEffectToPlayerJunk() {
        itemKind[0] = "Junk";
        HeroQuest.itemApplyEffectToPlayer(itemName,itemKind, itemPower[0], playerHealth, playerStrength, playerMagic);
        assertEquals(20, playerStrength[0]);
    }

    @Test
    void itemRepair() {
        HeroQuest.itemRepair(itemPower, playerCraftingSkill);
        assertEquals(26, itemPower[0]);
    }
}
