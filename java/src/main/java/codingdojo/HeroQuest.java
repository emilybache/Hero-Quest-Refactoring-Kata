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

    public static String itemToString(String itemName, String itemKind, int itemPower) {
        return String.format("Item: %s\nKind: %s\nPower: %d\n", itemName, itemKind, itemPower);
    }

    public static int playerFallsDown(int playerStrength, int playerHealth) {
        output.append("Player drops off a cliff.\n");

        if (playerStrength < 5) {
            playerHealth -= 10;
            output.append("Player's strength is too small. Health decreases by 10.\n");
        }
        return playerHealth;
    }

    public static class ItemUsageResult {
        public final String itemKind;
        public final int itemPower;
        public ItemUsageResult(String itemKind, int itemPower) {
            this.itemKind = itemKind;
            this.itemPower = itemPower;
        }
    }

    public static ItemUsageResult itemReduceByUsage(String itemKind, int itemPower) {
        output.append(String.format("Using the item with kind '%s' and power %d\n", itemKind, itemPower));

        itemPower /= 2;

        if (itemPower == 0) {
            itemKind = "Junk";
        }
        return new ItemUsageResult(itemKind, itemPower);
    }

    public static class ItemEffectResult {
        public final int playerHealth;
        public final int playerStrength;
        public final int playerMagic;
        public ItemEffectResult(int playerHealth, int playerStrength, int playerMagic) {
            this.playerHealth = playerHealth;
            this.playerStrength = playerStrength;
            this.playerMagic = playerMagic;
        }
    }

    public static ItemEffectResult itemApplyEffectToPlayer(String itemName, String itemKind, int itemPower, int playerHealth, int playerStrength, int playerMagic) {
        output.append(String.format("Applying the effect of %s (%s):\n", itemName, itemKind));

        if (Objects.equals(itemKind, "Health")) {
            playerHealth += itemPower;
        } else if (Objects.equals(itemKind, "Strength")) {
            playerStrength += itemPower;
        } else if (Objects.equals(itemKind, "Magic")) {
            playerMagic += itemPower;
        } else {
            // ignore unknown item kind
        }
        return new ItemEffectResult(playerHealth, playerStrength, playerMagic);
    }

    public static int itemRepair(int playerCraftingSkill, int itemPower) {
        output.append("Using the repair skill to fix the item:\n");

        int repairAmount = -5 + ((playerCraftingSkill * 2) + 1);

        itemPower += repairAmount;

        output.append(String.format("Repaired the item by %d points. Item's Durability: %d\n", //
                repairAmount, itemPower));
        return itemPower;
    }

    public static int enemyAttackPlayer(String enemyName, int enemyPower, int playerStrength, int playerHealth) {
        output.append(String.format("The enemy '%s' attacks!\n", enemyName));
        int damage = enemyPower;

        if (playerStrength > enemyPower) {
            damage = damage / 2;
            output.append("Player's strength allows them to reduce the damage!\n");
        }

        playerHealth = playerHealth - damage;
        output.append(String.format("Player takes %d damage. Health is now: %d\n", damage, playerHealth));

        return playerHealth;
    }

    public static int playerChallengeEnemy(String enemyName, int playerStrength, int itemPower, int enemyPower) {
        output.append(String.format("The player challenges %s!\n", enemyName));
        int playerAttackPower = playerStrength + (itemPower > 0 ? itemPower / 2 : 0);

        if (playerAttackPower > enemyPower) {
            enemyPower = enemyPower - (playerAttackPower / 2);
            output.append(String.format("The player defeats the enemy! Enemy power reduced to %d\n", enemyPower));
        } else {
            output.append("The enemy is too strong. The player retreats!\n");
        }

        return enemyPower;
    }
}