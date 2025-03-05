const { HeroQuest } = require('./HeroQuest');

let questData = {
    playerName: "Conan",
    playerHealth: 100,
    playerStrength: 20,
    playerMagic: 10,
    playerCraftingSkill: 10,
    itemName: "Amulet of Strength",
    itemKind: "Strength",
    itemPower: 10
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

HeroQuest.itemApplyEffectToPlayer(questData);
HeroQuest.itemReduceByUsage(questData);

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
HeroQuest.itemRepair(questData);
result = HeroQuest.itemToString(
    questData.itemName,
    questData.itemKind,
    questData.itemPower
);
console.log("Item now\n" + result);
