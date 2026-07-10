namespace CodingDojo.Test;

using System.Text;

public class HeroQuestAcceptanceTest
{
    [Fact]
    public Task FullScenario()
    {
        HeroQuest.Output = new StringBuilder();

        QuestData questData = new()
        {
            PlayerName = "Conan",
            PlayerHealth = 100,
            PlayerStrength = 7,
            PlayerMagic = 15,
            PlayerCraftingSkill = 12,
            ItemName = "Healing Potion",
            ItemKind = "Health",
            ItemPower = 20,
            EnemyName = "Goblin Warlord",
            EnemyPower = 12
        };

        HeroQuest.Output.AppendLine("=== QUEST BEGINNING ===\n");
        string result = HeroQuest.PlayerToString(questData.PlayerName, questData.PlayerHealth, questData.PlayerStrength,
            questData.PlayerMagic, questData.PlayerCraftingSkill);
        HeroQuest.Output.AppendLine(result);

        result = HeroQuest.ItemToString(questData.ItemName, questData.ItemKind, questData.ItemPower);
        HeroQuest.Output.AppendLine(result);

        HeroQuest.Output.AppendLine("--- Exploring the dungeon... ---\n");
        questData.PlayerHealth = HeroQuest.PlayerFallsDown(questData.PlayerStrength, questData.PlayerHealth);
        result = HeroQuest.PlayerToString(questData.PlayerName, questData.PlayerHealth, questData.PlayerStrength,
            questData.PlayerMagic, questData.PlayerCraftingSkill);
        HeroQuest.Output.AppendLine(result);

        HeroQuest.Output.AppendLine("--- Using the healing item ---\n");
        (questData.PlayerHealth, questData.PlayerStrength, questData.PlayerMagic) = HeroQuest.ItemApplyEffectToPlayer(
            questData.ItemName, questData.ItemKind, questData.ItemPower, questData.PlayerHealth,
            questData.PlayerStrength, questData.PlayerMagic);
        result = HeroQuest.PlayerToString(questData.PlayerName, questData.PlayerHealth, questData.PlayerStrength,
            questData.PlayerMagic, questData.PlayerCraftingSkill);
        HeroQuest.Output.AppendLine(result);

        result = HeroQuest.ItemToString(questData.ItemName, questData.ItemKind, questData.ItemPower);
        HeroQuest.Output.AppendLine(result);

        HeroQuest.Output.AppendLine("--- Item degradation from repeated use ---\n");
        (questData.ItemKind, questData.ItemPower) =
            HeroQuest.ItemReduceByUsage(questData.ItemKind, questData.ItemPower);
        result = HeroQuest.ItemToString(questData.ItemName, questData.ItemKind, questData.ItemPower);
        HeroQuest.Output.AppendLine(result);

        (questData.ItemKind, questData.ItemPower) =
            HeroQuest.ItemReduceByUsage(questData.ItemKind, questData.ItemPower);
        result = HeroQuest.ItemToString(questData.ItemName, questData.ItemKind, questData.ItemPower);
        HeroQuest.Output.AppendLine(result);

        HeroQuest.Output.AppendLine("--- Repairing the damaged item ---\n");
        questData.ItemPower = HeroQuest.ItemRepair(questData.PlayerCraftingSkill, questData.ItemPower);
        result = HeroQuest.ItemToString(questData.ItemName, questData.ItemKind, questData.ItemPower);
        HeroQuest.Output.AppendLine(result);

        HeroQuest.Output.AppendLine("=== ENEMY ENCOUNTER ===\n");
        result = HeroQuest.EnemyToString(questData.EnemyName, questData.EnemyPower);
        HeroQuest.Output.AppendLine(result);

        questData.PlayerHealth = HeroQuest.EnemyAttackPlayer(questData.EnemyName, questData.EnemyPower,
            questData.PlayerStrength, questData.PlayerHealth);
        result = HeroQuest.PlayerToString(questData.PlayerName, questData.PlayerHealth, questData.PlayerStrength,
            questData.PlayerMagic, questData.PlayerCraftingSkill);
        HeroQuest.Output.AppendLine(result);

        HeroQuest.Output.AppendLine("--- Player retaliates ---\n");
        questData.EnemyPower = HeroQuest.PlayerChallengeEnemy(questData.EnemyName, questData.PlayerStrength,
            questData.ItemPower, questData.EnemyPower);
        result = HeroQuest.EnemyToString(questData.EnemyName, questData.EnemyPower);
        HeroQuest.Output.AppendLine(result);

        return Verifier.Verify(HeroQuest.Output.ToString());
    }
}