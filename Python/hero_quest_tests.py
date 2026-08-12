import unittest

from hero_quest import HeroQuest


class HeroQuestTestCase(unittest.TestCase):

    def setUp(self):
        HeroQuest.output = []
        self.quest_data = {
            "player_name": "Conan",
            "player_health": 100,
            "player_strength": 20,
            "player_magic": 10,
            "player_crafting_skill": 10,
            "item_name": "Amulet of Strength",
            "item_kind": "Strength",
            "item_power": 10,
            "enemy_name": "Goblin",
            "enemy_power": 5
        }

    def test_player_to_string(self) -> None:
        result = HeroQuest.player_to_string(self.quest_data["player_name"], self.quest_data["player_health"],
                                            self.quest_data["player_strength"], self.quest_data["player_magic"],
                                            self.quest_data["player_crafting_skill"])

        expected = "Conan's Attributes:\nHealth: 100\nStrength: 20\nMagic: 10\nCrafting Skill: 10\n"
        assert result == expected

    def test_player_falls_down(self):
        self.quest_data["player_strength"] = 3
        self.quest_data["player_health"] = HeroQuest.player_falls_down(self.quest_data["player_strength"],
                                                                       self.quest_data["player_health"])

        assert 90 == self.quest_data["player_health"]

    def test_player_falls_down_no_damage(self):
        self.quest_data["player_health"] = HeroQuest.player_falls_down(self.quest_data["player_strength"],
                                                                       self.quest_data["player_health"])

        assert 100 == self.quest_data["player_health"]

    def test_item_to_string(self):
        result = HeroQuest.item_to_string(self.quest_data["item_name"], self.quest_data["item_kind"],
                                          self.quest_data["item_power"])

        expected = "Item: Amulet of Strength\nKind: Strength\nPower: 10\n"
        assert expected == result

    def test_item_reduce_by_usage(self):
        (self.quest_data["item_kind"],
         self.quest_data["item_power"]) = HeroQuest.item_reduce_by_usage(self.quest_data["item_kind"],
                                                                        self.quest_data["item_power"])

        assert 5 == self.quest_data["item_power"]

    def test_item_reduce_by_usage_to_junk(self):
        self.quest_data["item_power"] = 1
        (self.quest_data["item_kind"],
         self.quest_data["item_power"]) = HeroQuest.item_reduce_by_usage(self.quest_data["item_kind"],
                                                                        self.quest_data["item_power"])

        assert 0 == self.quest_data["item_power"]
        assert "Junk" == self.quest_data["item_kind"]

    def test_item_apply_effect_to_player(self):
        (self.quest_data["player_health"], self.quest_data["player_strength"],
         self.quest_data["player_magic"]) = HeroQuest.item_apply_effect_to_player(
            self.quest_data["item_name"], self.quest_data["item_kind"], self.quest_data["item_power"],
            self.quest_data["player_health"], self.quest_data["player_strength"], self.quest_data["player_magic"])

        assert 30 == self.quest_data["player_strength"]

    def test_item_apply_effect_to_player_junk(self):
        self.quest_data["item_kind"] = "Junk"
        (self.quest_data["player_health"], self.quest_data["player_strength"],
         self.quest_data["player_magic"]) = HeroQuest.item_apply_effect_to_player(
            self.quest_data["item_name"], self.quest_data["item_kind"], self.quest_data["item_power"],
            self.quest_data["player_health"], self.quest_data["player_strength"], self.quest_data["player_magic"])

        assert 20 == self.quest_data["player_strength"]

    def test_item_repair(self):
        self.quest_data["item_kind"] = "Junk"
        self.quest_data["item_power"] = HeroQuest.item_repair(self.quest_data["player_crafting_skill"],
                                                              self.quest_data["item_power"])

        assert 26 == self.quest_data["item_power"]

    def test_enemy_attack_player(self):
        self.quest_data["player_health"] = HeroQuest.enemy_attack_player(self.quest_data["enemy_name"],
                                                                         self.quest_data["enemy_power"],
                                                                         self.quest_data["player_strength"],
                                                                         self.quest_data["player_health"])
        assert 98 == self.quest_data["player_health"]

    def test_player_challenge_enemy(self):
        self.quest_data["enemy_power"] = HeroQuest.player_challenge_enemy(self.quest_data["enemy_name"],
                                                                          self.quest_data["player_strength"],
                                                                          self.quest_data["item_power"],
                                                                          self.quest_data["enemy_power"])
        # player_attack_power = 20 + 10/2 = 25
        # enemy_power = 5 - 25/2 = 5 - 12 = -7
        assert -7 == self.quest_data["enemy_power"]


if __name__ == '__main__':
    unittest.main()
