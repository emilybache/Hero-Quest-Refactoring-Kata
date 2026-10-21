package hero_quest_test

import (
	"testing"

	"github.com/codecop/Hero-Quest-Refactoring-Kata-Struct/hero_quest"
	"github.com/stretchr/testify/assert"
)

func TestPlayerToString(t *testing.T) {
	questData := createQuestData()

	result := hero_quest.PlayerToString(questData.PlayerName, questData.PlayerHealth, questData.PlayerStrength, questData.PlayerMagic, questData.PlayerCraftingSkill)

	assert.Equal(t, "Conan's Attributes:\nHealth: 100\nStrength: 7\nMagic: 15\nCrafting Skill: 12\n", result)
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

	assert.Equal(t, "Item: Healing Potion\nKind: Health\nPower: 20\n", result)
}

func TestItemReduceByUsage(t *testing.T) {
	questData := createQuestData()

	hero_quest.ItemReduceByUsage(&questData)

	assert.Equal(t, 10, questData.ItemPower)
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

	assert.Equal(t, 120, questData.PlayerHealth)
}

func TestItemApplyEffectToPlayerJunk(t *testing.T) {
	questData := createQuestData()
	questData.ItemKind = "Junk"

	hero_quest.ItemApplyEffectToPlayer(&questData)

	assert.Equal(t, 7, questData.PlayerStrength)
}

func TestItemRepair(t *testing.T) {
	questData := createQuestData()

	hero_quest.ItemRepair(&questData)

	assert.Equal(t, 40, questData.ItemPower)
}

func TestEnemyToString(t *testing.T) {
	questData := createQuestData()

	result := hero_quest.EnemyToString(questData.EnemyName, questData.EnemyPower)

	assert.Equal(t, "Enemy: Goblin\nPower: 5\n", result)
}

func TestEnemyAttackPlayer(t *testing.T) {
	questData := createQuestData()
	questData.PlayerStrength = 20
	hero_quest.EnemyAttackPlayer(&questData)

	assert.Equal(t, 98, questData.PlayerHealth)
}

func TestPlayerChallengeEnemy(t *testing.T) {
	questData := createQuestData()
	questData.PlayerStrength = 20
	questData.ItemPower = 10
	hero_quest.PlayerChallengeEnemy(&questData)

	assert.Equal(t, -7, questData.EnemyPower)
}

func createQuestData() hero_quest.QuestData {
	hero_quest.Output = []string{}
	return hero_quest.QuestData{
		PlayerName:          "Conan",
		PlayerHealth:        100,
		PlayerStrength:      7,
		PlayerMagic:         15,
		PlayerCraftingSkill: 12,
		ItemName:            "Healing Potion",
		ItemKind:            "Health",
		ItemPower:           20,
		EnemyName:           "Goblin",
		EnemyPower:          5,
	}
}
