Feature: AddLanguage

As a Mars user, 
I want to add Languages which I speak, 
so that traders can know my Languages.

Background: Clean up languages
	Given Login with default credentials
	When Clean up languages
	Then No language is in the table

@tag1
Scenario: TC_001 Add single language with valid name and level
	When Add Languages
		| Language  | Level  |
		| English   | Fluent |
	Then A successful message pop is shown on the right top
	#And Clean up test languages
	#	| Language  | Level  |
	#	| English   | Fluent |


@tag1
Scenario: TC_002 Add four languages with valid name and level
	When Add Languages
		| Language  | Level  |
		| English   | Fluent |
		| Chinese	| Fluent |
		| French    | Fluent |
		| Japanese  | Fluent |

	Then A successful message pop is shown on the right top
	#And Clean up test languages
	#	| Language  | Level  |
	#	| English   | Fluent |
	#	| Chinese	| Fluent |
	#	| French    | Fluent |
	#	| Japanese  | Fluent |


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