let output = [];

class HeroQuest {

    static playerToString(playerName, playerHealth, playerStrength, playerMagic, playerCraftingSkill) {
        return `${playerName}'s Attributes:\nHealth: ${playerHealth}\nStrength: ${playerStrength}\nMagic: ${playerMagic}\nCrafting Skill: ${playerCraftingSkill}\n`;
    }

    static enemyToString(enemyName, enemyPower) {
        return `Enemy: ${enemyName}\nPower: ${enemyPower}\n`;
    }

    static itemToString(itemName, itemKind, itemPower) {
        return `Item: ${itemName}\nKind: ${itemKind}\nPower: ${itemPower}\n`;
    }

    static playerFallsDown(playerStrength, playerHealth) {
        output.push("Player drops off a cliff.\n");

        if (playerStrength < 5) {
            playerHealth -= 10;
            output.push("Player's strength is too small. Health decreases by 10.\n");
        }

        return playerHealth;
    }

    static itemReduceByUsage(itemKind, itemPower) {
        output.push(`Using the item with kind '${itemKind}' and power ${itemPower}\n`);

        itemPower = Math.floor(itemPower / 2);

        if (itemPower === 0) {
            itemKind = "Junk";
        }

        return { itemKind, itemPower };
    }

    static itemApplyEffectToPlayer(itemName, itemKind, itemPower, playerHealth, playerStrength, playerMagic) {
        output.push(`Applying the effect of ${itemName} (${itemKind}):\n`);

        if (itemKind === "Health") {
            playerHealth += itemPower;
        } else if (itemKind === "Strength") {
            playerStrength += itemPower;
        } else if (itemKind === "Magic") {
            playerMagic += itemPower;
        } else {
            // ignore unknown item kind
        }

        return { playerHealth, playerStrength, playerMagic };
    }

    static itemRepair(playerCraftingSkill, itemPower) {
        output.push("Using the repair skill to fix the item:\n");

        let repairAmount = -5 + (playerCraftingSkill * 2) + 1;

        itemPower += repairAmount;

        output.push(`Repaired the item by ${repairAmount} points. Item's Durability: ${itemPower}\n`);

        return itemPower;
    }

    static enemyAttackPlayer(enemyName, enemyPower, playerStrength, playerHealth) {
        output.push(`The enemy '${enemyName}' attacks!\n`);
        let damage = enemyPower;

        if (playerStrength > enemyPower) {
            damage = Math.floor(damage / 2);
            output.push("Player's strength allows them to reduce the damage!\n");
        }

        playerHealth -= damage;
        output.push(`Player takes ${damage} damage. Health is now: ${playerHealth}\n`);

        return playerHealth;
    }

    static playerChallengeEnemy(enemyName, playerStrength, itemPower, enemyPower) {
        output.push(`The player challenges ${enemyName}!\n`);
        let playerAttackPower = playerStrength + (itemPower > 0 ? Math.floor(itemPower / 2) : 0);

        if (playerAttackPower > enemyPower) {
            enemyPower -= Math.floor(playerAttackPower / 2);
            output.push(`The player defeats the enemy! Enemy power reduced to ${enemyPower}\n`);
        } else {
            output.push("The enemy is too strong. The player retreats!\n");
        }

        return enemyPower;
    }
}

module.exports = {
    HeroQuest,
    output
};
