import unittest

from hero_quest import HeroQuest


class HeroQuestTestCase(unittest.TestCase):

    def setUp(self):
        HeroQuest.output = []
        self.player_name = "Conan"
        self.player_health = 100
        self.player_strength = 20
        self.player_magic = 10
        self.player_crafting_skill = 10
        self.item_name = "Amulet of Strength"
        self.item_kind = "Strength"
        self.item_power = 10
        self.enemy_name = "Goblin"
        self.enemy_power = 5

    def test_player_to_string(self) -> None:
        result = HeroQuest.player_to_string(
            self.player_name,
            self.player_health,
            self.player_strength,
            self.player_magic,
            self.player_crafting_skill,
        )

        expected = "Conan's Attributes:\nHealth: 100\nStrength: 20\nMagic: 10\nCrafting Skill: 10\n"
        assert result == expected

    def test_player_falls_down(self):
        self.player_strength = 3
        self.player_health = HeroQuest.player_falls_down(
            self.player_strength, self.player_health
        )

        assert 90 == self.player_health

    def test_player_falls_down_no_damage(self):
        self.player_health = HeroQuest.player_falls_down(
            self.player_strength, self.player_health
        )

        assert 100 == self.player_health

    def test_item_to_string(self):
        result = HeroQuest.item_to_string(
            self.item_name, self.item_kind, self.item_power
        )

        expected = "Item: Amulet of Strength\nKind: Strength\nPower: 10\n"
        assert expected == result

    def test_item_reduce_by_usage(self):
        self.item_kind, self.item_power = HeroQuest.item_reduce_by_usage(
            self.item_kind, self.item_power
        )

        assert 5 == self.item_power

    def test_item_reduce_by_usage_to_junk(self):
        self.item_power = 1
        self.item_kind, self.item_power = HeroQuest.item_reduce_by_usage(
            self.item_kind, self.item_power
        )

        assert 0 == self.item_power
        assert "Junk" == self.item_kind

    def test_item_apply_effect_to_player(self):
        self.player_health, self.player_strength, self.player_magic = (
            HeroQuest.item_apply_effect_to_player(
                self.item_name,
                self.item_kind,
                self.item_power,
                self.player_health,
                self.player_strength,
                self.player_magic,
            )
        )

        assert 30 == self.player_strength

    def test_item_apply_effect_to_player_junk(self):
        self.item_kind = "Junk"
        self.player_health, self.player_strength, self.player_magic = (
            HeroQuest.item_apply_effect_to_player(
                self.item_name,
                self.item_kind,
                self.item_power,
                self.player_health,
                self.player_strength,
                self.player_magic,
            )
        )

        assert 20 == self.player_strength

    def test_item_repair(self):
        self.item_power = HeroQuest.item_repair(
            self.player_crafting_skill, self.item_power
        )

        assert 26 == self.item_power

    def test_enemy_to_string(self):
        result = HeroQuest.enemy_to_string(self.enemy_name, self.enemy_power)
        expected = "Enemy: Goblin\nPower: 5\n"
        assert result == expected

    def test_enemy_attack_player(self):
        self.player_health = HeroQuest.enemy_attack_player(
            self.enemy_name, self.enemy_power, self.player_strength, self.player_health
        )
        assert 98 == self.player_health

    def test_player_challenge_enemy(self):
        self.enemy_power = HeroQuest.player_challenge_enemy(
            self.enemy_name, self.player_strength, self.item_power, self.enemy_power
        )
        assert -7 == self.enemy_power


if __name__ == "__main__":
    unittest.main()
