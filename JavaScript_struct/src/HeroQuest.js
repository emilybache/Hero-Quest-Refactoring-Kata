let output = [];

class HeroQuest {
    static playerToString(playerName, playerHealth, playerStrength, playerMagic, playerCraftingSkill) {
        return `${playerName}'s Attributes:\nHealth: ${playerHealth}\nStrength: ${playerStrength}\nMagic: ${playerMagic}\nCrafting Skill: ${playerCraftingSkill}\n`;
    }

    static playerFallsDown(questData) {
        output.push("Player drops off a cliff.\n");

        if (questData.playerStrength < 5) {
            questData.playerHealth -= 10;
            output.push("Player's strength is too small. Health decreases by 10.\n");
        }
    }

    static itemToString(itemName, itemKind, itemPower) {
        return `Item: ${itemName}\nKind: ${itemKind}\nPower: ${itemPower}\n`;
    }

    static itemReduceByUsage(questData) {
        output.push(`Using the item with kind '${questData.itemKind}' and power ${questData.itemPower}\n`);

        questData.itemPower = Math.floor(questData.itemPower / 2);

        if (questData.itemPower === 0) {
            questData.itemKind = "Junk";
        }
    }

    static itemApplyEffectToPlayer(questData) {
        output.push(`Applying the effect of ${questData.itemName} (${questData.itemKind}):\n`);

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
        output.push("Using the repair skill to fix the item:\n");

        let repairAmount = -5 + ((questData.playerCraftingSkill * 2) + 1);

        questData.itemPower += repairAmount;

        output.push(`Repaired the item by ${repairAmount} points. Item's Durability: ${questData.itemPower}\n`);
    }

    static enemyToString(enemyName, enemyPower) {
        return `Enemy: ${enemyName}\nPower: ${enemyPower}\n`;
    }

    static enemyAttackPlayer(questData) {
        output.push(`The enemy '${questData.enemyName}' attacks!\n`);
        let damage = questData.enemyPower;

        if (questData.playerStrength > questData.enemyPower) {
            damage = Math.floor(damage / 2);
            output.push("Player's strength allows them to reduce the damage!\n");
        }

        questData.playerHealth -= damage;
        output.push(`Player takes ${damage} damage. Health is now: ${questData.playerHealth}\n`);
    }

    static playerChallengeEnemy(questData) {
        output.push(`The player challenges ${questData.enemyName}!\n`);
        let playerAttackPower = questData.playerStrength + (questData.itemPower > 0 ? Math.floor(questData.itemPower / 2) : 0);

        if (playerAttackPower > questData.enemyPower) {
            questData.enemyPower -= Math.floor(playerAttackPower / 2);
            output.push(`The player defeats the enemy! Enemy power reduced to ${questData.enemyPower}\n`);
        } else {
            output.push("The enemy is too strong. The player retreats!\n");
        }
    }
}

module.exports = {
    HeroQuest,
    output
};
