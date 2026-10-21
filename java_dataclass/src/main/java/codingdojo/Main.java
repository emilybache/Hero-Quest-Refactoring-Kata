package codingdojo;

public class Main {

    public static void run() {
        QuestData questData = new QuestData();
        questData.setPlayerName("Conan");
        questData.setPlayerHealth(100);
        questData.setPlayerStrength(7);
        questData.setPlayerMagic(15);
        questData.setPlayerCraftingSkill(12);
        questData.setItemName("Healing Potion");
        questData.setItemKind("Health");
        questData.setItemPower(20);
        questData.setEnemyName("Goblin Warlord");
        questData.setEnemyPower(12);

        HeroQuest.output.append("=== QUEST BEGINNING ===\n\n");

        String result = HeroQuest.playerToString(questData.getPlayerName(), questData.getPlayerHealth(),
                questData.getPlayerStrength(), questData.getPlayerMagic(), questData.getPlayerCraftingSkill());
        HeroQuest.output.append(result).append("\n");

        result = HeroQuest.itemToString(questData.getItemName(), questData.getItemKind(), questData.getItemPower());
        HeroQuest.output.append(result).append("\n");

        HeroQuest.output.append("--- Exploring the dungeon... ---\n\n");

        HeroQuest.playerFallsDown(questData);
        result = HeroQuest.playerToString(questData.getPlayerName(), questData.getPlayerHealth(),
                questData.getPlayerStrength(), questData.getPlayerMagic(), questData.getPlayerCraftingSkill());
        HeroQuest.output.append(result).append("\n");

        HeroQuest.output.append("--- Using the healing item ---\n\n");

        HeroQuest.itemApplyEffectToPlayer(questData);
        result = HeroQuest.playerToString(questData.getPlayerName(), questData.getPlayerHealth(),
                questData.getPlayerStrength(), questData.getPlayerMagic(), questData.getPlayerCraftingSkill());
        HeroQuest.output.append(result).append("\n");

        result = HeroQuest.itemToString(questData.getItemName(), questData.getItemKind(), questData.getItemPower());
        HeroQuest.output.append(result).append("\n");

        HeroQuest.output.append("--- Item degradation from repeated use ---\n\n");

        HeroQuest.itemReduceByUsage(questData);
        result = HeroQuest.itemToString(questData.getItemName(), questData.getItemKind(), questData.getItemPower());
        HeroQuest.output.append(result).append("\n");

        HeroQuest.itemReduceByUsage(questData);
        result = HeroQuest.itemToString(questData.getItemName(), questData.getItemKind(), questData.getItemPower());
        HeroQuest.output.append(result).append("\n");

        HeroQuest.output.append("--- Repairing the damaged item ---\n\n");

        HeroQuest.itemRepair(questData);
        result = HeroQuest.itemToString(questData.getItemName(), questData.getItemKind(), questData.getItemPower());
        HeroQuest.output.append(result).append("\n");

        HeroQuest.output.append("=== ENEMY ENCOUNTER ===\n\n");

        result = HeroQuest.enemyToString(questData.getEnemyName(), questData.getEnemyPower());
        HeroQuest.output.append(result).append("\n");

        HeroQuest.enemyAttackPlayer(questData);
        result = HeroQuest.playerToString(questData.getPlayerName(), questData.getPlayerHealth(),
                questData.getPlayerStrength(), questData.getPlayerMagic(), questData.getPlayerCraftingSkill());
        HeroQuest.output.append(result).append("\n");

        HeroQuest.output.append("--- Player retaliates ---\n\n");

        HeroQuest.playerChallengeEnemy(questData);
        result = HeroQuest.enemyToString(questData.getEnemyName(), questData.getEnemyPower());
        HeroQuest.output.append(result).append("\n");
    }

    public static void main(String[] args) {
        HeroQuest.output = new StringBuilder();
        run();
        System.out.println(HeroQuest.output);
    }
}
