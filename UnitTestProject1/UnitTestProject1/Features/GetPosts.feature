Feature: GetPosts
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: Verify author of the posts 
	Given I Perform GET operation for "posts/{postid}"
	And I perform operation for post "1"
	Then I should see the "author" name as "typicode"
