package codingdojo;

import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;

import static org.junit.jupiter.api.Assertions.assertEquals;

public class HeroQuestTest {

    private String playerName;
    private int playerHealth;
    private int playerStrength;
    private int playerMagic;
    private int playerCraftingSkill;
    private String itemName;
    private String itemKind;
    private int itemPower;

    @BeforeEach
    void SetUp() {
        HeroQuest.output.setLength(0);
        playerName = "Conan";
        playerHealth = 100;
        playerStrength = 20;
        playerMagic = 10;
        playerCraftingSkill = 10;
        itemName = "Amulet of Strength";
        itemKind = "Strength";
        itemPower = 10;
    }

    @Test
    void playerToString() {
        var result = HeroQuest.playerToString(playerName,
                playerHealth, playerStrength, playerMagic, playerCraftingSkill);

        var expected = "Conan's Attributes:\nHealth: 100\nStrength: 20\nMagic: " +
                "10\nCrafting " +
                "Skill: 10\n";

        assertEquals(expected, result);
    }

    @Test
    void playerFallsDown() {
        playerStrength = 3;
        playerHealth = HeroQuest.playerFallsDown(playerStrength, playerHealth);
        assertEquals(90, playerHealth);
    }

    @Test
    void playerFallsDownNoDamage() {
        playerHealth = HeroQuest.playerFallsDown(playerStrength, playerHealth);
        assertEquals(100, playerHealth);
    }

    @Test
    void itemToString() {
        var result = HeroQuest.itemToString(itemName, itemKind, itemPower);
        var expected = "Item: Amulet of Strength\nKind: Strength\nPower: 10\n";
        assertEquals(expected, result);
    }

    @Test
    void itemReduceByUsage() {
        HeroQuest.ItemUsageResult result = HeroQuest.itemReduceByUsage(itemKind, itemPower);
        itemPower = result.itemPower;
        assertEquals(5, itemPower);
    }

    @Test
    void itemReduceByUsageToJunk() {
        itemPower = 1;
        HeroQuest.ItemUsageResult result = HeroQuest.itemReduceByUsage(itemKind, itemPower);
        itemPower = result.itemPower;
        itemKind = result.itemKind;
        assertEquals(0, itemPower);
        assertEquals("Junk", itemKind);
    }

    @Test
    void itemApplyEffectToPlayer() {
        HeroQuest.ItemEffectResult result = HeroQuest.itemApplyEffectToPlayer(itemName, itemKind, itemPower, playerHealth, playerStrength, playerMagic);
        playerStrength = result.playerStrength;
        assertEquals(30, playerStrength);
    }

    @Test
    void itemApplyEffectToPlayerJunk() {
        itemKind = "Junk";
        HeroQuest.ItemEffectResult result = HeroQuest.itemApplyEffectToPlayer(itemName, itemKind, itemPower, playerHealth, playerStrength, playerMagic);
        playerStrength = result.playerStrength;
        assertEquals(20, playerStrength);
    }

    @Test
    void itemRepair() {
        itemPower = HeroQuest.itemRepair(playerCraftingSkill, itemPower);
        assertEquals(26, itemPower);
    }
}
