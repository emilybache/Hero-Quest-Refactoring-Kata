from dataclasses import dataclass


@dataclass
class QuestData:
    player_name: str
    player_health: int
    player_strength: int
    player_magic: int
    player_crafting_skill: int
    item_name: str
    item_kind: str
    item_power: int
    enemy_name: str = ""
    enemy_power: int = 0


class HeroQuest:
    output = []

    @staticmethod
    def player_to_string(player_name: str, player_health: int, player_strength: int, player_magic: int, player_crafting_skill: int):
        return ("{0}'s Attributes:\nHealth: {1}\nStrength: {2}\nMagic: {3}\nCrafting Skill: {4}\n"
                .format(player_name, player_health, player_strength, player_magic, player_crafting_skill))

    @staticmethod
    def player_falls_down(quest_data: QuestData):
        HeroQuest.output.append("Player drops off a cliff.\n")

        if quest_data.player_strength < 5:
            quest_data.player_health -= 10
            HeroQuest.output.append("Player's strength is too small. Health decreases by 10.\n")

    @staticmethod
    def item_to_string(item_name: str, item_kind: str, item_power: int):
        return "Item: {0}\nKind: {1}\nPower: {2}\n".format(item_name, item_kind, item_power)

    @staticmethod
    def item_reduce_by_usage(quest_data: QuestData):
        HeroQuest.output.append(f"Using the item with kind '{quest_data.item_kind}' and power {quest_data.item_power}\n")

        quest_data.item_power = int(quest_data.item_power / 2)
        if quest_data.item_power == 0:
            quest_data.item_kind = "Junk"

    @staticmethod
    def item_apply_effect_to_player(quest_data: QuestData):
        HeroQuest.output.append(f"Applying the effect of {quest_data.item_name} ({quest_data.item_kind}):\n")

        if quest_data.item_kind == "Health":
            quest_data.player_health += quest_data.item_power
        elif quest_data.item_kind == "Strength":
            quest_data.player_strength += quest_data.item_power
        elif quest_data.item_kind == "Magic":
            quest_data.player_magic += quest_data.item_power
        else:
            pass  # ignore unknown item kind

    @staticmethod
    def item_repair(quest_data: QuestData):
        HeroQuest.output.append("Using the repair skill to fix the item:\n")

        repair_amount = -5 + ((quest_data.player_crafting_skill * 2) + 1)

        quest_data.item_power += repair_amount

        HeroQuest.output.append(f"Repaired the item by {repair_amount} points. Item's Durability: {quest_data.item_power}\n")

    @staticmethod
    def enemy_to_string(enemy_name: str, enemy_power: int):
        return "Enemy: {0}\nPower: {1}\n".format(enemy_name, enemy_power)

    @staticmethod
    def enemy_attack_player(quest_data: QuestData):
        HeroQuest.output.append(f"The enemy '{quest_data.enemy_name}' attacks!\n")
        damage = quest_data.enemy_power

        if quest_data.player_strength > quest_data.enemy_power:
            damage = int(damage / 2)
            HeroQuest.output.append("Player's strength allows them to reduce the damage!\n")

        quest_data.player_health -= damage
        HeroQuest.output.append(f"Player takes {damage} damage. Health is now: {quest_data.player_health}\n")

    @staticmethod
    def player_challenge_enemy(quest_data: QuestData):
        HeroQuest.output.append(f"The player challenges {quest_data.enemy_name}!\n")
        player_attack_power = quest_data.player_strength + (int(quest_data.item_power / 2) if quest_data.item_power > 0 else 0)

        if player_attack_power > quest_data.enemy_power:
            quest_data.enemy_power -= int(player_attack_power / 2)
            HeroQuest.output.append(f"The player defeats the enemy! Enemy power reduced to {quest_data.enemy_power}\n")
        else:
            HeroQuest.output.append("The enemy is too strong. The player retreats!\n")
