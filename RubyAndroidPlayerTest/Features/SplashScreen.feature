Feature: Splash screen
	As a demo representative
	I want to show the splash screen when I first launch the app
	So I can deepen the impression of our technoligies to customers

@RU_8
Scenario: Launch the app
	When I first launch the app
	Then I should see a splash screen pop up
	And I should be in content selection view

@RU_9
Scenario: Set the app to foreground
	Given I am in content selection view
	When I press Back key
	And I set the app to foreground
	Then I should not see a splash screen pop up
	And I should be in content selection view