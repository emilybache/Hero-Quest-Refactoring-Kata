package codingdojo;

import static codingdojo.HeroQuest.itemApplyEffectToPlayer;
import static codingdojo.HeroQuest.itemReduceByUsage;
import static codingdojo.HeroQuest.itemRepair;
import static codingdojo.HeroQuest.itemToString;
import static codingdojo.HeroQuest.playerToString;

public class Main {

    public static void main(String[] args) {
        var playerName = "Conan";
        var playerHealth = 100;
        var playerStrength = 20;
        var playerMagic = 10;
        var playerCraftingSkill = 10;
        var amuletItemName = "Amulet of Strength";
        var amuletItemKind = "Strength";
        var amuletItemPower = 10;

        String result = playerToString(playerName, playerHealth, playerStrength, playerMagic,
                playerCraftingSkill);
        System.out.printf("Player at begin\n%s\n", result);

        result = itemToString(amuletItemName, amuletItemKind, amuletItemPower);
        System.out.printf("Player found an item\n%s\n", result);

        HeroQuest.ItemEffectResult effectResult = itemApplyEffectToPlayer(amuletItemName, amuletItemKind, amuletItemPower, playerHealth, playerStrength,
                playerMagic);
        playerHealth = effectResult.playerHealth;
        playerStrength = effectResult.playerStrength;
        playerMagic = effectResult.playerMagic;

        HeroQuest.ItemUsageResult usageResult = itemReduceByUsage(amuletItemKind, amuletItemPower);
        amuletItemKind = usageResult.itemKind;
        amuletItemPower = usageResult.itemPower;

        result = playerToString(playerName, playerHealth, playerStrength, playerMagic, playerCraftingSkill);
        System.out.printf("Player now\n%s\n", result);

        result = itemToString(amuletItemName, amuletItemKind, amuletItemPower);
        System.out.printf("Item now\n%s\n", result);

        System.out.printf("Player tries to repair item...\n");
        amuletItemPower = itemRepair(playerCraftingSkill, amuletItemPower);
        result = itemToString(amuletItemName, amuletItemKind, amuletItemPower);
        System.out.printf("Item now\n%s\n", result);
    }
}
