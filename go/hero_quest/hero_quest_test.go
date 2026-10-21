package hero_quest_test

import (
	"testing"

	"github.com/codecop/Hero-Quest-Refactoring-Kata/hero_quest"
	"github.com/stretchr/testify/assert"
)

var (
	testPlayerName          = "Conan"
	testPlayerHealth        = 100
	testPlayerStrength      = 7
	testPlayerMagic         = 15
	testPlayerCraftingSkill = 12

	testItemName  = "Healing Potion"
	testItemKind  = "Health"
	testItemPower = 20

	testEnemyName = "Goblin"
	testEnemyPower = 5
)

func TestPlayerToString(t *testing.T) {
	result := hero_quest.PlayerToString(testPlayerName, testPlayerHealth, testPlayerStrength, testPlayerMagic, testPlayerCraftingSkill)

	assert.Equal(t, "Conan's Attributes:\nHealth: 100\nStrength: 7\nMagic: 15\nCrafting Skill: 12\n", result)
}

func TestPlayerFallsDown(t *testing.T) {
	playerStrength := 3
	playerHealth := 100
	hero_quest.PlayerFallsDown(&playerHealth, &playerStrength)

	assert.Equal(t, 90, playerHealth)
}

func TestPlayerFallsDownNoDamage(t *testing.T) {
	playerStrength := 7
	playerHealth := 100
	hero_quest.PlayerFallsDown(&playerHealth, &playerStrength)

	assert.Equal(t, 100, playerHealth)
}

func TestItemToString(t *testing.T) {
	result := hero_quest.ItemToString(testItemName, testItemKind, testItemPower)

	assert.Equal(t, "Item: Healing Potion\nKind: Health\nPower: 20\n", result)
}

func TestItemReduceByUsage(t *testing.T) {
	itemKind := "Health"
	itemPower := 20
	hero_quest.ItemReduceByUsage(&itemKind, &itemPower)

	assert := assert.New(t)
	assert.Equal(10, itemPower)
	assert.Equal("Health", itemKind)
}

func TestItemReduceByUsageToJunk(t *testing.T) {
	itemKind := "Health"
	itemPower := 1
	hero_quest.ItemReduceByUsage(&itemKind, &itemPower)

	assert := assert.New(t)
	assert.Equal(0, itemPower)
	assert.Equal("Junk", itemKind)
}

func TestItemApplyEffectToPlayer(t *testing.T) {
	playerHealth := 100
	playerStrength := 7
	playerMagic := 15
	hero_quest.ItemApplyEffectToPlayer(testItemName, testItemKind, testItemPower, &playerHealth, &playerStrength, &playerMagic)

	assert.Equal(t, 120, playerHealth)
}

func TestItemApplyEffectToPlayerJunk(t *testing.T) {
	playerHealth := 100
	playerStrength := 7
	playerMagic := 15
	hero_quest.ItemApplyEffectToPlayer(testItemName, "Junk", testItemPower, &playerHealth, &playerStrength, &playerMagic)

	assert.Equal(t, 100, playerHealth)
	assert.Equal(t, 7, playerStrength)
}

func TestItemRepair(t *testing.T) {
	itemPower := 20
	hero_quest.ItemRepair(&itemPower, testPlayerCraftingSkill)

	assert.Equal(t, 40, itemPower)
}

func TestEnemyToString(t *testing.T) {
	result := hero_quest.EnemyToString(testEnemyName, testEnemyPower)

	assert.Equal(t, "Enemy: Goblin\nPower: 5\n", result)
}

func TestEnemyAttackPlayer(t *testing.T) {
	playerHealth := 100
	playerStrength := 20
	hero_quest.EnemyAttackPlayer(testEnemyName, testEnemyPower, playerStrength, &playerHealth)

	assert.Equal(t, 98, playerHealth)
}

func TestPlayerChallengeEnemy(t *testing.T) {
	playerStrength := 20
	itemPower := 10
	enemyPower := 5
	hero_quest.PlayerChallengeEnemy(testEnemyName, playerStrength, itemPower, &enemyPower)

	assert.Equal(t, -7, enemyPower) 
}
