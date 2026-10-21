#include <stdio.h>
#include <time.h>

#include "quest.h"

void run()
{
    char result[256];
    const char playerName[] = "Conan";
    int playerHealth = 100;
    int playerStrength = 7;
    int playerMagic = 15;
    int playerCraftingSkill = 12;
    const char itemName[] = "Healing Potion";
    char itemKind[] = "Health";
    int itemPower = 20;
    const char enemyName[] = "Goblin Warlord";
    int enemyPower = 12;

    resetOutput();

    appendOutput("=== QUEST BEGINNING ===\n\n");

    playerToString(result, playerName, playerHealth, playerStrength,
                   playerMagic, playerCraftingSkill);
    appendOutput(result);
    appendOutput("\n");

    itemToString(result, itemName, itemKind, itemPower);
    appendOutput(result);
    appendOutput("\n");

    appendOutput("--- Exploring the dungeon... ---\n\n");

    playerFallsDown(&playerHealth, &playerStrength);
    playerToString(result, playerName, playerHealth, playerStrength,
                   playerMagic, playerCraftingSkill);
    appendOutput(result);
    appendOutput("\n");

    appendOutput("--- Using the healing item ---\n\n");

    itemApplyEffectToPlayer(itemName, itemKind, itemPower, &playerHealth,
                            &playerStrength, &playerMagic);
    playerToString(result, playerName, playerHealth, playerStrength,
                   playerMagic, playerCraftingSkill);
    appendOutput(result);
    appendOutput("\n");

    itemToString(result, itemName, itemKind, itemPower);
    appendOutput(result);
    appendOutput("\n");

    appendOutput("--- Item degradation from repeated use ---\n\n");

    itemReduceByUsage(itemKind, &itemPower);
    itemToString(result, itemName, itemKind, itemPower);
    appendOutput(result);
    appendOutput("\n");

    itemReduceByUsage(itemKind, &itemPower);
    itemToString(result, itemName, itemKind, itemPower);
    appendOutput(result);
    appendOutput("\n");

    appendOutput("--- Repairing the damaged item ---\n\n");

    itemRepair(&itemPower, playerCraftingSkill);
    itemToString(result, itemName, itemKind, itemPower);
    appendOutput(result);
    appendOutput("\n");

    appendOutput("=== ENEMY ENCOUNTER ===\n\n");

    enemyToString(result, enemyName, enemyPower);
    appendOutput(result);
    appendOutput("\n");

    enemyAttackPlayer(enemyName, enemyPower, playerStrength, &playerHealth);
    playerToString(result, playerName, playerHealth, playerStrength,
                   playerMagic, playerCraftingSkill);
    appendOutput(result);
    appendOutput("\n");

    appendOutput("--- Player retaliates ---\n\n");

    playerChallengeEnemy(enemyName, playerStrength, itemPower, &enemyPower);
    enemyToString(result, enemyName, enemyPower);
    appendOutput(result);
    appendOutput("\n");
}

#ifndef UNIT_TEST
int main(void)
{
    run();
    printf("%s", outputBuffer);
    return 0;
}
#endif
