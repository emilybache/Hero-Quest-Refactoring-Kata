#include <stdio.h>
#include <string.h>

#include "quest.h"

char outputBuffer[8192];
size_t outputLength = 0;

void resetOutput()
{
    outputLength = 0;
    outputBuffer[0] = '\0';
}

void appendOutput(const char* str)
{
    size_t len = strlen(str);
    if (outputLength + len < sizeof(outputBuffer)) {
        memcpy(outputBuffer + outputLength, str, len);
        outputLength += len;
        outputBuffer[outputLength] = '\0';
    }
}

void playerToString(char* result, //
                    const char* playerName,
                    int playerHealth,
                    int playerStrength,
                    int playerMagic,
                    int playerCraftingSkill)
{
    sprintf(result,
            "%s's Attributes:\nHealth: %d\nStrength: %d\nMagic: %d\nCrafting "
            "Skill: %d\n",
            playerName, playerHealth, playerStrength, playerMagic, playerCraftingSkill);
}

void playerFallsDown(int* playerHealth, int* playerStrength)
{
    appendOutput("Player drops off a cliff.\n");

    if (*playerStrength < 5) {
        *playerHealth -= 10;
        appendOutput(
            "Player's strength is too small. Health decreases by 10.\n");
    }
}

void itemToString(char* result, //
                  const char* itemName,
                  const char* itemKind,
                  int itemPower)
{
    sprintf(result, "Item: %s\nKind: %s\nPower: %d\n", itemName, itemKind, itemPower);
}

void itemReduceByUsage(char* itemKind, int* itemPower)
{
    char temp[256];
    sprintf(temp, "Using the item with kind '%s' and power %d\n", itemKind, *itemPower);
    appendOutput(temp);

    *itemPower /= 2;

    if (*itemPower == 0) {
        strcpy(itemKind, "Junk");
    }
}

void itemApplyEffectToPlayer(const char* itemName,
                             const char* itemKind,
                             int itemPower,
                             int* playerHealth,
                             int* playerStrength,
                             int* playerMagic)
{
    char temp[256];
    sprintf(temp, "Applying the effect of %s (%s):\n", itemName, itemKind);
    appendOutput(temp);

    if (strcmp(itemKind, "Health") == 0) {
        *playerHealth += itemPower;
    }
    else if (strcmp(itemKind, "Strength") == 0) {
        *playerStrength += itemPower;
    }
    else if (strcmp(itemKind, "Magic") == 0) {
        *playerMagic += itemPower;
    }
    else {
        // ignore unknown item kind
    }
}

void itemRepair(int* itemPower, int playerCraftingSkill)
{
    appendOutput("Using the repair skill to fix the item:\n");

    int repairAmount = -5 + ((playerCraftingSkill * 2) + 1);

    *itemPower += repairAmount;

    char temp[256];
    sprintf(temp, "Repaired the item by %d points. Item's Durability: %d\n",
            repairAmount, *itemPower);
    appendOutput(temp);
}

void enemyToString(char* result, const char* enemyName, int enemyPower)
{
    sprintf(result, "Enemy: %s\nPower: %d\n", enemyName, enemyPower);
}

void enemyAttackPlayer(const char* enemyName, //
                       int enemyPower,
                       int playerStrength,
                       int* playerHealth)
{
    char temp[256];
    sprintf(temp, "The enemy '%s' attacks!\n", enemyName);
    appendOutput(temp);

    int damage = enemyPower;
    if (playerStrength > enemyPower) {
        damage = damage / 2;
        appendOutput("Player's strength allows them to reduce the damage!\n");
    }

    *playerHealth = *playerHealth - damage;
    sprintf(temp, "Player takes %d damage. Health is now: %d\n", damage, *playerHealth);
    appendOutput(temp);
}

void playerChallengeEnemy(const char* enemyName, //
                          int playerStrength,
                          int itemPower,
                          int* enemyPower)
{
    char temp[256];
    sprintf(temp, "The player challenges %s!\n", enemyName);
    appendOutput(temp);

    int playerAttackPower = playerStrength + (itemPower > 0 ? itemPower / 2 : 0);

    if (playerAttackPower > *enemyPower) {
        *enemyPower = *enemyPower - (playerAttackPower / 2);
        sprintf(temp, "The player defeats the enemy! Enemy power reduced to %d\n", *enemyPower);
        appendOutput(temp);
    }
    else {
        appendOutput("The enemy is too strong. The player retreats!\n");
    }
}
