const { HeroQuest } = require('../src/HeroQuest');

describe('HeroQuestAcceptanceTest', () => {

    it("FullScenario", () => {
        const questData = {
            playerName: "Conan",
            playerHealth: 100,
            playerStrength: 7,
            playerMagic: 15,
            playerCraftingSkill: 12,
            itemName: "Healing Potion",
            itemKind: "Health",
            itemPower: 20,
            enemyName: "Goblin Warlord",
            enemyPower: 12
        };

        let output = "";

        output += "=== QUEST BEGINNING ===\n\n";
        output += HeroQuest.playerToString(questData.playerName, questData.playerHealth, questData.playerStrength,
            questData.playerMagic, questData.playerCraftingSkill) + "\n";

        output += HeroQuest.itemToString(questData.itemName, questData.itemKind, questData.itemPower) + "\n";

        output += "--- Exploring the dungeon... ---\n\n";
        questData.playerHealth = HeroQuest.playerFallsDown(questData.playerStrength, questData.playerHealth);
        output += HeroQuest.playerToString(questData.playerName, questData.playerHealth, questData.playerStrength,
            questData.playerMagic, questData.playerCraftingSkill) + "\n";

        output += "--- Using the healing item ---\n\n";
        ({ playerHealth: questData.playerHealth, playerStrength: questData.playerStrength, playerMagic: questData.playerMagic } =
            HeroQuest.itemApplyEffectToPlayer(questData.itemName, questData.itemKind, questData.itemPower,
                questData.playerHealth, questData.playerStrength, questData.playerMagic));
        output += HeroQuest.playerToString(questData.playerName, questData.playerHealth, questData.playerStrength,
            questData.playerMagic, questData.playerCraftingSkill) + "\n";

        output += HeroQuest.itemToString(questData.itemName, questData.itemKind, questData.itemPower) + "\n";

        output += "--- Item degradation from repeated use ---\n\n";
        ({ itemKind: questData.itemKind, itemPower: questData.itemPower } =
            HeroQuest.itemReduceByUsage(questData.itemKind, questData.itemPower));
        output += HeroQuest.itemToString(questData.itemName, questData.itemKind, questData.itemPower) + "\n";

        ({ itemKind: questData.itemKind, itemPower: questData.itemPower } =
            HeroQuest.itemReduceByUsage(questData.itemKind, questData.itemPower));
        output += HeroQuest.itemToString(questData.itemName, questData.itemKind, questData.itemPower) + "\n";

        output += "--- Repairing the damaged item ---\n\n";
        questData.itemPower = HeroQuest.itemRepair(questData.playerCraftingSkill, questData.itemPower);
        output += HeroQuest.itemToString(questData.itemName, questData.itemKind, questData.itemPower) + "\n";

        output += "=== ENEMY ENCOUNTER ===\n\n";
        output += HeroQuest.enemyToString(questData.enemyName, questData.enemyPower) + "\n";

        questData.playerHealth = HeroQuest.enemyAttackPlayer(questData.enemyName, questData.enemyPower,
            questData.playerStrength, questData.playerHealth);
        output += HeroQuest.playerToString(questData.playerName, questData.playerHealth, questData.playerStrength,
            questData.playerMagic, questData.playerCraftingSkill) + "\n";

        output += "--- Player retaliates ---\n\n";
        questData.enemyPower = HeroQuest.playerChallengeEnemy(questData.enemyName, questData.playerStrength,
            questData.itemPower, questData.enemyPower);
        output += HeroQuest.enemyToString(questData.enemyName, questData.enemyPower) + "\n";

        expect(output).toMatchSnapshot();
    });

});
