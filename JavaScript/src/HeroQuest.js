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
        console.log("Player drops off a cliff.");

        if (playerStrength < 5) {
            playerHealth -= 10;
            console.log("Player's strength is too small. Health decreases by 10.");
        }

        return playerHealth;
    }

    static itemReduceByUsage(itemKind, itemPower) {
        console.log(`Using the item with kind '${itemKind}' and power ${itemPower}`);

        itemPower = Math.floor(itemPower / 2);

        if (itemPower === 0) {
            itemKind = "Junk";
        }

        return { itemKind, itemPower };
    }

    static itemApplyEffectToPlayer(itemName, itemKind, itemPower, playerHealth, playerStrength, playerMagic) {
        console.log(`Applying the effect of ${itemName} (${itemKind}):`);

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
        console.log("Using the repair skill to fix the item:");

        let repairAmount = -5 + (playerCraftingSkill * 2) + 1;

        itemPower += repairAmount;

        console.log(`Repaired the item by ${repairAmount} points. Item's Durability: ${itemPower}`);

        return itemPower;
    }

    static enemyAttackPlayer(enemyName, enemyPower, playerStrength, playerHealth) {
        console.log(`The enemy '${enemyName}' attacks!`);
        let damage = enemyPower;

        if (playerStrength > enemyPower) {
            damage = Math.floor(damage / 2);
            console.log("Player's strength allows them to reduce the damage!");
        }

        playerHealth -= damage;
        console.log(`Player takes ${damage} damage. Health is now: ${playerHealth}`);

        return playerHealth;
    }

    static playerChallengeEnemy(enemyName, playerStrength, itemPower, enemyPower) {
        console.log(`The player challenges ${enemyName}!`);
        let playerAttackPower = playerStrength + (itemPower > 0 ? Math.floor(itemPower / 2) : 0);

        if (playerAttackPower > enemyPower) {
            enemyPower -= Math.floor(playerAttackPower / 2);
            console.log(`The player defeats the enemy! Enemy power reduced to ${enemyPower}`);
        } else {
            console.log("The enemy is too strong. The player retreats!");
        }

        return enemyPower;
    }
}

module.exports = {
    HeroQuest
};
