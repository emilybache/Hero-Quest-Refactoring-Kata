package codingdojo;

import static codingdojo.HeroQuest.itemApplyEffectToPlayer;
import static codingdojo.HeroQuest.itemReduceByUsage;
import static codingdojo.HeroQuest.itemRepair;
import static codingdojo.HeroQuest.itemToString;
import static codingdojo.HeroQuest.playerToString;

public class Main {

    public static void main(String[] args) {
        var playerName = "Conan";
        var playerHealth = new int[] { 100 };
        var playerStrength = new int[] { 20 };
        var playerMagic = new int[] { 10 };
        var playerCraftingSkill = 10;
        var amuletItemName = "Amulet of Strength";
        var amuletItemKind = new String[] { "Strength" };
        var amuletItemPower = new int[] { 10 };

        String result = playerToString(playerName, playerHealth[0], playerStrength[0], playerMagic[0],
                playerCraftingSkill);
        System.out.printf("Player at begin\n%s\n", result);

        result = itemToString(amuletItemName, amuletItemKind[0], amuletItemPower[0]);
        System.out.printf("Player found an item\n%s\n", result);

        itemApplyEffectToPlayer(amuletItemName, amuletItemKind, amuletItemPower[0], playerHealth, playerStrength,
                playerMagic);
        itemReduceByUsage(amuletItemKind, amuletItemPower);

        result = playerToString(playerName, playerHealth[0], playerStrength[0], playerMagic[0], playerCraftingSkill);
        System.out.printf("Player now\n%s\n", result);

        result = itemToString(amuletItemName, amuletItemKind[0], amuletItemPower[0]);
        System.out.printf("Item now\n%s\n", result);

        System.out.printf("Player tries to repair item...\n");
        itemRepair(amuletItemPower, playerCraftingSkill);
        result = itemToString(amuletItemName, amuletItemKind[0], amuletItemPower[0]);
        System.out.printf("Item now\n%s\n", result);
    }
}
