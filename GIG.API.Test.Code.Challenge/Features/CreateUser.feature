
Feature: CreateUser
	

@mytag
Scenario: User Created Successfully
	When I create user with the following details
		| email | password |
		| janet.weaver@reqres.in      | helloJ123         |
	Then User is created successfully

Scenario: Unsuccessfull user creation
	When I crwate user with the following detail
	| email |
	| janet.weaver@reqres.in      |
	Then User is not created successfully

