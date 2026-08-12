package codingdojo;

import java.util.Objects;

public class HeroQuest {

    public static StringBuilder output = new StringBuilder();

    public static String playerToString(String playerName, int playerHealth, int playerStrength, int playerMagic, int playerCraftingSkill) {
        return String.format("%s's Attributes:\nHealth: %d\nStrength: %d\nMagic: %d\nCrafting Skill: %d\n", //
                playerName, playerHealth, playerStrength, playerMagic, playerCraftingSkill);
    }

    public static String enemyToString(String enemyName, int enemyPower) {
        return String.format("Enemy: %s\nPower: %d\n", enemyName, enemyPower);
    }

    public static void playerFallsDown(int[] playerHealth, int[] playerStrength) {
        output.append("Player drops off a cliff.\n");

        if (playerStrength[0] < 5) {
            playerHealth[0] -= 10;
            output.append("Player's strength is too small. Health decreases by 10.\n");
        }
    }

    public static String itemToString(String itemName, String itemKind, int itemPower) {
        return String.format("Item: %s\nKind: %s\nPower: %d\n", itemName, itemKind, itemPower);
    }

    public static void itemReduceByUsage(String[] itemKind, int[] itemPower) {
        output.append(String.format("Using the item with kind '%s' and power %d\n", itemKind[0], itemPower[0]));

        itemPower[0] /= 2;

        if (itemPower[0] == 0) {
            itemKind[0] = "Junk";
        }
    }

    public static void itemApplyEffectToPlayer(String itemName, String[] itemKind, int itemPower, int[] playerHealth, int[] playerStrength, int[] playerMagic) {
        output.append(String.format("Applying the effect of %s (%s):\n", itemName, itemKind[0]));

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
        output.append("Using the repair skill to fix the item:\n");

        int repairAmount = -5 + ((playerCraftingSkill * 2) + 1);

        itemPower[0] += repairAmount;

        output.append(String.format("Repaired the item by %d points. Item's Durability: %d\n", //
                repairAmount, itemPower[0]));
    }

    public static void enemyAttackPlayer(String enemyName, int enemyPower, int[] playerStrength, int[] playerHealth) {
        output.append(String.format("The enemy '%s' attacks!\n", enemyName));
        int damage = enemyPower;

        if (playerStrength[0] > enemyPower) {
            damage = damage / 2;
            output.append("Player's strength allows them to reduce the damage!\n");
        }

        playerHealth[0] = playerHealth[0] - damage;
        output.append(String.format("Player takes %d damage. Health is now: %d\n", damage, playerHealth[0]));
    }

    public static void playerChallengeEnemy(String enemyName, int[] playerStrength, int[] itemPower, int[] enemyPower) {
        output.append(String.format("The player challenges %s!\n", enemyName));
        int playerAttackPower = playerStrength[0] + (itemPower[0] > 0 ? itemPower[0] / 2 : 0);

        if (playerAttackPower > enemyPower[0]) {
            enemyPower[0] = enemyPower[0] - (playerAttackPower / 2);
            output.append(String.format("The player defeats the enemy! Enemy power reduced to %d\n", enemyPower[0]));
        } else {
            output.append("The enemy is too strong. The player retreats!\n");
        }
    }
}
