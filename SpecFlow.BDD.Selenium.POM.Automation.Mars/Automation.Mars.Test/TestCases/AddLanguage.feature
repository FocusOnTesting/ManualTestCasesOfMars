Feature: AddLanguage

As a Mars user, 
I want to add Languages which I speak, 
so that traders can know my Languages.

Background: Clean up languages
	Given Login with default credentials
	When Clean up stale languages
	Then No language is in the table

@tag1
Scenario: Add language with valid name and level
	When Click Add New button
	And Input a language '<Language>'
	And Choose a language level '<Level>'
	And Click Add button
	Then A successful message pop is shown on the right top
	And Clean up test language datas

	Examples: 
	| Language | Level  |
	| English  | Fluent |