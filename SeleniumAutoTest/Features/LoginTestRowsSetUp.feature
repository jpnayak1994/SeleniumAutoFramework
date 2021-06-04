Feature: LoginTestRowsSetUp
	Simple calculator for adding two numbers


@smoke @positive @LoginTestFeature @FeatureTest
Scenario Outline: Check login with correct username and password
	Given I have navigated to the application
	And I see application opened
	Then I click login link
	When I enter UserName and Password as per <Scenarios> provided and clicked Login
	Then I click Login Button
	Then I should see the Username with Hello
	Then I click LogOff link
	Examples:
	| Scenarios    |
	| Scenario1    |
	| Scenario2    |
	#| 3    |