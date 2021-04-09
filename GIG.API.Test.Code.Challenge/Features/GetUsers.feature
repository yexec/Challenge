Feature: GetUsers
	As a QA Engineer I want to perform GET operation of reqres.in

@mytag
Scenario: Get users list
	Given I perform GET operation for "/api/users"
	Then I should see response code of "200"