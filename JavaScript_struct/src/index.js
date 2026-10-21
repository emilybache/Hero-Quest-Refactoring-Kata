const { HeroQuest, output } = require('./HeroQuest');

function run() {
    let questData = {
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

    output.push("=== QUEST BEGINNING ===\n\n");

    let result = HeroQuest.playerToString(
        questData.playerName,
        questData.playerHealth,
        questData.playerStrength,
        questData.playerMagic,
        questData.playerCraftingSkill
    );
    output.push(result + "\n");

    result = HeroQuest.itemToString(
        questData.itemName,
        questData.itemKind,
        questData.itemPower
    );
    output.push(result + "\n");

    output.push("--- Exploring the dungeon... ---\n\n");

    HeroQuest.playerFallsDown(questData);
    result = HeroQuest.playerToString(
        questData.playerName,
        questData.playerHealth,
        questData.playerStrength,
        questData.playerMagic,
        questData.playerCraftingSkill
    );
    output.push(result + "\n");

    output.push("--- Using the healing item ---\n\n");

    HeroQuest.itemApplyEffectToPlayer(questData);
    result = HeroQuest.playerToString(
        questData.playerName,
        questData.playerHealth,
        questData.playerStrength,
        questData.playerMagic,
        questData.playerCraftingSkill
    );
    output.push(result + "\n");

    result = HeroQuest.itemToString(
        questData.itemName,
        questData.itemKind,
        questData.itemPower
    );
    output.push(result + "\n");

    output.push("--- Item degradation from repeated use ---\n\n");

    HeroQuest.itemReduceByUsage(questData);
    result = HeroQuest.itemToString(
        questData.itemName,
        questData.itemKind,
        questData.itemPower
    );
    output.push(result + "\n");

    HeroQuest.itemReduceByUsage(questData);
    result = HeroQuest.itemToString(
        questData.itemName,
        questData.itemKind,
        questData.itemPower
    );
    output.push(result + "\n");

    output.push("--- Repairing the damaged item ---\n\n");

    HeroQuest.itemRepair(questData);
    result = HeroQuest.itemToString(
        questData.itemName,
        questData.itemKind,
        questData.itemPower
    );
    output.push(result + "\n");

    output.push("=== ENEMY ENCOUNTER ===\n\n");

    result = HeroQuest.enemyToString(questData.enemyName, questData.enemyPower);
    output.push(result + "\n");

    HeroQuest.enemyAttackPlayer(questData);
    result = HeroQuest.playerToString(
        questData.playerName,
        questData.playerHealth,
        questData.playerStrength,
        questData.playerMagic,
        questData.playerCraftingSkill
    );
    output.push(result + "\n");

    output.push("--- Player retaliates ---\n\n");

    HeroQuest.playerChallengeEnemy(questData);
    result = HeroQuest.enemyToString(questData.enemyName, questData.enemyPower);
    output.push(result + "\n");
}

module.exports = { run };

if (require.main === module) {
    output.splice(0, output.length);
    run();
    console.log(output.join(""));
}
