Feature: Languages

As a Mars user, 
I want to add，update, delete Languages which I speak, 
So that traders can know my Languages.

Background: Clean up languages
	Given Login with default credentials
	When Clean up languages
	Then No language is in the table

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


@Negative @Regression
Scenario: TC_003 Add language with duplicate name and valid level
	When I add languages
		| Language  | Level            |
		| English   | Basic            |
		| English   | Conversational   |
	Then Languages should not be added successfully


@Negative @Regression
Scenario: TC_004 Add language with empty name and valid level
	When I add languages
		| Language  | Level            |
		|           | Basic            |
	Then Languages should not be added successfully


@Negative @Regression
Scenario: TC_005 Add language with valid name and empty level
	When I add languages
		| Language  | Level  |
		| English   |        |
	Then Languages should not be added successfully


@Smoke @Regression
Scenario: TC_009 Add language then cancel
	When I click Add New button
	And I input a language '<Language>'
	And I choose a language level '<Level>'
	And I click cancel button of add language
	Then Languages should not be added successfully

	Examples: 
	| Language  | Level  |
	| English   | Fluent |


@Regression
Scenario: TC_010 Update language with new name
	Given I add languages
		| Language  | Level  |
		| English   | Fluent |
	#When I update the language '<Language>' and level '<Level>'
	When I update languages
		| Language  | Level  |
	    | French    | Fluent |
	Then Languages should be updated successfully
#	Then The record is updated to new language '<Language>' and level '<Level>'
#
#	Examples: 
#	| Language  | Level  |
#	| French    |        |


@Regression
Scenario: TC_011 Update language with new level
	Given I add languages
		| Language  | Level  |
		| English   | Fluent |
	When I update languages
		| Language  | Level  |
		| English   | Basic  |
	Then Languages should be updated successfully


@Smoke @Regression
Scenario: TC_012 Update language with valid name and level
	Given I add languages
		| Language  | Level  |
		| English   | Fluent |
	When I update languages
		| Language  | Level  |
		| French    | Basic  |
	Then Languages should be updated successfully


@Regression
Scenario: TC_014 Update language with a duplicate name and different valid level
	Given I add languages
		| Language  | Level  |
		| Chinese   | Fluent |
	When I update languages
		| Language  | Level  |
		| Chinese   | Basic  |
	Then Languages should be updated successfully


@Regression
Scenario: TC_015 Update language without any change
	Given I add languages
		| Language  | Level  |
		| Chinese   | Fluent |
	When I update languages
		| Language  | Level   |
	    | Chinese   | Fluent  |
	Then An error message is displayed


@Regression
Scenario: TC_019 Update language then cancel
	Given I add languages
		| Language  | Level  |
		| Chinese   | Fluent |
	When I click Update button
	And I update a language name'<Language>'
	And I update a language level '<Level>'
	And I click cancel button of update language
	Then The languages shoud be the same as added
	
	Examples: 
	| Language  | Level  |
	| English   | Basic  |


@Regression
Scenario: TC_020 Delete a language when there are fewer than 4 language items
	Given I add languages
		| Language  | Level  |
		| Chinese   | Fluent |
	When I delete languages
	Then No language is in the table