Feature: UpdateLanguages

As a Mars user, 
I want to update Languages which I speak, 
So that traders can know new Languages.

Background: Clean up languages
	Given Login with default credentials
	When Clean up languages
	Then No language is in the table

@Smoke @Regression
Scenario: TC_012 Update language with valid name and level
	When I add languages
		| Language  | Level  |
		| English   | Fluent |
	And I update the language '<Language>' and level '<Level>'
	Then The record is updated to new language '<Language>' and level '<Level>'
	#And Clean up test languages

	Examples: 
	| Language  | Level  |
	| French    | Basic  |
