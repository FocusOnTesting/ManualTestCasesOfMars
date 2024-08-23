Feature: UpdateLanguages

As a Mars user, 
I want to update Languages which I speak, 
so that traders can know new Languages.

Background: Clean up languages
	Given Login with default credentials
	When Clean up languages
	Then No language is in the table

@tag1
Scenario: TC_012 Update language with valid name and level
	When Add Languages
		| Language  | Level  |
		| English   | Fluent |
	And I Update the language '<Language>' and Level '<Level>'
	Then The record is updated to new language '<Language>' and level '<Level>'

	Examples: 
	| Language  | Level  |
	| French    | Basic  |
