Feature: Detail View
	As a demo representative
	I want to show detail view when I tap on demo clip
	So customers can view basic demo clip attributes

@RU_19
Scenario: View demo clip attributes
	Given I am in content selection view
	When I select demo content NBA
	Then I should see the detail view pop up
	And I should see following information appear in the detail view
	| Video clip title		| Audio              | Video       |
	| NBA					| 5.1ch (Dolby AC-4) | 1280 x 720  |

@RU_20
Scenario: In detail view, rotate the device 
	Given I am in content selection view
	When I select demo content NBA
	Then I should see the detail view pop up
	When I rotate the device to Portrait
	Then I should see the UI stay the same
	
@RU_23
Scenario: In detial view, lock and unlock device
	Given I am in content selection view
	When I select demo content NBA
	Then I should see the detail view pop up
	When I lock the device for 3 seconds and wake it up
	Then I should see the detail view pop up

@RU_28
Scenario: Close detail view
	Given I am in content selection view
	When I select demo content NBA
	Then I should see the detail view pop up
	When I close the detail view
	Then I should not see the detail view pop up
