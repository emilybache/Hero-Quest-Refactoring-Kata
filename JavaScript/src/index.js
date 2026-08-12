const { HeroQuest } = require('./HeroQuest');

let questData = {
    playerName: "Conan",
    playerHealth: 100,
    playerStrength: 20,
    playerMagic: 10,
    playerCraftingSkill: 10,
    itemName: "Amulet of Strength",
    itemKind: "Strength",
    itemPower: 10,
    enemyName: "Goblin",
    enemyPower: 10
};

let result = HeroQuest.playerToString(
    questData.playerName,
    questData.playerHealth,
    questData.playerStrength,
    questData.playerMagic,
    questData.playerCraftingSkill
);
console.log("Player at begin\n" + result);

result = HeroQuest.itemToString(
    questData.itemName,
    questData.itemKind,
    questData.itemPower
);
console.log("Player found an item\n" + result);

({ playerHealth: questData.playerHealth, playerStrength: questData.playerStrength, playerMagic: questData.playerMagic } =
    HeroQuest.itemApplyEffectToPlayer(questData.itemName, questData.itemKind, questData.itemPower,
        questData.playerHealth, questData.playerStrength, questData.playerMagic));
({ itemKind: questData.itemKind, itemPower: questData.itemPower } =
    HeroQuest.itemReduceByUsage(questData.itemKind, questData.itemPower));

result = HeroQuest.playerToString(
    questData.playerName,
    questData.playerHealth,
    questData.playerStrength,
    questData.playerMagic,
    questData.playerCraftingSkill
);
console.log("Player now\n" + result);

result = HeroQuest.itemToString(
    questData.itemName,
    questData.itemKind,
    questData.itemPower
);
console.log("Item now\n" + result);

console.log("Player tries to repair item...");
questData.itemPower = HeroQuest.itemRepair(questData.playerCraftingSkill, questData.itemPower);
result = HeroQuest.itemToString(
    questData.itemName,
    questData.itemKind,
    questData.itemPower
);
console.log("Item now\n" + result);

result = HeroQuest.enemyToString(questData.enemyName, questData.enemyPower);
console.log("Enemy encountered\n" + result);

questData.playerHealth = HeroQuest.enemyAttackPlayer(questData.enemyName, questData.enemyPower,
    questData.playerStrength, questData.playerHealth);
questData.enemyPower = HeroQuest.playerChallengeEnemy(questData.enemyName, questData.playerStrength,
    questData.itemPower, questData.enemyPower);

result = HeroQuest.enemyToString(questData.enemyName, questData.enemyPower);
console.log("Enemy now\n" + result);
