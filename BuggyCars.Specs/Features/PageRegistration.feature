Feature: Page Registration
        In order to vote for a sport car
        As a visitor of the website
        I want to be able to register and login into the website

@registration
Scenario: Register Successfully with Unused Credentials
	Given User is at Register Page and enters the details
		| Key             | Value        |
		| Username        | random       |
		| FirstName       | Sundeep      |
		| LastName        | Lakshmipathi |
		| Password        | Password123! |
		| ConfirmPassword | Password123! |
	When User clicks on the Register button
	Then message should display Registration is successful

@registration
Scenario: Register with existing Credentials
	Given User is at Register Page and enters the details
		| Key             | Value               |
		| Username        | 2434738552172702718 |
		| FirstName       | Sundeep             |
		| LastName        | Lakshmipathi        |
		| Password        | Password123!        |
		| ConfirmPassword | Password123!        |
	When User clicks on the Register button
	Then message should display UsernameExistsException: User already exists

	@login
Scenario: Login with valid credentials
	Given I enter login credentials
		| Key      | Value               |
		| Username | 2434738552172702718 |
		| Password | Password123!        |
	When I click login button
	Then I should be logged in



	@logout
Scenario: Logout
	Given I enter login credentials
		| Key      | Value               |
		| Username | 2434738552172702718 |
		| Password | Password123!        |
	When I click login button
	Then I should be logged in
	When I click logout button
	Then I should be logged out
