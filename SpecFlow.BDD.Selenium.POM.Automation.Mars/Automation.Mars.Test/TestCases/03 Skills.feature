Feature: 03 Skills

As a Mars user, 
I want to add，update, delete Skills which I have，
So that traders can know my Skills.

Background: Clean up skills
	Given Login with default credentials
	And I am on the profile page skills section
	When Clean up skills
	Then No skill is in the table

#@Smoke @Regression
#Scenario: TC_001 Add single skill with valid name and level
#	When Click Add New button
#	And Input a skill '<Skill>'
#	And Choose a skill level '<Level>'
#	And Click Add button
#	When Add Skills
#	Then A successful message pop is shown on the right top
#	And Clean up test skills
#
#	Examples: 
#	| Skill     | Level  |
#	| English   | Fluent |


@Smoke @Regression
Scenario: TC_001 Add single skill with valid name and level
	When I add skills
		| Skill     | Level         |
		| CSharp    | Beginner      |
	Then Skills should be added successfully
    And Clean up test skills
		| Skill     | Level         |
		| CSharp    | Beginner      |


@Negative @Regression
Scenario: TC_002 Add skill with duplicate name and valid level
	When I add skills
		| Skill     | Level         |
		| Java      | Beginner      |
		| Java  	| Intermediate  |
	Then Skills should not be added successfully
	And Clean up test skills
		| Skill     | Level         |
		| Java      | Beginner      |

@Negative @Regression
Scenario: TC_003 Add skill with empty name and valid level
	When I add skills
		| Skill     | Level         |
		|           | Beginner      |
	Then Skills should not be added successfully


@Negative @Regression
Scenario: TC_004 Add skill with valid name and empty level
	When I add skills
		| Skill     | Level  |
		| Java      |        |
	Then Skills should not be added successfully


@Negative @Regression
Scenario: TC_005 Add skill in name with huge length  inputs
	When I add skills
		| Skill  | Level  |
		| 0123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789   |  Beginner |
	Then Skills should not be added successfully


@Negative @Regression
Scenario: TC_006 Add skill in name with special characters
	When I add skills
		| Skill     | Level    |
		| /.,&*$#@  | Beginner |
	Then Skills should not be added successfully


@Smoke @Regression
Scenario: TC_009 Add skill then cancel
	When I click Add New button in Skills section
	And I input a skill '<Skill>'
	And I choose a skill level '<Level>'
	And I click cancel button of adding skill
	Then Skills should not be added successfully

	Examples: 
	| Skill     | Level         |
	| CSharp    | Beginner      |


@Regression
Scenario: TC_010 Update skill with new name
	Given I add skills
		| Skill     | Level         |
		| CSharp    | Beginner      |
	When I update skills
		| Skill     | Level         |
		| Java      | Beginner      |
	Then Skills should be updated successfully
	And Clean up test skills
		| Skill     | Level         |
		| Java      | Beginner      |


@Regression
Scenario: TC_011 Update skill with new level
	Given I add skills
		| Skill     | Level         |
		| CSharp    | Beginner      |
	When I update skills
		| Skill     | Level         |
		| CSharp    | Intermediate  |
	Then Skills should be updated successfully
	And Clean up test skills
		| Skill     | Level         |
		| CSharp    | Intermediate  |

@Smoke @Regression
Scenario: TC_012 Update skill with valid name and level
	Given I add skills
		| Skill     | Level         |
		| CSharp    | Beginner      |
	When I update skills
		| Skill     | Level         |
		| Java      | Intermediate  |
	Then Skills should be updated successfully
	And Clean up test skills
		| Skill     | Level         |
		| Java      | Intermediate  |

@Regression
Scenario: TC_014 Update skill with a duplicate name and different valid level
	Given I add skills
		| Skill     | Level         |
		| CSharp    | Beginner      |
	When I update skills
		| Skill     | Level         |
		| CSharp    | Intermediate  |
	Then Skills should be updated successfully
	And Clean up test skills
		| Skill     | Level         |
		| CSharp    | Intermediate  |


@Regression
Scenario: TC_015 Update skill without any change
	Given I add skills
		| Skill     | Level         |
		| CSharp    | Intermediate  |
	When I update skills
		| Skill     | Level         |
		| CSharp    | Intermediate  |
	Then An error message is displayed for updating skill operation
	And Clean up test skills
		| Skill     | Level         |
		| CSharp    | Intermediate  |


@Regression
Scenario: TC_019 Update skill then cancel
	Given I add skills
		| Skill     | Level         |
		| CSharp    | Intermediate  |
	When I click Update button in Skills section
	And I update a skill name'<Skill>'
	And I update a skill level '<Level>'
	And I click cancel button of update skill
	Then The skills shoud be the same as added
	And Clean up test skills
	    | Skill     | Level         |
		| CSharp    | Intermediate  |

	Examples: 
		| Skill     | Level     |
		| Java      | Beginner  |


@Regression
Scenario: TC_021 Delete a skill
	Given I add skills
		| Skill     | Level         |
		| CSharp    | Beginner      |
	When I delete skills
	Then No skill is in the table