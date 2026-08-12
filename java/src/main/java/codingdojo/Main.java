package codingdojo;

public class Main {
    public static void main(String[] args) {
        HeroQuest.output = new StringBuilder();

        QuestData questData = new QuestData();
        questData.playerName = "Conan";
        questData.playerHealth = 100;
        questData.playerStrength = 7;
        questData.playerMagic = 15;
        questData.playerCraftingSkill = 12;
        questData.itemName = "Healing Potion";
        questData.itemKind = "Health";
        questData.itemPower = 20;
        questData.enemyName = "Goblin Warlord";
        questData.enemyPower = 12;

        System.out.println(HeroQuest.playerToString(questData.playerName, questData.playerHealth, questData.playerStrength,
                questData.playerMagic, questData.playerCraftingSkill));
    }
}
