Feature: 01 Login

As a Mars user, 
I want to login, 
So that I can user this platform.

@Smoke @Regression
Scenario: TC_001 Login with default credentials
	Given Login with default credentials
	Then Login successfully
