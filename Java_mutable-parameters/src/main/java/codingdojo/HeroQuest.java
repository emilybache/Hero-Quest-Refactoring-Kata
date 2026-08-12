package codingdojo;

import java.util.Objects;

public class HeroQuest {

    public static String playerToString(String playerName, int playerHealth, int playerStrength, int playerMagic, int playerCraftingSkill) {
        return String.format("%s's Attributes:\nHealth: %d\nStrength: %d\nMagic: %d\nCrafting Skill: %d\n", //
                playerName, playerHealth, playerStrength, playerMagic, playerCraftingSkill);
    }

    public static void playerFallsDown(int[] playerHealth, int[] playerStrength) {
        System.out.println("Player drops off a cliff.");

        if (playerStrength[0] < 5) {
            playerHealth[0] -= 10;
            System.out.println("Player's strength is too small. Health decreases by 10.");
        }
    }

    public static String itemToString(String itemName, String itemKind, int itemPower) {
        return String.format("Item: %s\nKind: %s\nPower: %d\n", itemName, itemKind, itemPower);
    }

    public static void itemReduceByUsage(String[] itemKind, int[] itemPower) {
        System.out.println(String.format("Using the item with kind '%s' and power %d", itemKind[0], itemPower[0]));

        itemPower[0] /= 2;

        if (itemPower[0] == 0) {
            itemKind[0] = "Junk";
        }
    }

    public static void itemApplyEffectToPlayer(String itemName, String[] itemKind, int itemPower, int[] playerHealth, int[] playerStrength, int[] playerMagic) {
        System.out.println(String.format("Applying the effect of %s (%s):", itemName, itemKind[0]));

        if (Objects.equals(itemKind[0], "Health")) {
            playerHealth[0] += itemPower;
        } else if (Objects.equals(itemKind[0], "Strength")) {
            playerStrength[0] += itemPower;
        } else if (Objects.equals(itemKind[0], "Magic")) {
            playerMagic[0] += itemPower;
        } else {
            // ignore unknown item kind
        }
    }

    public static void itemRepair(int[] itemPower, int playerCraftingSkill) {
        System.out.println("Using the repair skill to fix the item:");

        int repairAmount = -5 + ((playerCraftingSkill * 2) + 1);

        itemPower[0] += repairAmount;

        System.out.println(String.format("Repaired the item by %d points. Item's Durability: %d", //
                repairAmount, itemPower[0]));
    }
}
