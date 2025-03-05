package codingdojo;

import static codingdojo.HeroQuest.itemApplyEffectToPlayer;
import static codingdojo.HeroQuest.itemReduceByUsage;
import static codingdojo.HeroQuest.itemRepair;
import static codingdojo.HeroQuest.itemToString;
import static codingdojo.HeroQuest.playerToString;

public class Main {

    public static void main(String[] args) {
        QuestData questData = new QuestData();
        questData.setPlayerName("Conan");
        questData.setPlayerHealth(100);
        questData.setPlayerStrength(20);
        questData.setPlayerMagic(10);
        questData.setPlayerCraftingSkill(10);
        questData.setItemName("Amulet of Strength");
        questData.setItemKind("Strength");
        questData.setItemPower(10);

        String result = playerToString(questData.getPlayerName(),
                questData.getPlayerHealth(), questData.getPlayerStrength(), questData.getPlayerMagic(), questData.getPlayerCraftingSkill());
        System.out.printf("Player at begin\n%s\n", result);

        result = itemToString(questData.getItemName(), questData.getItemKind(), questData.getItemPower());
        System.out.printf("Player found an item\n%s\n", result);

        itemApplyEffectToPlayer(questData);
        itemReduceByUsage(questData);

        result = HeroQuest.playerToString(questData.getPlayerName(),
                questData.getPlayerHealth(), questData.getPlayerStrength(), questData.getPlayerMagic(), questData.getPlayerCraftingSkill());
        System.out.printf("Player now\n%s\n", result);

        result = itemToString(questData.getItemName(), questData.getItemKind(), questData.getItemPower());
        System.out.printf("Item now\n%s\n", result);

        System.out.printf("Player tries to repair item...\n");
        itemRepair(questData);
        result = itemToString(questData.getItemName(), questData.getItemKind(), questData.getItemPower());
        System.out.printf("Item now\n%s\n", result);
    }
}
