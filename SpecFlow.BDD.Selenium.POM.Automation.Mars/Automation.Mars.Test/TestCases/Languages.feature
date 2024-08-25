Feature: Languages

As a Mars user, 
I want to add，update, delete Languages which I speak, 
So that traders can know my Languages.

Background: Clean up languages
	Given Login with default credentials
	When Clean up languages
	Then No language is in the table

@Smoke @Regression
Scenario: TC_001 Add single language with valid name and level
	When I add languages
		| Language  | Level  |
		| English   | Fluent |
	Then Languages should be added successfully
	#And Clean up test languages


@Regression
Scenario: TC_002 Add four languages with valid name and level
	When I add languages
		| Language  | Level            |
		| English   | Basic            |
		| Janpanese	| Conversational   |
		| French    | Fluent           |
		| Chinese   | Native/Bilingual |
	Then Languages should be added successfully
	#And Clean up test languages

@Regression
Scenario: TC_003 Add language with duplicate name and valid level
	When I add languages
		| Language  | Level            |
		| English   | Basic            |
		| English   | Conversational   |
	Then Languages should not be added successfully
	#And Clean up test languages

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

#@Smoke @Regression
#Scenario: TC_001 Add single language with valid name and level
#	When Click Add New button
#	And Input a language '<Language>'
#	And Choose a language level '<Level>'
#	And Click Add button
#	When Add Languages
#	Then A successful message pop is shown on the right top
#	And Clean up test languages
#
#	Examples: 
#	| Language  | Level  |
#	| English   | Fluent |