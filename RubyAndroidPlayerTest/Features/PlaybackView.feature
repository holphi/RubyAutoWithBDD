Feature: Playback View
	As a demo representative
	I want to show playback view when I tap on play button in detail view
	So I control/display content playback to customers

@RU_29
Scenario: Playback control shown by default
	Given I am in content selection view
	When I select and play the demo content NBA
	Then I should be in playback view
	And I should see playback control displayed
	When after 3 seconds
	Then I should not see playback control display

@RU_30
Scenario: Playback control shows again when tapping on screen
	Given I am in content selection view
	When I select and play the demo content NBA
	Then I should be in playback view
	Then after 3 seconds
	Then I should not see playback control display
	When I tap on screen
	Then I should see playback control displayed

@RU_32
Scenario: Stop content playback after tap on back button
	Given I am in content selection view
	When I select and play the demo content NBA
	Then I should be in playback view
	And the content should be played back
	Then after 10 second
	When I tap on Back button
	Then I should be in content selection view

@RU_33
Scenario: Stop content playback after tap on physical back button
	Given I am in content selection view
	When I select and play the demo content NBA
	Then I should be in playback view
	Then after 5 second
	When I press Back key
	Then I should be in content selection view

@RU_34
Scenario: Perform play/pause operation
	Given I am in content selection view
	When I select and play the demo content Homeland
	Then I should be in playback view
	When I press PlayPause button
	Then the content should not be played back
	When I press PlayPause button
	Then the content should be played back

@RU_35
Scenario: Perform rewind operation
	Given I am in content selection view
	When I select and play the demo content NBA
	Then I should be in playback view
	Then after 20 seconds
	When I tap on Rewind button
	Then the playback should go to 10 seconds ago
	And the content should be played back

@RU_39
Scenario: Lock/unlock screen in content playback
	Given I am in content selection view
	When I select and play the demo content NBA
	Then I should be in playback view
	When I lock the device for 10 seconds and wake it up
	Then I should be in playback view
	And the content should be played back

@RU_62
Scenario: The content file is missing
	Given The content file is missing
	When I launch Dolby demo app
	Then I should be in content selection view
	When I select demo content Video clip missing
	Then I should see the detail view pop up
	When I tap on Play button
	Then I should be in playback view
	And I should see a toast message Unable to play content from given URL pop up

@RU_68
Scenario: Lock/unlock screen in pause state
	Given I am in content selection view
	When I select and play the demo content NBA
	Then I should be in playback view
	When I press PlayPause button
	And I lock the device for 10 seconds and wake it up
	Then the content should not be played back
	When I press PlayPause button
	Then the content should be played back
