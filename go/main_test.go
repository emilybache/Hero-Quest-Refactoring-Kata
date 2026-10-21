package main

import (
	"strings"
	"testing"

	"github.com/codecop/Hero-Quest-Refactoring-Kata/hero_quest"
	"github.com/franiglesias/golden"
)

func TestFullScenario(t *testing.T) {
	hero_quest.Output = []string{}
	run()
	actual := strings.Join(hero_quest.Output, "")
	g := golden.New()
	g.Verify(t, actual)
}
