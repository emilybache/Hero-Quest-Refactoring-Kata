const { HeroQuest, output } = require('./HeroQuest');

function run() {
    let playerName = "Conan";
    let playerHealth = 100;
    let playerStrength = 7;
    let playerMagic = 15;
    let playerCraftingSkill = 12;
    let itemName = "Healing Potion";
    let itemKind = "Health";
    let itemPower = 20;
    let enemyName = "Goblin Warlord";
    let enemyPower = 12;

    output.push("=== QUEST BEGINNING ===\n\n");

    let result = HeroQuest.playerToString(playerName, playerHealth, playerStrength, playerMagic, playerCraftingSkill);
    output.push(result + "\n");

    result = HeroQuest.itemToString(itemName, itemKind, itemPower);
    output.push(result + "\n");

    output.push("--- Exploring the dungeon... ---\n\n");

    playerHealth = HeroQuest.playerFallsDown(playerStrength, playerHealth);
    result = HeroQuest.playerToString(playerName, playerHealth, playerStrength, playerMagic, playerCraftingSkill);
    output.push(result + "\n");

    output.push("--- Using the healing item ---\n\n");

    let effectResult = HeroQuest.itemApplyEffectToPlayer(itemName, itemKind, itemPower, playerHealth, playerStrength, playerMagic);
    playerHealth = effectResult.playerHealth;
    playerStrength = effectResult.playerStrength;
    playerMagic = effectResult.playerMagic;
    result = HeroQuest.playerToString(playerName, playerHealth, playerStrength, playerMagic, playerCraftingSkill);
    output.push(result + "\n");

    result = HeroQuest.itemToString(itemName, itemKind, itemPower);
    output.push(result + "\n");

    output.push("--- Item degradation from repeated use ---\n\n");

    let usageResult = HeroQuest.itemReduceByUsage(itemKind, itemPower);
    itemKind = usageResult.itemKind;
    itemPower = usageResult.itemPower;
    result = HeroQuest.itemToString(itemName, itemKind, itemPower);
    output.push(result + "\n");

    usageResult = HeroQuest.itemReduceByUsage(itemKind, itemPower);
    itemKind = usageResult.itemKind;
    itemPower = usageResult.itemPower;
    result = HeroQuest.itemToString(itemName, itemKind, itemPower);
    output.push(result + "\n");

    output.push("--- Repairing the damaged item ---\n\n");

    itemPower = HeroQuest.itemRepair(playerCraftingSkill, itemPower);
    result = HeroQuest.itemToString(itemName, itemKind, itemPower);
    output.push(result + "\n");

    output.push("=== ENEMY ENCOUNTER ===\n\n");

    result = HeroQuest.enemyToString(enemyName, enemyPower);
    output.push(result + "\n");

    playerHealth = HeroQuest.enemyAttackPlayer(enemyName, enemyPower, playerStrength, playerHealth);
    result = HeroQuest.playerToString(playerName, playerHealth, playerStrength, playerMagic, playerCraftingSkill);
    output.push(result + "\n");

    output.push("--- Player retaliates ---\n\n");

    enemyPower = HeroQuest.playerChallengeEnemy(enemyName, playerStrength, itemPower, enemyPower);
    result = HeroQuest.enemyToString(enemyName, enemyPower);
    output.push(result + "\n");
}

module.exports = { run };

if (require.main === module) {
    output.splice(0, output.length);
    run();
    console.log(output.join("\n"));
}
