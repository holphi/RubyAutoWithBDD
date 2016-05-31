Feature: Content selection view
	As a demo representative
	I want to show content selection view by default when I start the app
	So I can view all video clips I am going to demo to customers

@RU_11
Scenario: Default elements in content sel view 
	Given I am in content selection view
	Then I should see the text Movie and Video Clips displayed

@RU_12
Scenario: In content sel view, rotate the device 
	Given I am in content selection view
	When I rotate the device to Portrait
	Then I should see the UI stay the same

@RU_13
Scenario: Scroll video clips
	Given I am in content selection view
	And I have following video clips in metadata file
	| Video clip title       |
	| Deep Look              |
	| NBA                    |
	| Homeland               |
	| English Premier League |
	Then I should see those video clips listed in content selection view

@RU_14
Scenario: Tap on the demo clip
	Given I am in content selection view
	When I select demo content NBA
	Then I should see the detail view pop up

@RU_16
Scenario: Metadata file is missing
	Given The metadata file is missing
	When I launch Dolby demo app
	Then I should be in content selection view
	And I should see a toast message Metadata file not found pop up

@RU_17
Scenario: Metadata file content is invalid
	Given The metadata file is incorrect
	When I launch Dolby demo app
	Then I should be in content selection view
	And I should see the text No this kind of media on the device. displayed

@RU_18
Scenario: In content sel view, lock and unlock device
	Given I am in content selection view
	When I lock the device for 4 seconds and wake it up
	Then I should be in content selection view
	And I should see the text Movie and Video Clips displayed

@RU_61
Scenario: Set the app from background to foreground
	Given I am in content selection view
	When I press Home key
	And I set the app to foreground
	Then I should be in content selection view
	And I should see the UI stay the same