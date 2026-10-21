#ifndef HEROQUEST_H
#define HEROQUEST_H

extern char outputBuffer[8192];
extern size_t outputLength;

void resetOutput();
void appendOutput(const char* str);

void playerToString(char* result, //
                    const char* playerName,
                    int playerHealth,
                    int playerStrength,
                    int playerMagic,
                    int playerCraftingSkill);

void playerFallsDown(int* playerHealth, int* playerStrength);

void itemToString(char* result, //
                  const char* itemName,
                  const char* itemKind,
                  int itemPower);

void itemReduceByUsage(char* itemKind, int* itemPower);

void itemApplyEffectToPlayer(const char* itemName,
                             const char* itemKind,
                             int itemPower,
                             int* playerHealth,
                             int* playerStrength,
                             int* playerMagic);

void itemRepair(int* itemPower, int playerCraftingSkill);

void enemyToString(char* result, const char* enemyName, int enemyPower);

void enemyAttackPlayer(const char* enemyName, //
                       int enemyPower,
                       int playerStrength,
                       int* playerHealth);

void playerChallengeEnemy(const char* enemyName, //
                          int playerStrength,
                          int itemPower,
                          int* enemyPower);

#endif // HEROQUEST_H
