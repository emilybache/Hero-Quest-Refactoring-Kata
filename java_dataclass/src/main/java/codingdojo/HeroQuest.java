package codingdojo;

import java.util.Objects;

public class HeroQuest {

    public static StringBuilder output = new StringBuilder();

    public static String playerToString(String playerName, int playerHealth, int playerStrength, int playerMagic, int playerCraftingSkill) {
        return String.format("%s's Attributes:\nHealth: %d\nStrength: %d\nMagic: %d\nCrafting Skill: %d\n",
                playerName, playerHealth, playerStrength, playerMagic, playerCraftingSkill);
    }

    public static void playerFallsDown(QuestData questData) {
        output.append("Player drops off a cliff.\n");

        if (questData.getPlayerStrength() < 5) {
            questData.setPlayerHealth(questData.getPlayerHealth() - 10);
            output.append("Player's strength is too small. Health decreases by 10.\n");
        }
    }

    public static String itemToString(String itemName, String itemKind, int itemPower) {
        return String.format("Item: %s\nKind: %s\nPower: %d\n", itemName, itemKind, itemPower);
    }

    public static void itemReduceByUsage(QuestData questData) {
        output.append(String.format("Using the item with kind '%s' and power %d\n", questData.getItemKind(), questData.getItemPower()));

        questData.setItemPower(questData.getItemPower() / 2);

        if (questData.getItemPower() == 0) {
            questData.setItemKind("Junk");
        }

    }

    public static void itemApplyEffectToPlayer(QuestData data) {
        output.append(String.format("Applying the effect of %s (%s):\n", data.getItemName(), data.getItemKind()));

        if (Objects.equals(data.getItemKind(), "Health")) {
            data.setPlayerHealth(data.getPlayerHealth() + data.getItemPower());
        } else if (Objects.equals(data.getItemKind(), "Strength")) {
            data.setPlayerStrength(data.getPlayerStrength() + data.getItemPower());
        } else if (Objects.equals(data.getItemKind(), "Magic")) {
            data.setPlayerMagic(data.getPlayerMagic() + data.getItemPower());
        } else {
            // ignore unknown item kind
        }
    }

    public static void itemRepair(QuestData questData) {
        output.append("Using the repair skill to fix the item:\n");

        int repairAmount = -5 + ((questData.getPlayerCraftingSkill() * 2) + 1);

        questData.setItemPower(questData.getItemPower() + repairAmount);

        output.append(String.format("Repaired the item by %d points. Item's Durability: %d\n", repairAmount, questData.getItemPower()));
    }

    public static String enemyToString(String enemyName, int enemyPower) {
        return String.format("Enemy: %s\nPower: %d\n", enemyName, enemyPower);
    }

    public static void enemyAttackPlayer(QuestData questData) {
        output.append(String.format("The enemy '%s' attacks!\n", questData.getEnemyName()));
        int damage = questData.getEnemyPower();

        if (questData.getPlayerStrength() > questData.getEnemyPower()) {
            damage = damage / 2;
            output.append("Player's strength allows them to reduce the damage!\n");
        }

        questData.setPlayerHealth(questData.getPlayerHealth() - damage);
        output.append(String.format("Player takes %d damage. Health is now: %d\n", damage, questData.getPlayerHealth()));
    }

    public static void playerChallengeEnemy(QuestData questData) {
        output.append(String.format("The player challenges %s!\n", questData.getEnemyName()));
        int playerAttackPower = questData.getPlayerStrength() + (questData.getItemPower() > 0 ? questData.getItemPower() / 2 : 0);

        if (playerAttackPower > questData.getEnemyPower()) {
            int newEnemyPower = questData.getEnemyPower() - (playerAttackPower / 2);
            questData.setEnemyPower(newEnemyPower);
            output.append(String.format("The player defeats the enemy! Enemy power reduced to %d\n", newEnemyPower));
        } else {
            output.append("The enemy is too strong. The player retreats!\n");
        }
    }
}
