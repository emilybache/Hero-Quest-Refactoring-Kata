from hero_quest import HeroQuest


def run():
    player_name = "Conan"
    player_health = 100
    player_strength = 7
    player_magic = 15
    player_crafting_skill = 12
    item_name = "Healing Potion"
    item_kind = "Health"
    item_power = 20
    enemy_name = "Goblin Warlord"
    enemy_power = 12

    HeroQuest.output.append("=== QUEST BEGINNING ===\n\n")

    result = HeroQuest.player_to_string(
        player_name, player_health, player_strength, player_magic, player_crafting_skill
    )
    HeroQuest.output.append(result + "\n")

    result = HeroQuest.item_to_string(item_name, item_kind, item_power)
    HeroQuest.output.append(result + "\n")

    HeroQuest.output.append("--- Exploring the dungeon... ---\n\n")

    player_health = HeroQuest.player_falls_down(player_strength, player_health)
    result = HeroQuest.player_to_string(
        player_name, player_health, player_strength, player_magic, player_crafting_skill
    )
    HeroQuest.output.append(result + "\n")

    HeroQuest.output.append("--- Using the healing item ---\n\n")

    player_health, player_strength, player_magic = (
        HeroQuest.item_apply_effect_to_player(
            item_name,
            item_kind,
            item_power,
            player_health,
            player_strength,
            player_magic,
        )
    )
    result = HeroQuest.player_to_string(
        player_name, player_health, player_strength, player_magic, player_crafting_skill
    )
    HeroQuest.output.append(result + "\n")

    result = HeroQuest.item_to_string(item_name, item_kind, item_power)
    HeroQuest.output.append(result + "\n")

    HeroQuest.output.append("--- Item degradation from repeated use ---\n\n")

    item_kind, item_power = HeroQuest.item_reduce_by_usage(item_kind, item_power)
    result = HeroQuest.item_to_string(item_name, item_kind, item_power)
    HeroQuest.output.append(result + "\n")

    item_kind, item_power = HeroQuest.item_reduce_by_usage(item_kind, item_power)
    result = HeroQuest.item_to_string(item_name, item_kind, item_power)
    HeroQuest.output.append(result + "\n")

    HeroQuest.output.append("--- Repairing the damaged item ---\n\n")

    item_power = HeroQuest.item_repair(player_crafting_skill, item_power)
    result = HeroQuest.item_to_string(item_name, item_kind, item_power)
    HeroQuest.output.append(result + "\n")

    HeroQuest.output.append("=== ENEMY ENCOUNTER ===\n\n")

    result = HeroQuest.enemy_to_string(enemy_name, enemy_power)
    HeroQuest.output.append(result + "\n")

    player_health = HeroQuest.enemy_attack_player(
        enemy_name, enemy_power, player_strength, player_health
    )
    result = HeroQuest.player_to_string(
        player_name, player_health, player_strength, player_magic, player_crafting_skill
    )
    HeroQuest.output.append(result + "\n")

    HeroQuest.output.append("--- Player retaliates ---\n\n")

    enemy_power = HeroQuest.player_challenge_enemy(
        enemy_name, player_strength, item_power, enemy_power
    )
    result = HeroQuest.enemy_to_string(enemy_name, enemy_power)
    HeroQuest.output.append(result + "\n")


if __name__ == "__main__":
    HeroQuest.output = []
    run()
    print("".join(HeroQuest.output), end="")
