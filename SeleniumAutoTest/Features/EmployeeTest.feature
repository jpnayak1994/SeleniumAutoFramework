Feature: EmployeeTest
	Responsible for verfiying Benefits, Create Employee,

@smoke @EmployeeFeature @FeatureTest
Scenario: Create Employee with all details
		Given I have navigated to the application
	And I see application opened
	Then I click login link
	When I enter UserName and Password and click Login
	Then I click Login Button
	And I click employeeList link
	Then I click createnew Button
	And I enter following details
	#| Name     | Salary | DurationWorked | Grade | Email           |
	#| JPNayak | 4000   | 30             | 1     | autouser@ea.com |
	And I click create Button
	Then I click LogOff link