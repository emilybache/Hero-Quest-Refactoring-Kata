class HeroQuest {
    static playerToString(playerName, playerHealth, playerStrength, playerMagic, playerCraftingSkill) {
        return `${playerName}'s Attributes:\nHealth: ${playerHealth}\nStrength: ${playerStrength}\nMagic: ${playerMagic}\nCrafting Skill: ${playerCraftingSkill}\n`;
    }

    static playerFallsDown(questData) {
        console.log("Player drops off a cliff.");

        if (questData.playerStrength < 5) {
            questData.playerHealth -= 10;
            console.log("Player's strength is too small. Health decreases by 10.");
        }
    }

    static itemToString(itemName, itemKind, itemPower) {
        return `Item: ${itemName}\nKind: ${itemKind}\nPower: ${itemPower}\n`;
    }

    static itemReduceByUsage(questData) {
        console.log(`Using the item with kind '${questData.itemKind}' and power ${questData.itemPower}`);

        questData.itemPower = Math.floor(questData.itemPower / 2);

        if (questData.itemPower === 0) {
            questData.itemKind = "Junk";
        }
    }

    static itemApplyEffectToPlayer(questData) {
        console.log(`Applying the effect of ${questData.itemName} (${questData.itemKind}):`);

        if (questData.itemKind === "Health") {
            questData.playerHealth += questData.itemPower;
        } else if (questData.itemKind === "Strength") {
            questData.playerStrength += questData.itemPower;
        } else if (questData.itemKind === "Magic") {
            questData.playerMagic += questData.itemPower;
        } else {
            // ignore unknown item kind

        }
    }

    static itemRepair(questData) {
        console.log("Using the repair skill to fix the item:");

        let repairAmount = -5 + ((questData.playerCraftingSkill * 2) + 1);

        questData.itemPower += repairAmount;

        console.log(`Repaired the item by ${repairAmount} points. Item's Durability: ${questData.itemPower}`);
    }
}

module.exports = {
    HeroQuest
};
