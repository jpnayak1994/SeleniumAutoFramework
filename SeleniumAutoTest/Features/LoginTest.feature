Feature: LoginTest
	Simple calculator for adding two numbers

@smoke @positive @LoginFeature @FeatureTest
Scenario Outline: Check login with correct username and password
	Given I have navigated to the application
	And I see application opened
	Then I click login link
	When I enter UserName and Password and click Login
	Then I click Login Button
	Then I should see the Username with Hello
	Then I click LogOff link