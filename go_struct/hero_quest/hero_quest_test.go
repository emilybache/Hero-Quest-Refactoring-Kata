package hero_quest_test

import (
	"testing"

	"github.com/codecop/Hero-Quest-Refactoring-Kata-Struct/hero_quest"
	"github.com/stretchr/testify/assert"
)

func TestPlayerToString(t *testing.T) {
	questData := createQuestData()

	result := hero_quest.PlayerToString(questData.PlayerName, questData.PlayerHealth, questData.PlayerStrength, questData.PlayerMagic, questData.PlayerCraftingSkill)

	assert.Equal(t, "Conan's Attributes:\nHealth: 100\nStrength: 20\nMagic: 10\nCrafting Skill: 10\n", result)
}

func TestPlayerFallsDown(t *testing.T) {
	questData := createQuestData()
	questData.PlayerStrength = 3

	hero_quest.PlayerFallsDown(&questData)

	assert.Equal(t, 90, questData.PlayerHealth)
}

func TestPlayerFallsDownNoDamage(t *testing.T) {
	questData := createQuestData()

	hero_quest.PlayerFallsDown(&questData)

	assert.Equal(t, 100, questData.PlayerHealth)
}

func TestItemToString(t *testing.T) {
	questData := createQuestData()

	result := hero_quest.ItemToString(questData.ItemName, questData.ItemKind, questData.ItemPower)

	assert.Equal(t, "Item: Amulet of Strength\nKind: Strength\nPower: 10\n", result)
}

func TestItemReduceByUsage(t *testing.T) {
	questData := createQuestData()

	hero_quest.ItemReduceByUsage(&questData)

	assert.Equal(t, 5, questData.ItemPower)
}

func TestItemReduceByUsageToJunk(t *testing.T) {
	questData := createQuestData()
	questData.ItemPower = 1

	hero_quest.ItemReduceByUsage(&questData)

	assert := assert.New(t)
	assert.Equal(0, questData.ItemPower)
	assert.Equal("Junk", questData.ItemKind)
}

func TestItemApplyEffectToPlayer(t *testing.T) {
	questData := createQuestData()

	hero_quest.ItemApplyEffectToPlayer(&questData)

	assert.Equal(t, 30, questData.PlayerStrength)
}

func TestItemApplyEffectToPlayerJunk(t *testing.T) {
	questData := createQuestData()
	questData.ItemKind = "Junk"

	hero_quest.ItemApplyEffectToPlayer(&questData)

	assert.Equal(t, 20, questData.PlayerStrength)
}

func TestItemRepair(t *testing.T) {
	questData := createQuestData()

	hero_quest.ItemRepair(&questData)

	assert.Equal(t, 26, questData.ItemPower)
}

func createQuestData() hero_quest.QuestData {
	return hero_quest.QuestData{
		PlayerName:          "Conan",
		PlayerHealth:        100,
		PlayerStrength:      20,
		PlayerMagic:         10,
		PlayerCraftingSkill: 10,
		ItemName:            "Amulet of Strength",
		ItemKind:            "Strength",
		ItemPower:           10,
	}
}
