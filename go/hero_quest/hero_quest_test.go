package hero_quest_test

import (
	"testing"

	"github.com/codecop/Hero-Quest-Refactoring-Kata/hero_quest"
	"github.com/stretchr/testify/assert"
)

var (
	testPlayerName          = "Conan"
	testPlayerHealth        = 100
	testPlayerStrength      = 20
	testPlayerMagic         = 10
	testPlayerCraftingSkill = 10

	testItemName  = "Amulet of Strength"
	testItemKind  = "Strength"
	testItemPower = 10
)

func TestPlayerToString(t *testing.T) {
	result := hero_quest.PlayerToString(testPlayerName, testPlayerHealth, testPlayerStrength, testPlayerMagic, testPlayerCraftingSkill)

	assert.Equal(t, "Conan's Attributes:\nHealth: 100\nStrength: 20\nMagic: 10\nCrafting Skill: 10\n", result)
}

func TestPlayerFallsDown(t *testing.T) {
	testPlayerStrength = 3
	defer func() {
		testPlayerStrength = 20
		testPlayerHealth = 100
	}() // reset

	hero_quest.PlayerFallsDown(&testPlayerHealth, &testPlayerStrength)

	assert.Equal(t, 90, testPlayerHealth)
}

func TestPlayerFallsDownNoDamage(t *testing.T) {
	hero_quest.PlayerFallsDown(&testPlayerHealth, &testPlayerStrength)

	assert.Equal(t, 100, testPlayerHealth)
}

func TestItemToString(t *testing.T) {
	result := hero_quest.ItemToString(testItemName, testItemKind, testItemPower)

	assert.Equal(t, "Item: Amulet of Strength\nKind: Strength\nPower: 10\n", result)
}

func TestItemReduceByUsage(t *testing.T) {
	defer func() {
		testItemPower = 10
	}() // reset
	hero_quest.ItemReduceByUsage(&testItemKind, &testItemPower)

	assert.Equal(t, 5, testItemPower)
}

func TestItemReduceByUsageToJunk(t *testing.T) {
	testItemPower = 1
	defer func() {
		testItemPower = 10
		testItemKind = "Strength"
	}() // reset

	hero_quest.ItemReduceByUsage(&testItemKind, &testItemPower)

	assert := assert.New(t)
	assert.Equal(0, testItemPower)
	assert.Equal("Junk", testItemKind)
}

func TestItemApplyEffectToPlayer(t *testing.T) {
	defer func() {
		testPlayerStrength = 20
	}()
	hero_quest.ItemApplyEffectToPlayer(testItemName, testItemKind, testItemPower, &testPlayerHealth, &testPlayerStrength, &testPlayerMagic)

	assert.Equal(t, 30, testPlayerStrength)
}

func TestItemApplyEffectToPlayerJunk(t *testing.T) {
	hero_quest.ItemApplyEffectToPlayer(testItemName, "Junk", testItemPower, &testPlayerHealth, &testPlayerStrength, &testPlayerMagic)

	assert.Equal(t, 20, testPlayerStrength)
}

func TestItemRepair(t *testing.T) {
	defer func() {
		testItemPower = 10
	}()
	hero_quest.ItemRepair(&testItemPower, testPlayerCraftingSkill)

	assert.Equal(t, 26, testItemPower)
}
