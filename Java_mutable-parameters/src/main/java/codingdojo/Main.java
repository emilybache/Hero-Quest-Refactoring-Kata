package codingdojo;

public class Main {
    public static void main(String[] args) {
        HeroQuest.output = new StringBuilder();

        String playerName = "Conan";
        int playerHealth = 100;
        int playerStrength = 7;
        int playerMagic = 15;
        int playerCraftingSkill = 12;
        String itemName = "Healing Potion";
        String itemKind = "Health";
        int itemPower = 20;
        String enemyName = "Goblin Warlord";
        int enemyPower = 12;

        System.out.println(HeroQuest.playerToString(playerName, playerHealth, playerStrength,
                playerMagic, playerCraftingSkill));
    }
}
